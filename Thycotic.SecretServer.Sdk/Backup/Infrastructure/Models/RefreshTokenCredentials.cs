// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.RefreshTokenCredentials
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

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
