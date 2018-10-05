//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.IRestClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public interface IRestClient
  {
    Task<ApiResponse> GetAsync(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse Get(ApiRequest request);

    Task<ApiResponse<TModel>> GetAsync<TModel>(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse<TModel> Get<TModel>(ApiRequest request);

    Task<ApiResponse> PostAsync(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse Post(ApiRequest request);

    Task<ApiResponse<TModel>> PostAsync<TModel>(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse<TModel> Post<TModel>(ApiRequest request);

    Task<ApiResponse> PutAsync(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse Put(ApiRequest request);

    Task<ApiResponse<TModel>> PutAsync<TModel>(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse<TModel> Put<TModel>(ApiRequest request);

    Task<ApiResponse> DeleteAsync(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse Delete(ApiRequest request);

    Task<ApiResponse<TModel>> DeleteAsync<TModel>(ApiRequest request, CancellationToken cancellationToken);

    ApiResponse<TModel> Delete<TModel>(ApiRequest request);
  }
}
