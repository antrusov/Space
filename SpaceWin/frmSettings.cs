using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Blue.Windows;

namespace SpaceWin
{
    public partial class frmSettings : Form
    {
        StickyWindow stickyWindow;
        public frmSettings()
        {
            InitializeComponent();
            stickyWindow = new StickyWindow(this);
        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = Core.CFG;
        }
    }
}
