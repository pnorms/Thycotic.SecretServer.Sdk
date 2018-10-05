// Decompiled with JetBrains decompiler
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Extensions.ArgumentStringExtensions
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
// MVID: CC920DFA-063E-47A3-B841-9DC71BDC6EE3
// Assembly location: C:\Temp\Thycotic.SecretServer.Sdk.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Extensions
{
  public static class ArgumentStringExtensions
  {
    public static string[] SplitArgs(this string args)
    {
      char[] charArray = args.ToCharArray();
      bool flag = false;
      for (int index = 0; index < charArray.Length; ++index)
      {
        if (charArray[index] == '"')
          flag = !flag;
        if (!flag && charArray[index] == ' ')
          charArray[index] = '\n';
      }
      return ((IEnumerable<string>) new string(charArray).Split(new char[1]
      {
        '\n'
      }, StringSplitOptions.RemoveEmptyEntries)).Select<string, string>((Func<string, string>) (x => x.Trim('"', '\''))).ToArray<string>();
    }
  }
}
