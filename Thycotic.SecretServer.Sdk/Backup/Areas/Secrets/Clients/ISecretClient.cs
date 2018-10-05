// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Clients.ISecretClient
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.Threading;
using System.Threading.Tasks;
using Thycotic.SecretServer.Sdk.Areas.Secrets.Models;
using Thycotic.SecretServer.Sdk.Infrastructure.Models;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Clients
{
  public interface ISecretClient
  {
    Task<ApiResponse<SecretModel>> GetSecretAsync(int id, SecretArgs args, CancellationToken cancellationToken);

    ApiResponse<SecretModel> GetSecret(int id, SecretArgs args);

    Task<ApiResponse<object>> GetSecretFieldAsync(int id, string field, SecretArgs args, CancellationToken cancellationToken);

    ApiResponse<object> GetSecretField(int id, string field, SecretArgs args);
  }
}
