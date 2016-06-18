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
        /// Saves current file to disk
        /// </summary>
        public abstract void Save();

        /// <summary>
        /// Saves current data to a new file on disk
        /// </summary>
        /// <param name="fileName"></param>
        public void SaveAs(string fileName)
        {
            // Saves as new file
            Name = fileName;
            Save();
        }

        /// <summary>
        /// Dumps file contents to DUMP_LOG logger
        /// </summary>
        public abstract void Dump();
        #endregion
    }
}
