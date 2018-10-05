//
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretStubFilter
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Options for generating a secret stub")]
  public class SecretStubFilter
  {
    [Required]
    [Description("Secret template ID")]
    public int SecretTemplateId { get; set; }

    [Description("Containing folder ID. May be null unless secrets are required to be in folders.")]
    public int FolderId { get; set; }
  }
}
