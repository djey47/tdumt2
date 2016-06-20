using System;
using System.IO;
using System.Windows.Forms;
using DjeLibrary_2.Gui.WinForms;
using DjeLibrary_2.Support.Reports;
using log4net;
using ModdingLibrary_2.fileformats.database;

namespace TDUMT_2.MiniXmb.Gui
{
    public partial class XmbForm : Form
    {
        #region Technical members
        /// <summary>
        /// Internal logger
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger(typeof(XmbForm));
        #endregion

        #region Enums
        private enum KnownSoundSamples 
        {
            BackFiring_0, BackFiring_1, BackFiring_2, BackFiring_3, DumpValve, EngineLoad_0, EngineLoad_1, EngineLoad_2, EngineLoad_3, EngineLoad_4, EngineStart, EngineUnload_0, EngineUnload_1, EngineUnload_2, EngineUnload_3, TransmissionLoad_0, TransmissionLoad_1, TransmissionUnload_0, TransmissionUnload_1, Turbo_0, Turbo_1
        };
        #endregion

        #region Members
        private Xmb.VolumeEntry _CurrentVolumeEntry;
        private Xmb _Data;
        #endregion

        public XmbForm()
        {
            InitializeComponent();
            _InitializeContents();
        }

        /// <summary>
        /// Initializes form contents
        /// </summary>
        private void _InitializeContents()
        {
            // Known values for XMB samples
            sampleComboBox.Items.AddRange(Enum.GetNames(typeof(KnownSoundSamples)));

            // File info
            _UpdateXmbInfo();
            _UpdateVolumeInfo();
        }

        /// <summary>
        /// Loads provided data file
        /// </summary>
        /// <param name="filename"></param>
        private void _LoadXmb(string filename)
        {
            _Data = new Xmb { Name = filename };
            _Data.Read();
        }

        /// <summary>
        /// Updates XMB info label
        /// </summary>
        private void _UpdateXmbInfo()
        {
            const string defaultLabel = "Please load a TDU2 XMetadataBank file...";
            const string labelFormat = "{0} - {1} bytes - {2}";

            if (_Data == null)
            {
                xmbFileInfoLbl.Text = defaultLabel;
            }
            else
            {
                FileInfo fi = new FileInfo(_Data.Name);
                xmbFileInfoLbl.Text = string.Format(labelFormat, fi.Name, fi.Length, fi.LastWriteTime);
            }
        }

        /// <summary>
        /// Updates instructions info label
        /// </summary>
        private void _UpdateInstructions()
        {
            const string defaultLabel = "";
            const string labelInstructionSample = "Please type a sample name or select in list then hit 'Search' button.";
            const string labelInstructionChange = "Please make changes for current sample then hit 'Save' button.";

            if (_Data == null)
            {
                instructionsLbl.Text = defaultLabel;
            }
            else
            {
                if (_CurrentVolumeEntry.sampleName == null)
                {
                    instructionsLbl.Text = labelInstructionSample;
                }
                else
                {
                    instructionsLbl.Text = labelInstructionChange;
                }
            }
        }

        private void _UpdateVolumeInfo()
        {
            if (_CurrentVolumeEntry.sampleName != null)
            {
                inVolumeTxt.Text = _CurrentVolumeEntry.inVolume.ToString("F");
                outVolumeTxt.Text = _CurrentVolumeEntry.outVolume.ToString("F");
            }
        }

        #region Events
        private void fileBrowseBtn_Click(object sender, EventArgs e)
        {
            // Should not crash
            openFileDlg.Filter = "XMB files (*.xmb)|*.xmb";
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
                    throw new Exception("A Xmb file is required.");
                }

                Cursor = Cursors.WaitCursor;

                // File loading
                _CurrentVolumeEntry = new Xmb.VolumeEntry();
                _LoadXmb(fileTxt.Text);

                // Updates info labels
                _UpdateXmbInfo();
                _UpdateInstructions();
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

        private void revertBtn_Click(object sender, EventArgs e)
        {
            if (_Data != null)
            {
                _UpdateVolumeInfo();
            }
        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            // About box
            const string d = "2013";
            const string i = "Let's unbin it!";
            const string credits = "Thanks to...\r\nForgotten ones :)";
            AboutBox target = new AboutBox
            {
                CustomDate = d,
                CustomInformation = i,
                CustomMessage = credits,
                CustomImage = GuiResources.product
            };

            target.ShowDialog(this);
        }

        private void sampleSearchBtn_Click(object sender, EventArgs e)
        {
            if (_Data != null)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    _CurrentVolumeEntry = _Data.GetVolumeForSample(sampleComboBox.Text);
                    _UpdateInstructions();
                    _UpdateVolumeInfo();
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.Instance.AdditionalMessageOnError="This sample is not supported by current Xmb file.";
                    MsgBoxHelper.Instance.Error(this, ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
        #endregion

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (_Data != null && _CurrentVolumeEntry.sampleName != null)
            {
                try
                {
                    Cursor = Cursors.WaitCursor;

                    _CurrentVolumeEntry.inVolume = float.Parse(inVolumeTxt.Text);
                    _CurrentVolumeEntry.outVolume = float.Parse(outVolumeTxt.Text);

                    _Data.SetVolumeForSample(_CurrentVolumeEntry);
                    _Data.Save();

                    _UpdateXmbInfo();

                    MsgBoxHelper.Instance.Info(this, "Changes were applied succesfully.");
                }
                catch (FormatException ex)
                {
                    MsgBoxHelper.Instance.AdditionalMessageOnError = "Make sure entered values are valid numbers.";
                    MsgBoxHelper.Instance.Error(this, ex);
                }
                catch (Exception ex)
                {
                    MsgBoxHelper.Instance.AdditionalMessageOnError = "Make sure current Xmb file is not write protected.";
                    MsgBoxHelper.Instance.Error(this, ex);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }
            }
        }
    }
}
