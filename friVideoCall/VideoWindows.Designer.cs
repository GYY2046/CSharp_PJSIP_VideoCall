namespace friVideoCall
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
            this.pnlbg = new System.Windows.Forms.Panel();
            this.panelVideo = new System.Windows.Forms.Panel();
            this.panelRemoteVideo = new System.Windows.Forms.Panel();
            this.panelLocalVideo = new System.Windows.Forms.Panel();
            this.pnlbg.SuspendLayout();
            this.panelVideo.SuspendLayout();
            this.panelRemoteVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlbg
            // 
            this.pnlbg.Controls.Add(this.panelVideo);
            this.pnlbg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlbg.Location = new System.Drawing.Point(0, 0);
            this.pnlbg.Name = "pnlbg";
            this.pnlbg.Size = new System.Drawing.Size(800, 600);
            this.pnlbg.TabIndex = 1;
            // 
            // panelVideo
            // 
            this.panelVideo.BackgroundImage = global::friVideoCall.Properties.Resources.bg3;
            this.panelVideo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panelVideo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelVideo.Controls.Add(this.panelRemoteVideo);
            this.panelVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVideo.Location = new System.Drawing.Point(0, 0);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(784, 561);
            this.panelVideo.TabIndex = 2;
            // 
            // panelRemoteVideo
            // 
            this.panelRemoteVideo.BackgroundImage = global::friVideoCall.Properties.Resources.bg1;
            this.panelRemoteVideo.Controls.Add(this.panelLocalVideo);
            this.panelRemoteVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRemoteVideo.Location = new System.Drawing.Point(0, 0);
            this.panelRemoteVideo.Name = "panelRemoteVideo";
            this.panelRemoteVideo.Size = new System.Drawing.Size(780, 557);
            this.panelRemoteVideo.TabIndex = 1;
            // 
            // panelLocalVideo
            // 
            this.panelLocalVideo.BackgroundImage = global::friVideoCall.Properties.Resources.bg0;
            this.panelLocalVideo.Location = new System.Drawing.Point(437, 304);
            this.panelLocalVideo.Name = "panelLocalVideo";
            this.panelLocalVideo.Size = new System.Drawing.Size(340, 250);
            this.panelLocalVideo.TabIndex = 0;
            this.panelLocalVideo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLocalVideo_MouseDown);
            this.panelLocalVideo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLocalVideo_MouseMove);
            // 
            // VideoWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.ControlBox = false;
            this.Controls.Add(this.pnlbg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "VideoWindows";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "视频窗口";
            this.pnlbg.ResumeLayout(false);
            this.panelVideo.ResumeLayout(false);
            this.panelRemoteVideo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlbg;
        private System.Windows.Forms.Panel panelVideo;
        public System.Windows.Forms.Panel panelRemoteVideo;
        public System.Windows.Forms.Panel panelLocalVideo;
    }
}