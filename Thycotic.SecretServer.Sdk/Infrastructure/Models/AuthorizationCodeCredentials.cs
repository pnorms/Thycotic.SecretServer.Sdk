//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.AuthorizationCodeCredentials
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


namespace Thycotic.SecretServer.Sdk.Infrastructure.Models
{
  public class AuthorizationCodeCredentials : IOAuthCredentials
  {
    public string Code { get; set; }

    public string RedirectUri { get; set; }

    public string ClientId { get; set; }

    public string ClientSecret { get; set; }

    public string GrantType
    {
      get
      {
        return "authorization_code";
      }
    }
  }
}
