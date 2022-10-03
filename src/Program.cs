﻿using ApiSdk;
using Azure.Identity;
using DevLab.JmesPath;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Hosting;
using Microsoft.Graph.Cli.Core.Authentication;
using Microsoft.Graph.Cli.Core.Commands.Authentication;
using Microsoft.Graph.Cli.Core.Configuration;
using Microsoft.Graph.Cli.Core.Http;
using Microsoft.Graph.Cli.Core.IO;
using Microsoft.Kiota.Authentication.Azure;
using Microsoft.Kiota.Cli.Commons.IO;
using Microsoft.Kiota.Http.HttpClientLibrary;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.Hosting;
using System.CommandLine.Parsing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;
using System.CommandLine.IO;

namespace Microsoft.Graph.Cli
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            // We don't have access to a built host yet. Get configuration settings using a configuration builder.
            // Required to set initial token credentials.
            var configBuilder = new ConfigurationBuilder();
            ConfigureAppConfiguration(configBuilder);
            var config = configBuilder.Build();

            var authSettings = config.GetSection(nameof(AuthenticationOptions)).Get<AuthenticationOptions>();
            var pathUtil = new PathUtility();
            var authServiceFactory = new AuthenticationServiceFactory(pathUtil, authSettings);
            var authStrategy = AuthenticationStrategy.DeviceCode;

            var credential = await authServiceFactory.GetTokenCredentialAsync(authStrategy, authSettings?.TenantId, authSettings?.ClientId, authSettings?.ClientCertificateName, authSettings?.ClientCertificateThumbPrint);
            var authProvider = new AzureIdentityAuthenticationProvider(credential, new string[] { "graph.microsoft.com" });

            var assemblyVersion = Assembly.GetExecutingAssembly().GetName().Version;
            var options = new GraphClientOptions
            {
                GraphProductPrefix = "graph-cli",
                GraphServiceLibraryClientVersion = $"{assemblyVersion?.Major ?? 0}.{assemblyVersion?.Minor ?? 0}.{assemblyVersion?.Build ?? 0}",
                GraphServiceTargetVersion = "1.0"
            };
            var loggingHandler = new LoggingHandler();
            using var httpClient = GraphCliClientFactory.GetDefaultClient(options, lowestPriorityMiddlewares: new[] { loggingHandler });
            var core = new HttpClientRequestAdapter(authProvider, httpClient: httpClient);
            var client = new GraphClient(core);

            var commands = new List<Command>();
            var loginCommand = new LoginCommand(authServiceFactory);
            commands.Add(loginCommand.Build());

            var authCacheUtil = new AuthenticationCacheUtility(pathUtil);
            var logoutCommand = new LogoutCommand(new LogoutService(authCacheUtil));
            commands.Add(logoutCommand.Build());

            var builder = BuildCommandLine(client, commands).UseDefaults().UseHost(CreateHostBuilder);
            builder.AddMiddleware((invocation) =>
            {
                var host = invocation.GetHost();
                var isDebug = invocation.Parser.Configuration.RootCommand.Options.SingleOrDefault(static o => "debug".Equals(o.Name, StringComparison.Ordinal)) is Option<bool> debug ?
                                    invocation.ParseResult.GetValueForOption(debug) : false;
                if (isDebug == true)
                {
                    loggingHandler.Logger = host.Services.GetService<ILogger<LoggingHandler>>();
                }
                else
                {
                    loggingHandler.Logger = null;
                }

                var outputFilter = host.Services.GetRequiredService<IOutputFilter>();
                var outputFormatterFactory = host.Services.GetRequiredService<IOutputFormatterFactory>();
                var pagingService = host.Services.GetRequiredService<IPagingService>();
                invocation.BindingContext.AddService(_ => outputFilter);
                invocation.BindingContext.AddService(_ => outputFormatterFactory);
                invocation.BindingContext.AddService(_ => pagingService);
            });
            builder.UseExceptionHandler((ex, context) =>
            {
                switch (ex)
                {
                    case AuthenticationRequiredException:
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        context.Console.Error.WriteLine("Token acquisition failed. Run mgc login command first to get an access token.");
                        Console.ResetColor();
                        break;
                    case TaskCanceledException:
                        break;
                    default:
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Red;
                        context.Console.Error.WriteLine(ex.Message);
                        Console.ResetColor();
                        break;
                }
            });

            var parser = builder.Build();

            return await parser.InvokeAsync(args);
        }

        static CommandLineBuilder BuildCommandLine(GraphClient client, IEnumerable<Command> commands)
        {
            var rootCommand = client.BuildRootCommand();
            rootCommand.Description = "Microsoft Graph CLI";

            foreach (var command in commands)
            {
                rootCommand.AddCommand(command);
            }

            var debug = new Option<bool>("--debug", "Turn on debug logging.");
            rootCommand.AddGlobalOption(debug);

            return new CommandLineBuilder(rootCommand);
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder().ConfigureHostConfiguration((configHost) =>
            {
                configHost.SetBasePath(Directory.GetCurrentDirectory());
            }).ConfigureAppConfiguration((ctx, config) =>
            {
                ConfigureAppConfiguration(config);
            }).ConfigureServices((ctx, services) =>
            {
                var authSection = ctx.Configuration.GetSection(nameof(AuthenticationOptions));
                services.Configure<AuthenticationOptions>(authSection);
                services.AddSingleton<IPathUtility, PathUtility>();
                services.AddSingleton<IAuthenticationCacheUtility, AuthenticationCacheUtility>();
                services.AddSingleton<IOutputFilter, JmesPathOutputFilter>();
                services.AddSingleton<JmesPath>();
                services.AddSingleton<IOutputFormatterFactory, OutputFormatterFactory>();
                services.AddSingleton<IPagingService, GraphODataPagingService>();
            }).ConfigureLogging((ctx, logBuilder) =>
            {
                logBuilder.SetMinimumLevel(LogLevel.Warning);
                logBuilder.AddFilter("Microsoft.Graph.Cli.Core.Http", LogLevel.Debug);
            });

        static void ConfigureAppConfiguration(IConfigurationBuilder builder)
        {
            builder.Sources.Clear();
            builder.AddJsonFile(Path.Combine(System.AppContext.BaseDirectory, "app-settings.json"), optional: true);
            var pathUtil = new PathUtility();
            var authCache = new AuthenticationCacheUtility(pathUtil);
            var dataDir = pathUtil.GetApplicationDataDirectory();
            var userConfigPath = Path.Combine(dataDir, "settings.json");
            builder.AddJsonFile(userConfigPath, optional: true);
            builder.AddJsonFile(authCache.GetAuthenticationCacheFilePath(), optional: true, reloadOnChange: true);
            builder.AddEnvironmentVariables(prefix: "MGC_");
        }
    }
}
