using System;
using System.Windows.Forms;
using ModdingLibrary_2.support;
using TDUMT_2.Gui.Common;
using TDUMT_2.Gui.Mod;
using TDUMT_2.Main;
using TDUMT_2.Main.Gui.Common;

namespace TDUMT_2.Gui
{
    /// <summary>
    /// Main form for TDUMT II
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Events
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // End
            Close();
        }

        private void wsPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initial display
            fileBrowsingControl1.DisplayFolder(Context.GameFolder);
            fileBrowsingControl2.DisplayFolder( @"\");

            // Status welcome message
            statusLabel.Text = GuiResources.browser_status_welcomeMessage;


        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new SettingsDialog().ShowDialog(this);
        }

        private void toOtherPaneToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }


        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileBrowsingControl activeControl = _GetCurrentBrowsingControl();
            
            try
            {
                activeControl.OpenSelectedEntry();    
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }

        private void toLocationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileBrowsingControl activeControl = _GetCurrentBrowsingControl();

            try
            {
                activeControl.CopySelectedEntryToLocation();
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
        }



        #endregion

        #region Private methods
        /// <summary>
        /// Returns current browsing control
        /// </summary>
        /// <returns></returns>
        private FileBrowsingControl _GetCurrentBrowsingControl()
        {
            if (fileBrowsingControl1.FileListView.Focused)
            {
                return fileBrowsingControl1;
            }
            if (fileBrowsingControl2.FileListView.Focused)
            {
                return fileBrowsingControl2;
            }
            return null;
        }
        #endregion




    }
}
