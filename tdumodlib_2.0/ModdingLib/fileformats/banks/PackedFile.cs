namespace ModdingLibrary_2.fileformats.banks
{
    /// <summary>
    /// File packed into a Bnk
    /// </summary>
    public class PackedFile : PackedFolder
    {
        #region Enums
        #endregion

        #region Constants
        /// <summary>
        /// Unknwown file type
        /// </summary>
        public const uint UNKNOWN_TYPE = 0xFFFFFFFF;

        /// <summary>
        /// Seprator charcarter used in packed file paths
        /// </summary>
        public const char PATH_SEPARATOR = '/';
        #endregion

        #region Properties
        /// <summary>
        /// Unique identifier in file hierarchy
        /// </summary>
        public uint Id { get; set; }

        /// <summary>
        /// Order in packed data section
        /// </summary>
        //public uint Order { get; set; }

        /// <summary>
        /// Magic data (???)
        /// </summary>
        public ulong Magic { get; set; }

        /// <summary>
        /// Type of current file
        /// </summary>
        public uint Type { get; set; }

        /// <summary>
        /// File size
        /// </summary>
        public int Size
        {
            get
            {
                return Data.Length;
            }
        }

        /// <summary>
        /// File contents
        /// </summary>
        public byte[] Data
        {
            get { return _Data; }
            set { _Data = value; }
        }
        private byte[] _Data = new byte[0];

        /// <summary>
        /// Size of padding at the end of data. To be used when repacking.
        /// </summary>
        public int PaddingSize { get; set; }
        #endregion
    }
}