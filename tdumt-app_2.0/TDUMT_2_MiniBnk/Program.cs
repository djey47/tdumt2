using System;
using System.IO;
using System.Windows.Forms;
using log4net.Config;
using TDUMT_2.MiniBnkManager.Gui;
using TDUMT_2.MiniBnkManager.Support;

namespace TDUMT_2.MiniBnkManager
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var configPath = Path.Combine(Directory.GetCurrentDirectory(), "Conf");

            // Logging configuration
            var logConfigFile = Path.Combine(configPath, "log4net.xml");
            XmlConfigurator.Configure(new FileInfo(logConfigFile));
            
            // App config
            var appConfigFile = Path.Combine(configPath, "tdumt2_MBM.xml");
            AppConfig.Instance.ConfigFilePath = appConfigFile;
            AppConfig.Instance.Load();
            
            // Q&D mode
            Application.Run(new BnkForm());
        }
    }
}
