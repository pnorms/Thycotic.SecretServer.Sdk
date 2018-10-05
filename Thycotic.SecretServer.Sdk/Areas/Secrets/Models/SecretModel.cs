//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretModel
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret")]
  public class SecretModel
  {
    [Description("Secret ID")]
    public int Id { get; set; }

    [Description("Secret name")]
    public string Name { get; set; }

    [Description("Secret template ID")]
    public int SecretTemplateId { get; set; }

    [Description("Containing folder ID")]
    public int FolderId { get; set; }

    [Description("Whether the secret is active")]
    public bool Active { get; set; }

    [Description("Secret data fields")]
    public List<RestSecretItem> Items { get; set; }

    public int? LauncherConnectAsSecretId { get; set; }

    [Description("Minutes remaining in current checkout interval")]
    public int CheckOutMinutesRemaining { get; set; }

    [Description("Whether the secret is currently checked out")]
    public bool CheckedOut { get; set; }

    [Description("Name of user who has checked out the secret")]
    public string CheckOutUserDisplayName { get; set; }

    [Description("ID of user who has checked out the secret")]
    public int CheckOutUserId { get; set; }

    [Description("Whether the secret is restricted")]
    public bool IsRestricted { get; set; }

    [Description("Whether the secret is out of sync")]
    public bool IsOutOfSync { get; set; }

    [Description("Reason message if the secret is out of sync")]
    public string OutOfSyncReason { get; set; }

    public bool AutoChangeEnabled { get; set; }

    public string AutoChangeNextPassword { get; set; }

    public bool RequiresApprovalForAccess { get; set; }

    public bool RequiresComment { get; set; }

    [Description("Whether secret checkout is enabled")]
    public bool CheckOutEnabled { get; set; }

    [Description("Checkout interval, in minutes")]
    public int CheckOutIntervalMinutes { get; set; }

    public bool CheckOutChangePasswordEnabled { get; set; }

    public bool ProxyEnabled { get; set; }

    [Description("Whether session recording is enabled")]
    public bool SessionRecordingEnabled { get; set; }

    public bool RestrictSshCommands { get; set; }

    public bool AllowOwnersUnrestrictedSshCommands { get; set; }

    [Description("Whether double lock is enabled")]
    public bool IsDoubleLock { get; set; }

    public int DoubleLockId { get; set; }

    public bool EnableInheritPermissions { get; set; }

    public int PasswordTypeWebScriptId { get; set; }

    public int SiteId { get; set; }

    [Description("Whether the secret policy is inherited from the containing folder")]
    public bool EnableInheritSecretPolicy { get; set; }

    public int SecretPolicyId { get; set; }

    [Description("Current status of heartbeat")]
    public HeartbeatStatus LastHeartBeatStatus { get; set; }

    [Description("Time of last heartbeat check")]
    public DateTime LastHeartBeatCheck { get; set; }

    [Description("Number of failed password change attempts")]
    public int FailedPasswordChangeAttempts { get; set; }

    [Description("Time of most recent password change attempt")]
    public DateTime LastPasswordChangeAttempt { get; set; }

    [Description("Name of secret template")]
    public string SecretTemplateName { get; set; }

    public List<string> ResponseCodes { get; set; }

    public SecretModel()
    {
      this.Items = new List<RestSecretItem>();
      this.ResponseCodes = new List<string>();
    }
  }
}
