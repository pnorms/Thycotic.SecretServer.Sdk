//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Clients.IOAuthClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Clients
{
  public interface IOAuthClient
  {
    Task<ApiResponse<Token>> GetAccessTokenAsync(CancellationToken cancellationToken = default (CancellationToken));

    ApiResponse<Token> GetAccessToken();

    Task<ApiResponse<Token>> GetAccessTokenAsync(ClientCredentials credentials, CancellationToken cancellationToken = default (CancellationToken));

    ApiResponse<Token> GetAccessToken(ClientCredentials credentials);

    Task<ApiResponse<Token>> GetAccessTokenAsync(PasswordCredentials credentials, CancellationToken cancellationToken = default (CancellationToken));

    ApiResponse<Token> GetAccessToken(PasswordCredentials credentials);

    Task<ApiResponse<Token>> GetAccessTokenAsync(AuthorizationCodeCredentials credentials, CancellationToken cancellationToken = default (CancellationToken));

    ApiResponse<Token> GetAccessToken(AuthorizationCodeCredentials credentials);

    Task<ApiResponse<Token>> GetAccessTokenAsync(RefreshTokenCredentials credentials, CancellationToken cancellationToken = default (CancellationToken));

    ApiResponse<Token> GetAccessToken(RefreshTokenCredentials credentials);

    Task<ApiResponse<Token>> GetAccessTokenAsync<T>(T credentials, CancellationToken cancellationToken = default (CancellationToken)) where T : IOAuthCredentials;

    ApiResponse<Token> GetAccessToken<T>(T credentials) where T : IOAuthCredentials;

    Task<ApiResponse<Token>> GetAccessTokenAsync(IDictionary<string, string> credentials, string refreshToken, CancellationToken cancellationToken = default (CancellationToken));

    ApiResponse<Token> GetAccessToken(IDictionary<string, string> credentials, string refreshToken);
  }
}
