using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using Space;
using XnaGeometry;

namespace SpaceWin
{
    static class Core
    {
        public static Settings CFG;
        public static Orbits ORBITS;

        public static frmGraphs GraphsWindow;
        public static frmSettings SettingsWindow;
        public static frmViewer ViewerWindow;
        public static frmMain MainWindow;

        //public static List<double>[] DistLists;

        public static void Update(double dt)
        {
            if (CFG.Play)
            {
                ORBITS.Update(dt * CFG.TimeScale);
                GraphsWindow.UpdateGraphs();
            }
        }

        public static void Init()
        {
            CFG = new Settings();
            ORBITS = new Orbits();

            CFG.Camera.Scale = 50;
            CFG.Camera.Move("rotox", 298);
            CFG.Camera.Move("rotoy", -286);

            MainWindow = new frmMain();
            ViewerWindow = new frmViewer();
            SettingsWindow = new frmSettings();
            GraphsWindow = new frmGraphs();
            ViewerWindow.Visible = true;
            SettingsWindow.Visible = true;
            GraphsWindow.Visible = true;

            //restore windows states
            MainWindow.Size     = SpaceWin.Properties.Settings.Default.MainSize;
            ViewerWindow.Size   = SpaceWin.Properties.Settings.Default.ViewerSize;
            SettingsWindow.Size = SpaceWin.Properties.Settings.Default.SettingsSize;
            GraphsWindow.Size   = SpaceWin.Properties.Settings.Default.GraphsSize;
            MainWindow.Location     = SpaceWin.Properties.Settings.Default.MainLocation;
            ViewerWindow.Location   = SpaceWin.Properties.Settings.Default.ViewerLocation;
            SettingsWindow.Location = SpaceWin.Properties.Settings.Default.SettingsLocation;
            GraphsWindow.Location   = SpaceWin.Properties.Settings.Default.GraphsLocation;

            Core.BindCheckboxToWindow(MainWindow.chkView, ViewerWindow);
            Core.BindCheckboxToWindow(MainWindow.chkSettings, SettingsWindow);
            Core.BindCheckboxToWindow(MainWindow.chkGraphs, GraphsWindow);
        }

        public static void Done()
        {
            //save windows states
            SpaceWin.Properties.Settings.Default.MainSize     = MainWindow.Size;
            SpaceWin.Properties.Settings.Default.ViewerSize   = ViewerWindow.Size;
            SpaceWin.Properties.Settings.Default.SettingsSize = SettingsWindow.Size;
            SpaceWin.Properties.Settings.Default.GraphsSize   = GraphsWindow.Size;
            SpaceWin.Properties.Settings.Default.MainLocation     = MainWindow.Location;
            SpaceWin.Properties.Settings.Default.ViewerLocation   = ViewerWindow.Location;
            SpaceWin.Properties.Settings.Default.SettingsLocation = SettingsWindow.Location;
            SpaceWin.Properties.Settings.Default.GraphsLocation   = GraphsWindow.Location;
            SpaceWin.Properties.Settings.Default.Save();
        }

        #region [ Bind CheckBox to Form ]

        static List<Tuple<CheckBox, Form>> chk2from = new List<Tuple<CheckBox, Form>>();

        public static void BindCheckboxToWindow(CheckBox chk, Form form)
        {
            if (chk == null || form == null)
                return;

            chk2from.Add(new Tuple<CheckBox, Form>(chk, form));
            chk.CheckedChanged += chk_CheckedChanged;
            form.FormClosing += form_FormClosing;
        }

        static void form_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form form = (Form)sender;
            Tuple<CheckBox, Form> pair = null;
            for (int i = 0; i < chk2from.Count; i++)
                if (chk2from[i].Item2 == form)
                    pair = chk2from[i];

            //hide, not close
            e.Cancel = true;

            //uncheck
            if (pair != null)
                pair.Item1.Checked = false;
        }

        static void chk_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox chk = (CheckBox)sender;
            Tuple<CheckBox, Form> pair = null;
            for (int i = 0; i < chk2from.Count; i++)
                if (chk2from[i].Item1 == chk)
                    pair = chk2from[i];

            pair.Item2.Visible = chk.Checked;
        }

        #endregion  

    }
}
