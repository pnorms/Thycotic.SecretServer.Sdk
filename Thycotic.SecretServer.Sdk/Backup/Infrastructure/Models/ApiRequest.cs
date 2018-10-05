// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.ApiRequest
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

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
