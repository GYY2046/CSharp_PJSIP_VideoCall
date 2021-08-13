namespace pjsua2_csharp_video_demo
{
    partial class VideoWindows
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
            this.panelRemote = new System.Windows.Forms.Panel();
            this.panelLocal = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelRemote
            // 
            this.panelRemote.AllowDrop = true;
            this.panelRemote.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelRemote.Location = new System.Drawing.Point(0, 0);
            this.panelRemote.Name = "panelRemote";
            this.panelRemote.Size = new System.Drawing.Size(498, 494);
            this.panelRemote.TabIndex = 0;
            // 
            // panelLocal
            // 
            this.panelLocal.AllowDrop = true;
            this.panelLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLocal.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLocal.Location = new System.Drawing.Point(257, 274);
            this.panelLocal.Name = "panelLocal";
            this.panelLocal.Size = new System.Drawing.Size(229, 212);
            this.panelLocal.TabIndex = 0;
            this.panelLocal.Paint += new System.Windows.Forms.PaintEventHandler(this.panelLocal_Paint);
            this.panelLocal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLocal_MouseDown);
            this.panelLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLocal_MouseMove);
            // 
            // VideoWindows
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(498, 498);
            this.Controls.Add(this.panelLocal);
            this.Controls.Add(this.panelRemote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "VideoWindows";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "视频窗口";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel panelRemote;
        public System.Windows.Forms.Panel panelLocal;
    }
}