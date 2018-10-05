//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretUpdateArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret update options")]
  public class SecretUpdateArgs : SecretRestrictedArgs
  {
    [Required]
    [Range(1, 2147483647)]
    [Description("Secret ID. Must match ID in path")]
    public int Id { get; set; }

    [Required]
    [Description("Secret name")]
    public string Name { get; set; }

    [Description("Containing folder ID")]
    public int? FolderId { get; set; }

    [Description("Whether the secret is active")]
    public bool Active { get; set; }

    [Required]
    [Description("Secret data fields")]
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

    public int? SecretPolicyId { get; set; }

    public string AutoChangeNextPassword { get; set; }

    [Description("SSH key options")]
    public SshKeyArgs SshKeyArgs { get; set; }
  }
}
