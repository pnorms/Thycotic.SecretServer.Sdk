﻿//
// Type: Thycotic.SecretServer.Sdk.Infrastructure.Loggers.NoLogger
// Assembly: Thycotic.SecretServer.Sdk, Version=1.0.0.0, Culture=neutral, PublicKeyToken=53bfb0ae55ece166
//


using Microsoft.Extensions.Logging;
using System;

namespace Thycotic.SecretServer.Sdk.Infrastructure.Loggers
{
  public class NoLogger : ILogger
  {
    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
    {
    }

    public bool IsEnabled(LogLevel logLevel)
    {
      return false;
    }

    public IDisposable BeginScope<TState>(TState state)
    {
      return (IDisposable) null;
    }
  }
}
