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
using Space;
using XnaGeometry;

namespace SpaceWin
{
    public partial class frmGraphs : Form
    {
        StickyWindow stickyWindow;
        public frmGraphs()
        {
            InitializeComponent();
            stickyWindow = new StickyWindow(this);

            ReloadSeries();

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.Name = "Enable";
            chk.HeaderText = "";
            chk.TrueValue = true;
            chk.FalseValue = false;
            chk.Width = 30;
            dgvOrbits.Columns.Add(chk);

            dgvOrbits.Columns.Add("Name", "Name");
            dgvOrbits.Columns.Add("A", "A");
            dgvOrbits.Columns.Add("B", "B");
            dgvOrbits.Columns.Add("X", "X");
            dgvOrbits.Columns.Add("Y", "Y");
            dgvOrbits.Columns.Add("Z", "Z");
            dgvOrbits.Columns.Add("W", "W");
            dgvOrbits.Columns.Add("Total", "Total");

            dgvOrbits.DataSource = Core.ORBITS.Items;

        }

        public void ReloadSeries()
        {
            chartDists.Series.Clear();
            for (int i = 0; i < Core.ORBITS.Items.Count; i++)
            {
                chartDists.Series.Add(i.ToString()).ChartType =
                    System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
                chartDists.Series[i].Name = Core.ORBITS.Items[i].Orbit.Name;
            }
        }

        public void UpdateGraphs()
        {
            for (int i = 0; i < Core.ORBITS.Dists.Count && i < chartDists.Series.Count; i++)
            {
                chartDists.Series[i].Points.Clear();
                if (Core.ORBITS.Items[i].Enable)
                    for (int j = 0; j < Core.ORBITS.Dists[i].Count; j++)
                        chartDists.Series[i].Points.AddXY(j, Core.ORBITS.Dists[i][j]);
            }
        }

        private void dgvOrbits_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrbits.Rows)
            {
                //Enable
                bool Enable = ((Orbits.OrbitEx)row.DataBoundItem).Enable;
                row.Cells["Enable"].Value = Enable;

                //Name
                string Name = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Name;
                row.Cells["Name"].Value = Name;

                //A
                double A = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Ellipse.A;
                row.Cells["A"].Value = A;

                //B
                double B = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Ellipse.B;
                row.Cells["B"].Value = B;

                //X
                double X = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Orientation.X;
                row.Cells["X"].Value = X;

                //Y
                double Y = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Orientation.Y;
                row.Cells["Y"].Value = Y;

                //Z
                double Z = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Orientation.Z;
                row.Cells["Z"].Value = Z;

                //W
                double W = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Orientation.W;
                row.Cells["W"].Value = W;

                //Total
                double Total = ((Orbits.OrbitEx)row.DataBoundItem).Orbit.Ellipse.Total;
                row.Cells["Total"].Value = Total;
            }
        }

        #region [ checkbox handle ]

        const int CHK_COLUMN_INDEX = 0;

        private void dgvOrbits_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == CHK_COLUMN_INDEX && e.RowIndex != -1)
            {
                Core.ORBITS.Items[e.RowIndex].Enable = (bool)dgvOrbits.Rows[e.RowIndex].Cells["Enable"].Value;
            }
        }

        private void dgvOrbits_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == CHK_COLUMN_INDEX && e.RowIndex != -1)
                dgvOrbits.EndEdit();
        }

        #endregion
    }
}
