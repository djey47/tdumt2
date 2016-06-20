using log4net;

namespace ModdingLibrary_2.fileformats
{
    /// <summary>
    /// Represents abstract view of any TDU file
    /// </summary>
    public abstract class AbstractFile
    {
        #region Properties
        /// <summary>
        /// File name
        /// </summary>
        public string Name { get; set; }
        #endregion

        #region Technical members
        /// <summary>
        /// Global logger for object dumping
        /// </summary>
        public static readonly ILog DUMP_LOG = LogManager.GetLogger("Dump");
        #endregion

        #region Operations
        /// <summary>
        /// Reads current file and stores information into memory
        /// </summary>
        public abstract void Read();
        
        /// <summary>
        /// Save current file to disk
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Dumps current object information to logs
        /// </summary>
        public abstract void Dump();

        /// <summary>
        /// Save current data to a new file on disk
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(string fileName)
        {
            string currentFileName = Name.Clone() as string;

            // Saves as new file
            Name = fileName;
            Save();
        }
        #endregion
    }
}
