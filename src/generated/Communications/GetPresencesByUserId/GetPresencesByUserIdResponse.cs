using ApiSdk.Models.Microsoft.Graph;
using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Communications.GetPresencesByUserId {
    /// <summary>Provides operations to call the getPresencesByUserId method.</summary>
    public class GetPresencesByUserIdResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        public List<ApiSdk.Models.Microsoft.Graph.Presence> Value { get; set; }
        /// <summary>
        /// Instantiates a new getPresencesByUserIdResponse and sets the default values.
        /// </summary>
        public GetPresencesByUserIdResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static ApiSdk.Communications.GetPresencesByUserId.GetPresencesByUserIdResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new GetPresencesByUserIdResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<T, IParseNode>> GetFieldDeserializers<T>() {
            return new Dictionary<string, Action<T, IParseNode>> {
                {"value", (o,n) => { (o as GetPresencesByUserIdResponse).Value = n.GetCollectionOfObjectValues<ApiSdk.Models.Microsoft.Graph.Presence>(ApiSdk.Models.Microsoft.Graph.Presence.CreateFromDiscriminatorValue).ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<ApiSdk.Models.Microsoft.Graph.Presence>("value", Value);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}