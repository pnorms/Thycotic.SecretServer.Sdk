//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.HeartbeatStatus
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  public enum HeartbeatStatus
  {
    Failed,
    Success,
    Pending,
    Disabled,
    UnableToConnect,
    UnknownError,
    IncompatibleHost,
    AccountLockedOut,
    DnsMismatch,
    UnableToValidateServerPublicKey,
    Processing,
  }
}
