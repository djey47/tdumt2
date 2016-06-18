using System;

namespace DjeLibrary_2.Support.Reports
{
    /// <summary>
    /// Represents a failure to be handled in application.
    /// </summary>
    public class ApplicationFailure : ApplicationException
    {
        #region Constants
        /// <summary>
        /// 
        /// </summary>
        private const string _APP_NAME_UNKNOWN = "unknown";
        #endregion
        /// <summary>
        /// Application name
        /// </summary>
        public string AppName
        { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="innerException"></param>
        public ApplicationFailure(string appName, Exception innerException) : base("Failure from application: " + appName, innerException)
        {
            AppName = appName;
        }

        /// <summary>
        /// 
        /// </summary>
        public ApplicationFailure() : this(_APP_NAME_UNKNOWN, null)
        {}
    }
}
