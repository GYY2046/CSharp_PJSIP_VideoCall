namespace pjsua2_csharp_video_demo
{
    partial class VideoDemoForm
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
            this.btnInit = new System.Windows.Forms.Button();
            this.btnStartPreview = new System.Windows.Forms.Button();
            this.btnStopPreview = new System.Windows.Forms.Button();
            this.btnMakeCall = new System.Windows.Forms.Button();
            this.btnHangCall = new System.Windows.Forms.Button();
            this.btnDestroy = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(62, 23);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "初始化";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnStartPreview
            // 
            this.btnStartPreview.Location = new System.Drawing.Point(62, 66);
            this.btnStartPreview.Name = "btnStartPreview";
            this.btnStartPreview.Size = new System.Drawing.Size(75, 23);
            this.btnStartPreview.TabIndex = 1;
            this.btnStartPreview.Text = "启动摄像头";
            this.btnStartPreview.UseVisualStyleBackColor = true;
            this.btnStartPreview.Click += new System.EventHandler(this.btnStartPreview_Click);
            // 
            // btnStopPreview
            // 
            this.btnStopPreview.Location = new System.Drawing.Point(62, 267);
            this.btnStopPreview.Name = "btnStopPreview";
            this.btnStopPreview.Size = new System.Drawing.Size(75, 23);
            this.btnStopPreview.TabIndex = 2;
            this.btnStopPreview.Text = "关闭摄像头";
            this.btnStopPreview.UseVisualStyleBackColor = true;
            this.btnStopPreview.Click += new System.EventHandler(this.btnStopPreview_Click);
            // 
            // btnMakeCall
            // 
            this.btnMakeCall.Location = new System.Drawing.Point(62, 169);
            this.btnMakeCall.Name = "btnMakeCall";
            this.btnMakeCall.Size = new System.Drawing.Size(75, 23);
            this.btnMakeCall.TabIndex = 3;
            this.btnMakeCall.Text = "拨打电话";
            this.btnMakeCall.UseVisualStyleBackColor = true;
            this.btnMakeCall.Click += new System.EventHandler(this.btnMakeCall_Click);
            // 
            // btnHangCall
            // 
            this.btnHangCall.Location = new System.Drawing.Point(62, 223);
            this.btnHangCall.Name = "btnHangCall";
            this.btnHangCall.Size = new System.Drawing.Size(75, 23);
            this.btnHangCall.TabIndex = 4;
            this.btnHangCall.Text = "挂断电话";
            this.btnHangCall.UseVisualStyleBackColor = true;
            this.btnHangCall.Click += new System.EventHandler(this.btnHangCall_Click);
            // 
            // btnDestroy
            // 
            this.btnDestroy.Location = new System.Drawing.Point(62, 335);
            this.btnDestroy.Name = "btnDestroy";
            this.btnDestroy.Size = new System.Drawing.Size(75, 23);
            this.btnDestroy.TabIndex = 5;
            this.btnDestroy.Text = "注销";
            this.btnDestroy.UseVisualStyleBackColor = true;
            this.btnDestroy.Click += new System.EventHandler(this.btnDestroy_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.Location = new System.Drawing.Point(171, 169);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(75, 23);
            this.btnAnswer.TabIndex = 6;
            this.btnAnswer.Text = "接听电话";
            this.btnAnswer.UseVisualStyleBackColor = true;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // VideoDemoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 431);
            this.Controls.Add(this.btnAnswer);
            this.Controls.Add(this.btnDestroy);
            this.Controls.Add(this.btnHangCall);
            this.Controls.Add(this.btnMakeCall);
            this.Controls.Add(this.btnStopPreview);
            this.Controls.Add(this.btnStartPreview);
            this.Controls.Add(this.btnInit);
            this.Name = "VideoDemoForm";
            this.Text = "VideoDemoForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.Button btnStartPreview;
        private System.Windows.Forms.Button btnStopPreview;
        private System.Windows.Forms.Button btnMakeCall;
        private System.Windows.Forms.Button btnHangCall;
        private System.Windows.Forms.Button btnDestroy;
        private System.Windows.Forms.Button btnAnswer;
    }
}