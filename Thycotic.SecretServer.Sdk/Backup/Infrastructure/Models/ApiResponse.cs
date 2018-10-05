// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Models.ApiResponse
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.Net;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Models
{
  public class ApiResponse
  {
    public HttpStatusCode StatusCode { get; set; }

    public string ReasonPhrase { get; set; }

    public string Content { get; set; }

    public bool IsSuccessStatusCode { get; set; }
  }
}
