using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TDUMT_2_MiniXmb.Gui;

namespace TDUMT_2_MiniXmb
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
            Application.Run(new XmbForm());
        }
    }
}
