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

            // Logging configuration
            string logConfigFile = Path.Combine(Directory.GetCurrentDirectory(), "Conf", "log4net.xml");
            XmlConfigurator.Configure(new FileInfo(logConfigFile));
            
            // App config
            var appConfigFile = Path.Combine(Directory.GetCurrentDirectory(), "Conf", "tdumt2_MBM.xml");
            AppConfig.Instance.ConfigFilePath = appConfigFile;
            AppConfig.Instance.Load();
            
            // Q&D mode
            Application.Run(new BnkForm());
        }
    }
}
