//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.CacheClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Providers;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public class CacheClient : ICacheClient
  {
    private const string CacheDat = "_cache.dat";
    private readonly IDataProtector _dataProtector;
    private readonly ISdkClientConfigProvider _sdkClientConfigProvider;
    private List<CacheClient.CacheEntry> _cache;

    public CacheClient(IDataProtector dataProtector, ISdkClientConfigProvider sdkClientConfigProvider)
    {
      this._dataProtector = dataProtector;
      this._sdkClientConfigProvider = sdkClientConfigProvider;
    }

    public async Task<ApiResponse<T>> WithCacheAsync<T>(string key, Func<Task<ApiResponse<T>>> func)
    {
      CacheSettings settings = this._sdkClientConfigProvider.LoadCacheSettings();
      if (settings.Strategy == CacheStrategy.CacheThenServer || settings.Strategy == CacheStrategy.CacheThenServerAllowExpired)
      {
        this.Hydrate();
        ApiResponse<T> cachedValue;
        if (this.TryGetValue<T>(key, true, out cachedValue))
          return cachedValue;
      }
      ApiResponse<T> response = await func();
      if (settings.Strategy == CacheStrategy.Never)
        return response;
      this.Hydrate();
      if (!response.IsSuccessStatusCode)
      {
        bool respectExpiration = settings.Strategy != CacheStrategy.CacheThenServerAllowExpired;
        ApiResponse<T> cachedValue;
        if (this.TryGetValue<T>(key, respectExpiration, out cachedValue))
          return cachedValue;
      }
      else
      {
        this.AddValue<T>(key, settings.Minutes, response);
        this.Stash();
      }
      return response;
    }

    public ApiResponse<T> WithCache<T>(string key, Func<ApiResponse<T>> func)
    {
      CacheSettings cacheSettings = this._sdkClientConfigProvider.LoadCacheSettings();
      if (cacheSettings.Strategy == CacheStrategy.CacheThenServer || cacheSettings.Strategy == CacheStrategy.CacheThenServerAllowExpired)
      {
        this.Hydrate();
        ApiResponse<T> cachedValue;
        if (this.TryGetValue<T>(key, true, out cachedValue))
          return cachedValue;
      }
      ApiResponse<T> response = func();
      if (cacheSettings.Strategy == CacheStrategy.Never)
        return response;
      this.Hydrate();
      if (!response.IsSuccessStatusCode)
      {
        bool respectExpiration = cacheSettings.Strategy != CacheStrategy.CacheThenServerAllowExpired;
        ApiResponse<T> cachedValue;
        if (this.TryGetValue<T>(key, respectExpiration, out cachedValue))
          return cachedValue;
      }
      else
      {
        this.AddValue<T>(key, cacheSettings.Minutes, response);
        this.Stash();
      }
      return response;
    }

    public void Bust()
    {
      this._cache = new List<CacheClient.CacheEntry>();
      if (!File.Exists("_cache.dat"))
        return;
      File.Delete("_cache.dat");
    }

    private bool TryGetValue<T>(string key, bool respectExpiration, out ApiResponse<T> cachedValue)
    {
      List<CacheClient.CacheEntry> cache = this._cache;
      CacheClient.CacheEntry cacheEntry = cache != null ? cache.OrderBy<CacheClient.CacheEntry, DateTime>((Func<CacheClient.CacheEntry, DateTime>) (x => x.Expiration)).FirstOrDefault<CacheClient.CacheEntry>((Func<CacheClient.CacheEntry, bool>) (x =>
      {
        if (!(x.Key == key))
          return false;
        if (respectExpiration)
          return x.Expiration > DateTime.UtcNow;
        return true;
      })) : (CacheClient.CacheEntry) null;
      if (cacheEntry == null)
      {
        cachedValue = (ApiResponse<T>) null;
        return false;
      }
      string str = Encoding.UTF8.GetString(this._dataProtector.Unprotect(cacheEntry.ProtectedBytes));
      cachedValue = (ApiResponse<T>) JsonConvert.DeserializeObject<ApiResponse<T>>(str);
      return true;
    }

    private void AddValue<T>(string key, int minutes, ApiResponse<T> response)
    {
      byte[] bytes = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) response));
      this._cache.RemoveAll((Predicate<CacheClient.CacheEntry>) (x => x.Key == key));
      this._cache.Add(new CacheClient.CacheEntry()
      {
        Key = key,
        ProtectedBytes = this._dataProtector.Protect(bytes),
        Expiration = minutes == 0 ? DateTime.MaxValue : DateTime.UtcNow.AddMinutes((double) minutes)
      });
    }

    private void Hydrate()
    {
      if (File.Exists("_cache.dat"))
      {
        try
        {
          this._cache = (List<CacheClient.CacheEntry>) JsonConvert.DeserializeObject<List<CacheClient.CacheEntry>>(Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes("_cache.dat"))));
        }
        catch
        {
          File.Delete("_cache.dat");
          this._cache = new List<CacheClient.CacheEntry>();
        }
      }
      else
        this._cache = new List<CacheClient.CacheEntry>();
    }

    private void Stash()
    {
      byte[] bytes = this._dataProtector.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) this._cache)));
      try
      {
        File.WriteAllBytes("_cache.dat", bytes);
      }
      catch
      {
        try
        {
          Thread.Sleep(30);
          File.WriteAllBytes("_cache.dat", bytes);
        }
        catch
        {
        }
      }
    }

    private class CacheEntry
    {
      public string Key { get; set; }

      public DateTime Expiration { get; set; }

      public byte[] ProtectedBytes { get; set; }
    }
  }
}
