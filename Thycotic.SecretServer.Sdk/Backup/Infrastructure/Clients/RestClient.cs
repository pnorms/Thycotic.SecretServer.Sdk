// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.RestClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Providers;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public class RestClient : BaseClient, IRestClient
  {
    public RestClient(ISdkClientConfigProvider sdkClientConfig)
      : base(sdkClientConfig)
    {
    }

    public async Task<ApiResponse> GetAsync(ApiRequest request, CancellationToken cancellationToken)
    {
      return await BaseClient.GetApiResponseAsync(BaseClient.GetHttpRequestMessage(this.GetUri<object>(request.ResourcePath, request.Data), HttpMethod.Get, request.Headers, request.BearerToken, (HttpContent) null), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse<TModel>> GetAsync<TModel>(ApiRequest request, CancellationToken cancellationToken)
    {
      return await BaseClient.GetApiResponseAsync<TModel>(BaseClient.GetHttpRequestMessage(this.GetUri<object>(request.ResourcePath, request.Data), HttpMethod.Get, request.Headers, request.BearerToken, (HttpContent) null), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse> PostAsync(ApiRequest request, CancellationToken cancellationToken)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      StringContent jsonContent = BaseClient.GetJsonContent<object>(request.Data);
      HttpMethod post = HttpMethod.Post;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      StringContent stringContent = jsonContent;
      return await BaseClient.GetApiResponseAsync(BaseClient.GetHttpRequestMessage(uri, post, headers, bearerToken, (HttpContent) stringContent), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse<TModel>> PostAsync<TModel>(ApiRequest request, CancellationToken cancellationToken)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      StringContent jsonContent = BaseClient.GetJsonContent<object>(request.Data);
      HttpMethod post = HttpMethod.Post;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      StringContent stringContent = jsonContent;
      return await BaseClient.GetApiResponseAsync<TModel>(BaseClient.GetHttpRequestMessage(uri, post, headers, bearerToken, (HttpContent) stringContent), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse> PutAsync(ApiRequest request, CancellationToken cancellationToken)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      StringContent jsonContent = BaseClient.GetJsonContent<object>(request.Data);
      HttpMethod put = HttpMethod.Put;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      StringContent stringContent = jsonContent;
      return await BaseClient.GetApiResponseAsync(BaseClient.GetHttpRequestMessage(uri, put, headers, bearerToken, (HttpContent) stringContent), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse<TModel>> PutAsync<TModel>(ApiRequest request, CancellationToken cancellationToken)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      StringContent jsonContent = BaseClient.GetJsonContent<object>(request.Data);
      HttpMethod put = HttpMethod.Put;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      StringContent stringContent = jsonContent;
      return await BaseClient.GetApiResponseAsync<TModel>(BaseClient.GetHttpRequestMessage(uri, put, headers, bearerToken, (HttpContent) stringContent), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse> DeleteAsync(ApiRequest request, CancellationToken cancellationToken)
    {
      return await BaseClient.GetApiResponseAsync(BaseClient.GetHttpRequestMessage(this.GetUri(request.ResourcePath), HttpMethod.Delete, request.Headers, request.BearerToken, (HttpContent) null), request.Credentials, cancellationToken);
    }

    public async Task<ApiResponse<TModel>> DeleteAsync<TModel>(ApiRequest request, CancellationToken cancellationToken)
    {
      return await BaseClient.GetApiResponseAsync<TModel>(BaseClient.GetHttpRequestMessage(this.GetUri(request.ResourcePath), HttpMethod.Delete, request.Headers, request.BearerToken, (HttpContent) null), request.Credentials, cancellationToken);
    }

    public ApiResponse Get(ApiRequest request)
    {
      return BaseClient.GetApiResponse(BaseClient.GetHttpWebRequest(this.GetUri<object>(request.ResourcePath, request.Data), HttpMethod.Get, request.Headers, request.BearerToken, (byte[]) null, "application/json"), request.Credentials);
    }

    public ApiResponse<TModel> Get<TModel>(ApiRequest request)
    {
      return BaseClient.GetApiResponse<TModel>(BaseClient.GetHttpWebRequest(this.GetUri<object>(request.ResourcePath, request.Data), HttpMethod.Get, request.Headers, request.BearerToken, (byte[]) null, "application/json"), request.Credentials);
    }

    public ApiResponse Post(ApiRequest request)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      byte[] jsonBytes = BaseClient.GetJsonBytes<object>(request.Data);
      HttpMethod post = HttpMethod.Post;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      byte[] content = jsonBytes;
      string contentType = "application/json";
      return BaseClient.GetApiResponse(BaseClient.GetHttpWebRequest(uri, post, headers, bearerToken, content, contentType), request.Credentials);
    }

    public ApiResponse<TModel> Post<TModel>(ApiRequest request)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      byte[] jsonBytes = BaseClient.GetJsonBytes<object>(request.Data);
      HttpMethod post = HttpMethod.Post;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      byte[] content = jsonBytes;
      string contentType = "application/json";
      return BaseClient.GetApiResponse<TModel>(BaseClient.GetHttpWebRequest(uri, post, headers, bearerToken, content, contentType), request.Credentials);
    }

    public ApiResponse Put(ApiRequest request)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      byte[] jsonBytes = BaseClient.GetJsonBytes<object>(request.Data);
      HttpMethod put = HttpMethod.Put;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      byte[] content = jsonBytes;
      string contentType = "application/json";
      return BaseClient.GetApiResponse(BaseClient.GetHttpWebRequest(uri, put, headers, bearerToken, content, contentType), request.Credentials);
    }

    public ApiResponse<TModel> Put<TModel>(ApiRequest request)
    {
      Uri uri = this.GetUri(request.ResourcePath);
      byte[] jsonBytes = BaseClient.GetJsonBytes<object>(request.Data);
      HttpMethod put = HttpMethod.Put;
      HttpRequestHeaders headers = request.Headers;
      string bearerToken = request.BearerToken;
      byte[] content = jsonBytes;
      string contentType = "application/json";
      return BaseClient.GetApiResponse<TModel>(BaseClient.GetHttpWebRequest(uri, put, headers, bearerToken, content, contentType), request.Credentials);
    }

    public ApiResponse Delete(ApiRequest request)
    {
      return BaseClient.GetApiResponse(BaseClient.GetHttpWebRequest(this.GetUri(request.ResourcePath), HttpMethod.Delete, request.Headers, request.BearerToken, (byte[]) null, "application/json"), request.Credentials);
    }

    public ApiResponse<TModel> Delete<TModel>(ApiRequest request)
    {
      return BaseClient.GetApiResponse<TModel>(BaseClient.GetHttpWebRequest(this.GetUri(request.ResourcePath), HttpMethod.Delete, request.Headers, request.BearerToken, (byte[]) null, "application/json"), request.Credentials);
    }
  }
}
