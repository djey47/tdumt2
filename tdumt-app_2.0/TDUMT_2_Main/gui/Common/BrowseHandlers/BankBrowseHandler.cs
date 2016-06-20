using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ModdingLibrary_2.fileformats.banks;
using ModdingLibrary_2.support;

namespace TDUMT_2.Gui.Common.BrowseHandlers
{
    /// <summary>
    /// Enables browsing into TDU Banks (.BNK)
    /// </summary>
    class BankBrowseHandler : AbstractBrowseHandler
    {
        #region Overrides of AbstractBrowseHandler

        /// <summary>
        /// To redefine: list of accepted extensions
        /// </summary>
        public override List<string> DisplayedExtensions
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        /// <summary>
        /// Methode to redefine to return all entries
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public override List<ListViewItem> GetEntries(string path)
        {
            List<ListViewItem> items = new List<ListViewItem>();

            // Opens BNK file
            Bnk bank = new Bnk { Name = path };
            bank.Read();

            // Reads contents
            List<PackedFile> packedFiles = bank.GetPackedFiles();

            foreach (PackedFile f in packedFiles)
            {
                ListViewItem item = new ListViewItem(f.Name, 4) {Tag = f};
                items.Add(item);
            }
 
            return items;
        }

        #endregion
    }
}
