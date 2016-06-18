using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;

namespace DjeLibrary_2.Systems
{
    /// <summary>
    /// Provides utility methods to access to handle file systems
    /// </summary>
    public class FileUtils
    {
        private static readonly ILog _Log = LogManager.GetLogger(typeof(FileUtils));

        /// <summary>
        /// Copy contents of sourceDirectory to targetDirectory. Will create target if it does not exist.
        /// </summary>
        /// <param name="sourceDirectory"></param>
        /// <param name="targetDirectory"></param>
        public static void Copy(string sourceDirectory, string targetDirectory)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            Copy(diSource, diTarget);
        }

        /// <summary>
        /// Copy contents of source to target (recursive). Will create target if it does not exist.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public static void Copy(DirectoryInfo source, DirectoryInfo target)
        {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false)
            {
                Directory.CreateDirectory(target.FullName);
            }
            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                _Log.Debug(string.Format(@"Copying {0}\{1}", target.FullName, fi.Name));
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }
            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                Copy(diSourceSubDir, nextTargetSubDir);
            }
        }
    }
}
