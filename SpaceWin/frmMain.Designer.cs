namespace SpaceWin
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
            this.chkView = new System.Windows.Forms.CheckBox();
            this.chkSettings = new System.Windows.Forms.CheckBox();
            this.chkChildLock = new System.Windows.Forms.CheckBox();
            this.chkGraphs = new System.Windows.Forms.CheckBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // chkView
            // 
            this.chkView.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkView.Checked = true;
            this.chkView.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkView.Location = new System.Drawing.Point(12, 12);
            this.chkView.Name = "chkView";
            this.chkView.Size = new System.Drawing.Size(55, 23);
            this.chkView.TabIndex = 8;
            this.chkView.Text = "View";
            this.chkView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkView.UseVisualStyleBackColor = true;
            // 
            // chkSettings
            // 
            this.chkSettings.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkSettings.Checked = true;
            this.chkSettings.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSettings.Location = new System.Drawing.Point(73, 12);
            this.chkSettings.Name = "chkSettings";
            this.chkSettings.Size = new System.Drawing.Size(55, 23);
            this.chkSettings.TabIndex = 9;
            this.chkSettings.Text = "Settings";
            this.chkSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkSettings.UseVisualStyleBackColor = true;
            // 
            // chkChildLock
            // 
            this.chkChildLock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkChildLock.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkChildLock.Location = new System.Drawing.Point(412, 12);
            this.chkChildLock.Name = "chkChildLock";
            this.chkChildLock.Size = new System.Drawing.Size(76, 23);
            this.chkChildLock.TabIndex = 10;
            this.chkChildLock.Text = "Child Lock";
            this.chkChildLock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkChildLock.UseVisualStyleBackColor = true;
            this.chkChildLock.CheckedChanged += new System.EventHandler(this.chkChildLock_CheckedChanged);
            // 
            // chkGraphs
            // 
            this.chkGraphs.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkGraphs.Checked = true;
            this.chkGraphs.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkGraphs.Location = new System.Drawing.Point(134, 12);
            this.chkGraphs.Name = "chkGraphs";
            this.chkGraphs.Size = new System.Drawing.Size(55, 23);
            this.chkGraphs.TabIndex = 11;
            this.chkGraphs.Text = "Graphs";
            this.chkGraphs.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkGraphs.UseVisualStyleBackColor = true;
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.Location = new System.Drawing.Point(351, 12);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(55, 23);
            this.btnLoad.TabIndex = 12;
            this.btnLoad.Text = "Load ...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // dlgOpenFile
            // 
            this.dlgOpenFile.DefaultExt = "xml";
            this.dlgOpenFile.FileName = "*.xml";
            this.dlgOpenFile.Filter = "Orbits (*.xml)|*.xml|All files (*.*)|*.*";
            this.dlgOpenFile.InitialDirectory = "..\\Data\\";
            this.dlgOpenFile.Title = "Load Orbits";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(500, 51);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.chkGraphs);
            this.Controls.Add(this.chkChildLock);
            this.Controls.Add(this.chkSettings);
            this.Controls.Add(this.chkView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmMain";
            this.Text = "Main";
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.CheckBox chkView;
        public System.Windows.Forms.CheckBox chkSettings;
        private System.Windows.Forms.CheckBox chkChildLock;
        public System.Windows.Forms.CheckBox chkGraphs;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog dlgOpenFile;


    }
}

