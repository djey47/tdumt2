using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using DjeLibrary_2.Forms.Dialogs;
using DjeLibrary_2.Support.Reports;
using log4net;
using ModdingLibrary_2.fileformats.banks;

namespace TDUMT_2.MiniBnkManager.Gui
{
    public partial class BnkForm : Form
    {
        #region Constants
        /// <summary>
        /// Directory level to start when creating folders
        /// </summary>
        private const int _DIRECTORY_LVL = 5;
        #endregion

        #region Members
        /// <summary>
        /// Current BNK
        /// </summary>
        private Bnk _Bank;

        /// <summary>
        /// Internal logger
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger(typeof(BnkForm));
        #endregion

        public BnkForm()
        {
            InitializeComponent();
            _InitializeContents();
        }

        /// <summary>
        /// Initializes form contents
        /// </summary>
        private void _InitializeContents()
        {
            // Default work directory
            wDirTxt.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\work";

            // File info
            _UpdateBnkInfo();
            _UpdatePackedInfo();
        }

        #region Events
        private void fileBrowseBtn_Click(object sender, EventArgs e)
        {
            // Should not crash
            openFileDlg.Filter = "TDU banks (*.bnk)|*.bnk";
            DialogResult dr = openFileDlg.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                fileTxt.Text = openFileDlg.FileName;
            }
        }

        private void loadBtn_Click(object sender, EventArgs ea)
        {
            try
            {
                if (string.IsNullOrEmpty(fileTxt.Text))
                {
                    throw new Exception("A Bnk file is required.");
                }

                Cursor = Cursors.WaitCursor;

                // File loading
                _LoadBnk(fileTxt.Text);

                // Updates bnk contents
                _UpdateList();

                // Updates info labels
                _UpdateBnkInfo();
                _UpdatePackedInfo();
            } 
            catch (Exception e)
            {
                _Log.Error(FailureHandler.GetStackTrace(e));
                MessageBox.Show(this, e.Message);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void dirBrowseBtn_Click(object sender, EventArgs e)
        {
            // Should not crash
            folderBrowserDlg.Description = "Select a directory to work with unpacked files...";
            DialogResult dr = folderBrowserDlg.ShowDialog(this);

            if (dr == DialogResult.OK)
            {
                wDirTxt.Text = folderBrowserDlg.SelectedPath;
            }
        }

        private void openDirBtn_Click(object sender, EventArgs ea)
        {
            if (!string.IsNullOrEmpty(wDirTxt.Text))
            {
                try
                {
                    Process.Start(wDirTxt.Text);
                }
                catch (Exception e)
                {
                    _Log.Error(FailureHandler.GetStackTrace(e));
                    MessageBox.Show(this, e.Message);
                }
            }
        }

        private void repackBtn_Click(object sender, EventArgs ea)
        {
            if (_Bank != null)
            {
                folderBrowserDlg.Description = "Select a directory to repack...";

                DialogResult dr = folderBrowserDlg.ShowDialog(this);

                if (dr == DialogResult.OK)
                {
                    string bnkDir = folderBrowserDlg.SelectedPath;
                    string[] splittedPath = bnkDir.Split('\\');
                    string bnkDefaultName = splittedPath[splittedPath.Length - 1];

                    // Target BNK selection
                    saveFileDialog.Filter = "TDU banks (*.bnk)|*.bnk";
                    saveFileDialog.Title = "Repack to BNK file...";
                    saveFileDialog.FileName = bnkDefaultName;

                    dr = saveFileDialog.ShowDialog(this);

                    if (dr == DialogResult.OK)
                    {
                        try
                        {
                            Cursor = Cursors.WaitCursor;

                            // Updates Bnk contents
                            _Bank.Repack(bnkDir);
                            // Commit to disk
                            _Bank.SaveAs(saveFileDialog.FileName);
                            // Reloads current file
                            _Bank.Read();

                            MessageBox.Show(this, "Repack Succeeded!");
                        }
                        catch (Exception e)
                        {
                            _Log.Error(FailureHandler.GetStackTrace(e));
                            MessageBox.Show(this, e.Message);
                        }
                        finally
                        {
                            Cursor = Cursors.Default;
                        }
                    }
                }
            }
        }

        private void extractAllButton_Click(object sender, EventArgs e)
        {
            if (_Bank != null)
            {
                try
                {
                    // All items selected
                    contentsLst.SelectedIndices.Clear();

                    for (int i = 0; i < contentsLst.Items.Count; i++)
                    {
                        contentsLst.SelectedIndices.Add(i);
                    }

                    _ExtractSelectedFiles();

                    MessageBox.Show(this, "Unpack Everything Succeeded!");
                }
                catch (Exception ex)
                {
                    _Log.Error(FailureHandler.GetStackTrace(ex));
                    MessageBox.Show(this, ex.Message);
                }
            }

        }

        private void contentsLst_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void contentsLst_DragDrop(object sender, DragEventArgs e)
        {
            // Extract the data from the DataObject-Container into a string list
            string[] fileList = (string[])e.Data.GetData(DataFormats.FileDrop, false);

            // Loads the first item
            if (fileList.Length == 1)
            {
                fileTxt.Text = fileList[0];
                loadBtn_Click(sender, new EventArgs());
            }
        }

        private void contentsLst_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Another packed file has been selected
            _UpdatePackedInfo();
        }

        private void extractBtn_Click(object sender, EventArgs ea)
        {
            if (_Bank != null)
            {
                try
                {
                    if (contentsLst.SelectedIndices.Count == 0)
                    {
                        throw new Exception("At least 1 packed file must be selected for extraction.");
                    }

                    _ExtractSelectedFiles();


                    MessageBox.Show(this, "Unpack Succeeded!");
                }
                catch (Exception e)
                {
                    _Log.Error(FailureHandler.GetStackTrace(e));
                    MessageBox.Show(this, e.Message);
                }
            }
        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            // About box
            const string d = "2011";
            const string i = "Let's unbin it!";
            const string credits = "Thanks to...\r\nRollingtheboy - Knyazev\r\n+TDU Modders invested in beta testing:\r\ntomsolo Tool831 wagnerpsc Xarlith jorge Minime891 reventon09 Speeder thunderhawk17382 Beurky keyser92 Knyazev kristiannn Opelos_HUN MRick\r\n+Forgotten ones :)";
            AboutBox target = new AboutBox
            {
                CustomDate = d,
                CustomInformation = i,
                CustomMessage = credits,
                CustomImage = GuiResources.product
            };

            target.ShowDialog(this);
        }

        private void dumpButton_Click(object sender, EventArgs e)
        {
            if(_Bank != null)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    _Bank.Dump();
                    MessageBox.Show(this, "BNK now dumped. Have a look at corresponding log file (DjeLib-dump.log).");
                }
                catch (Exception ex)
                {
                    _Log.Error(FailureHandler.GetStackTrace(ex));
                    MessageBox.Show(this, ex.Message);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Updates list of packed list
        /// </summary>
        private void _UpdateList()
        {
            if (_Bank != null)
            {
                contentsLst.Items.Clear();

                foreach(PackedFile f in _Bank.PackedFiles)
                {
                    contentsLst.Items.Add(f.Name);
                }  
            }
        }

        /// <summary>
        /// Updates BNK info label
        /// </summary>
        private void _UpdateBnkInfo()
        {
            const string defaultLabel = "Please load a TDU/TDU2 bnk file...";
            const string labelFormat = "[{0}] {1} : {2} packed file(s) - {3} bytes";

            if (_Bank != null)
            {
                FileInfo fi = new FileInfo(_Bank.Name);

                bnkFileInfoLbl.Text = string.Format(labelFormat, _Bank.Version, fi.Name, _Bank.PackedFiles.Count, fi.Length);
            }
            else
            {
                bnkFileInfoLbl.Text = defaultLabel;
            }
        }

        /// <summary>
        /// Updates packed file info label
        /// </summary>
        private void _UpdatePackedInfo()
        {
            const string defaultLabel = "Please select a single packed file...";
            const string labelFormat = "{0}: {1} bytes";

            if (_Bank != null && contentsLst.SelectedItems.Count == 1)
            {

                PackedFile pf = _Bank.GetPackedFile((uint)contentsLst.SelectedIndex);
                packedFileInfoLbl.Text = string.Format(labelFormat, pf.Name, pf.Size);
            }
            else
            {
                packedFileInfoLbl.Text = defaultLabel;
            }
        }

        /// <summary>
        /// Loads specified bank file
        /// </summary>
        /// <param name="filename"></param>
        private void _LoadBnk(string filename)
        {
            _Bank = new Bnk {Name = filename};
            _Bank.Read();
        }

        /// <summary>
        /// Extracts selected packed files in
        /// </summary>
        private void _ExtractSelectedFiles()
        {           
            string wd = wDirTxt.Text;

            if (string.IsNullOrEmpty(wd))
            {
                throw new Exception("A valid work directory is required.");
            }

            // Creates directory for current BNK
            FileInfo fi = new FileInfo(_Bank.Name);
            wd += (@"\" + fi.Name);

            if(!Directory.Exists(wd))
            {
                Directory.CreateDirectory(wd);
            }

            // Parses file tree and creates files if necessary
            _ParseTree(_Bank.PackedRoot, 0, wd);
        }

        /// <summary>
        /// Recursive method to create file hierarchy on disk
        /// </summary>
        /// <param name="packedEntry"></param>
        /// <param name="lvl"></param>
        /// <param name="currentPath"></param>
        private void _ParseTree(PackedFolder packedEntry, int lvl, string currentPath)
        {
            if (packedEntry.GetType() == typeof(PackedFile))
            {
                // Extracts file
                PackedFile pf = packedEntry as PackedFile;

                if (pf != null)
                {
                    // Has it been selected ?
                    if(contentsLst.SelectedIndices.Contains((int)pf.Id))
                    {
                        string targetFilename = (currentPath + @"\" + pf.Name);

                        Bnk.Extract(pf, targetFilename);
                    }
                }
            }
            else
            {
                // Creates folder only when starting from interesting level, does not create extension directories
                if (lvl >= _DIRECTORY_LVL && !packedEntry.Name.StartsWith("."))
                {
                    currentPath += (@"\" + packedEntry.Name);
                    
                    if (!Directory.Exists(currentPath))
                    {
                        Directory.CreateDirectory(currentPath);
                    }
                }

                // Children
                foreach (PackedFolder child in packedEntry.Children)
                {
                    _ParseTree(child, lvl + 1, currentPath);
                }
            }
        }
        #endregion
    }
}