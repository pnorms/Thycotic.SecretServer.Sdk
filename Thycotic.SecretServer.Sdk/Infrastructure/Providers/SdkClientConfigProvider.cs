//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Providers.SdkClientConfigProvider
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Microsoft.AspNetCore.DataProtection;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;
using System.Configuration;
using Newtonsoft.Json.Linq;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Providers
{

public class SdkClientConfigProvider : ISdkClientConfigProvider
{
    private const string ConfigSettingsFile = "Thycotic.SecretServer.Sdk.json";
    private dynamic ConfigSettings;
    private readonly IDataProtector _dataProtector;
    private CacheSettings _cacheSettings;
    private ClientCredentials _credentials;
    private string _resetToken;
    private string _url;

    public SdkClientConfigProvider(IDataProtector dataProtector)
    {
        this._dataProtector = dataProtector;
        try
        {
            ConfigSettings = JObject.Parse(File.ReadAllText(ConfigSettingsFile));
        }
        catch
        {
            ConfigSettings = JObject.Parse(@"{
                'credentials': 'credentials.config',
                'endpoint': 'endpoint.config',
                'cache': 'cache.config',
                'resettoken': 'reset-token.config'
            }");
        }
    }

    public bool EndpointExists()
    {
      return File.Exists((string)ConfigSettings.endpoint);
    }

    public string LoadEndpoint()
    {
      if (this._url == null)
      {
        if (File.Exists((string)ConfigSettings.endpoint))
        {
          try
          {
            this._url = Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes((string)ConfigSettings.endpoint)));
          }
          catch
          {
            File.Delete((string)ConfigSettings.endpoint);
          }
        }
      }
      return this._url;
    }

    public void SaveEndpoint(string url)
    {
      File.WriteAllBytes((string)ConfigSettings.endpoint, this._dataProtector.Protect(Encoding.UTF8.GetBytes(url)));
      this._url = url;
    }

    public void SaveCacheSettings(CacheSettings settings)
    {
      File.WriteAllBytes((string)ConfigSettings.cache, this._dataProtector.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) settings))));
      this._cacheSettings = settings;
    }

    public CacheSettings LoadCacheSettings()
    {
      if (this._cacheSettings == null)
      {
        if (File.Exists((string)ConfigSettings.cache))
        {
          try
          {
            this._cacheSettings = (CacheSettings) JsonConvert.DeserializeObject<CacheSettings>(Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes((string)ConfigSettings.cache))));
          }
          catch
          {
            File.Delete((string)ConfigSettings.cache);
          }
        }
      }
      return this._cacheSettings ?? new CacheSettings();
    }

    public ClientCredentials LoadCredentials()
    {
      if (this._credentials == null)
      {
        if (File.Exists((string)ConfigSettings.credentials))
        {
          try
          {
            this._credentials = (ClientCredentials) JsonConvert.DeserializeObject<ClientCredentials>(Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes((string)ConfigSettings.credentials))));
          }
          catch
          {
            File.Delete((string)ConfigSettings.credentials);
          }
        }
      }
      return this._credentials;
    }

    public void SaveCredentials(ClientCredentials credentials)
    {
      File.WriteAllBytes((string)ConfigSettings.credentials, this._dataProtector.Protect(Encoding.UTF8.GetBytes(JsonConvert.SerializeObject((object) credentials))));
      this._credentials = credentials;
    }

    public bool CredentialsExist()
    {
      return File.Exists((string)ConfigSettings.credentials);
    }

    public void RemoveConfigurations()
    {
      if (File.Exists((string)ConfigSettings.endpoint))
        File.Delete((string)ConfigSettings.endpoint);
      this._url = (string) null;
      if (File.Exists((string)ConfigSettings.credentials))
        File.Delete((string)ConfigSettings.credentials);
      this._credentials = (ClientCredentials) null;
      if (File.Exists((string)ConfigSettings.cache))
        File.Delete((string)ConfigSettings.cache);
      this._cacheSettings = (CacheSettings) null;
    }

    public string LoadResetToken()
    {
      if (this._resetToken == null)
      {
        if (File.Exists((string)ConfigSettings.resettoken))
        {
          try
          {
            this._resetToken = Encoding.UTF8.GetString(this._dataProtector.Unprotect(File.ReadAllBytes((string)ConfigSettings.resettoken)));
          }
          catch
          {
            File.Delete((string)ConfigSettings.resettoken);
          }
        }
      }
      return this._resetToken;
    }

    public void SaveResetToken(string token)
    {
      if (token == null)
        return;
      File.WriteAllBytes((string)ConfigSettings.resettoken, this._dataProtector.Protect(Encoding.UTF8.GetBytes(token)));
      this._resetToken = token;
    }
  }
}
