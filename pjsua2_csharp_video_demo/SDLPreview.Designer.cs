namespace pjsua2_csharp_video_demo
{
    partial class SDLPreview
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.panelRemote = new System.Windows.Forms.Panel();
            this.panelLocal = new System.Windows.Forms.Panel();
            this.panelRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRemote
            // 
            this.panelRemote.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panelRemote.Controls.Add(this.panelLocal);
            this.panelRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRemote.Location = new System.Drawing.Point(0, 0);
            this.panelRemote.Name = "panelRemote";
            this.panelRemote.Size = new System.Drawing.Size(712, 534);
            this.panelRemote.TabIndex = 0;
            // 
            // panelLocal
            // 
            this.panelLocal.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelLocal.Location = new System.Drawing.Point(490, 313);
            this.panelLocal.Name = "panelLocal";
            this.panelLocal.Size = new System.Drawing.Size(222, 221);
            this.panelLocal.TabIndex = 0;
            // 
            // SDLPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRemote);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SDLPreview";
            this.Size = new System.Drawing.Size(712, 534);
            this.panelRemote.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRemote;
        private System.Windows.Forms.Panel panelLocal;
    }
}
