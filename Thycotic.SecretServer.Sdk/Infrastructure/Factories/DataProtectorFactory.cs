//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Factories.DataProtectorFactory
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Factories
{
  public class DataProtectorFactory
  {
    private const string Purpose = "thycotic-sdk-client";
    private const string KeyDirectory = ".thycotic";

    public static IDataProtector Create()
    {
      string homePath = DataProtectorFactory.GetHomePath();
      if (homePath == null)
        throw new ApplicationException("Could not find a valid home path environment variable.");
      return DataProtectionProvider.Create(new DirectoryInfo(Path.Combine(homePath, ".thycotic", "thycotic-sdk-client"))).CreateProtector("thycotic-sdk-client");
    }

    private static string GetHomePath()
    {
      List<string> source = new List<string>(3);
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        source.Add("LOCALAPPDATA");
      if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        source.AddRange((IEnumerable<string>) new string[3]
        {
          "HOME",
          "Home",
          "home"
        });
      return source.Select<string, string>(new Func<string, string>(Environment.GetEnvironmentVariable)).FirstOrDefault<string>((Func<string, bool>) (x => x != null));
    }
  }
}
