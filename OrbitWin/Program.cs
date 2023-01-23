using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Space;

namespace OrbitWin
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Core.Init();
                Application.Run(Core.MainWindow);
                Core.Done();
            }
            catch (Exception ex)
            {
                Logger.Err(ex);
            }
        }
    }
}
