using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.CommandLine;
using System.CommandLine.Invocation;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
namespace ApiSdk.IdentityGovernance.AccessReviews.Definitions.Item.Instances.Item.AcceptRecommendations {
    /// <summary>Builds and executes requests for operations under \identityGovernance\accessReviews\definitions\{accessReviewScheduleDefinition-id}\instances\{accessReviewInstance-id}\microsoft.graph.acceptRecommendations</summary>
    public class AcceptRecommendationsRequestBuilder {
        /// <summary>Path parameters for the request</summary>
        private Dictionary<string, object> PathParameters { get; set; }
        /// <summary>The request adapter to use to execute the requests.</summary>
        private IRequestAdapter RequestAdapter { get; set; }
        /// <summary>Url template to use to build the URL for the current request builder</summary>
        private string UrlTemplate { get; set; }
        /// <summary>
        /// Invoke action acceptRecommendations
        /// </summary>
        public Command BuildPostCommand() {
            var command = new Command("post");
            // Create options for all the parameters
            command.AddOption(new Option<string>("--accessreviewscheduledefinition-id", description: "key: id of accessReviewScheduleDefinition"));
            command.AddOption(new Option<string>("--accessreviewinstance-id", description: "key: id of accessReviewInstance"));
            command.Handler = CommandHandler.Create<string, string>(async (accessReviewScheduleDefinitionId, accessReviewInstanceId) => {
                var requestInfo = CreatePostRequestInformation();
                if (!String.IsNullOrEmpty(accessReviewScheduleDefinitionId)) requestInfo.PathParameters.Add("accessReviewScheduleDefinition_id", accessReviewScheduleDefinitionId);
                if (!String.IsNullOrEmpty(accessReviewInstanceId)) requestInfo.PathParameters.Add("accessReviewInstance_id", accessReviewInstanceId);
                await RequestAdapter.SendNoContentAsync(requestInfo);
                // Print request output. What if the request has no return?
                Console.WriteLine("Success");
            });
            return command;
        }
        /// <summary>
        /// Instantiates a new AcceptRecommendationsRequestBuilder and sets the default values.
        /// <param name="pathParameters">Path parameters for the request</param>
        /// <param name="requestAdapter">The request adapter to use to execute the requests.</param>
        /// </summary>
        public AcceptRecommendationsRequestBuilder(Dictionary<string, object> pathParameters, IRequestAdapter requestAdapter) {
            _ = pathParameters ?? throw new ArgumentNullException(nameof(pathParameters));
            _ = requestAdapter ?? throw new ArgumentNullException(nameof(requestAdapter));
            UrlTemplate = "{+baseurl}/identityGovernance/accessReviews/definitions/{accessReviewScheduleDefinition_id}/instances/{accessReviewInstance_id}/microsoft.graph.acceptRecommendations";
            var urlTplParams = new Dictionary<string, object>(pathParameters);
            PathParameters = urlTplParams;
            RequestAdapter = requestAdapter;
        }
        /// <summary>
        /// Invoke action acceptRecommendations
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// </summary>
        public RequestInformation CreatePostRequestInformation(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default) {
            var requestInfo = new RequestInformation {
                HttpMethod = HttpMethod.POST,
                UrlTemplate = UrlTemplate,
                PathParameters = PathParameters,
            };
            h?.Invoke(requestInfo.Headers);
            requestInfo.AddRequestOptions(o?.ToArray());
            return requestInfo;
        }
        /// <summary>
        /// Invoke action acceptRecommendations
        /// <param name="cancellationToken">Cancellation token to use when cancelling requests</param>
        /// <param name="h">Request headers</param>
        /// <param name="o">Request options</param>
        /// <param name="responseHandler">Response handler to use in place of the default response handling provided by the core service</param>
        /// </summary>
        public async Task PostAsync(Action<IDictionary<string, string>> h = default, IEnumerable<IRequestOption> o = default, IResponseHandler responseHandler = default, CancellationToken cancellationToken = default) {
            var requestInfo = CreatePostRequestInformation(h, o);
            await RequestAdapter.SendNoContentAsync(requestInfo, responseHandler, cancellationToken);
        }
    }
}
