// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretRestrictedArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Restricted secret update options")]
  public class SecretRestrictedArgs
  {
    [Description("Whether to include inactive secrets")]
    public bool IncludeInactive { get; set; }

    [Description("New secret password")]
    public string NewPassword { get; set; }

    [Description("Double Lock password")]
    public string DoubleLockPassword { get; set; }

    [Description("Associated ticket number")]
    public string TicketNumber { get; set; }

    [Description("Associated ticket system ID")]
    public int? TicketSystemId { get; set; }

    [Description("Comment for this operation")]
    public string Comment { get; set; }

    [Description("Check in the secret if it is checked out")]
    public bool ForceCheckIn { get; set; }
  }
}
