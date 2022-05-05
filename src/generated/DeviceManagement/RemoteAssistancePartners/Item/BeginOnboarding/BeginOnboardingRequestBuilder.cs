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
namespace ApiSdk.DeviceManagement.RemoteAssistancePartners.Item.BeginOnboarding {
    /// <summary>Provides operations to call the beginOnboarding method.</summary>
    public class BeginOnboardingRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// A request to start onboarding.  Must be coupled with the appropriate TeamViewer account information
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            command.Description = "A request to start onboarding.  Must be coupled with the appropriate TeamViewer account information";
            // Create options for all the parameters
            var remoteAssistancePartnerIdOption = new Option<string>("--remote-assistance-partner-id", description: "key: id of remoteAssistancePartner") {
            };
            remoteAssistancePartnerIdOption.IsRequired = true;
            command.AddOption(remoteAssistancePartnerIdOption);
            command.SetHandler(async (object[] parameters) => {
                var remoteAssistancePartnerId = (string) parameters[0];
                var cancellationToken = (CancellationToken) parameters[1];
                var requestInfo = CreatePostRequestInformation(q => {
                });
                requestInfo.PathParameters.Add("remoteAssistancePartner%2Did", remoteAssistancePartnerId);
                await RequestAdapter.SendNoContentAsync(requestInfo, errorMapping: default, cancellationToken: cancellationToken);
                Console.WriteLine("Success");
            }, new CollectionBinding(remoteAssistancePartnerIdOption, new TypeBinding(typeof(CancellationToken))));
            return command;
        }
        /// <summary>
        /// Instantiates a new BeginOnboardingRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public BeginOnboardingRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/deviceManagement/remoteAssistancePartners/{remoteAssistancePartner%2Did}/microsoft.graph.beginOnboarding";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// A request to start onboarding.  Must be coupled with the appropriate TeamViewer account information
        /// <param name="requestConfiguration">Configuration for the request such as headers, query parameters, and middleware options.</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(Action<BeginOnboardingRequestBuilderPostRequestConfiguration> requestConfiguration = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = Method.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            if (requestConfiguration != null) {
                var requestConfig = new BeginOnboardingRequestBuilderPostRequestConfiguration();
                requestConfiguration.Invoke(requestConfig);
                requestInfo.AddRequestOptions(requestConfig.Options);
                requestInfo.AddHeaders(requestConfig.Headers);
            }
            return requestInfo;
        }
        /// <summary>Configuration for the request such as headers, query parameters, and middleware options.</summary>
        public class BeginOnboardingRequestBuilderPostRequestConfiguration {
            /// <summary>Request headers</summary>
            public IDictionary<string, string> Headers { get; set; }
            /// <summary>Request options</summary>
            public IList<IRequestOption> Options { get; set; }
            /// <summary>
            /// Instantiates a new beginOnboardingRequestBuilderPostRequestConfiguration and sets the default values.
            /// </summary>
            public BeginOnboardingRequestBuilderPostRequestConfiguration() {
                Options = new List<IRequestOption>();
                Headers = new Dictionary<string, string>();
            }
        }
    }
}
