//
// Type: Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Clients.SdkClientAccountClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Clients;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Clients
{
  public class SdkClientAccountClient : ISdkClientAccountClient
  {
    private readonly ILogger _logger;
    private readonly IRestClient _restClient;

    public SdkClientAccountClient(ILogger logger, IRestClient restClient)
    {
      this._logger = logger;
      this._restClient = restClient;
    }

    public Task<ApiResponse<SdkClientAccountModel>> GetSdkClientAccountAsync(string accessToken, int id, SdkClientAccountArgs args, CancellationToken cancellationToken)
    {
      ApiRequest request = new ApiRequest()
      {
        BearerToken = accessToken,
        Data = (object) args,
        ResourcePath = string.Format("api/v1/sdk-client-accounts/{0}", (object) id)
      };
      LoggerExtensions.LogDebug(this._logger, "Get dev ops account {0}", new object[1]
      {
        (object) id
      });
      return this._restClient.GetAsync<SdkClientAccountModel>(request, cancellationToken);
    }

    public ApiResponse<SdkClientAccountModel> GetSdkClientAccount(string accessToken, int id, SdkClientAccountArgs args)
    {
      ApiRequest request = new ApiRequest()
      {
        BearerToken = accessToken,
        Data = (object) args,
        ResourcePath = string.Format("api/v1/sdk-client-accounts/{0}", (object) id)
      };
      LoggerExtensions.LogDebug(this._logger, "Get dev ops account {0}", new object[1]
      {
        (object) id
      });
      return this._restClient.Get<SdkClientAccountModel>(request);
    }

    public Task<ApiResponse<SdkClientAccountModel>> CreateSdkClientAccountAsync(SdkClientAccountCreateArgs args, CancellationToken cancellationToken)
    {
      ApiRequest request = new ApiRequest()
      {
        Data = (object) args,
        ResourcePath = "api/v1/sdk-client-accounts"
      };
      LoggerExtensions.LogDebug(this._logger, "Create a new dev ops account", Array.Empty<object>());
      return this._restClient.PostAsync<SdkClientAccountModel>(request, cancellationToken);
    }

    public ApiResponse<SdkClientAccountModel> CreateSdkClientAccount(SdkClientAccountCreateArgs args)
    {
      ApiRequest request = new ApiRequest()
      {
        Data = (object) args,
        ResourcePath = "api/v1/sdk-client-accounts"
      };
      LoggerExtensions.LogDebug(this._logger, "Create a new dev ops account", Array.Empty<object>());
      return this._restClient.Post<SdkClientAccountModel>(request);
    }

    public Task<ApiResponse<SdkClientAccountModel>> UpdateSdkClientAccountAsync(string accessToken, int id, SdkClientAccountArgs args, CancellationToken cancellationToken)
    {
      ApiRequest request = new ApiRequest()
      {
        BearerToken = accessToken,
        Data = (object) args,
        ResourcePath = string.Format("api/v1/sdk-client-accounts/{0}", (object) id)
      };
      LoggerExtensions.LogDebug(this._logger, "Update dev ops account {0}", new object[1]
      {
        (object) id
      });
      return this._restClient.PutAsync<SdkClientAccountModel>(request, cancellationToken);
    }

    public ApiResponse<SdkClientAccountModel> UpdateSdkClientAccount(string accessToken, int id, SdkClientAccountArgs args)
    {
      ApiRequest request = new ApiRequest()
      {
        BearerToken = accessToken,
        Data = (object) args,
        ResourcePath = string.Format("api/v1/sdk-client-accounts/{0}", (object) id)
      };
      LoggerExtensions.LogDebug(this._logger, "Update dev ops account {0}", new object[1]
      {
        (object) id
      });
      return this._restClient.Put<SdkClientAccountModel>(request);
    }

    public Task<ApiResponse<DeletedModel>> DeleteSdkClientAccountAsync(string accessToken, int id, CancellationToken cancellationToken)
    {
      return this._restClient.DeleteAsync<DeletedModel>(new ApiRequest()
      {
        BearerToken = accessToken,
        ResourcePath = string.Format("api/v1/sdk-client-accounts/{0}", (object) id)
      }, cancellationToken);
    }

    public ApiResponse<DeletedModel> DeleteSdkClientAccount(string accessToken, int id)
    {
      return this._restClient.Delete<DeletedModel>(new ApiRequest()
      {
        BearerToken = accessToken,
        ResourcePath = string.Format("api/v1/sdk-client-accounts/{0}", (object) id)
      });
    }
  }
}
