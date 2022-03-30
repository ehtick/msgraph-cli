namespace ApiSdk.Models.Microsoft.Graph {
    /// <summary>Provides operations to manage the identityGovernance singleton.</summary>
    public enum AccessPackageRequestState {
        Submitted,
        PendingApproval,
        Delivering,
        Delivered,
        DeliveryFailed,
        Denied,
        Scheduled,
        Canceled,
        PartiallyDelivered,
        UnknownFutureValue,
    }
}
