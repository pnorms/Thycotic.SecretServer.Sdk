﻿//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Providers.ISdkClientConfigProvider
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Providers
{
  public interface ISdkClientConfigProvider
  {
    void SaveEndpoint(string data);

    string LoadEndpoint();

    void SaveCacheSettings(CacheSettings settings);

    CacheSettings LoadCacheSettings();

    void SaveCredentials(ClientCredentials credentials);

    ClientCredentials LoadCredentials();

    bool CredentialsExist();

    void RemoveConfigurations();

    bool EndpointExists();

    void SaveResetToken(string data);

    string LoadResetToken();
  }
}
