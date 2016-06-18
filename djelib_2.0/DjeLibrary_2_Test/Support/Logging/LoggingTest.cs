using DjeLibrary_2;
using DjeLibray_2_Test.Support.Logging;
using log4net;

namespace DjeLibrary_2_Test.Support.Logging
{
    public class LoggingTest
    {
        /// <summary>
        /// Internal logger
        /// </summary>
        private static readonly ILog _Log = LogManager.GetLogger(typeof (LoggingTest));
        
        public void MyTestInitialize()
        {
            LoggingUtil.Initialize();
        }

        public void InfoTest()
        {
            // Log files are stored in Debug/logs folder
            _Log.Info("Writing message at log INFO level (unit test) ...");
        }

        public void DebugTest()
        {
            // Log files are stored in Debug/logs folder
            _Log.Debug("This is debug content from unit test");
        }
    }
}
