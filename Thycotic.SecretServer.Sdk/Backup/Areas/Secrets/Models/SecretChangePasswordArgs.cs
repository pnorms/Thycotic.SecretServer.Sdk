﻿// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Areas.Secrets.Models.SecretChangePasswordArgs
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System.ComponentModel;

namespace Thycotic.SecretServer.Sdk.Areas.Secrets.Models
{
  [Description("Secret password change options")]
  public class SecretChangePasswordArgs
  {
    [Description("Options for rotating SSH keys")]
    public RotateSshKeyArgs SshKeyArgs { get; set; }
  }
}
