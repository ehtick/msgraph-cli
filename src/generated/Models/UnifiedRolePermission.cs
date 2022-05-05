using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace ApiSdk.Models {
    public class UnifiedRolePermission : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Set of tasks that can be performed on a resource.</summary>
        public List<string> AllowedResourceActions { get; set; }
        /// <summary>Optional constraints that must be met for the permission to be effective.</summary>
        public string Condition { get; set; }
        /// <summary>Set of tasks that may not be performed on a resource. Not yet supported.</summary>
        public List<string> ExcludedResourceActions { get; set; }
        /// <summary>
        /// Instantiates a new unifiedRolePermission and sets the default values.
        /// </summary>
        public UnifiedRolePermission() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        /// </summary>
        public static UnifiedRolePermission CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UnifiedRolePermission();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"allowedResourceActions", n => { AllowedResourceActions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
                {"condition", n => { Condition = n.GetStringValue(); } },
                {"excludedResourceActions", n => { ExcludedResourceActions = n.GetCollectionOfPrimitiveValues<string>().ToList(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        /// </summary>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfPrimitiveValues<string>("allowedResourceActions", AllowedResourceActions);
            writer.WriteStringValue("condition", Condition);
            writer.WriteCollectionOfPrimitiveValues<string>("excludedResourceActions", ExcludedResourceActions);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
