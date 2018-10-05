// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretCreateArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret create options")]
  public class SecretCreateArgs
  {
    [Required]
    [Description("Secret name")]
    public string Name { get; set; }

    [Description("Secret folder ID. May be null unless secrets are required to be in folders.")]
    public int? FolderId { get; set; }

    [Required]
    [Range(1, 2147483647)]
    [Description("Secret template ID")]
    public int SecretTemplateId { get; set; }

    [Required]
    [Description("Secret fields")]
    public List<RestSecretItem> Items { get; set; }

    public int? LauncherConnectAsSecretId { get; set; }

    public bool AutoChangeEnabled { get; set; }

    public bool RequiresComment { get; set; }

    [Description("Whether secret checkout is enabled")]
    public bool CheckOutEnabled { get; set; }

    [Description("Checkout interval, in minutes")]
    public int? CheckOutIntervalMinutes { get; set; }

    public bool CheckOutChangePasswordEnabled { get; set; }

    public bool ProxyEnabled { get; set; }

    [Description("Whether session recording is enabled")]
    public bool SessionRecordingEnabled { get; set; }

    public int? PasswordTypeWebScriptId { get; set; }

    [Range(1, 2147483647)]
    public int SiteId { get; set; }

    [Description("Whether the secret policy is inherited from the containing folder")]
    public bool EnableInheritSecretPolicy { get; set; }

    [Description("Secret policy ID")]
    public int? SecretPolicyId { get; set; }

    [Description("SSH key options")]
    public SshKeyArgs SshKeyArgs { get; set; }
  }
}
