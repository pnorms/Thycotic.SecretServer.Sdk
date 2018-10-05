// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Extensions.ApiResponseExtensions
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Extensions
{
  public static class ApiResponseExtensions
  {
    public static ApiResponse<TDest> Map<TSrc, TDest>(this ApiResponse<TSrc> response)
    {
      ApiResponse<TDest> apiResponse = new ApiResponse<TDest>();
      apiResponse.Content = response.Content;
      apiResponse.IsSuccessStatusCode = response.IsSuccessStatusCode;
      apiResponse.ReasonPhrase = response.ReasonPhrase;
      apiResponse.StatusCode = response.StatusCode;
      return apiResponse;
    }
  }
}
