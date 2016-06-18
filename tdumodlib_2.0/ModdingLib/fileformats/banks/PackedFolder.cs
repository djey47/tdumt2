using System.Collections.Generic;

namespace ModdingLibrary_2.fileformats.banks
{
    /// <summary>
    /// Represents a BNK folder entry
    /// </summary>
    public class PackedFolder
    {
        /// <summary>
        /// Entry name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full path to this entry
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// List of sub-entries (folders or packed files)
        /// </summary>
        public List<PackedFolder> Children { get; set; }
    }
}