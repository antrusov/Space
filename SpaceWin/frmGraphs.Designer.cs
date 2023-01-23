namespace SpaceWin
{
    partial class frmGraphs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartDists = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabsGraphs = new System.Windows.Forms.TabControl();
            this.tabDists = new System.Windows.Forms.TabPage();
            this.tabOrbits = new System.Windows.Forms.TabPage();
            this.dgvOrbits = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.chartDists)).BeginInit();
            this.tabsGraphs.SuspendLayout();
            this.tabDists.SuspendLayout();
            this.tabOrbits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrbits)).BeginInit();
            this.SuspendLayout();
            // 
            // chartDists
            // 
            chartArea1.AxisY.Minimum = 0D;
            chartArea1.Name = "ChartArea1";
            this.chartDists.ChartAreas.Add(chartArea1);
            this.chartDists.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartDists.Legends.Add(legend1);
            this.chartDists.Location = new System.Drawing.Point(3, 3);
            this.chartDists.Name = "chartDists";
            this.chartDists.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.StackedColumn;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartDists.Series.Add(series1);
            this.chartDists.Size = new System.Drawing.Size(599, 344);
            this.chartDists.TabIndex = 0;
            this.chartDists.Text = "chart1";
            // 
            // tabsGraphs
            // 
            this.tabsGraphs.Controls.Add(this.tabDists);
            this.tabsGraphs.Controls.Add(this.tabOrbits);
            this.tabsGraphs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsGraphs.Location = new System.Drawing.Point(0, 0);
            this.tabsGraphs.Name = "tabsGraphs";
            this.tabsGraphs.SelectedIndex = 0;
            this.tabsGraphs.Size = new System.Drawing.Size(613, 376);
            this.tabsGraphs.TabIndex = 1;
            // 
            // tabDists
            // 
            this.tabDists.Controls.Add(this.chartDists);
            this.tabDists.Location = new System.Drawing.Point(4, 22);
            this.tabDists.Name = "tabDists";
            this.tabDists.Padding = new System.Windows.Forms.Padding(3);
            this.tabDists.Size = new System.Drawing.Size(605, 350);
            this.tabDists.TabIndex = 0;
            this.tabDists.Text = "Dists";
            this.tabDists.UseVisualStyleBackColor = true;
            // 
            // tabOrbits
            // 
            this.tabOrbits.Controls.Add(this.dgvOrbits);
            this.tabOrbits.Location = new System.Drawing.Point(4, 22);
            this.tabOrbits.Name = "tabOrbits";
            this.tabOrbits.Padding = new System.Windows.Forms.Padding(3);
            this.tabOrbits.Size = new System.Drawing.Size(605, 350);
            this.tabOrbits.TabIndex = 1;
            this.tabOrbits.Text = "Orbits";
            this.tabOrbits.UseVisualStyleBackColor = true;
            // 
            // dgvOrbits
            // 
            this.dgvOrbits.AllowUserToAddRows = false;
            this.dgvOrbits.AllowUserToDeleteRows = false;
            this.dgvOrbits.AllowUserToOrderColumns = true;
            this.dgvOrbits.AllowUserToResizeRows = false;
            this.dgvOrbits.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrbits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrbits.Location = new System.Drawing.Point(3, 3);
            this.dgvOrbits.Name = "dgvOrbits";
            this.dgvOrbits.Size = new System.Drawing.Size(599, 344);
            this.dgvOrbits.TabIndex = 0;
            this.dgvOrbits.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOrbits_CellMouseUp);
            this.dgvOrbits.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOrbits_CellValueChanged);
            this.dgvOrbits.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvOrbits_DataBindingComplete);
            // 
            // frmGraphs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 376);
            this.Controls.Add(this.tabsGraphs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmGraphs";
            this.Text = "Graphs";
            ((System.ComponentModel.ISupportInitialize)(this.chartDists)).EndInit();
            this.tabsGraphs.ResumeLayout(false);
            this.tabDists.ResumeLayout(false);
            this.tabOrbits.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrbits)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabsGraphs;
        private System.Windows.Forms.TabPage tabDists;
        private System.Windows.Forms.TabPage tabOrbits;
        private System.Windows.Forms.DataGridView dgvOrbits;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDists;
    }
}