//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Extensions.ApiResponseExtensions
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


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
