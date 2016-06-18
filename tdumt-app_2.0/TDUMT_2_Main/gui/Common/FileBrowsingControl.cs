using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ModdingLibrary_2.fileformats.banks;
using TDUMT_2.Gui.Common.BrowseHandlers;

namespace TDUMT_2.Main.Gui.Common
{
    public partial class FileBrowsingControl : UserControl
    {
        #region Structures
        internal class DirectoryComboEntry
        {
            /// <summary>
            /// Level in hierarchy for indentation
            /// </summary>
            private int level;

            /// <summary>
            /// Label to display in list
            /// </summary>
            private readonly string label;

            public DirectoryComboEntry(string p) : this (p, -1)
            {}

            public DirectoryComboEntry(string p, int level) 
            {
                Info = new DirectoryInfo(p);
                this.level = level;


                    StringBuilder sb = new StringBuilder();
                    for (int i = 1; i <= level; i++)
                    {
                        sb.Append("  ");
                    }
                    sb.Append(Info.Name);

                    label = sb.ToString();    

            }

            public DirectoryComboEntry(string p, Environment.SpecialFolder spDir)
                : this(p)
            {
                switch (spDir)
                {
                    case Environment.SpecialFolder.MyDocuments:
                        label = "*My Documents*";
                        break;
                    case Environment.SpecialFolder.DesktopDirectory:
                        label = "*Desktop*";
                        break;
                    default:
                        label = spDir.ToString();
                        break;
                }
            }
            /// <summary>
            /// Directory information
            /// </summary>
            public DirectoryInfo Info {
                get;
                set;}

            /// <summary>
            /// Returns short name for display purpose
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return label;

            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// DisplayedFolder
        /// </summary>
        public string CurrentFolder { get; set; }

        /// <summary>
        /// The file list view
        /// </summary>
        public ListView FileListView
        {
            get { return fileListView; }
        }
        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public FileBrowsingControl()
        {
            InitializeComponent();


            
        }

        /// <summary>
        /// Displays contents of specified folder
        /// </summary>
        /// <param name="path"></param>
        public void DisplayFolder(string path)
        {
            // Path must exist !
            if (path != null && Directory.Exists(path))
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    _Refresh(path);
                    CurrentFolder = path;
                }
                catch (Exception e)
                {
                    MessageBox.Show(this, e.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }

        }

        /// <summary>
        /// Actualizes contents
        /// </summary>
        /// <param name="path"></param>
        private void _Refresh(string path)
        {
            // Contents list
            _RefreshFileView(path);

            // Path combobox
            pathComboBox.Text = path;
            _RefreshPathCombo(path);
        }

        /// <summary>
        /// Actualizes directories and files
        /// </summary>
        /// <param name="path"></param>
        private void _RefreshFileView(string path)
        {
            // Retrieves correct handler
            AbstractBrowseHandler handler = AbstractBrowseHandler.GetHandler(path);

            // Populates the file list
            try
            {
                ListViewItem[] items = handler.GetEntries(path).ToArray();
                fileListView.Items.Clear();
                fileListView.Items.AddRange(items);                
            }
            catch (NotImplementedException ex)
            {
                // LOG : Not applicable
                throw ex;
            }
        }

        /// <summary>
        /// Actualizes combo contents
        /// </summary>
        /// <param name="path"></param>
        private void _RefreshPathCombo(string path)
        {
            pathComboBox.Items.Clear();

            // Current hierarchy first
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            List<DirectoryComboEntry> hierarchy = new List<DirectoryComboEntry>();

            string[] pathItems = dirInfo.FullName.Split('\\');
            int level = 0;
            string currentPath = "";

            foreach (var pathItem in pathItems)
            {
                level++;
                currentPath += (pathItem + @"\\");

                DirectoryInfo di = new DirectoryInfo(currentPath);
                DirectoryComboEntry entry = new DirectoryComboEntry(di.FullName, level);

                pathComboBox.Items.Add(entry);
            }

            // TDU root
            pathComboBox.Items.Add(new DirectoryComboEntry(@"D:\Jeux\Test Drive Unlimited"));

            // System folders
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            pathComboBox.Items.Add(new DirectoryComboEntry(desktopPath, Environment.SpecialFolder.DesktopDirectory));
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            pathComboBox.Items.Add(new DirectoryComboEntry(docPath, Environment.SpecialFolder.MyDocuments));

            // Logical drives
            string[] drives = Environment.GetLogicalDrives();
            foreach (var drive in drives)
            {
                pathComboBox.Items.Add(new DirectoryComboEntry(drive));
            }

        }

        #region Events
        private void fileListView_DoubleClick(object sender, EventArgs e)
        {
            // Double click on a list item -> open it
            OpenSelectedEntry();
        }

        private void parentButton_Click(object sender, EventArgs e)
        {
            // Level-up!
            try
            {
                DirectoryInfo currentDir = new DirectoryInfo(CurrentFolder);
                DirectoryInfo parentDir = currentDir.Parent;

                if (parentDir != null && parentDir.Exists)
                {
                    _Refresh(parentDir.FullName);
                    CurrentFolder = parentDir.FullName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }

        }

        private void pathComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Displays selected entry
            DirectoryComboEntry selectedEntry = pathComboBox.SelectedItem as DirectoryComboEntry;

            if (selectedEntry != null)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    _RefreshFileView(selectedEntry.Info.FullName);
                    CurrentFolder = selectedEntry.Info.FullName;
                    pathComboBox.Text = CurrentFolder;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
#endregion

        #region Public methods
        /// <summary>
        /// Opens current entry in file list
        /// </summary>
        public void OpenSelectedEntry()
        {
            if (fileListView.SelectedItems.Count == 1)
            {
                
                Cursor = Cursors.WaitCursor;

                ListViewItem currentItem = fileListView.SelectedItems[0];
                Object tag = currentItem.Tag;

                try
                {
                    if (tag is FileSystemInfo)
                    {
                        // File or directory
                        string path = ((tag as FileSystemInfo).FullName);

                        try
                        {
                            _Refresh(path);
                            CurrentFolder = path;
                        }
                        catch (NotImplementedException ex)
                        {
                            // Not applicable -> entry will be opened with default assos
                            __SystemRun(path);
                        }
                    }
                    else if (tag is PackedFile)
                    {
                        // Packed file -> it must be extracted first
                        // Reloads BNK to get correct contents
                        Bnk parentBnk = new Bnk {Name = CurrentFolder};
                        parentBnk.Read();

                        PackedFile updatedPackedFile = parentBnk.GetPackedFile((tag as PackedFile).Id);
                        // TODO handle temporary folder
                        string path = @"T:\COMMUN\" + updatedPackedFile.Name;
                        Bnk.Extract(updatedPackedFile, path);

                        // Opens with default file associations for now
                        __SystemRun(path);
                    }
                }
 
                catch (Exception ex)
                {
                    MessageBox.Show(this, ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }

        }

        /// <summary>
        /// Copies selected entry to a location on disk
        /// </summary>
        public void CopySelectedEntryToLocation()
        {



        }
        #endregion

        #region Protected methods
        /// <summary>
        /// Utility method launching specified file as a new process
        /// </summary>
        /// <param name="fileName">File to run</param>
        protected static void __SystemRun(string fileName)
        {
            if (File.Exists(fileName))
            {
                ProcessStartInfo appliProcess = new ProcessStartInfo(fileName);
                Process.Start(appliProcess);
            }
        }
        #endregion

    }
}