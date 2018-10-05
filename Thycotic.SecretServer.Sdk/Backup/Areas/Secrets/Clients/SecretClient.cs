// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Clients.SecretClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Areas.Secrets.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Clients;
using Thycotic.SecretServer.Sdk.Infrastructure.Extensions;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Clients
{
  public class SecretClient : ISecretClient
  {
    private readonly ICacheClient _cacheClient;
    private readonly ILogger _logger;
    private readonly IOAuthClient _oAuthClient;
    private readonly IRestClient _restClient;

    public SecretClient(ILogger logger, IRestClient restClient, IOAuthClient oAuthClient, ICacheClient cacheClient)
    {
      this._logger = logger;
      this._restClient = restClient;
      this._cacheClient = cacheClient;
      this._oAuthClient = oAuthClient;
    }

    public Task<ApiResponse<SecretModel>> GetSecretAsync(int id, SecretArgs args, CancellationToken cancellationToken)
    {
      return this.ScopedAsync<SecretModel>(string.Format("api/v1/secrets/{0}", (object) id), (object) args, (Func<ApiRequest, Task<ApiResponse<SecretModel>>>) (apiRequest => this._restClient.GetAsync<SecretModel>(apiRequest, cancellationToken)), cancellationToken);
    }

    public ApiResponse<SecretModel> GetSecret(int id, SecretArgs args)
    {
      return this.Scoped<SecretModel>(string.Format("api/v1/secrets/{0}", (object) id), (object) args, (Func<ApiRequest, ApiResponse<SecretModel>>) (apiRequest => this._restClient.Get<SecretModel>(apiRequest)));
    }

    public Task<ApiResponse<object>> GetSecretFieldAsync(int id, string field, SecretArgs args, CancellationToken cancellationToken)
    {
      return this.ScopedAsync<object>(string.Format("api/v1/secrets/{0}/fields/{1}", (object) id, (object) field), (object) args, (Func<ApiRequest, Task<ApiResponse<object>>>) (apiRequest => this._restClient.GetAsync<object>(apiRequest, cancellationToken)), cancellationToken);
    }

    public ApiResponse<object> GetSecretField(int id, string field, SecretArgs args)
    {
      return this.Scoped<object>(string.Format("api/v1/secrets/{0}/fields/{1}", (object) id, (object) field), (object) args, (Func<ApiRequest, ApiResponse<object>>) (apiRequest => this._restClient.Get<object>(apiRequest)));
    }

    private Task<ApiResponse<T>> ScopedAsync<T>(string resourcePath, object args, Func<ApiRequest, Task<ApiResponse<T>>> func, CancellationToken cancellationToken)
    {
      LoggerExtensions.LogDebug(this._logger, resourcePath, Array.Empty<object>());
      return this._cacheClient.WithCacheAsync<T>(resourcePath, (Func<Task<ApiResponse<T>>>) (async () =>
      {
        ApiResponse<Token> tokenResponse = await this._oAuthClient.GetAccessTokenAsync(cancellationToken);
        if (!tokenResponse.IsSuccessStatusCode)
          return tokenResponse.Map<Token, T>();
        ApiRequest apiRequest = new ApiRequest()
        {
          BearerToken = tokenResponse.Model.AccessToken,
          Data = args,
          ResourcePath = resourcePath
        };
        return await func(apiRequest);
      }));
    }

    private ApiResponse<T> Scoped<T>(string resourcePath, object args, Func<ApiRequest, ApiResponse<T>> func)
    {
      LoggerExtensions.LogDebug(this._logger, resourcePath, Array.Empty<object>());
      return this._cacheClient.WithCache<T>(resourcePath, (Func<ApiResponse<T>>) (() =>
      {
        ApiResponse<Token> accessToken = this._oAuthClient.GetAccessToken();
        if (!accessToken.IsSuccessStatusCode)
          return accessToken.Map<Token, T>();
        return func(new ApiRequest()
        {
          BearerToken = accessToken.Model.AccessToken,
          Data = args,
          ResourcePath = resourcePath
        });
      }));
    }
  }
}
