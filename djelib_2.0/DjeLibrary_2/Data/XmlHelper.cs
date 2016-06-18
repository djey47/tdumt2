using System;
using System.Xml;
using log4net;


namespace DjeLibrary_2.Data
{
    /// <summary>
    /// Classe statique donnant l'accès à la gestion avancée du format XML
    /// </summary>
    public class XmlHelper
    {
        #region Constantes
        /// <summary>
        /// En-tête XML 1.0 standard
        /// </summary>
        public const string XML_1_0_HEADER = "<?xml version=\"1.0\" ?>";
        #endregion

        /// <summary>
        /// Logger.
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(XmlHelper));

        #region Public methods
        /// <summary>
        /// Returns specified attribute value, or default value if it does not exist
        /// </summary>
        /// <param name="node">parent node</param>
        /// <param name="attributeName">name of attribute</param>
        /// <param name="defaultValue">value to return upon error</param>
        /// <returns></returns>
        public static string GetAttributeWithDefaultValue(XmlNode node, string attributeName, string defaultValue)
        {
            string returnedValue = defaultValue;

            if (node != null)
            {
                XmlAttribute currentAttribute = node.Attributes[attributeName];
                
                if (currentAttribute == null)
                    _log.Warn(string.Format("Attribute '{0}' was not found in XML: using default value: '{1}'.",attributeName, defaultValue));          
                else
                    returnedValue = currentAttribute.Value;
            }

            return returnedValue;
        }
        #endregion
    }
}