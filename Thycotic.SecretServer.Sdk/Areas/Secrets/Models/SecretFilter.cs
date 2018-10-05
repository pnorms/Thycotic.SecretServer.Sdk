//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretFilter
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret filter options")]
  public class SecretFilter
  {
    [Description("Search text")]
    public string SearchText { get; set; }

    [Description("Field to search")]
    public string SearchField { get; set; }

    [Description("Whether to include inactive secrets in results")]
    public bool IncludeInactive { get; set; }

    [Description("Whether to include restricted secrets in results")]
    public bool IncludeRestricted { get; set; }

    [Description("Return only secrets matching a certain template")]
    public int? SecretTemplateId { get; set; }

    [Description("Return only secrets within a certain folder")]
    public int? FolderId { get; set; }

    [Description("Whether to include secrets in subfolders of the specified folder")]
    public bool IncludeSubFolders { get; set; }

    [Description("Return only secrets with a certain heartbeat status")]
    public Thycotic.SecretServer.Sdk.Areas.Secrets.Models.HeartbeatStatus? HeartbeatStatus { get; set; }

    [Description("Return only secrets within a certain site")]
    public int? SiteId { get; set; }
  }
}
