//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.OAuthClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Providers;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public class OAuthClient : BaseClient, IOAuthClient
  {
    public OAuthClient(ISdkClientConfigProvider sdkClientConfigProvider)
      : base(sdkClientConfigProvider)
    {
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync(CancellationToken cancellationToken = default (CancellationToken))
    {
      OAuthClient oauthClient = this;
      ClientCredentials credentials = oauthClient.SdkClientConfigProvider.LoadCredentials();
      if (credentials != null)
      {
            // ISSUE: explicit non-virtual call
            //return await __nonvirtual (oauthClient.GetAccessTokenAsync(credentials, cancellationToken));
            return await (oauthClient.GetAccessTokenAsync(credentials, cancellationToken));
            }
      ApiResponse<Token> apiResponse = new ApiResponse<Token>();
      apiResponse.IsSuccessStatusCode = false;
      apiResponse.StatusCode = HttpStatusCode.Unauthorized;
      return apiResponse;
    }

    public ApiResponse<Token> GetAccessToken()
    {
      ClientCredentials credentials = this.SdkClientConfigProvider.LoadCredentials();
      if (credentials != null)
        return this.GetAccessToken(credentials);
      ApiResponse<Token> apiResponse = new ApiResponse<Token>();
      apiResponse.IsSuccessStatusCode = false;
      apiResponse.StatusCode = HttpStatusCode.Unauthorized;
      return apiResponse;
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync(ClientCredentials credentials, CancellationToken cancellationToken = default (CancellationToken))
    {
      return await this.GetAccessTokenAsync((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "client_id",
          credentials.ClientId
        },
        {
          "client_secret",
          credentials.ClientSecret
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, (string) null, cancellationToken);
    }

    public ApiResponse<Token> GetAccessToken(ClientCredentials credentials)
    {
      return this.GetAccessToken((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "client_id",
          credentials.ClientId
        },
        {
          "client_secret",
          credentials.ClientSecret
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, (string) null);
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync(PasswordCredentials credentials, CancellationToken cancellationToken = default (CancellationToken))
    {
      return await this.GetAccessTokenAsync((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "username",
          credentials.Username
        },
        {
          "password",
          credentials.Password
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, (string) null, cancellationToken);
    }

    public ApiResponse<Token> GetAccessToken(PasswordCredentials credentials)
    {
      return this.GetAccessToken((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "username",
          credentials.Username
        },
        {
          "password",
          credentials.Password
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, (string) null);
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync(AuthorizationCodeCredentials credentials, CancellationToken cancellationToken = default (CancellationToken))
    {
      return await this.GetAccessTokenAsync((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "code",
          credentials.Code
        },
        {
          "redirect_uri",
          credentials.RedirectUri
        },
        {
          "client_id",
          credentials.ClientId
        },
        {
          "client_secret",
          credentials.ClientSecret
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, (string) null, cancellationToken);
    }

    public ApiResponse<Token> GetAccessToken(AuthorizationCodeCredentials credentials)
    {
      return this.GetAccessToken((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "code",
          credentials.Code
        },
        {
          "redirect_uri",
          credentials.RedirectUri
        },
        {
          "client_id",
          credentials.ClientId
        },
        {
          "client_secret",
          credentials.ClientSecret
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, (string) null);
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync(RefreshTokenCredentials credentials, CancellationToken cancellationToken = default (CancellationToken))
    {
      return await this.GetAccessTokenAsync((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "refresh_token",
          credentials.RefreshToken
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, credentials.AccessToken, cancellationToken);
    }

    public ApiResponse<Token> GetAccessToken(RefreshTokenCredentials credentials)
    {
      return this.GetAccessToken((IDictionary<string, string>) new Dictionary<string, string>()
      {
        {
          "refresh_token",
          credentials.RefreshToken
        },
        {
          "grant_type",
          credentials.GrantType
        }
      }, string.Format("bearer {0}", (object) credentials.AccessToken));
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync<T>(T credentials, CancellationToken cancellationToken = default (CancellationToken)) where T : IOAuthCredentials
    {
      ClientCredentials credentials1 = (object) (T) credentials as ClientCredentials;
      if (credentials1 != null)
        return await this.GetAccessTokenAsync(credentials1, cancellationToken);
      PasswordCredentials credentials2 = (object) (T) credentials as PasswordCredentials;
      if (credentials2 != null)
        return await this.GetAccessTokenAsync(credentials2, cancellationToken);
      AuthorizationCodeCredentials credentials3 = (object) (T) credentials as AuthorizationCodeCredentials;
      if (credentials3 != null)
        return await this.GetAccessTokenAsync(credentials3, cancellationToken);
      RefreshTokenCredentials credentials4 = (object) (T) credentials as RefreshTokenCredentials;
      if (credentials4 != null)
        return await this.GetAccessTokenAsync(credentials4, cancellationToken);
      throw new AuthenticationException("Unsupported credential type");
    }

    public ApiResponse<Token> GetAccessToken<T>(T credentials) where T : IOAuthCredentials
    {
      ClientCredentials credentials1 = (object) credentials as ClientCredentials;
      if (credentials1 != null)
        return this.GetAccessToken(credentials1);
      PasswordCredentials credentials2 = (object) credentials as PasswordCredentials;
      if (credentials2 != null)
        return this.GetAccessToken(credentials2);
      AuthorizationCodeCredentials credentials3 = (object) credentials as AuthorizationCodeCredentials;
      if (credentials3 != null)
        return this.GetAccessToken(credentials3);
      RefreshTokenCredentials credentials4 = (object) credentials as RefreshTokenCredentials;
      if (credentials4 != null)
        return this.GetAccessToken(credentials4);
      throw new AuthenticationException("Unsupported credential type");
    }

    public async Task<ApiResponse<Token>> GetAccessTokenAsync(IDictionary<string, string> credentials, string refreshToken, CancellationToken cancellationToken = default (CancellationToken))
    {
      Uri uri = new Uri(string.Format("{0}/oauth2/token", (object) this.SdkClientConfigProvider.LoadEndpoint().Trim('/')));
      FormUrlEncodedContent urlEncodedContent1 = new FormUrlEncodedContent((IEnumerable<KeyValuePair<string, string>>) credentials);
      HttpMethod post = HttpMethod.Post;
            // ISSUE: variable of the null type
            //null local = null;
            string bearerToken = refreshToken;
      FormUrlEncodedContent urlEncodedContent2 = urlEncodedContent1;
      return await BaseClient.GetApiResponseAsync<Token>(BaseClient.GetHttpRequestMessage(uri, post, (HttpRequestHeaders) null, bearerToken, (HttpContent) urlEncodedContent2), (ICredentials) null, cancellationToken);
    }

    public ApiResponse<Token> GetAccessToken(IDictionary<string, string> credentials, string refreshToken)
    {
      Uri uri = new Uri(string.Format("{0}/oauth2/token", (object) this.SdkClientConfigProvider.LoadEndpoint().Trim('/')));
      byte[] formUrlEncodedBytes = BaseClient.GetFormUrlEncodedBytes(credentials.ToList<KeyValuePair<string, string>>());
      HttpMethod post = HttpMethod.Post;
      // ISSUE: variable of the null type
      //null local = null;
      string bearerToken = refreshToken;
      byte[] content = formUrlEncodedBytes;
      string contentType = "application/x-www-form-urlencoded";
      return BaseClient.GetApiResponse<Token>(BaseClient.GetHttpWebRequest(uri, post, (HttpRequestHeaders) null, bearerToken, content, contentType), (ICredentials) null);
    }
  }
}
