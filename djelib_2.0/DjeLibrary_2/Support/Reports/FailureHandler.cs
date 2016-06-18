using System;
using System.Text;
using DjeLibrary_2.Forms.Dialogs;
using DjeLibrary_2.Gui.WinForms;
using log4net;

namespace DjeLibrary_2.Support.Reports
{
    /// <summary>
    /// Utility class handling failures in application.
    /// </summary>
    public static class FailureHandler
    {
        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof (FailureHandler));

        /// <summary>
        /// General handling (log+report to send).
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="ex"></param>
        public static void Handle(string appName, Exception ex)
        {
            // Embeds the exception into an application failure
            ApplicationFailure fail = new ApplicationFailure(appName, ex);

            // Writes complete stack trace in log
            if (_log.IsDebugEnabled)
            {
                string completeStackTrace = GetStackTrace(fail);
                _log.Debug(completeStackTrace);

                // Displays report dialog
                FailureReportDialog dlg = new FailureReportDialog(fail.AppName, completeStackTrace);
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Returns complete exception message and stack strace, including inner exceptions.
        /// </summary>
        /// <param name="ex">exception to display</param>
        /// <returns></returns>
        public static string GetStackTrace(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            _FillStackTrace(sb, ex);
            return sb.ToString();
        }

        /// <summary>
        /// Recursive method returning exception message and stack trace, with inner exceptions if any
        /// </summary>
        /// <param name="sb">Required</param>
        /// <param name="ex"></param>
        private static void _FillStackTrace(StringBuilder sb, Exception ex)
        {
            if (sb != null && ex != null)
            {
                sb.Append(">>");
                sb.AppendLine(ex.Message);

                if (!string.IsNullOrEmpty(ex.StackTrace))
                {
                    sb.AppendLine(ex.StackTrace);
                }

                _FillStackTrace(sb, ex.InnerException);
            }
        }
    }
}
