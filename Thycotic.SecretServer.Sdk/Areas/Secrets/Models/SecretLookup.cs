//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretLookup
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Simple secret representation")]
  public class SecretLookup
  {
    [Description("Secret ID")]
    public int Id { get; set; }

    [Description("Secret name")]
    public string Value { get; set; }
  }
}
