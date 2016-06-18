using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using DjeLibrary_2.Gui.WinForms;

namespace DjeLibrary_2.Gui.WinForms
{
    /// <summary>
    /// Generic dialog allowing to gather details over an application failure.
    /// </summary>
    public partial class FailureReportDialog : Form
    {
        #region Messages
        /// <summary>
        /// Format string for failure label
        /// </summary>
        private const string _FORMAT_FAILURE_LABEL = "Sorry, {0} has failed. Here are the details:";
        #endregion

        #region Constants
        /// <summary>
        /// Format for stack file name
        /// </summary>
        private const string _FORMAT_STACK_FILE = @"{0}{1}{2}-{3:yyyy-MM-dd_hh-mm-ss}.txt";
        #endregion

        #region Properties
        /// <summary>
        /// Application name
        /// </summary>
        public string AppName { get; set; }
        #endregion
        /// <summary>
        /// Forbidden constructor
        /// </summary>
        private FailureReportDialog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Builds report dialog
        /// </summary>
        /// <param name="appName">Name of application where failure has happened</param>
        /// <param name="stackTrace"></param>
        public FailureReportDialog(string appName, string stackTrace) : this()
        {
            AppName = appName;
            stackTextBox.Text = stackTrace;
            failureLabel.Text = string.Format(_FORMAT_FAILURE_LABEL, appName);
        }

        #region Events
        private void copyButton_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(stackTextBox.Text);
            MsgBoxHelper.Instance.Info(this, "Details copied to clipboard.");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            // Writes contents into a file on user Desktop
            string targetFile = string.Format(_FORMAT_STACK_FILE,
                                              Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                                              Path.DirectorySeparatorChar,
                                              AppName,
                                              DateTime.Now);
            File.WriteAllText(targetFile, stackTextBox.Text, Encoding.UTF8);

            // Message
            MsgBoxHelper.Instance.Info(this, "Details copied to a file on desktop:\r\n" + targetFile);
        }
        #endregion
    }
}