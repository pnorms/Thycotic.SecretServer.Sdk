// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.ICacheClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

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
