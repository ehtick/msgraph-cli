using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Cli.Commons.Binding;
using Microsoft.Kiota.Cli.Commons.IO;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.Users.Item.Insights.Shared.Item.LastSharedMethod.Ref {
    /// <summary>Builds and executes requests for operations under \users\{user-id}\insights\shared\{sharedInsight-id}\lastSharedMethod\$ref</summary>
    public class RefRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Delete ref of navigation property lastSharedMethod for users
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete ref of navigation property lastSharedMethod for users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var sharedInsightIdOption = new Option<string>("--shared-insight-id", description: "key: id of sharedInsight") {
            };
            sharedInsightIdOption.IsRequired = true;
            command.AddOption(sharedInsightIdOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var sharedInsightId = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("user_id", userId);
                PathParameters.Add("sharedInsight_id", sharedInsightId);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(userIdOption, sharedInsightIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Get ref of lastSharedMethod from users
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "Get ref of lastSharedMethod from users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var sharedInsightIdOption = new Option<string>("--shared-insight-id", description: "key: id of sharedInsight") {
            };
            sharedInsightIdOption.IsRequired = true;
            command.AddOption(sharedInsightIdOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            var outputFilterOption = new Option<string>("--query");
            command.AddOption(outputFilterOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var sharedInsightId = (string) parameters[1];
                var output = (FormatterType) parameters[2];
                var outputFilterOption = (string) parameters[3];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[4];
                var cancellationToken = (CancellationToken) parameters[5];
                PathParameters.Clear();
                PathParameters.Add("user_id", userId);
                PathParameters.Add("sharedInsight_id", sharedInsightId);
                var requestInfo = CreateGetRequestInformation(q => {
                });
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                var formatter = outputFormatterFactory.GetFormatter(output);
                formatter.WriteOutput(response);
            }, new CollectionBinding(userIdOption, sharedInsightIdOption, outputOption, outputFilterOption, new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Update the ref of navigation property lastSharedMethod in users
        /// </summary>
        public Command BuildPutCommand() {
            var command = new Command("put");
            command.Description = "Update the ref of navigation property lastSharedMethod in users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var sharedInsightIdOption = new Option<string>("--shared-insight-id", description: "key: id of sharedInsight") {
            };
            sharedInsightIdOption.IsRequired = true;
            command.AddOption(sharedInsightIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var sharedInsightId = (string) parameters[1];
                var body = (string) parameters[2];
                var cancellationToken = (CancellationToken) parameters[3];
                PathParameters.Clear();
                PathParameters.Add("user_id", userId);
                PathParameters.Add("sharedInsight_id", sharedInsightId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<Ref>();
                var requestInfo = CreatePutRequestInformation(model, q => {
                });
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(userIdOption, sharedInsightIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new RefRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public RefRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user_id}/insights/shared/{sharedInsight_id}/lastSharedMethod/$ref";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete ref of navigation property lastSharedMethod for users
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Get ref of lastSharedMethod from users
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Update the ref of navigation property lastSharedMethod in users
        /// <param name="body"></param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePutRequestInformation(Ref body, Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PUT,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
    }
}