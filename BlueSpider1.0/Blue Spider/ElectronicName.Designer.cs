namespace Blue_Spider
{
    partial class ElectronicName
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
            this.btn_start_name = new System.Windows.Forms.Button();
            this.list_electronic_name = new System.Windows.Forms.ListBox();
            this.list_title = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btn_start_name
            // 
            this.btn_start_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_start_name.Location = new System.Drawing.Point(14, 16);
            this.btn_start_name.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start_name.Name = "btn_start_name";
            this.btn_start_name.Size = new System.Drawing.Size(376, 26);
            this.btn_start_name.TabIndex = 10;
            this.btn_start_name.Text = "开始点名";
            this.btn_start_name.UseVisualStyleBackColor = false;
            this.btn_start_name.Click += new System.EventHandler(this.btn_start_name_Click);
            // 
            // list_electronic_name
            // 
            this.list_electronic_name.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.list_electronic_name.FormattingEnabled = true;
            this.list_electronic_name.ItemHeight = 12;
            this.list_electronic_name.Location = new System.Drawing.Point(14, 67);
            this.list_electronic_name.Margin = new System.Windows.Forms.Padding(2);
            this.list_electronic_name.Name = "list_electronic_name";
            this.list_electronic_name.Size = new System.Drawing.Size(378, 376);
            this.list_electronic_name.TabIndex = 25;
            // 
            // list_title
            // 
            this.list_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.list_title.FormattingEnabled = true;
            this.list_title.ItemHeight = 12;
            this.list_title.Items.AddRange(new object[] {
            "    学生IP               学生姓名               时间"});
            this.list_title.Location = new System.Drawing.Point(14, 54);
            this.list_title.Margin = new System.Windows.Forms.Padding(2);
            this.list_title.Name = "list_title";
            this.list_title.Size = new System.Drawing.Size(378, 16);
            this.list_title.TabIndex = 26;
            // 
            // ElectronicName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(407, 458);
            this.Controls.Add(this.list_title);
            this.Controls.Add(this.list_electronic_name);
            this.Controls.Add(this.btn_start_name);
            this.Name = "ElectronicName";
            this.Text = "电子点名";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElectronicName_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_start_name;
        private System.Windows.Forms.ListBox list_electronic_name;
        private System.Windows.Forms.ListBox list_title;
    }
}