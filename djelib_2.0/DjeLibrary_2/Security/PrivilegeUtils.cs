using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Security.Principal;
using System.Windows.Forms;
using log4net;

namespace DjeLibrary_2.Security
{
    /// <summary>
    /// Utility class giving access to rights management.
    /// </summary>
    public static class PrivilegeUtils
    {
        /// <summary>
        /// Internal logger
        /// </summary>
        private static readonly ILog _LOG = LogManager.GetLogger(typeof (PrivilegeUtils));

        #region Constants
        /// <summary>
        /// Verb to use when running as administrator
        /// </summary>
        private const string _VERB_RUN_AS_ADMIN = "runas";
        #endregion

        #region Properties
        /// <summary>
        /// Returns true if current user has administrator rights (=belongs to administrators group), else false
        /// </summary>
        public static bool Administrator
        {
            get
            {
                bool result = false;
                WindowsIdentity id = WindowsIdentity.GetCurrent();

                if (id != null)
                {
                    WindowsPrincipal p = new WindowsPrincipal(id);

                    result = p.IsInRole(WindowsBuiltInRole.Administrator);

                    _LOG.Debug("Admin rights? " + result);
                }
                return result;
            }
        }
        #endregion

        #region Public methods
        /// <summary>
        /// Restart current WinForms application with elevated privileges.
        /// </summary>
        public static void RestartElevated()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
                                             {
                                                 UseShellExecute = true,
                                                 WorkingDirectory = Environment.CurrentDirectory,
                                                 FileName = Application.ExecutablePath,
                                                 Verb = _VERB_RUN_AS_ADMIN
                                             };

            try
            {
                Process.Start(startInfo);
            }
            catch (Win32Exception ex)
            {
                _LOG.Error("Unable to restart application with admin privileges", ex);
                throw;
            }

            // Ends current application
            Application.Exit();
        }
        #endregion
    }
}