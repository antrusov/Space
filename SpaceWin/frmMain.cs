using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Space;
using Blue.Windows;

namespace SpaceWin
{
    public partial class frmMain : Form
    {
        StickyWindow stickyWindow;
        public frmMain()
        {
            InitializeComponent();
            stickyWindow = new StickyWindow(this, true, false);
        }

        private void chkChildLock_CheckedChanged(object sender, EventArgs e)
        {
            stickyWindow.ChildLock = chkChildLock.Checked;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dlgOpenFile.InitialDirectory = Path.Combine(Directory.GetParent(Application.StartupPath).FullName, "Data");
            dlgOpenFile.RestoreDirectory = true;
            if (dlgOpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                try
                {
                    Core.ORBITS.Load(dlgOpenFile.FileName);
                    Core.GraphsWindow.ReloadSeries();
                }
                catch (Exception ex)
                {
                    Logger.Err(ex);
                    MessageBox.Show(ex.Message, "Failed loading orbits", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        //private void frmMain_Activated(object sender, EventArgs e)
        //{
        //    if (chkView.Checked) Core.ViewerWindow.BringToFront();
        //    if (chkSettings.Checked) Core.SettingsWindow.BringToFront();
        //    if (chkGraphs.Checked) Core.GraphsWindow.BringToFront();
        //    BringToFront();
        //    Focus();
        //}

    }
}
