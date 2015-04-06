using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

// ReSharper disable CheckNamespace

[assembly: XmlConfigurator(Watch = true)]

/// <summary>
/// Logger - A simple, extend-able, adjustable abstraction of log4net
/// All configuration is handled in log4net, this class simply makes it easier to call, allows for customizing behavior, and loosens the coupling a bit.
/// </summary>
public static class Logger
{
    #region Public API Surface (overload-apalooza)

    /// <summary>
    /// Logs the specified debug message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Debug(string message, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.DebugImpl(message, null, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified debug message.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Debug(Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.DebugImpl(null, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified debug message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Debug(string message, Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.DebugImpl(message, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified error message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Error(string message, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.ErrorImpl(message, null, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified error message.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Error(Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.ErrorImpl(null, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified error message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Error(string message, Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.ErrorImpl(message, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified fatal message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Fatal(string message, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.FatalImpl(message, null, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified fatal message.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Fatal(Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.FatalImpl(null, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified fatal message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Fatal(string message, Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.FatalImpl(message, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified informational message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Info(string message, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.InfoImpl(message, null, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified informational message.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Info(Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.InfoImpl(null, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified informational message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Info(string message, Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.InfoImpl(message, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified trace message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Trace(string message, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.TraceImpl(message, null, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified trace message.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Trace(Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.TraceImpl(null, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified trace message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Trace(string message, Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.TraceImpl(message, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified warning message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Warn(string message, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.WarnImpl(message, null, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified warning message.
    /// </summary>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Warn(Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method != null && method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.WarnImpl(null, exception, referenceId.Value, caller);
    }

    /// <summary>
    /// Logs the specified warning message.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="exception">The exception.</param>
    /// <param name="caller">The caller.</param>
    /// <param name="referenceId">The reference identifier.</param>
    /// <returns></returns>
    public static LoggerResult Warn(string message, Exception exception, string caller = null, Guid? referenceId = null)
    {
        if (string.IsNullOrWhiteSpace(caller))
        {
            // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
            var frame = new StackFrame(1);
            var method = frame.GetMethod();
            if (method != null && method.DeclaringType != null)
            {
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }
        }

        if (referenceId == null) referenceId = Guid.NewGuid();

        return Logger.WarnImpl(message, exception, referenceId.Value, caller);
    }

    #endregion

    #region Private Implementations

    private static LoggerResult DebugImpl(string message, Exception exception, Guid referenceId, string caller)
    {
        // Grab log4net
        var logger = LogManager.GetLogger(caller);

        // Skip if Log4Net is null
        if (logger == null) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Log4NetNull);

        // Skip if level isn't enabled
        if (!logger.IsDebugEnabled) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Threshold);

        // Build log message
        var logMessage = Logger.BuildLogMessage(message, referenceId, caller, exception);

        // Call appropriate log4net method
        if (exception == null)
        {
            logger.Debug(logMessage);
        }
        else
        {
            logger.Debug(logMessage, exception);
        }

        // Return the ReferenceId
        return LoggerResult.CreateLogged(referenceId);
    }

    private static LoggerResult ErrorImpl(string message, Exception exception, Guid referenceId, string caller)
    {
        // Grab log4net
        var logger = LogManager.GetLogger(caller);

        // Skip if Log4Net is null
        if (logger == null) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Log4NetNull);

        // Skip if level isn't enabled
        if (!logger.IsErrorEnabled) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Threshold);

        // Build log message
        var logMessage = Logger.BuildLogMessage(message, referenceId, caller, exception);

        // Call appropriate log4net method
        if (exception == null)
        {
            logger.Error(logMessage);
        }
        else
        {
            logger.Error(logMessage, exception);
        }

        // Return the ReferenceId
        return LoggerResult.CreateLogged(referenceId);
    }

    private static LoggerResult FatalImpl(string message, Exception exception, Guid referenceId, string caller)
    {
        // Grab log4net
        var logger = LogManager.GetLogger(caller);

        // Skip if Log4Net is null
        if (logger == null) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Log4NetNull);

        // Skip if level isn't enabled
        if (!logger.IsFatalEnabled) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Threshold);

        // Build log message
        var logMessage = Logger.BuildLogMessage(message, referenceId, caller, exception);

        // Call appropriate log4net method
        if (exception == null)
        {
            logger.Fatal(logMessage);
        }
        else
        {
            logger.Fatal(logMessage, exception);
        }

        // Return the ReferenceId
        return LoggerResult.CreateLogged(referenceId);
    }

    private static LoggerResult InfoImpl(string message, Exception exception, Guid referenceId, string caller)
    {
        // Grab log4net
        var logger = LogManager.GetLogger(caller);

        // Skip if Log4Net is null
        if (logger == null) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Log4NetNull);

        // Skip if level isn't enabled
        if (!logger.IsInfoEnabled) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Threshold);

        // Build log message
        var logMessage = Logger.BuildLogMessage(message, referenceId, caller, exception);

        // Call appropriate log4net method
        if (exception == null)
        {
            logger.Info(logMessage);
        }
        else
        {
            logger.Info(logMessage, exception);
        }

        // Return the ReferenceId
        return LoggerResult.CreateLogged(referenceId);
    }

    private static LoggerResult TraceImpl(string message, Exception exception, Guid referenceId, string caller)
    {
        // Native diagnostics
        var diagMessage = Logger.BuildTraceMessage(message, referenceId, caller, exception);
        System.Diagnostics.Trace.WriteLine(diagMessage);

        // Return the ReferenceId
        return LoggerResult.CreateLogged(referenceId);
    }

    private static LoggerResult WarnImpl(string message, Exception exception, Guid referenceId, string caller)
    {
        // Grab log4net
        var logger = LogManager.GetLogger(caller);

        // Skip if Log4Net is null
        if (logger == null) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Log4NetNull);

        // Skip if level isn't enabled
        if (!logger.IsWarnEnabled) return LoggerResult.CreateNotLogged(LoggerResultType.NotLogged_Threshold);

        // Build log message
        var logMessage = Logger.BuildLogMessage(message, referenceId, caller, exception);

        // Call appropriate log4net method
        if (exception == null)
        {
            logger.Warn(logMessage);
        }
        else
        {
            logger.Warn(logMessage, exception);
        }

        // Return the ReferenceId
        return LoggerResult.CreateLogged(referenceId);
    }

    #endregion

    #region Private Helpers

    private static string BuildLogMessage(string message, Guid referenceId, string caller, Exception exception = null)
    {
        var msg = message;

        if (string.IsNullOrWhiteSpace(message) && exception == null) msg = "No message was passed to Logger";
        if (string.IsNullOrWhiteSpace(message) && exception != null) msg = GetMessageFromException(exception);
        if (!string.IsNullOrWhiteSpace(message) && exception != null) msg = string.Format("{0} | {1}", msg, GetMessageFromException(exception));

        return string.Format("[{0}] [{1}] [{2}]", referenceId, caller, msg);
    }

    private static string BuildTraceMessage(string message, Guid referenceId, string caller, Exception exception = null)
    {
        var msg = message;

        if (string.IsNullOrWhiteSpace(message) && exception == null) msg = "No message was passed to Logger";
        if (string.IsNullOrWhiteSpace(message) && exception != null) msg = GetMessageFromException(exception);
        if (!string.IsNullOrWhiteSpace(message) && exception != null) msg = string.Format("{0} | {1}", msg, GetMessageFromException(exception));

        return string.Format("[LOGGER-TRACE] {0} --- {1} --- {2} --- {3}", DateTime.Now, referenceId, caller, msg);
    }

    private static string GetMessageFromException(Exception exception)
    {
        // Get exception message
        var r = exception.Message;

        // Remove newline, return, and tab control characters
        if (r.Contains("\r")) r = r.Replace("\r", string.Empty);
        if (r.Contains("\n")) r = r.Replace("\n", string.Empty);
        if (r.Contains("\r\n")) r = r.Replace("\r\n", string.Empty);
        if (r.Contains("\t")) r = r.Replace("\t", string.Empty);

        // Trim to 500 chars
        if (r.Length > 500) r = r.Substring(0, 500);

        return r;
    }

    #endregion
}

public enum LoggerResultType
{
    Null = 1,
    Logged = 2,
    NotLogged_Log4NetNull = 4,
    NotLogged_Threshold = 8,
}

public struct LoggerResult
{
    public bool Logged { get; private set; }
    public Guid ReferenceId { get; private set; }
    public LoggerResultType Type { get; private set; }

    public static LoggerResult CreateLogged(Guid referenceId)
    {
        return new LoggerResult
        {
            Logged = true,
            ReferenceId = referenceId,
            Type = LoggerResultType.Logged,
        };
    }

    public static LoggerResult CreateNotLogged(LoggerResultType type)
    {
        return new LoggerResult
        {
            Logged = false,
            ReferenceId = Guid.Empty,
            Type = type,
        };
    }
}
