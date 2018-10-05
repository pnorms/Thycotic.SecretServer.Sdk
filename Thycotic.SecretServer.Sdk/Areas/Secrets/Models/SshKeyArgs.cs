//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SshKeyArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("SSH key options")]
  public class SshKeyArgs
  {
    [Description("Whether to generate an SSH private key")]
    public bool GenerateSshKeys { get; set; }

    [Description("Whether to generate an SSH private key passphrase")]
    public bool GeneratePassphrase { get; set; }
  }
}
