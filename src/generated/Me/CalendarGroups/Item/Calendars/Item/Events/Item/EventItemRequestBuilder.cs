using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Accept;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Attachments;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Calendar;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Cancel;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Decline;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.DismissReminder;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Extensions;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Forward;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.Instances;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.MultiValueExtendedProperties;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.SingleValueExtendedProperties;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.SnoozeReminder;
using ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item.TentativelyAccept;
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
namespace ApiSdk.Me.CalendarGroups.Item.Calendars.Item.Events.Item {
    /// <summary>Provides operations to manage the events property of the microsoft.graph.calendar entity.</summary>
    public class EventItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAcceptCommand() {
            var command = new Command("accept");
            var builder = new AcceptRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildAttachmentsCommand() {
            var command = new Command("attachments");
            var builder = new AttachmentsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildCreateUploadSessionCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildCalendarCommand() {
            var command = new Command("calendar");
            var builder = new CalendarRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildCancelCommand() {
            var command = new Command("cancel");
            var builder = new CancelRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildDeclineCommand() {
            var command = new Command("decline");
            var builder = new DeclineRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Delete navigation property events for me
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property events for me";
            // Create options for all the parameters
            var calendarGroupIdOption = new Option<string>("--calendar-group-id", description: "key: id of calendarGroup") {
            };
            calendarGroupIdOption.IsRequired = true;
            command.AddOption(calendarGroupIdOption);
            var calendarIdOption = new Option<string>("--calendar-id", description: "key: id of calendar") {
            };
            calendarIdOption.IsRequired = true;
            command.AddOption(calendarIdOption);
            var eventIdOption = new Option<string>("--event-id", description: "key: id of event") {
            };
            eventIdOption.IsRequired = true;
            command.AddOption(eventIdOption);
            var ifMatchOption = new Option<string>("--if-match", description: "ETag") {
            };
            ifMatchOption.IsRequired = false;
            command.AddOption(ifMatchOption);
            command.SetHandler(async (object[] parameters) => {
                var calendarGroupId = (string) parameters[0];
                var calendarId = (string) parameters[1];
                var eventId = (string) parameters[2];
                var ifMatch = (string) parameters[3];
                var cancellationToken = (CancellationToken) parameters[4];
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("calendarGroup%2Did", calendarGroupId);
                requestInfo.PathParameters.Add("calendar%2Did", calendarId);
                requestInfo.PathParameters.Add("event%2Did", eventId);
                requestInfo.Headers["If-Match"] = ifMatch;
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(calendarGroupIdOption, calendarIdOption, eventIdOption, ifMatchOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        public Command BuildDismissReminderCommand() {
            var command = new Command("dismiss-reminder");
            var builder = new DismissReminderRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildExtensionsCommand() {
            var command = new Command("extensions");
            var builder = new ExtensionsRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildForwardCommand() {
            var command = new Command("forward");
            var builder = new ForwardRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// The events in the calendar. Navigation property. Read-only.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The events in the calendar. Navigation property. Read-only.";
            // Create options for all the parameters
            var calendarGroupIdOption = new Option<string>("--calendar-group-id", description: "key: id of calendarGroup") {
            };
            calendarGroupIdOption.IsRequired = true;
            command.AddOption(calendarGroupIdOption);
            var calendarIdOption = new Option<string>("--calendar-id", description: "key: id of calendar") {
            };
            calendarIdOption.IsRequired = true;
            command.AddOption(calendarIdOption);
            var eventIdOption = new Option<string>("--event-id", description: "key: id of event") {
            };
            eventIdOption.IsRequired = true;
            command.AddOption(eventIdOption);
            var selectOption = new Option<string[]>("--select", description: "Select properties to be returned") {
                Arity = ArgumentArity.ZeroOrMore
            };
            selectOption.IsRequired = false;
            command.AddOption(selectOption);
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
                var calendarGroupId = (string) parameters[0];
                var calendarId = (string) parameters[1];
                var eventId = (string) parameters[2];
                var select = (string[]) parameters[3];
                var output = (FormatterType) parameters[4];
                var query = (string) parameters[5];
                var jsonNoIndent = (bool) parameters[6];
                var outputFilter = (IOutputFilter) parameters[7];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[8];
                var cancellationToken = (CancellationToken) parameters[9];
                var requestInfo = CreateGetRequestInformation(q => {
                    q.QueryParameters.Select = select;
                });
                requestInfo.PathParameters.Add("calendarGroup%2Did", calendarGroupId);
                requestInfo.PathParameters.Add("calendar%2Did", calendarId);
                requestInfo.PathParameters.Add("event%2Did", eventId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(calendarGroupIdOption, calendarIdOption, eventIdOption, selectOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        public Command BuildInstancesCommand() {
            var command = new Command("instances");
            var builder = new InstancesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildMultiValueExtendedPropertiesCommand() {
            var command = new Command("multi-value-extended-properties");
            var builder = new MultiValueExtendedPropertiesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        /// <summary>
        /// Update the navigation property events in me
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property events in me";
            // Create options for all the parameters
            var calendarGroupIdOption = new Option<string>("--calendar-group-id", description: "key: id of calendarGroup") {
            };
            calendarGroupIdOption.IsRequired = true;
            command.AddOption(calendarGroupIdOption);
            var calendarIdOption = new Option<string>("--calendar-id", description: "key: id of calendar") {
            };
            calendarIdOption.IsRequired = true;
            command.AddOption(calendarIdOption);
            var eventIdOption = new Option<string>("--event-id", description: "key: id of event") {
            };
            eventIdOption.IsRequired = true;
            command.AddOption(eventIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var calendarGroupId = (string) parameters[0];
                var calendarId = (string) parameters[1];
                var eventId = (string) parameters[2];
                var body = (string) parameters[3];
                var cancellationToken = (CancellationToken) parameters[4];
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<Event>(Event.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                requestInfo.PathParameters.Add("calendarGroup%2Did", calendarGroupId);
                requestInfo.PathParameters.Add("calendar%2Did", calendarId);
                requestInfo.PathParameters.Add("event%2Did", eventId);
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(calendarGroupIdOption, calendarIdOption, eventIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        public Command BuildSingleValueExtendedPropertiesCommand() {
            var command = new Command("single-value-extended-properties");
            var builder = new SingleValueExtendedPropertiesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildCommand());
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildSnoozeReminderCommand() {
            var command = new Command("snooze-reminder");
            var builder = new SnoozeReminderRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildTentativelyAcceptCommand() {
            var command = new Command("tentatively-accept");
            var builder = new TentativelyAcceptRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new EventItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public EventItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/me/calendarGroups/{calendarGroup%2Did}/calendars/{calendar%2Did}/events/{event%2Did}{?%24select}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property events for me
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<EventItemRequestBuilderDeleteRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new EventItemRequestBuilderDeleteRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// The events in the calendar. Navigation property. Read-only.
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<EventItemRequestBuilderGetRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new EventItemRequestBuilderGetRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddQueryParameters(requestConfig.QueryParameters);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property events in me
        /// <param name="body"></param>
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(Event body, Action<EventItemRequestBuilderPatchRequestConfiguration> requestConfiguration = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            if (requestConfiguration != null) {
                var requestConfig = new EventItemRequestBuilderPatchRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class EventItemRequestBuilderDeleteRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new eventItemRequestBuilderDeleteRequestConfiguration and sets the default values.
            /// </summary>
            public EventItemRequestBuilderDeleteRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>The events in the calendar. Navigation property. Read-only.</summary>
        public class EventItemRequestBuilderGetQueryParameters {
            /// <summary>Select properties to be returned</summary>
            [QueryParameter("%24select")]
            public string[] Select { get; set; }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class EventItemRequestBuilderGetRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>Request query parameters</summary>
            public EventItemRequestBuilderGetQueryParameters QueryParameters { get; set; } = new EventItemRequestBuilderGetQueryParameters();
            /// <summary>
            /// Instantiates a new eventItemRequestBuilderGetRequestConfiguration and sets the default values.
            /// </summary>
            public EventItemRequestBuilderGetRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class EventItemRequestBuilderPatchRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new eventItemRequestBuilderPatchRequestConfiguration and sets the default values.
            /// </summary>
            public EventItemRequestBuilderPatchRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
