//
// Type: Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models.SdkClientAccountModel
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


namespace Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models
{
  public class SdkClientAccountModel
  {
    public int Id { get; set; }

    public int? UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }
  }
}
