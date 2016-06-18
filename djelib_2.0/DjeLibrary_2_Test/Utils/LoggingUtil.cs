using log4net.Config;

namespace DjeLibray_2_Test.Support.Logging
{
    /// <summary>
    /// Utility class to initialize logging system.
    /// </summary>
    static class LoggingUtil
    {
        /// <summary>
        /// Initializes log4net configuration from XML file.
        /// </summary>
        public static void Initialize()
        {
            // log4net init
            XmlConfigurator.Configure();
        }
    }
}
