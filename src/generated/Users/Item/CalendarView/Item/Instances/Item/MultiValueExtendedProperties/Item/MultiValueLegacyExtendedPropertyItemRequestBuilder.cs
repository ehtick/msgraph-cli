using ApiSdk.Models;
using ApiSdk.Models.ODataErrors;
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
namespace ApiSdk.Users.Item.CalendarView.Item.Instances.Item.MultiValueExtendedProperties.Item {
    /// <summary>Provides operations to manage the multiValueExtendedProperties property of the microsoft.graph.event entity.</summary>
    public class MultiValueLegacyExtendedPropertyItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Delete navigation property multiValueExtendedProperties for users
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property multiValueExtendedProperties for users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var eventIdOption = new Option<string>("--event-id", description: "key: id of event") {
            };
            eventIdOption.IsRequired = true;
            command.AddOption(eventIdOption);
            var eventId1Option = new Option<string>("--event-id1", description: "key: id of event") {
            };
            eventId1Option.IsRequired = true;
            command.AddOption(eventId1Option);
            var multiValueLegacyExtendedPropertyIdOption = new Option<string>("--multi-value-legacy-extended-property-id", description: "key: id of multiValueLegacyExtendedProperty") {
            };
            multiValueLegacyExtendedPropertyIdOption.IsRequired = true;
            command.AddOption(multiValueLegacyExtendedPropertyIdOption);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var eventId = (string) parameters[1];
                var eventId1 = (string) parameters[2];
                var multiValueLegacyExtendedPropertyId = (string) parameters[3];
                var ifMatch = (string) parameters[4];
                var cancellationToken = (CancellationToken) parameters[5];
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("event%2Did", eventId);
                requestInfo.PathParameters.Add("event%2Did1", eventId1);
                requestInfo.PathParameters.Add("multiValueLegacyExtendedProperty%2Did", multiValueLegacyExtendedPropertyId);
                requestInfo.Headers["If-Match"] = ifMatch;
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(userIdOption, eventIdOption, eventId1Option, multiValueLegacyExtendedPropertyIdOption, ifMatchOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// The collection of multi-value extended properties defined for the event. Read-only. Nullable.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The collection of multi-value extended properties defined for the event. Read-only. Nullable.";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var eventIdOption = new Option<string>("--event-id", description: "key: id of event") {
            };
            eventIdOption.IsRequired = true;
            command.AddOption(eventIdOption);
            var eventId1Option = new Option<string>("--event-id1", description: "key: id of event") {
            };
            eventId1Option.IsRequired = true;
            command.AddOption(eventId1Option);
            var multiValueLegacyExtendedPropertyIdOption = new Option<string>("--multi-value-legacy-extended-property-id", description: "key: id of multiValueLegacyExtendedProperty") {
            };
            multiValueLegacyExtendedPropertyIdOption.IsRequired = true;
            command.AddOption(multiValueLegacyExtendedPropertyIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
            var expandOption = new Option<string[]>("--expand", description: "Expand related entities") {
                Arity = ArgumentArity.ZeroOrMore
            };
            expandOption.IsRequired = false;
            command.AddOption(expandOption);
            var outputOption = new Option<FormatterType>("--output", () => FormatterType.JSON){
                IsRequired = true
            };
            command.AddOption(outputOption);
            var queryOption = new Option<string>("--query");
            command.AddOption(queryOption);
            var jsonNoIndentOption = new Option<bool>("--json-no-indent", r => {
                if (bool.TryParse(r.Tokens.Select(t => t.Value).LastOrDefault(), out var value)) {
                    return value;
                }
                return true;
            }, description: "Disable indentation for the JSON output formatter.");
            command.AddOption(jsonNoIndentOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var eventId = (string) parameters[1];
                var eventId1 = (string) parameters[2];
                var multiValueLegacyExtendedPropertyId = (string) parameters[3];
                var select = (string[]) parameters[4];
                var expand = (string[]) parameters[5];
                var output = (FormatterType) parameters[6];
                var query = (string) parameters[7];
                var jsonNoIndent = (bool) parameters[8];
                var outputFilter = (IOutputFilter) parameters[9];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[10];
                var cancellationToken = (CancellationToken) parameters[11];
                var requestInfo = CreateGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                    q.QueryParameters.Expand = expand;
                });
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("event%2Did", eventId);
                requestInfo.PathParameters.Add("event%2Did1", eventId1);
                requestInfo.PathParameters.Add("multiValueLegacyExtendedProperty%2Did", multiValueLegacyExtendedPropertyId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(userIdOption, eventIdOption, eventId1Option, multiValueLegacyExtendedPropertyIdOption, selectOption, expandOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Update the navigation property multiValueExtendedProperties in users
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property multiValueExtendedProperties in users";
            // Create options for all the parameters
            var userIdOption = new Option<string>("--user-id", description: "key: id of user") {
            };
            userIdOption.IsRequired = true;
            command.AddOption(userIdOption);
            var eventIdOption = new Option<string>("--event-id", description: "key: id of event") {
            };
            eventIdOption.IsRequired = true;
            command.AddOption(eventIdOption);
            var eventId1Option = new Option<string>("--event-id1", description: "key: id of event") {
            };
            eventId1Option.IsRequired = true;
            command.AddOption(eventId1Option);
            var multiValueLegacyExtendedPropertyIdOption = new Option<string>("--multi-value-legacy-extended-property-id", description: "key: id of multiValueLegacyExtendedProperty") {
            };
            multiValueLegacyExtendedPropertyIdOption.IsRequired = true;
            command.AddOption(multiValueLegacyExtendedPropertyIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var userId = (string) parameters[0];
                var eventId = (string) parameters[1];
                var eventId1 = (string) parameters[2];
                var multiValueLegacyExtendedPropertyId = (string) parameters[3];
                var body = (string) parameters[4];
                var cancellationToken = (CancellationToken) parameters[5];
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<MultiValueLegacyExtendedProperty>(MultiValueLegacyExtendedProperty.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("user%2Did", userId);
                requestInfo.PathParameters.Add("event%2Did", eventId);
                requestInfo.PathParameters.Add("event%2Did1", eventId1);
                requestInfo.PathParameters.Add("multiValueLegacyExtendedProperty%2Did", multiValueLegacyExtendedPropertyId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(userIdOption, eventIdOption, eventId1Option, multiValueLegacyExtendedPropertyIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new MultiValueLegacyExtendedPropertyItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public MultiValueLegacyExtendedPropertyItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/users/{user%2Did}/calendarView/{event%2Did}/instances/{event%2Did1}/multiValueExtendedProperties/{multiValueLegacyExtendedProperty%2Did}{?%24select,%24expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property multiValueExtendedProperties for users
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<MultiValueLegacyExtendedPropertyItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new MultiValueLegacyExtendedPropertyItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// The collection of multi-value extended properties defined for the event. Read-only. Nullable.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<MultiValueLegacyExtendedPropertyItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new MultiValueLegacyExtendedPropertyItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property multiValueExtendedProperties in users
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(MultiValueLegacyExtendedProperty body, Action<MultiValueLegacyExtendedPropertyItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new MultiValueLegacyExtendedPropertyItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class MultiValueLegacyExtendedPropertyItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new multiValueLegacyExtendedPropertyItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public MultiValueLegacyExtendedPropertyItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>The collection of multi-value extended properties defined for the event. Read-only. Nullable.</summary>
        public class MultiValueLegacyExtendedPropertyItemRequestBuilderGetQueryParameters {
            /// <summary>Expand related entities</summary>
            [QueryParameter("%24expand")]
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class MultiValueLegacyExtendedPropertyItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public MultiValueLegacyExtendedPropertyItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new MultiValueLegacyExtendedPropertyItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new multiValueLegacyExtendedPropertyItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public MultiValueLegacyExtendedPropertyItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class MultiValueLegacyExtendedPropertyItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new multiValueLegacyExtendedPropertyItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public MultiValueLegacyExtendedPropertyItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
