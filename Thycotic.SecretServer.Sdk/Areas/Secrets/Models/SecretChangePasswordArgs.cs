//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretChangePasswordArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret password change options")]
  public class SecretChangePasswordArgs
  {
    [Description("Options for rotating SSH keys")]
    public RotateSshKeyArgs SshKeyArgs { get; set; }
  }
}
