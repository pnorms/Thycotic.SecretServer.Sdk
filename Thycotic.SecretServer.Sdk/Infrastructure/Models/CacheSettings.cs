//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.CacheSettings
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


namespace Thycotic.SecretServer.Sdk.Infrastructure.Models
{
  public class CacheSettings
  {
    public int Minutes { get; set; }

    public CacheStrategy Strategy { get; set; }
  }
}
