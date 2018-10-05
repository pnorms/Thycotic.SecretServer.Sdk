// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretItemUpdateArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret field update options")]
  public class SecretItemUpdateArgs : SecretRestrictedArgs
  {
    [Description("Value of the secret field")]
    public string Value { get; set; }

    [Description("File name (used for file attachment fields)")]
    public string FileName { get; set; }

    [Description("Binary file data (used for file attachment fields)")]
    public byte[] FileAttachment { get; set; }
  }
}
