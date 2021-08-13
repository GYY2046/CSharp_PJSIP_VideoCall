namespace friVideoCall
{
    partial class Video
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
            this.panelBack = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReject = new System.Windows.Forms.Button();
            this.btnAnswer = new System.Windows.Forms.Button();
            this.panelRemote = new System.Windows.Forms.Panel();
            this.panelLocal = new System.Windows.Forms.Panel();
            this.panelBack.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelRemote.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.AutoSize = true;
            this.panelBack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.panelBack.Controls.Add(this.tableLayoutPanel1);
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(858, 540);
            this.panelBack.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnReject, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnAnswer, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.panelRemote, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(858, 540);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnReject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReject.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReject.Image = global::friVideoCall.Properties.Resources.MTMS_V_Rejected;
            this.btnReject.Location = new System.Drawing.Point(3, 487);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(423, 50);
            this.btnReject.TabIndex = 1;
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnAnswer
            // 
            this.btnAnswer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(83)))), ((int)(((byte)(83)))));
            this.btnAnswer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnAnswer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAnswer.Image = global::friVideoCall.Properties.Resources.MTMS_V_Answer;
            this.btnAnswer.Location = new System.Drawing.Point(432, 487);
            this.btnAnswer.Name = "btnAnswer";
            this.btnAnswer.Size = new System.Drawing.Size(423, 50);
            this.btnAnswer.TabIndex = 1;
            this.btnAnswer.UseVisualStyleBackColor = false;
            this.btnAnswer.Click += new System.EventHandler(this.btnAnswer_Click);
            // 
            // panelRemote
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.panelRemote, 2);
            this.panelRemote.Controls.Add(this.panelLocal);
            this.panelRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRemote.Location = new System.Drawing.Point(0, 0);
            this.panelRemote.Margin = new System.Windows.Forms.Padding(0);
            this.panelRemote.Name = "panelRemote";
            this.panelRemote.Size = new System.Drawing.Size(858, 484);
            this.panelRemote.TabIndex = 2;
            this.panelRemote.Paint += new System.Windows.Forms.PaintEventHandler(this.panelRemote_Paint);
            this.panelRemote.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelRemote_MouseDown);
            // 
            // panelLocal
            // 
            this.panelLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panelLocal.BackColor = System.Drawing.Color.DimGray;
            this.panelLocal.Location = new System.Drawing.Point(675, 384);
            this.panelLocal.Margin = new System.Windows.Forms.Padding(0);
            this.panelLocal.Name = "panelLocal";
            this.panelLocal.Size = new System.Drawing.Size(180, 100);
            this.panelLocal.TabIndex = 1;
            this.panelLocal.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelLocal_MouseDown);
            this.panelLocal.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelLocal_MouseMove);
            // 
            // Video
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(858, 540);
            this.Controls.Add(this.panelBack);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Video";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Video";
            this.TopMost = true;
            this.panelBack.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelRemote.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        public System.Windows.Forms.Panel panelRemote;
        public System.Windows.Forms.Panel panelLocal;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnAnswer;
        private System.Windows.Forms.Button btnReject;
    }
}