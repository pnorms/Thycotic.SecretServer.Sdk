//
// Type: Thycotic.SecretServer.Sdk.Areas.SdkClientAccounts.Models.SdkClientAccountCreateArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


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
