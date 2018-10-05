// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretStubFilter
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

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
