﻿namespace Blue_Spider
{
    partial class FileTransfer_2
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
            this.btn_SendN = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_send1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.File = new System.Windows.Forms.TextBox();
            this.lb_IPPort = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_SendN
            // 
            this.btn_SendN.BackColor = System.Drawing.Color.Tan;
            this.btn_SendN.Location = new System.Drawing.Point(545, 363);
            this.btn_SendN.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_SendN.Name = "btn_SendN";
            this.btn_SendN.Size = new System.Drawing.Size(114, 27);
            this.btn_SendN.TabIndex = 29;
            this.btn_SendN.Text = "发送文件（1:N）";
            this.btn_SendN.UseVisualStyleBackColor = false;
            this.btn_SendN.Click += new System.EventHandler(this.btn_SendN_Click);
            // 
            // btn_select
            // 
            this.btn_select.BackColor = System.Drawing.Color.Silver;
            this.btn_select.Location = new System.Drawing.Point(330, 363);
            this.btn_select.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(67, 27);
            this.btn_select.TabIndex = 28;
            this.btn_select.Text = "选择文件";
            this.btn_select.UseVisualStyleBackColor = false;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_send1
            // 
            this.btn_send1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_send1.Location = new System.Drawing.Point(417, 363);
            this.btn_send1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_send1.Name = "btn_send1";
            this.btn_send1.Size = new System.Drawing.Size(107, 27);
            this.btn_send1.TabIndex = 27;
            this.btn_send1.Text = "发送文件（1:1）";
            this.btn_send1.UseVisualStyleBackColor = false;
            this.btn_send1.Click += new System.EventHandler(this.btn_send1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 21);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "接收文件的学生：";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Message);
            this.groupBox2.Location = new System.Drawing.Point(232, 26);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(428, 300);
            this.groupBox2.TabIndex = 34;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件传输状态：";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(13, 18);
            this.Message.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(387, 270);
            this.Message.TabIndex = 27;
            // 
            // File
            // 
            this.File.Font = new System.Drawing.Font("宋体", 12F);
            this.File.Location = new System.Drawing.Point(9, 363);
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(295, 26);
            this.File.TabIndex = 36;
            // 
            // lb_IPPort
            // 
            this.lb_IPPort.FormattingEnabled = true;
            this.lb_IPPort.ItemHeight = 12;
            this.lb_IPPort.Location = new System.Drawing.Point(9, 44);
            this.lb_IPPort.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lb_IPPort.Name = "lb_IPPort";
            this.lb_IPPort.Size = new System.Drawing.Size(208, 280);
            this.lb_IPPort.TabIndex = 37;
            this.lb_IPPort.MouseCaptureChanged += new System.EventHandler(this.lb_IPPort_MouseCaptureChanged);
            // 
            // FileTransfer_2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(687, 417);
            this.Controls.Add(this.lb_IPPort);
            this.Controls.Add(this.File);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btn_SendN);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_send1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FileTransfer_2";
            this.Text = "文件传输_2";
            this.Load += new System.EventHandler(this.FileTransfer_2_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_SendN;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_send1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.TextBox File;
        private System.Windows.Forms.ListBox lb_IPPort;
    }
}