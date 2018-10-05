//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.Token
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Newtonsoft.Json;
using System;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Models
{
  public class Token
  {
    private DateTime _datetime;

    [JsonProperty("access_token")]
    public string AccessToken { get; set; }

    [JsonProperty("refresh_token")]
    public string RefreshToken { get; set; }

    [JsonProperty("token_type")]
    public string TokenType { get; set; }

    [JsonProperty("expires_in")]
    public int ExpiresIn { get; set; }

    [JsonIgnore]
    public DateTime Expiration
    {
      get
      {
        return this._datetime.AddSeconds((double) this.ExpiresIn);
      }
    }

    public Token()
    {
      this._datetime = DateTime.UtcNow;
    }
  }
}
