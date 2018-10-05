//
// Type: Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Clients.ISdkClientAccountClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Clients
{
  public interface ISdkClientAccountClient
  {
    Task<ApiResponse<SdkClientAccountModel>> GetSdkClientAccountAsync(string accessToken, int id, SdkClientAccountArgs args, CancellationToken cancellationToken);

    ApiResponse<SdkClientAccountModel> GetSdkClientAccount(string accessToken, int id, SdkClientAccountArgs args);

    Task<ApiResponse<SdkClientAccountModel>> CreateSdkClientAccountAsync(SdkClientAccountCreateArgs args, CancellationToken cancellationToken);

    ApiResponse<SdkClientAccountModel> CreateSdkClientAccount(SdkClientAccountCreateArgs args);

    Task<ApiResponse<SdkClientAccountModel>> UpdateSdkClientAccountAsync(string accessToken, int id, SdkClientAccountArgs args, CancellationToken cancellationToken);

    ApiResponse<SdkClientAccountModel> UpdateSdkClientAccount(string accessToken, int id, SdkClientAccountArgs args);

    Task<ApiResponse<DeletedModel>> DeleteSdkClientAccountAsync(string accessToken, int id, CancellationToken cancellationToken);

    ApiResponse<DeletedModel> DeleteSdkClientAccount(string accessToken, int id);
  }
}
