// <auto-generated/>
using ApiSdk.Models.ODataErrors;
using ApiSdk.Models;
using ApiSdk.Users.Item.Todo.Lists.Item.Tasks.Item.Attachments.Item.Value;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Cli.Commons.Extensions;
using Microsoft.Kiota.Cli.Commons.IO;
using Microsoft.Kiota.Cli.Commons;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ApiSdk.Users.Item.Todo.Lists.Item.Tasks.Item.Attachments.Item
{
    /// <summary>
    /// Provides operations to manage the attachments property of the microsoft.graph.todoTask entity.
    /// </summary>
    public class AttachmentBaseItemRequestBuilder : BaseCliRequestBuilder
    {
        /// <summary>
        /// Provides operations to manage the media for the user entity.
        /// </summary>
        /// <returns>A <see cref="Command"/></returns>
        public Command BuildContentNavCommand()
        {
            var command = new Command("content");
            command.Description = "Provides operations to manage the media for the user entity.";
            var builder = new ContentRequestBuilder(PathParameters);
            var execCommands = new List<Command>();
            execCommands.Add(builder.BuildDeleteCommand());
            execCommands.Add(builder.BuildGetCommand());
            execCommands.Add(builder.BuildPutCommand());
            foreach (var cmd in execCommands)
            {
                command.AddCommand(cmd);
            }
            return command;
        }
        /// <summary>
        /// Delete navigation property attachments for users
        /// </summary>
        /// <returns>A <see cref="Command"/></returns>
        public Command BuildDeleteCommand()
        {
            var command = new Command("delete");
            command.Description = "Delete navigation property attachments for users";
            var userIdOption = new Option<string>("--user-id", description: "The unique identifier of user. Use 'me' for the currently signed in user.") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var todoTaskListIdOption = new Option<string>("--todo-task-list-id", description: "The unique identifier of todoTaskList") {
            };
            todoTaskListIdOption.IsRequired = true;
            command.AddOption(todoTaskListIdOption);
            var todoTaskIdOption = new Option<string>("--todo-task-id", description: "The unique identifier of todoTask") {
            };
            todoTaskIdOption.IsRequired = true;
            command.AddOption(todoTaskIdOption);
            var attachmentBaseIdOption = new Option<string>("--attachment-base-id", description: "The unique identifier of attachmentBase") {
            };
            attachmentBaseIdOption.IsRequired = true;
            command.AddOption(attachmentBaseIdOption);
            var ifMatchOption = new Option<string[]>("--if-match", description: "ETag") {
                Arity = ArgumentArity.ZeroOrMore
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (invocationContext) => {
                var userId = invocationContext.ParseResult.GetValueForOption(userIdOption);
                var todoTaskListId = invocationContext.ParseResult.GetValueForOption(todoTaskListIdOption);
                var todoTaskId = invocationContext.ParseResult.GetValueForOption(todoTaskIdOption);
                var attachmentBaseId = invocationContext.ParseResult.GetValueForOption(attachmentBaseIdOption);
                var ifMatch = invocationContext.ParseResult.GetValueForOption(ifMatchOption);
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToDeleteRequestInformation(q => {
                });
                if (userId is not null) requestInfo.PathParameters.Add("user%2Did", userId);
                if (todoTaskListId is not null) requestInfo.PathParameters.Add("todoTaskList%2Did", todoTaskListId);
                if (todoTaskId is not null) requestInfo.PathParameters.Add("todoTask%2Did", todoTaskId);
                if (attachmentBaseId is not null) requestInfo.PathParameters.Add("attachmentBase%2Did", attachmentBaseId);
                if (ifMatch is not null) requestInfo.Headers.Add("If-Match", ifMatch);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await reqAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// A collection of file attachments for the task.
        /// </summary>
        /// <returns>A <see cref="Command"/></returns>
        public Command BuildGetCommand()
        {
            var command = new Command("get");
            command.Description = "A collection of file attachments for the task.";
            var userIdOption = new Option<string>("--user-id", description: "The unique identifier of user. Use 'me' for the currently signed in user.") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var todoTaskListIdOption = new Option<string>("--todo-task-list-id", description: "The unique identifier of todoTaskList") {
            };
            todoTaskListIdOption.IsRequired = true;
            command.AddOption(todoTaskListIdOption);
            var todoTaskIdOption = new Option<string>("--todo-task-id", description: "The unique identifier of todoTask") {
            };
            todoTaskIdOption.IsRequired = true;
            command.AddOption(todoTaskIdOption);
            var attachmentBaseIdOption = new Option<string>("--attachment-base-id", description: "The unique identifier of attachmentBase") {
            };
            attachmentBaseIdOption.IsRequired = true;
            command.AddOption(attachmentBaseIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON);
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            command.SetHandler(async (invocationContext) => {
                var userId = invocationContext.ParseResult.GetValueForOption(userIdOption);
                var todoTaskListId = invocationContext.ParseResult.GetValueForOption(todoTaskListIdOption);
                var todoTaskId = invocationContext.ParseResult.GetValueForOption(todoTaskIdOption);
                var attachmentBaseId = invocationContext.ParseResult.GetValueForOption(attachmentBaseIdOption);
                var select = invocationContext.ParseResult.GetValueForOption(selectOption);
                var output = invocationContext.ParseResult.GetValueForOption(outputOption);
                var query = invocationContext.ParseResult.GetValueForOption(queryOption);
                IOutputFilter outputFilter = invocationContext.BindingContext.GetService(typeof(IOutputFilter)) as IOutputFilter ?? throw new ArgumentNullException("outputFilter");
                IOutputFormatterFactory outputFormatterFactory = invocationContext.BindingContext.GetService(typeof(IOutputFormatterFactory)) as IOutputFormatterFactory ?? throw new ArgumentNullException("outputFormatterFactory");
                var cancellationToken = invocationContext.GetCancellationToken();
                var reqAdapter = invocationContext.GetRequestAdapter();
                var requestInfo = ToGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                });
                if (userId is not null) requestInfo.PathParameters.Add("user%2Did", userId);
                if (todoTaskListId is not null) requestInfo.PathParameters.Add("todoTaskList%2Did", todoTaskListId);
                if (todoTaskId is not null) requestInfo.PathParameters.Add("todoTask%2Did", todoTaskId);
                if (attachmentBaseId is not null) requestInfo.PathParameters.Add("attachmentBase%2Did", attachmentBaseId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await reqAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken) ?? Stream.Null;
                response = (response != Stream.Null) ? await outputFilter.FilterOutputAsync(response, query, cancellationToken) : response;
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, cancellationToken);
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new <see cref="AttachmentBaseItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="pathParameters">Path parameters for the request</param>
        public AttachmentBaseItemRequestBuilder(Dictionary<string, object> pathParameters) : base("{+baseurl}/users/{user%2Did}/todo/lists/{todoTaskList%2Did}/tasks/{todoTask%2Did}/attachments/{attachmentBase%2Did}{?%24select}", pathParameters)
        {
        }
        /// <summary>
        /// Instantiates a new <see cref="AttachmentBaseItemRequestBuilder"/> and sets the default values.
        /// </summary>
        /// <param name="rawUrl">The raw URL to use for the request builder.</param>
        public AttachmentBaseItemRequestBuilder(string rawUrl) : base("{+baseurl}/users/{user%2Did}/todo/lists/{todoTaskList%2Did}/tasks/{todoTask%2Did}/attachments/{attachmentBase%2Did}{?%24select}", rawUrl)
        {
        }
        /// <summary>
        /// Delete navigation property attachments for users
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToDeleteRequestInformation(Action<RequestConfiguration<DefaultQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.DELETE, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// A collection of file attachments for the task.
        /// </summary>
        /// <returns>A <see cref="RequestInformation"/></returns>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<AttachmentBaseItemRequestBuilderGetQueryParameters>>? requestConfiguration = default)
        {
#nullable restore
#else
        public RequestInformation ToGetRequestInformation(Action<RequestConfiguration<AttachmentBaseItemRequestBuilderGetQueryParameters>> requestConfiguration = default)
        {
#endif
            var requestInfo = new RequestInformation(Method.GET, UrlTemplate, PathParameters);
            requestInfo.Configure(requestConfiguration);
            requestInfo.Headers.TryAdd("Accept", "application/json");
            return requestInfo;
        }
        /// <summary>
        /// A collection of file attachments for the task.
        /// </summary>
        public class AttachmentBaseItemRequestBuilderGetQueryParameters 
        {
            /// <summary>Select properties to be returned</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
            [QueryParameter("%24select")]
            public string[]? Select { get; set; }
#nullable restore
#else
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
#endif
        }
    }
}
