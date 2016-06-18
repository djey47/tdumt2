using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DjeLibrary_2.Systems;

namespace DjeLibrary_2_Test.Systems
{
    class FileUtilsTest
    {
        public static void Main()
        {
            string sourceDirectory = @"c:\sourceDirectory";
            string targetDirectory = @"c:\targetDirectory";
            FileUtils.Copy(sourceDirectory, targetDirectory);
        }
    }
}
