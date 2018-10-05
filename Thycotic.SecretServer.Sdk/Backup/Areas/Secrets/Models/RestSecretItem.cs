// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.RestSecretItem
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret data field item")]
  public class RestSecretItem
  {
    public int? ItemId { get; set; }

    [Description("File attachment ID (used for file attachments)")]
    public int? FileAttachmentId { get; set; }

    [Description("File name (used for file attachments)")]
    public string Filename { get; set; }

    [Description("Item value")]
    public string ItemValue { get; set; }

    [Description("Field ID")]
    public int? FieldId { get; set; }

    [Description("Field name")]
    public string FieldName { get; set; }

    [Description("Field slug")]
    public string Slug { get; set; }

    [Description("Field description")]
    public string FieldDescription { get; set; }

    [Description("Whether the field is a file attachment")]
    public bool IsFile { get; set; }

    [Description("Whether the field is notes")]
    public bool IsNotes { get; set; }

    [Description("Whether the field is a password")]
    public bool IsPassword { get; set; }
  }
}
