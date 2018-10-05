//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretSummary
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret summary")]
  public class SecretSummary
  {
    [Description("Secret ID")]
    public int Id { get; set; }

    [Description("Secret name")]
    public string Name { get; set; }

    [Description("Secret template ID")]
    public int SecretTemplateId { get; set; }

    [Description("Name of secret template")]
    public string SecretTemplateName { get; set; }

    [Description("Containing folder ID")]
    public int FolderId { get; set; }

    public int SiteId { get; set; }

    [Description("Whether the secret is active")]
    public bool Active { get; set; }

    [Description("Whether the secret is currently checked out")]
    public bool CheckedOut { get; set; }

    [Description("Whether the secret is restricted")]
    public bool IsRestricted { get; set; }

    [Description("Whether the secret is out of sync")]
    public bool IsOutOfSync { get; set; }

    [Description("Reason message if the secret is out of sync")]
    public string OutOfSyncReason { get; set; }

    [Description("Current status of heartbeat")]
    public HeartbeatStatus LastHeartBeatStatus { get; set; }

    [Description("Time of most recent password change attempt")]
    public DateTime? LastPasswordChangeAttempt { get; set; }

    public List<string> ResponseCodes { get; set; }
  }
}
