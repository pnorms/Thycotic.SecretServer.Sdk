// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models.SdkClientAccountCreateArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System;

namespace Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models
{
  public class SdkClientAccountCreateArgs
  {
    public Guid ClientId { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string RuleName { get; set; }

    public string OnboardingKey { get; set; }
  }
}
