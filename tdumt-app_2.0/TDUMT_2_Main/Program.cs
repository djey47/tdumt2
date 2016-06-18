using System;
using System.IO;
using System.Windows.Forms;
using log4net.Config;
using TDUMT_2.Gui;

namespace TDUMT_2
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
            string configFile = Directory.GetCurrentDirectory() + @"\Conf\log4net.xml";
            XmlConfigurator.Configure(new FileInfo(configFile));
            
            // Full mode
            Application.Run(new MainForm());
        }
    }
}
