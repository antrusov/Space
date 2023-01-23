namespace SpaceWin
{
    partial class frmViewer
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
            this.SuspendLayout();
            // 
            // glOrbit
            // 
            this.glOrbit.BackColor = System.Drawing.Color.Black;
            this.glOrbit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glOrbit.Location = new System.Drawing.Point(0, 0);
            this.glOrbit.Name = "glOrbit";
            this.glOrbit.Size = new System.Drawing.Size(589, 556);
            this.glOrbit.TabIndex = 0;
            this.glOrbit.VSync = false;
            this.glOrbit.Load += new System.EventHandler(this.glOrbit_Load);
            this.glOrbit.Paint += new System.Windows.Forms.PaintEventHandler(this.glOrbit_Paint);
            this.glOrbit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glOrbit_MouseDown);
            this.glOrbit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glOrbit_MouseMove);
            this.glOrbit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glOrbit_MouseUp);
            this.glOrbit.Resize += new System.EventHandler(this.glOrbit_Resize);
            // 
            // frmViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 556);
            this.Controls.Add(this.glOrbit);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.KeyPreview = true;
            this.Name = "frmViewer";
            this.Text = "Viewer";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmViewer_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private OpenTK.GLControl glOrbit;
    }
}