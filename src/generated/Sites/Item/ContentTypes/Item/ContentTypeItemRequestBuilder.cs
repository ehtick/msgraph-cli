using ApiSdk.Models.Microsoft.Graph;
using ApiSdk.Models.Microsoft.Graph.ODataErrors;
using ApiSdk.Sites.Item.ContentTypes.Item.AssociateWithHubSites;
using ApiSdk.Sites.Item.ContentTypes.Item.Base;
using ApiSdk.Sites.Item.ContentTypes.Item.BaseTypes;
using ApiSdk.Sites.Item.ContentTypes.Item.ColumnLinks;
using ApiSdk.Sites.Item.ContentTypes.Item.ColumnPositions;
using ApiSdk.Sites.Item.ContentTypes.Item.Columns;
using ApiSdk.Sites.Item.ContentTypes.Item.CopyToDefaultContentLocation;
using ApiSdk.Sites.Item.ContentTypes.Item.IsPublished;
using ApiSdk.Sites.Item.ContentTypes.Item.Publish;
using ApiSdk.Sites.Item.ContentTypes.Item.Unpublish;
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
namespace ApiSdk.Sites.Item.ContentTypes.Item {
    /// <summary>Provides operations to manage the contentTypes property of the microsoft.graph.site entity.</summary>
    public class ContentTypeItemRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        public Command BuildAssociateWithHubSitesCommand() {
            var command = new Command("associate-with-hub-sites");
            var builder = new AssociateWithHubSitesRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildBaseCommand() {
            var command = new Command("base");
            var builder = new BaseRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildGetCommand());
            return command;
        }
        public Command BuildBaseTypesCommand() {
            var command = new Command("base-types");
            var builder = new BaseTypesRequestBuilder(PathParameters, RequestAdapter);
            foreach (var cmd in builder.BuildCommand()) {
                command.AddCommand(cmd);
            }
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildColumnLinksCommand() {
            var command = new Command("column-links");
            var builder = new ColumnLinksRequestBuilder(PathParameters, RequestAdapter);
            foreach (var cmd in builder.BuildCommand()) {
                command.AddCommand(cmd);
            }
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildColumnPositionsCommand() {
            var command = new Command("column-positions");
            var builder = new ColumnPositionsRequestBuilder(PathParameters, RequestAdapter);
            foreach (var cmd in builder.BuildCommand()) {
                command.AddCommand(cmd);
            }
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildColumnsCommand() {
            var command = new Command("columns");
            var builder = new ColumnsRequestBuilder(PathParameters, RequestAdapter);
            foreach (var cmd in builder.BuildCommand()) {
                command.AddCommand(cmd);
            }
            command.AddCommand(builder.BuildCountCommand());
            command.AddCommand(builder.BuildCreateCommand());
            command.AddCommand(builder.BuildListCommand());
            return command;
        }
        public Command BuildCopyToDefaultContentLocationCommand() {
            var command = new Command("copy-to-default-content-location");
            var builder = new CopyToDefaultContentLocationRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Delete navigation property contentTypes for sites
        /// </summary>
        public Command BuildDeleteCommand() {
            var command = new Command("delete");
            command.Description = "Delete navigation property contentTypes for sites";
            // Create options for all the parameters
            var siteIdOption = new Option<string>("--site-id", description: "key: id of site") {
            };
            siteIdOption.IsRequired = true;
            command.AddOption(siteIdOption);
            var contentTypeIdOption = new Option<string>("--content-type-id", description: "key: id of contentType") {
            };
            contentTypeIdOption.IsRequired = true;
            command.AddOption(contentTypeIdOption);
            command.SetHandler(async (object[] parameters) => {
                var siteId = (string) parameters[0];
                var contentTypeId = (string) parameters[1];
                var cancellationToken = (CancellationToken) parameters[2];
                PathParameters.Clear();
                PathParameters.Add("site_id", siteId);
                PathParameters.Add("contentType_id", contentTypeId);
                var requestInfo = CreateDeleteRequestInformation(q => {
                });
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(siteIdOption, contentTypeIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// The collection of content types defined for this site.
        /// </summary>
        public Command BuildGetCommand() {
            var command = new Command("get");
            command.Description = "The collection of content types defined for this site.";
            // Create options for all the parameters
            var siteIdOption = new Option<string>("--site-id", description: "key: id of site") {
            };
            siteIdOption.IsRequired = true;
            command.AddOption(siteIdOption);
            var contentTypeIdOption = new Option<string>("--content-type-id", description: "key: id of contentType") {
            };
            contentTypeIdOption.IsRequired = true;
            command.AddOption(contentTypeIdOption);
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
                var siteId = (string) parameters[0];
                var contentTypeId = (string) parameters[1];
                var select = (string[]) parameters[2];
                var expand = (string[]) parameters[3];
                var output = (FormatterType) parameters[4];
                var query = (string) parameters[5];
                var jsonNoIndent = (bool) parameters[6];
                var outputFilter = (IOutputFilter) parameters[7];
                var outputFormatterFactory = (IOutputFormatterFactory) parameters[8];
                var cancellationToken = (CancellationToken) parameters[9];
                PathParameters.Clear();
                PathParameters.Add("site_id", siteId);
                PathParameters.Add("contentType_id", contentTypeId);
                var requestInfo = CreateGetRequestInformation(q => {
                    q.Select = select;
                    q.Expand = expand;
                });
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                var response = await RequestAdapter.SendPrimitiveAsync<Stream>(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                response = await outputFilter?.FilterOutputAsync(response, query, cancellationToken) ?? response;
                var formatterOptions = output.GetOutputFormatterOptions(new FormatterOptionsModel(!jsonNoIndent));
                var formatter = outputFormatterFactory.GetFormatter(output);
                await formatter.WriteOutputAsync(response, formatterOptions, cancellationToken);
            }, new CollectionBinding(siteIdOption, contentTypeIdOption, selectOption, expandOption, outputOption, queryOption, jsonNoIndentOption, new TypeBinding(typeof(IOutputFilter)), new TypeBinding(typeof(IOutputFormatterFactory)), new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Update the navigation property contentTypes in sites
        /// </summary>
        public Command BuildPatchCommand() {
            var command = new Command("patch");
            command.Description = "Update the navigation property contentTypes in sites";
            // Create options for all the parameters
            var siteIdOption = new Option<string>("--site-id", description: "key: id of site") {
            };
            siteIdOption.IsRequired = true;
            command.AddOption(siteIdOption);
            var contentTypeIdOption = new Option<string>("--content-type-id", description: "key: id of contentType") {
            };
            contentTypeIdOption.IsRequired = true;
            command.AddOption(contentTypeIdOption);
            var bodyOption = new Option<string>("--body") {
            };
            bodyOption.IsRequired = true;
            command.AddOption(bodyOption);
            command.SetHandler(async (object[] parameters) => {
                var siteId = (string) parameters[0];
                var contentTypeId = (string) parameters[1];
                var body = (string) parameters[2];
                var cancellationToken = (CancellationToken) parameters[3];
                PathParameters.Clear();
                PathParameters.Add("site_id", siteId);
                PathParameters.Add("contentType_id", contentTypeId);
                using var stream = new MemoryStream(Encoding.UTF8.GetBytes(body));
                var parseNode = ParseNodeFactoryRegistry.DefaultInstance.GetRootParseNode("application/json", stream);
                var model = parseNode.GetObjectValue<ContentType>(ContentType.CreateFromDiscriminatorValue);
                var requestInfo = CreatePatchRequestInformation(model, q => {
                });
                var errorMapping = new Dictionary<string, ParsableFactory<IParsable>> {
                    {"4XX", ODataError.CreateFromDiscriminatorValue},
                    {"5XX", ODataError.CreateFromDiscriminatorValue},
                };
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: errorMapping, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(siteIdOption, contentTypeIdOption, bodyOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        public Command BuildPublishCommand() {
            var command = new Command("publish");
            var builder = new PublishRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        public Command BuildUnpublishCommand() {
            var command = new Command("unpublish");
            var builder = new UnpublishRequestBuilder(PathParameters, RequestAdapter);
            command.AddCommand(builder.BuildPostCommand());
            return command;
        }
        /// <summary>
        /// Instantiates a new ContentTypeItemRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public ContentTypeItemRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/sites/{site_id}/contentTypes/{contentType_id}{?select,expand}";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Delete navigation property contentTypes for sites
        /// <param name="headers">Request headers</param>
        /// <param name="options">Request options</param>
        /// </summary>
        public RequestInformation CreateDeleteRequestInformation(Action<IDictionary<string, string>> headers = default, IEnumerable<IRequestOption> options = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.DELETE,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            headers?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(options?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// The collection of content types defined for this site.
        /// <param name="headers">Request headers</param>
        /// <param name="options">Request options</param>
        /// <param name="queryParameters">Request query parameters</param>
        /// </summary>
        public RequestInformation CreateGetRequestInformation(Action<GetQueryParameters> queryParameters = default, Action<IDictionary<string, string>> headers = default, IEnumerable<IRequestOption> options = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.GET,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (queryParameters != null) {
                var qParams = new GetQueryParameters();
                queryParameters.Invoke(qParams);
                qParams.AddQueryParameters(requestInfo.QueryParameters);
            }
            headers?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(options?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Update the navigation property contentTypes in sites
        /// <param name="body"></param>
        /// <param name="headers">Request headers</param>
        /// <param name="options">Request options</param>
        /// </summary>
        public RequestInformation CreatePatchRequestInformation(ContentType body, Action<IDictionary<string, string>> headers = default, IEnumerable<IRequestOption> options = default) {
            _ = body ?? throw new ArgumentNullException(nameof(body));
            var requestInfo = new RequestInformation {
                HttpMethod = Method.PATCH,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            requestInfo.SetContentFromParsable(RequestAdapter, "application/json", body);
            headers?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(options?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Provides operations to call the isPublished method.
        /// </summary>
        public IsPublishedRequestBuilder IsPublished() {
            return new IsPublishedRequestBuilder(PathParameters, RequestAdapter);
        }
        /// <summary>The collection of content types defined for this site.</summary>
        public class GetQueryParameters : QueryParametersBase {
            /// <summary>Expand related entities</summary>
            public string[] Expand { get; set; }
            /// <summary>Select properties to be returned</summary>
            public string[] Select { get; set; }
        }
    }
}
