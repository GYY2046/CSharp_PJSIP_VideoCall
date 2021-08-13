namespace pjsua2_csharp_video_demo
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnInit = new System.Windows.Forms.Button();
            this.btnSelectCamra = new System.Windows.Forms.Button();
            this.comboxCamre = new System.Windows.Forms.ComboBox();
            this.btnStartCamera = new System.Windows.Forms.Button();
            this.previewPanel = new System.Windows.Forms.Panel();
            this.textRemoteIP = new System.Windows.Forms.TextBox();
            this.btnMakeCall = new System.Windows.Forms.Button();
            this.panelRemoteVideo = new System.Windows.Forms.Panel();
            this.btnStopCall = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnInitCall = new System.Windows.Forms.Button();
            this.btnStopPreview = new System.Windows.Forms.Button();
            this.panelRemoteVideo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(35, 49);
            this.btnInit.Margin = new System.Windows.Forms.Padding(2);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnSelectCamra
            // 
            this.btnSelectCamra.Location = new System.Drawing.Point(35, 91);
            this.btnSelectCamra.Margin = new System.Windows.Forms.Padding(2);
            this.btnSelectCamra.Name = "btnSelectCamra";
            this.btnSelectCamra.Size = new System.Drawing.Size(75, 23);
            this.btnSelectCamra.TabIndex = 1;
            this.btnSelectCamra.Text = "获取摄像头";
            this.btnSelectCamra.UseVisualStyleBackColor = true;
            this.btnSelectCamra.Click += new System.EventHandler(this.btnSelectCamra_Click);
            // 
            // comboxCamre
            // 
            this.comboxCamre.DropDownHeight = 130;
            this.comboxCamre.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboxCamre.FormattingEnabled = true;
            this.comboxCamre.IntegralHeight = false;
            this.comboxCamre.Location = new System.Drawing.Point(129, 95);
            this.comboxCamre.Margin = new System.Windows.Forms.Padding(2);
            this.comboxCamre.Name = "comboxCamre";
            this.comboxCamre.Size = new System.Drawing.Size(166, 22);
            this.comboxCamre.TabIndex = 2;
            // 
            // btnStartCamera
            // 
            this.btnStartCamera.Location = new System.Drawing.Point(35, 141);
            this.btnStartCamera.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartCamera.Name = "btnStartCamera";
            this.btnStartCamera.Size = new System.Drawing.Size(75, 23);
            this.btnStartCamera.TabIndex = 4;
            this.btnStartCamera.Text = "启动摄像头";
            this.btnStartCamera.UseVisualStyleBackColor = true;
            this.btnStartCamera.Click += new System.EventHandler(this.btnStartCamera_Click);
            // 
            // previewPanel
            // 
            this.previewPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.previewPanel.Location = new System.Drawing.Point(199, 111);
            this.previewPanel.Margin = new System.Windows.Forms.Padding(2);
            this.previewPanel.Name = "previewPanel";
            this.previewPanel.Size = new System.Drawing.Size(265, 198);
            this.previewPanel.TabIndex = 5;
            // 
            // textRemoteIP
            // 
            this.textRemoteIP.Location = new System.Drawing.Point(129, 175);
            this.textRemoteIP.Margin = new System.Windows.Forms.Padding(2);
            this.textRemoteIP.Name = "textRemoteIP";
            this.textRemoteIP.Size = new System.Drawing.Size(166, 21);
            this.textRemoteIP.TabIndex = 6;
            // 
            // btnMakeCall
            // 
            this.btnMakeCall.Location = new System.Drawing.Point(35, 174);
            this.btnMakeCall.Margin = new System.Windows.Forms.Padding(2);
            this.btnMakeCall.Name = "btnMakeCall";
            this.btnMakeCall.Size = new System.Drawing.Size(75, 24);
            this.btnMakeCall.TabIndex = 7;
            this.btnMakeCall.Text = "拨打";
            this.btnMakeCall.UseVisualStyleBackColor = true;
            this.btnMakeCall.Click += new System.EventHandler(this.btnMakeCall_Click);
            // 
            // panelRemoteVideo
            // 
            this.panelRemoteVideo.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panelRemoteVideo.Controls.Add(this.previewPanel);
            this.panelRemoteVideo.Location = new System.Drawing.Point(35, 213);
            this.panelRemoteVideo.Margin = new System.Windows.Forms.Padding(2);
            this.panelRemoteVideo.Name = "panelRemoteVideo";
            this.panelRemoteVideo.Size = new System.Drawing.Size(466, 309);
            this.panelRemoteVideo.TabIndex = 6;
            this.panelRemoteVideo.VisibleChanged += new System.EventHandler(this.panelRemoteVideo_VisibleChanged);
            // 
            // btnStopCall
            // 
            this.btnStopCall.Location = new System.Drawing.Point(338, 175);
            this.btnStopCall.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopCall.Name = "btnStopCall";
            this.btnStopCall.Size = new System.Drawing.Size(62, 22);
            this.btnStopCall.TabIndex = 8;
            this.btnStopCall.Text = "挂断";
            this.btnStopCall.UseVisualStyleBackColor = true;
            this.btnStopCall.Click += new System.EventHandler(this.btnStopCall_Click);
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(348, 49);
            this.btnDestroy.Margin = new System.Windows.Forms.Padding(2);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(62, 22);
            this.btnDestroy.TabIndex = 9;
            this.btnDestroy.Text = "注销";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(338, 141);
            this.btnAnswer.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(62, 22);
            this.btnAnswer.TabIndex = 10;
            this.btnAnswer.Text = "接听";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnInitCall
            // 
            this.btnInitCall.Location = new System.Drawing.Point(129, 140);
            this.btnInitCall.Margin = new System.Windows.Forms.Padding(2);
            this.btnInitCall.Name = "btnInitCall";
            this.btnInitCall.Size = new System.Drawing.Size(75, 23);
            this.btnInitCall.TabIndex = 11;
            this.btnInitCall.Text = "初始化Call";
            this.btnInitCall.UseVisualStyleBackColor = true;
            this.btnInitCall.Click += new System.EventHandler(this.btnInitCall_Click);
            // 
            // btnStopPreview
            // 
            this.btnStopPreview.Location = new System.Drawing.Point(234, 140);
            this.btnStopPreview.Margin = new System.Windows.Forms.Padding(2);
            this.btnStopPreview.Name = "btnStopPreview";
            this.btnStopPreview.Size = new System.Drawing.Size(75, 23);
            this.btnStopPreview.TabIndex = 12;
            this.btnStopPreview.Text = "关闭预览";
            this.btnStopPreview.UseVisualStyleBackColor = true;
            this.btnStopPreview.Click += new System.EventHandler(this.btnStopPreview_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 530);
            this.Controls.Add(this.btnStopPreview);
            this.Controls.Add(this.btnInitCall);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnDestroy);
            this.Controls.Add(this.btnStopCall);
            this.Controls.Add(this.panelRemoteVideo);
            this.Controls.Add(this.btnMakeCall);
            this.Controls.Add(this.textRemoteIP);
            this.Controls.Add(this.btnStartCamera);
            this.Controls.Add(this.comboxCamre);
            this.Controls.Add(this.btnSelectCamra);
            this.Controls.Add(this.btnInit);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.panelRemoteVideo.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnSelectCamra;
        private System.Windows.Forms.ComboBox comboxCamre;
        private System.Windows.Forms.Button btnStartCamera;
        private System.Windows.Forms.Panel previewPanel;
        private System.Windows.Forms.TextBox textRemoteIP;
        private System.Windows.Forms.Button btnMakeCall;
        private System.Windows.Forms.Panel panelRemoteVideo;
        private System.Windows.Forms.Button btnStopCall;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnInitCall;
        private System.Windows.Forms.Button btnStopPreview;
        //private SDLPreview sdlPreview;
    }
}

