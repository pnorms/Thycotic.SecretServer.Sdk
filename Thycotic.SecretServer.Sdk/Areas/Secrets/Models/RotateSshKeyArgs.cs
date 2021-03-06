﻿//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.RotateSshKeyArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("SSH key rotation options")]
  public class RotateSshKeyArgs
  {
    [Description("Whether to generate the next SSH private key. Must be true if the private key is empty.")]
    public bool GenerateSshKeys { get; set; }

    [Description("Whether to generate the next SSH private key passphrase. Must be true if the passphrase is empty.")]
    public bool GeneratePassphrase { get; set; }

    [Description("Private key passphrase")]
    public string Passphrase { get; set; }

    [Description("Private key")]
    public string PrivateKey { get; set; }
  }
}
