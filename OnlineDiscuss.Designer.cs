namespace Blue_Spider
{
    partial class OnlineDiscuss
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
            this.lb_text_content = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_text_people = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lb_text_content
            // 
            this.lb_text_content.FormattingEnabled = true;
            this.lb_text_content.ItemHeight = 12;
            this.lb_text_content.Location = new System.Drawing.Point(6, 20);
            this.lb_text_content.Name = "lb_text_content";
            this.lb_text_content.Size = new System.Drawing.Size(459, 256);
            this.lb_text_content.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_text_content);
            this.groupBox1.Location = new System.Drawing.Point(19, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 288);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "群聊内容";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lb_text_people);
            this.groupBox2.Location = new System.Drawing.Point(511, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 288);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "参与人员";
            // 
            // lb_text_people
            // 
            this.lb_text_people.FormattingEnabled = true;
            this.lb_text_people.ItemHeight = 12;
            this.lb_text_people.Location = new System.Drawing.Point(10, 20);
            this.lb_text_people.Name = "lb_text_people";
            this.lb_text_people.Size = new System.Drawing.Size(139, 256);
            this.lb_text_people.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(22, 322);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(461, 50);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "textBox1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(511, 322);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 50);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // OnlineDiscuss
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 386);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "OnlineDiscuss";
            this.Text = "OnlineDiscuss";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnlineDiscuss_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_text_content;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lb_text_people;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
    }
}