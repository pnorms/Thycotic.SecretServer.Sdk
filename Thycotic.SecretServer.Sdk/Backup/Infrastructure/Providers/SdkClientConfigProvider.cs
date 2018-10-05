// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Providers.SdkClientConfigProvider
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Providers
{
  public class SdkClientConfigProvider : ISdkClientConfigProvider
  {
    private const string EndpointConfig = "endpoint.config";
    private const string CredentialsConfig = "credentials.config";
    private const string CacheConfig = "cache.config";
    private const string ResetTokenConfig = "reset-token.config";
    private readonly IDataProtector _dataProtector;
    private CacheSettings _cacheSettings;
    private ClientCredentials _credentials;
    private string _resetToken;
    private string _url;

    public SdkClientConfigProvider(IDataProtector dataProtector)
    {
      this._dataProtector = dataProtector;
    }

    public bool EndpointExists()
    {
      return File.Exists("endpoint.config");
    }

    public string LoadEndpoint()
    {
      if (this._url == null)
      {
        if (File.Exists("endpoint.config"))
        {
          try
          {
            this._url = Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes("endpoint.config")));
          }
          catch
          {
            File.Delete("endpoint.config");
          }
        }
      }
      return this._url;
    }

    public void SaveEndpoint(string url)
    {
      File.WriteAllBytes("endpoint.config", this._dataProtector.Protect(Encoding.UTF8.GetBytes(url)));
      this._url = url;
    }

    public void SaveCacheSettings(CacheSettings settings)
    {
      File.WriteAllBytes("cache.config", this._dataProtector.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) settings))));
      this._cacheSettings = settings;
    }

    public CacheSettings LoadCacheSettings()
    {
      if (this._cacheSettings == null)
      {
        if (File.Exists("cache.config"))
        {
          try
          {
            this._cacheSettings = (CacheSettings) JsonConvert.DeserializeObject<CacheSettings>(Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes("cache.config"))));
          }
          catch
          {
            File.Delete("cache.config");
          }
        }
      }
      return this._cacheSettings ?? new CacheSettings();
    }

    public ClientCredentials LoadCredentials()
    {
      if (this._credentials == null)
      {
        if (File.Exists("credentials.config"))
        {
          try
          {
            this._credentials = (ClientCredentials) JsonConvert.DeserializeObject<ClientCredentials>(Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes("credentials.config"))));
          }
          catch
          {
            File.Delete("credentials.config");
          }
        }
      }
      return this._credentials;
    }

    public void SaveCredentials(ClientCredentials credentials)
    {
      File.WriteAllBytes("credentials.config", this._dataProtector.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) credentials))));
      this._credentials = credentials;
    }

    public bool CredentialsExist()
    {
      return File.Exists("credentials.config");
    }

    public void RemoveConfigurations()
    {
      if (File.Exists("endpoint.config"))
        File.Delete("endpoint.config");
      this._url = (string) null;
      if (File.Exists("credentials.config"))
        File.Delete("credentials.config");
      this._credentials = (ClientCredentials) null;
      if (File.Exists("cache.config"))
        File.Delete("cache.config");
      this._cacheSettings = (CacheSettings) null;
    }

    public string LoadResetToken()
    {
      if (this._resetToken == null)
      {
        if (File.Exists("reset-token.config"))
        {
          try
          {
            this._resetToken = Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes("reset-token.config")));
          }
          catch
          {
            File.Delete("reset-token.config");
          }
        }
      }
      return this._resetToken;
    }

    public void SaveResetToken(string token)
    {
      if (token == null)
        return;
      File.WriteAllBytes("reset-token.config", this._dataProtector.Protect(Encoding.UTF8.GetBytes(token)));
      this._resetToken = token;
    }
  }
}
