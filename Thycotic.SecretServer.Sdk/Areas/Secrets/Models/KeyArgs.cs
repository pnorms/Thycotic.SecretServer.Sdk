//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.KeyArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  public class KeyArgs
  {
    public bool GenerateKeys { get; set; }

    public int KeyFormat { get; set; }

    public string PrivateKey { get; set; }

    public string Passphrase { get; set; }

    public int Bits { get; set; }
  }
}
