//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.ApiRequest
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.Net;
using System.Net.Http.Headers;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Models
{
  public class ApiRequest
  {
    public string ResourcePath { get; set; }

    public string BearerToken { get; set; }

    public ICredentials Credentials { get; set; }

    public object Data { get; set; }

    public HttpRequestHeaders Headers { get; set; }
  }
}
