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
            this.list_electronic_name = new System.Windows.Forms.ListBox();
            this.btn_start_name = new System.Windows.Forms.Button();
            this.list_title = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // list_electronic_name
            // 
            this.list_electronic_name.FormattingEnabled = true;
            this.list_electronic_name.ItemHeight = 12;
            this.list_electronic_name.Location = new System.Drawing.Point(8, 65);
            this.list_electronic_name.Name = "list_electronic_name";
            this.list_electronic_name.Size = new System.Drawing.Size(395, 148);
            this.list_electronic_name.Sorted = true;
            this.list_electronic_name.TabIndex = 0;
            // 
            // btn_start_name
            // 
            this.btn_start_name.Location = new System.Drawing.Point(8, 12);
            this.btn_start_name.Name = "btn_start_name";
            this.btn_start_name.Size = new System.Drawing.Size(396, 26);
            this.btn_start_name.TabIndex = 1;
            this.btn_start_name.Text = "开始点名";
            this.btn_start_name.UseVisualStyleBackColor = true;
            this.btn_start_name.Click += new System.EventHandler(this.btn_start_name_Click);
            // 
            // list_title
            // 
            this.list_title.FormattingEnabled = true;
            this.list_title.ItemHeight = 12;
            this.list_title.Location = new System.Drawing.Point(8, 48);
            this.list_title.Name = "list_title";
            this.list_title.Size = new System.Drawing.Size(395, 16);
            this.list_title.TabIndex = 2;
            // 
            // ElectronicName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 232);
            this.Controls.Add(this.list_title);
            this.Controls.Add(this.btn_start_name);
            this.Controls.Add(this.list_electronic_name);
            this.Name = "ElectronicName";
            this.Text = "ElectronicName";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ElectronicName_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox list_electronic_name;
        private System.Windows.Forms.Button btn_start_name;
        private System.Windows.Forms.ListBox list_title;
    }
}