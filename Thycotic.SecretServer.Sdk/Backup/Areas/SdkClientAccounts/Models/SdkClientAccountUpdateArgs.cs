// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models.SdkClientAccountUpdateArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

namespace Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models
{
  public class SdkClientAccountUpdateArgs
  {
    public int? UserId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public bool ResetClientSecret { get; set; }
  }
}
