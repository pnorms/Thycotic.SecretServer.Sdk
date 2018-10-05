//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.RefreshTokenCredentials
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


namespace Thycotic.SecretServer.Sdk.Infrastructure.Models
{
  public class RefreshTokenCredentials : IOAuthCredentials
  {
    public string RefreshToken { get; set; }

    public string AccessToken { get; set; }

    public string GrantType
    {
      get
      {
        return "refresh_token";
      }
    }
  }
}
