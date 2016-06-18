using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using TDUMT_2.Gui.Common.BrowseHandlers;
using TDUMT_2.Main.Properties;

namespace TDUMT_2.Main.Gui.Common.BrowseHandlers
{
    /// <summary>
    /// Enables to browse into file system folders
    /// </summary>
    class DirectoryBrowseHandler:AbstractBrowseHandler
    {
        #region Overrides of AbstractBrowseHandler

        /// <summary>
        /// To redefine: list of accepted extensions
        /// </summary>
        public override List<string> DisplayedExtensions
        {
            get
            {
                // Get displayed extensions from resources
                string rawList = Resources.browser_system_displayedExtensions;
                return new List<String>(rawList.Split(','));
            }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Method to redefine to return all entries. Returns null if soecified entry is not a directory.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override List<ListViewItem> GetEntries(string path)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            if (Directory.Exists(path))
            {
                // Reads directory contents
                try
                {
                    string[] dirs = Directory.GetDirectories(path);
                    string[] files = Directory.GetFiles(path);

                    // Adds directories first
                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        ListViewItem item = new ListViewItem {Text = di.Name, Tag = di, ImageIndex = 0};

                        items.Add(item);
                    }

                    // Adds files
                    foreach (string file in files)
                    {
                        FileInfo fi = new FileInfo(file);

                        // Filter on extension
                        if (_ValidateExtension(fi.Extension))
                        {
                            ListViewItem item = new ListViewItem {Text = fi.Name, Tag = fi, ImageIndex = 4};

                            items.Add(item);
                        }
                    }
                }
                catch (UnauthorizedAccessException e)
                {
                    // Log?
                    throw e;
                }
            }
            else
            {
                throw new NotImplementedException("GetEntries is not applicable to classic files.");
            }
            return items;
        }

        #endregion
    }
}
