using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrbitWin
{
    static class Core
    {
        public static Config CFG;
        public static frmMain MainWindow;

        public static void Update(double dt)
        {
            if (CFG.Play)
            {
            }
        }

        public static void Init()
        {
            CFG = new Config();
            MainWindow = new frmMain();
            //...
        }

        public static void Done()
        {
            //...
        }
    }
}
