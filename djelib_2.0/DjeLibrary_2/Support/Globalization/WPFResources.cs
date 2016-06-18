using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using log4net;

namespace DjeLibrary_2.Support.Globalization
{
    ///<summary>
    /// Utility class to work with resources to be localized
    ///</summary>
    public class WPFResources
    {
        private const string RES_FILENAME = "Localization{0}.Xaml";

        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(WPFResources));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="resourceFolder"></param>
        /// <returns></returns>
        public static ResourceDictionary RetrieveDictionary(string resourceFolder) {
            ResourceDictionary dict = new ResourceDictionary();
            string systemCulture = Thread.CurrentThread.CurrentCulture.ToString();
            
            // Searches for corresponding resources file
            string localizationFileName = string.Concat(resourceFolder, string.Format(RES_FILENAME, "." + systemCulture));

            if (new FileInfo(localizationFileName).Exists) {
                _log.Debug(string.Format("Using resources file {0}",localizationFileName)); 
            } else {
                // File does not exist -> writes event to log              
                _log.Warn(string.Format("Resources file {0} for current language could not be found. Using default settings.", localizationFileName));

                localizationFileName = string.Concat(resourceFolder, string.Format(RES_FILENAME, ""));
            }

            dict.Source = new Uri(localizationFileName, UriKind.Absolute);

            return dict;
        }
    }
}