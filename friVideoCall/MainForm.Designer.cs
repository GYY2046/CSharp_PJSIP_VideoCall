namespace friVideoCall
{
    partial class MainForm
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
            this.txtRemoteIP = new System.Windows.Forms.TextBox();
            this.btnMakeCall = new System.Windows.Forms.Button();
            this.btnHangUp = new System.Windows.Forms.Button();
            this.txtLocalIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGetVoice = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lVolume = new System.Windows.Forms.Label();
            this.btnSetVolume = new System.Windows.Forms.Button();
            this.btnPlay = new System.Windows.Forms.Button();
            this.btnStopPlay = new System.Windows.Forms.Button();
            this.btnGetMic = new System.Windows.Forms.Button();
            this.btnSetMic = new System.Windows.Forms.Button();
            this.lMic = new System.Windows.Forms.Label();
            this.btnShowPrev = new System.Windows.Forms.Button();
            this.btnHide = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCanmerName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtRemoteIP
            // 
            this.txtRemoteIP.Location = new System.Drawing.Point(64, 91);
            this.txtRemoteIP.Name = "txtRemoteIP";
            this.txtRemoteIP.Size = new System.Drawing.Size(100, 21);
            this.txtRemoteIP.TabIndex = 0;
            this.txtRemoteIP.Text = "169.254.105.220";
            // 
            // btnMakeCall
            // 
            this.btnMakeCall.Location = new System.Drawing.Point(64, 227);
            this.btnMakeCall.Name = "btnMakeCall";
            this.btnMakeCall.Size = new System.Drawing.Size(75, 23);
            this.btnMakeCall.TabIndex = 1;
            this.btnMakeCall.Text = "拨打";
            this.btnMakeCall.UseVisualStyleBackColor = true;
            this.btnMakeCall.Click += new System.EventHandler(this.btnMakeCall_Click);
            // 
            // btnHangUp
            // 
            this.btnHangUp.Location = new System.Drawing.Point(64, 329);
            this.btnHangUp.Name = "btnHangUp";
            this.btnHangUp.Size = new System.Drawing.Size(75, 23);
            this.btnHangUp.TabIndex = 2;
            this.btnHangUp.Text = "挂断";
            this.btnHangUp.UseVisualStyleBackColor = true;
            this.btnHangUp.Click += new System.EventHandler(this.btnHangUp_Click);
            // 
            // txtLocalIP
            // 
            this.txtLocalIP.Location = new System.Drawing.Point(64, 42);
            this.txtLocalIP.Name = "txtLocalIP";
            this.txtLocalIP.Size = new System.Drawing.Size(100, 21);
            this.txtLocalIP.TabIndex = 3;
            this.txtLocalIP.Text = "169.254.119.169";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "本机：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "远端：";
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(64, 278);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer.TabIndex = 6;
            this.btnAnswer.Text = "接听";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(64, 174);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 7;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(64, 398);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 8;
            this.btnClose.Text = "销毁";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGetVoice
            // 
            this.btnGetVoice.Location = new System.Drawing.Point(249, 147);
            this.btnGetVoice.Name = "btnGetVoice";
            this.btnGetVoice.Size = new System.Drawing.Size(75, 23);
            this.btnGetVoice.TabIndex = 9;
            this.btnGetVoice.Text = "获得音量";
            this.btnGetVoice.UseVisualStyleBackColor = true;
            this.btnGetVoice.Click += new System.EventHandler(this.btnGetVoice_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(358, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 12);
            this.label3.TabIndex = 10;
            // 
            // lVolume
            // 
            this.lVolume.AutoSize = true;
            this.lVolume.Location = new System.Drawing.Point(348, 153);
            this.lVolume.Name = "lVolume";
            this.lVolume.Size = new System.Drawing.Size(41, 12);
            this.lVolume.TabIndex = 11;
            this.lVolume.Text = "音量：";
            // 
            // btnSetVolume
            // 
            this.btnSetVolume.Location = new System.Drawing.Point(446, 142);
            this.btnSetVolume.Name = "btnSetVolume";
            this.btnSetVolume.Size = new System.Drawing.Size(75, 23);
            this.btnSetVolume.TabIndex = 12;
            this.btnSetVolume.Text = "设置音量";
            this.btnSetVolume.UseVisualStyleBackColor = true;
            this.btnSetVolume.Click += new System.EventHandler(this.btnSetVolume_Click);
            // 
            // btnPlay
            // 
            this.btnPlay.Location = new System.Drawing.Point(249, 94);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Size = new System.Drawing.Size(75, 23);
            this.btnPlay.TabIndex = 13;
            this.btnPlay.Text = "播放";
            this.btnPlay.UseVisualStyleBackColor = true;
            this.btnPlay.Click += new System.EventHandler(this.btnPlay_Click);
            // 
            // btnStopPlay
            // 
            this.btnStopPlay.Location = new System.Drawing.Point(360, 94);
            this.btnStopPlay.Name = "btnStopPlay";
            this.btnStopPlay.Size = new System.Drawing.Size(75, 23);
            this.btnStopPlay.TabIndex = 14;
            this.btnStopPlay.Text = "停止播放";
            this.btnStopPlay.UseVisualStyleBackColor = true;
            this.btnStopPlay.Click += new System.EventHandler(this.btnStopPlay_Click);
            // 
            // btnGetMic
            // 
            this.btnGetMic.Location = new System.Drawing.Point(249, 227);
            this.btnGetMic.Name = "btnGetMic";
            this.btnGetMic.Size = new System.Drawing.Size(75, 23);
            this.btnGetMic.TabIndex = 15;
            this.btnGetMic.Text = "麦克风级别";
            this.btnGetMic.UseVisualStyleBackColor = true;
            this.btnGetMic.Click += new System.EventHandler(this.btnGetMic_Click);
            // 
            // btnSetMic
            // 
            this.btnSetMic.Location = new System.Drawing.Point(446, 227);
            this.btnSetMic.Name = "btnSetMic";
            this.btnSetMic.Size = new System.Drawing.Size(75, 23);
            this.btnSetMic.TabIndex = 16;
            this.btnSetMic.Text = "设置麦克风";
            this.btnSetMic.UseVisualStyleBackColor = true;
            this.btnSetMic.Click += new System.EventHandler(this.btnSetMic_Click);
            // 
            // lMic
            // 
            this.lMic.AutoSize = true;
            this.lMic.Location = new System.Drawing.Point(348, 232);
            this.lMic.Name = "lMic";
            this.lMic.Size = new System.Drawing.Size(41, 12);
            this.lMic.TabIndex = 17;
            this.lMic.Text = "级别：";
            // 
            // btnShowPrev
            // 
            this.btnShowPrev.Location = new System.Drawing.Point(249, 278);
            this.btnShowPrev.Name = "btnShowPrev";
            this.btnShowPrev.Size = new System.Drawing.Size(75, 23);
            this.btnShowPrev.TabIndex = 18;
            this.btnShowPrev.Text = "显示预览";
            this.btnShowPrev.UseVisualStyleBackColor = true;
            this.btnShowPrev.Click += new System.EventHandler(this.btnShowPrev_Click);
            // 
            // btnHide
            // 
            this.btnHide.Location = new System.Drawing.Point(249, 329);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(75, 23);
            this.btnHide.TabIndex = 19;
            this.btnHide.Text = "隐藏预览";
            this.btnHide.UseVisualStyleBackColor = true;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 20;
            this.label4.Text = "摄像头：";
            // 
            // txtCanmerName
            // 
            this.txtCanmerName.Location = new System.Drawing.Point(64, 139);
            this.txtCanmerName.Name = "txtCanmerName";
            this.txtCanmerName.Size = new System.Drawing.Size(179, 21);
            this.txtCanmerName.TabIndex = 21;
            this.txtCanmerName.Text = "Integrated Camera";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCanmerName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnHide);
            this.Controls.Add(this.btnShowPrev);
            this.Controls.Add(this.lMic);
            this.Controls.Add(this.btnSetMic);
            this.Controls.Add(this.btnGetMic);
            this.Controls.Add(this.btnStopPlay);
            this.Controls.Add(this.btnPlay);
            this.Controls.Add(this.btnSetVolume);
            this.Controls.Add(this.lVolume);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnGetVoice);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnInit);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocalIP);
            this.Controls.Add(this.btnHangUp);
            this.Controls.Add(this.btnMakeCall);
            this.Controls.Add(this.txtRemoteIP);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRemoteIP;
        private System.Windows.Forms.Button btnMakeCall;
        private System.Windows.Forms.Button btnHangUp;
        private System.Windows.Forms.TextBox txtLocalIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGetVoice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lVolume;
        private System.Windows.Forms.Button btnSetVolume;
        private System.Windows.Forms.Button btnPlay;
        private System.Windows.Forms.Button btnStopPlay;
        private System.Windows.Forms.Button btnGetMic;
        private System.Windows.Forms.Button btnSetMic;
        private System.Windows.Forms.Label lMic;
        private System.Windows.Forms.Button btnShowPrev;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCanmerName;
    }
}