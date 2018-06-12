namespace The_Student_Port
{
    partial class Online_news
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
            this.btn_send = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_text_people = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_text_content = new System.Windows.Forms.ListBox();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.btn_send.Location = new System.Drawing.Point(473, 313);
            this.btn_send.Margin = new System.Windows.Forms.Padding(2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(104, 32);
            this.btn_send.TabIndex = 8;
            this.btn_send.Text = "发送";
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(21, 313);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(409, 30);
            this.textBox1.TabIndex = 7;
            this.textBox1.Text = "textBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_text_people);
            this.groupBox2.Location = new System.Drawing.Point(460, 21);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(154, 274);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参与人员";
            // 
            // lb_text_people
            // 
            this.lb_text_people.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_text_people.FormattingEnabled = true;
            this.lb_text_people.ItemHeight = 12;
            this.lb_text_people.Location = new System.Drawing.Point(4, 19);
            this.lb_text_people.Margin = new System.Windows.Forms.Padding(2);
            this.lb_text_people.Name = "lb_text_people";
            this.lb_text_people.Size = new System.Drawing.Size(146, 244);
            this.lb_text_people.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_text_content);
            this.groupBox1.Location = new System.Drawing.Point(21, 21);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(422, 274);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "群聊内容";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_text_content
            // 
            this.lb_text_content.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_text_content.FormattingEnabled = true;
            this.lb_text_content.ItemHeight = 12;
            this.lb_text_content.Location = new System.Drawing.Point(0, 19);
            this.lb_text_content.Margin = new System.Windows.Forms.Padding(2);
            this.lb_text_content.Name = "lb_text_content";
            this.lb_text_content.Size = new System.Drawing.Size(414, 244);
            this.lb_text_content.TabIndex = 0;
            // 
            // Online_news
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 365);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Online_news";
            this.Text = "Online_news";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Online_news_FormClosing);
            this.Load += new System.EventHandler(this.Online_news_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lb_text_people;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_text_content;

    }
}