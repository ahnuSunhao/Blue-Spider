namespace The_Student_Port
{
    partial class Sumbit_job
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.buttonfile = new System.Windows.Forms.Button();
            this.buttonsend = new System.Windows.Forms.Button();
            this.File = new System.Windows.Forms.TextBox();
            this.BeginClient = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(410, 25);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(158, 21);
            this.textBox1.TabIndex = 53;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(335, 34);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 52;
            this.label1.Text = "教师机：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Message);
            this.groupBox1.Location = new System.Drawing.Point(9, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(641, 319);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文件传输";
            // 
            // Message
            // 
            this.Message.Location = new System.Drawing.Point(5, 19);
            this.Message.Multiline = true;
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(627, 295);
            this.Message.TabIndex = 0;
            // 
            // buttonfile
            // 
            this.buttonfile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonfile.Location = new System.Drawing.Point(470, 396);
            this.buttonfile.Margin = new System.Windows.Forms.Padding(2);
            this.buttonfile.Name = "buttonfile";
            this.buttonfile.Size = new System.Drawing.Size(63, 28);
            this.buttonfile.TabIndex = 24;
            this.buttonfile.Text = "选择文件";
            this.buttonfile.UseVisualStyleBackColor = false;
            this.buttonfile.Click += new System.EventHandler(this.buttonfile_Click);
            // 
            // buttonsend
            // 
            this.buttonsend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.buttonsend.Location = new System.Drawing.Point(578, 397);
            this.buttonsend.Margin = new System.Windows.Forms.Padding(2);
            this.buttonsend.Name = "buttonsend";
            this.buttonsend.Size = new System.Drawing.Size(63, 27);
            this.buttonsend.TabIndex = 46;
            this.buttonsend.Text = "发送文件";
            this.buttonsend.UseVisualStyleBackColor = false;
            this.buttonsend.Click += new System.EventHandler(this.buttonsend_Click);
            // 
            // File
            // 
            this.File.Location = new System.Drawing.Point(42, 397);
            this.File.Multiline = true;
            this.File.Name = "File";
            this.File.Size = new System.Drawing.Size(390, 27);
            this.File.TabIndex = 55;
            // 
            // BeginClient
            // 
            this.BeginClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.BeginClient.Location = new System.Drawing.Point(587, 25);
            this.BeginClient.Margin = new System.Windows.Forms.Padding(2);
            this.BeginClient.Name = "BeginClient";
            this.BeginClient.Size = new System.Drawing.Size(63, 27);
            this.BeginClient.TabIndex = 47;
            this.BeginClient.Text = "连接";
            this.BeginClient.UseVisualStyleBackColor = false;
            this.BeginClient.Click += new System.EventHandler(this.BeginClient_Click);
            // 
            // Sumbit_job
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 459);
            this.Controls.Add(this.BeginClient);
            this.Controls.Add(this.File);
            this.Controls.Add(this.buttonsend);
            this.Controls.Add(this.buttonfile);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Sumbit_job";
            this.Text = "Sumbit_job";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button buttonfile;
        private System.Windows.Forms.Button buttonsend;
        private System.Windows.Forms.TextBox File;
        private System.Windows.Forms.Button BeginClient;
        private System.Windows.Forms.TextBox Message;
    }
}