using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace TDUMT_2.Gui.Common.BrowseHandlers
{
    /// <summary>
    /// Abstract parent for any browse handler
    /// </summary>
    abstract class AbstractBrowseHandler
    {
        #region Properties
        /// <summary>
        /// To redefine: list of accepted extensions
        /// </summary>
        public abstract List<string> DisplayedExtensions { get;
            set;}
        #endregion

        /// <summary>
        /// Maps a regex pattern with the handler to use
        /// </summary>
        private static readonly Dictionary<string, Type> _Handlers = new Dictionary<string, Type>();

        /// <summary>
        /// Type for default handler
        /// </summary>
        private static readonly Type _DefaultHandlerClass;

        /// <summary>
        /// Type constructor. Loads configuration.
        /// </summary>
        static AbstractBrowseHandler()
        {
            // Get handler list from embedded configuration
            XmlDocument xml = null;  
            try  
            {
                string filePath = "TDUMT_2.Conf.BrowseHandlers.xml";  
                Stream fileStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filePath);  
                if (fileStream != null)  
                {  
                    xml = new XmlDocument();  
                    xml.Load(fileStream);

                    Assembly asm = Assembly.GetEntryAssembly();

                    // Default
                    string className = xml.SelectSingleNode(@"//defaultBrowseHandler").Attributes["class"].Value;
                    _DefaultHandlerClass = asm.GetType(className);

                    // Custom handlers
                    XmlNodeList nodes = xml.SelectNodes(@"//browseHandler");

                    if (nodes != null)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            className = node.Attributes["class"].Value;
                            string pattern = node.Attributes["entryRegex"].Value;
                            Type t = asm.GetType(className);
                            _Handlers.Add(pattern, t);
                        }
                    }
                }  
      
            }  
            catch (Exception ex)
            {   
                // if anything goes wrong I don't care - just return a null object.  
                // TODO log
            }  
  
        }

        /// <summary>
        /// Returns appropriate handler for specified entry name
        /// </summary>
        /// <param name="entryName"></param>
        /// <returns></returns>
        public static AbstractBrowseHandler GetHandler(string entryName)
        {
            // Tries to match with a regex
            Type handlerType = (from keyValuePair in _Handlers
                                where Regex.IsMatch(entryName, keyValuePair.Key,RegexOptions.IgnoreCase)
                                select keyValuePair.Value).FirstOrDefault();

            // Uses default handler when unmatched
            if (handlerType == null)
            {
                handlerType = _DefaultHandlerClass;
            }

            // Creates handler instance
            return Activator.CreateInstance(handlerType) as AbstractBrowseHandler;
        }

        /// <summary>
        /// Returns true if extension of specified file is accepted
        /// </summary>
        /// <param name="extension"></param>
        /// <returns></returns>
        protected bool _ValidateExtension(string extension)
        {
           return DisplayedExtensions.Contains(extension.ToUpper());
        }

        /// <summary>
        /// Method to redefine to return all contained entries. Must throw NotImplementedException when not applicable
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public abstract List<ListViewItem> GetEntries(string path);

 
    }
}
