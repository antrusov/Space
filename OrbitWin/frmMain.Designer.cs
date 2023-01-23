namespace OrbitWin
{
    partial class frmMain
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
            this.glOrbit = new OpenTK.GLControl();
            this.spltMain = new System.Windows.Forms.SplitContainer();
            this.pgOrbit = new System.Windows.Forms.PropertyGrid();
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).BeginInit();
            this.spltMain.Panel1.SuspendLayout();
            this.spltMain.Panel2.SuspendLayout();
            this.spltMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // glOrbit
            // 
            this.glOrbit.BackColor = System.Drawing.Color.Black;
            this.glOrbit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glOrbit.Location = new System.Drawing.Point(0, 0);
            this.glOrbit.Name = "glOrbit";
            this.glOrbit.Size = new System.Drawing.Size(582, 553);
            this.glOrbit.TabIndex = 0;
            this.glOrbit.VSync = false;
            this.glOrbit.Load += new System.EventHandler(this.glOrbit_Load);
            this.glOrbit.Paint += new System.Windows.Forms.PaintEventHandler(this.glOrbit_Paint);
            this.glOrbit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glOrbit_MouseDown);
            this.glOrbit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glOrbit_MouseMove);
            this.glOrbit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glOrbit_MouseUp);
            this.glOrbit.Resize += new System.EventHandler(this.glOrbit_Resize);
            // 
            // spltMain
            // 
            this.spltMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltMain.Location = new System.Drawing.Point(0, 0);
            this.spltMain.Name = "spltMain";
            // 
            // spltMain.Panel1
            // 
            this.spltMain.Panel1.Controls.Add(this.glOrbit);
            // 
            // spltMain.Panel2
            // 
            this.spltMain.Panel2.Controls.Add(this.pgOrbit);
            this.spltMain.Size = new System.Drawing.Size(953, 553);
            this.spltMain.SplitterDistance = 582;
            this.spltMain.TabIndex = 2;
            // 
            // pgOrbit
            // 
            this.pgOrbit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pgOrbit.Location = new System.Drawing.Point(0, 0);
            this.pgOrbit.Name = "pgOrbit";
            this.pgOrbit.PropertySort = System.Windows.Forms.PropertySort.Categorized;
            this.pgOrbit.Size = new System.Drawing.Size(367, 553);
            this.pgOrbit.TabIndex = 0;
            this.pgOrbit.ToolbarVisible = false;
            this.pgOrbit.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.pgOrbit_PropertyValueChanged);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 553);
            this.Controls.Add(this.spltMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMain";
            this.Text = "Orbit";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.spltMain.Panel1.ResumeLayout(false);
            this.spltMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltMain)).EndInit();
            this.spltMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glOrbit;
        private System.Windows.Forms.SplitContainer spltMain;
        private System.Windows.Forms.PropertyGrid pgOrbit;
    }
}

