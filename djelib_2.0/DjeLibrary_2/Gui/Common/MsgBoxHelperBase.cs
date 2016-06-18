using System;
using System.Text;

namespace DjeLibrary_2.Gui.Common
{
    /// <summary>
    /// Parent class for helper over WinForms and WPF implementations
    /// </summary>
    public abstract class MsgBoxHelperBase
    {
        #region Constants
        /// <summary>
        /// Pattern used to separate exception and additional messages
        /// </summary>
        private const string _MESSAGE_SEPARATOR = "---";
        #endregion

        #region Properties
        /// <summary>
        /// Additional message to display on error message box
        /// </summary>
        public string AdditionalMessageOnError { get; set; }
        #endregion

        #region Protected methods
        public string _GenerateErrorMessage(string errorMessage)
        {
            StringBuilder sbMessage = new StringBuilder(errorMessage);

            if (!string.IsNullOrEmpty(AdditionalMessageOnError))
            {
                sbMessage.Append(Environment.NewLine);
                sbMessage.Append(_MESSAGE_SEPARATOR);
                sbMessage.Append(Environment.NewLine);
                sbMessage.Append(AdditionalMessageOnError);

                AdditionalMessageOnError = null;
            }

            return sbMessage.ToString();
        }
        #endregion
    }
}
