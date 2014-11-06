using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Logger
{
    /// <summary>
    /// Logger - A simple, extend-able, adjustable abstraction of log4net
    ///
    /// All configuration is handled in log4net, this class simply makes it easier to call, allows for customizing behavior, and loosens the coupling a bit.
    /// </summary>
    public static class Logger
    {
        // Private logger, not used at the moment
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static Logger()
        {
        }

        #region Public Actions (overload-apalooza)

        /// <summary>
        /// Logs the specified debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Debug(string message, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return DebugImpl(message, null, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified debug message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Debug(Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return DebugImpl(null, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified debug message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Debug(string message, Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return DebugImpl(message, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Error(string message, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return ErrorImpl(message, null, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified error message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Error(Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return ErrorImpl(null, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified error message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Error(string message, Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return ErrorImpl(message, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Fatal(string message, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return FatalImpl(message, null, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified fatal message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Fatal(Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return FatalImpl(null, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified fatal message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Fatal(string message, Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return FatalImpl(message, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified informational message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Info(string message, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return InfoImpl(message, null, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified informational message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Info(Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return InfoImpl(null, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified informational message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Info(string message, Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return InfoImpl(message, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Trace(string message, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return TraceImpl(message, null, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified trace message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Trace(Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return TraceImpl(null, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified trace message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Trace(string message, Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return TraceImpl(message, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Warn(string message, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return WarnImpl(message, null, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified warning message.
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Warn(Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return WarnImpl(null, exception, referenceId.Value, caller);
        }

        /// <summary>
        /// Logs the specified warning message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="exception">The exception.</param>
        /// <param name="caller">The caller.</param>
        /// <param name="referenceId">The reference identifier.</param>
        /// <returns></returns>
        public static Guid? Warn(string message, Exception exception, string caller = null, Guid? referenceId = null)
        {
            if (string.IsNullOrWhiteSpace(caller))
            {
                // Required for .NET 4.0 support, CallerMemberNameAttribute is available in .NET 4.5
                StackFrame frame = new StackFrame(1);
                var method = frame.GetMethod();
                var type = method.DeclaringType.FullName;
                var name = method.Name;

                caller = string.Format("{0}.{1}", type, name);
            }

            if (referenceId == null) referenceId = Guid.NewGuid();

            return WarnImpl(message, exception, referenceId.Value, caller);
        }

        #endregion

        #region Private Actions

        private static Guid? DebugImpl(string message, Exception exception, Guid referenceId, string caller)
        {
            // Grab log4net
            var logger = log4net.LogManager.GetLogger(caller);

            // Skip if level isn't enabled in configuration
            if (!logger.IsDebugEnabled) return null;

            // Make sure message is populated, use exception if needed, fall-back on hard-coded generic error
            if (string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    message = GetMessageFromException(exception);
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Unknown Error Occurred - no message or exception was passed to Logger";
                }
            }

            // Combine message with caller and reference id
            var logMessage = BuildLogMessage(message, referenceId, caller);

            // Call appropriate log4net method
            if (exception == null)
            {
                logger.Debug(logMessage);
            }
            else
            {
                logger.Debug(logMessage, exception);
            }

            // Native diagnostics
            var diagMessage = BuildDebugMessage(message, referenceId, caller);
            System.Diagnostics.Debug.WriteLine(diagMessage);

            // Return the ReferenceId
            return referenceId;
        }

        private static Guid? ErrorImpl(string message, Exception exception, Guid referenceId, string caller)
        {
            // Grab log4net
            var logger = log4net.LogManager.GetLogger(caller);

            // Skip if level isn't enabled in configuration
            if (!logger.IsErrorEnabled) return null;

            // Make sure message is populated, use exception if needed, fall-back on hard-coded generic error
            if (string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    message = GetMessageFromException(exception);
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Unknown Error Occurred - no message or exception was passed to Logger";
                }
            }

            // Combine message with caller and reference id
            var logMessage = BuildLogMessage(message, referenceId, caller);

            // Call appropriate log4net method
            if (exception == null)
            {
                logger.Error(logMessage);
            }
            else
            {
                logger.Error(logMessage, exception);
            }

            // Native diagnostics
            var diagMessage = BuildDebugMessage(message, referenceId, caller);
            System.Diagnostics.Debug.WriteLine(diagMessage);

            // Return the ReferenceId
            return referenceId;
        }

        private static Guid? FatalImpl(string message, Exception exception, Guid referenceId, string caller)
        {
            // Grab log4net
            var logger = log4net.LogManager.GetLogger(caller);

            // Skip if level isn't enabled in configuration
            if (!logger.IsFatalEnabled) return null;

            // Make sure message is populated, use exception if needed, fall-back on hard-coded generic error
            if (string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    message = GetMessageFromException(exception);
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Unknown Error Occurred - no message or exception was passed to Logger";
                }
            }

            // Combine message with caller and reference id
            var logMessage = BuildLogMessage(message, referenceId, caller);

            // Call appropriate log4net method
            if (exception == null)
            {
                logger.Fatal(logMessage);
            }
            else
            {
                logger.Fatal(logMessage, exception);
            }

            // Native diagnostics
            var diagMessage = BuildDebugMessage(message, referenceId, caller);
            System.Diagnostics.Debug.WriteLine(diagMessage);

            // Return the ReferenceId
            return referenceId;
        }

        private static Guid? InfoImpl(string message, Exception exception, Guid referenceId, string caller)
        {
            // Grab log4net
            var logger = log4net.LogManager.GetLogger(caller);

            // Skip if level isn't enabled in configuration
            if (!logger.IsInfoEnabled) return null;

            // Make sure message is populated, use exception if needed, fall-back on hard-coded generic error
            if (string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    message = GetMessageFromException(exception);
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Unknown Error Occurred - no message or exception was passed to Logger";
                }
            }

            // Combine message with caller and reference id
            var logMessage = BuildLogMessage(message, referenceId, caller);

            // Call appropriate log4net method
            if (exception == null)
            {
                logger.Info(logMessage);
            }
            else
            {
                logger.Info(logMessage, exception);
            }

            // Native diagnostics
            var diagMessage = BuildDebugMessage(message, referenceId, caller);
            System.Diagnostics.Debug.WriteLine(diagMessage);

            // Return the ReferenceId
            return referenceId;
        }

        private static Guid? TraceImpl(string message, Exception exception, Guid referenceId, string caller)
        {
            // Grab log4net
            var logger = log4net.LogManager.GetLogger(caller);

            // Make sure message is populated, use exception if needed, fall-back on hard-coded generic error
            if (string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    message = GetMessageFromException(exception);
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Unknown Error Occurred - no message or exception was passed to Logger";
                }
            }

            // Native diagnostics
            var diagMessage = BuildTraceMessage(message, referenceId, caller);
            System.Diagnostics.Trace.WriteLine(diagMessage);

            // Return the ReferenceId
            return referenceId;
        }

        private static Guid? WarnImpl(string message, Exception exception, Guid referenceId, string caller)
        {
            // Grab log4net
            var logger = log4net.LogManager.GetLogger(caller);

            // Skip if level isn't enabled in configuration
            if (!logger.IsWarnEnabled) return null;

            // Make sure message is populated, use exception if needed, fall-back on hard-coded generic error
            if (string.IsNullOrWhiteSpace(message))
            {
                if (exception != null)
                {
                    message = GetMessageFromException(exception);
                }

                if (string.IsNullOrWhiteSpace(message))
                {
                    message = "Unknown Error Occurred - no message or exception was passed to Logger";
                }
            }

            // Combine message with caller and reference id
            var logMessage = BuildLogMessage(message, referenceId, caller);

            // Call appropriate log4net method
            if (exception == null)
            {
                logger.Warn(logMessage);
            }
            else
            {
                logger.Warn(logMessage, exception);
            }

            // Native diagnostics
            var diagMessage = BuildDebugMessage(message, referenceId, caller);
            System.Diagnostics.Debug.WriteLine(diagMessage);

            // Return the ReferenceId
            return referenceId;
        }

        #endregion

        #region Private Helpers

        private static string BuildLogMessage(string message, Guid referenceId, string caller)
        {
            return string.Format("{0} --- {1} --- {2}", referenceId, caller, message);
        }

        private static string BuildDebugMessage(string message, Guid referenceId, string caller)
        {
            return string.Format("Logger: (DEBUG) {0} --- {1} --- {2} -- {3}", DateTime.Now, referenceId, caller, message);
        }

        private static string BuildTraceMessage(string message, Guid referenceId, string caller)
        {
            return string.Format("Logger: (TRACE) {0} --- {1} --- {2} -- {3}", DateTime.Now, referenceId, caller, message);
        }

        private static string GetMessageFromException(Exception exception)
        {
            // Get exception message
            var r = exception.Message;

            // Inner Exception, only one level deep
            var innerException = exception.InnerException;
            if (innerException != null)
            {
                r = r + " --- " + innerException.Message;
            }

            // Remove newline, return, and tab control characters
            if (r.Contains('\r')) r.Replace('\r'.ToString(), string.Empty);
            if (r.Contains('\n')) r.Replace('\n'.ToString(), string.Empty);
            if (r.Contains('\t')) r.Replace('\t'.ToString(), string.Empty);

            return r;
        }

        #endregion
    }
}
