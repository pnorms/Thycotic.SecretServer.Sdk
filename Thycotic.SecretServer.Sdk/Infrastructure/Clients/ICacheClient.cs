//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.ICacheClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public interface ICacheClient
  {
    Task<ApiResponse<T>> WithCacheAsync<T>(string key, Func<Task<ApiResponse<T>>> func);

    ApiResponse<T> WithCache<T>(string key, Func<ApiResponse<T>> func);

    void Bust();
  }
}
