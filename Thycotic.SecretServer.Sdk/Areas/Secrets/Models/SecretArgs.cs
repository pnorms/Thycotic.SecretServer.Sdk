//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret query options")]
  public class SecretArgs
  {
    [Description("Whether to include inactive secrets in the results")]
    public bool IncludeInactive { get; set; }
  }
}
