using System;
using System.Windows;
using DjeLibrary_2.Gui.Common;

namespace DjeLibrary_2.Gui.WPF
{
    public class MsgBoxHelper : MsgBoxHelperBase
    {
        #region Properties
        public static MsgBoxHelper Instance
        {
            get 
            {
                if (_Instance == null)
                {
                    _Instance = new MsgBoxHelper();
                }                
                return _Instance; }
        }
        private static MsgBoxHelper _Instance;
        #endregion

        /// <summary>
        /// All the results values for Windows Forms dialogs
        /// </summary>
        public struct FormsDialogResult
        {
            public const string OK = "OK";
            public const string None = "None";
        }

        private MsgBoxHelper() { }

        /// <summary>
        /// Displays message of specified exception
        /// </summary>
        public void Error(Window owner, Exception ex)
        {
            string msg = _GenerateErrorMessage(ex.Message);

            if (owner == null)
            {
                MessageBox.Show(msg, global::System.Windows.Forms.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show(owner, msg, global::System.Windows.Forms.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Displays specified error message for a WPF application
        /// </summary>
        public void Error(System.Windows.Window owner, string message)
        {
            Exception ex = new Exception(message);
            Error(owner, ex);
        }

        /// <summary>
        /// Display simple message
        /// </summary>
        public void Info(Window owner, string infoMessage)
        {
            if (owner == null)
            {
                MessageBox.Show(infoMessage, global::System.Windows.Forms.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show(owner, infoMessage, global::System.Windows.Forms.Application.ProductName, MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
