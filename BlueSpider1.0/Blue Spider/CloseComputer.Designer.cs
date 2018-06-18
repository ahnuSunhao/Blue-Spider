namespace Blue_Spider
{
    partial class CloseComputer
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_onlineComputer = new System.Windows.Forms.ListBox();
            this.btn_CloseAll = new System.Windows.Forms.Button();
            this.pictureBox_select = new System.Windows.Forms.PictureBox();
            this.radioButton_black = new System.Windows.Forms.RadioButton();
            this.radioButton_back = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_select)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_onlineComputer);
            this.groupBox1.Location = new System.Drawing.Point(9, 10);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(266, 337);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可关机电脑：";
            // 
            // lb_onlineComputer
            // 
            this.lb_onlineComputer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_onlineComputer.FormattingEnabled = true;
            this.lb_onlineComputer.ItemHeight = 12;
            this.lb_onlineComputer.Location = new System.Drawing.Point(14, 19);
            this.lb_onlineComputer.Margin = new System.Windows.Forms.Padding(2);
            this.lb_onlineComputer.Name = "lb_onlineComputer";
            this.lb_onlineComputer.Size = new System.Drawing.Size(239, 304);
            this.lb_onlineComputer.TabIndex = 0;
            this.lb_onlineComputer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_onlineComputer_MouseDoubleClick);
            // 
            // btn_CloseAll
            // 
            this.btn_CloseAll.Location = new System.Drawing.Point(92, 354);
            this.btn_CloseAll.Margin = new System.Windows.Forms.Padding(2);
            this.btn_CloseAll.Name = "btn_CloseAll";
            this.btn_CloseAll.Size = new System.Drawing.Size(105, 34);
            this.btn_CloseAll.TabIndex = 1;
            this.btn_CloseAll.Text = "全部关机";
            this.btn_CloseAll.UseVisualStyleBackColor = true;
            this.btn_CloseAll.Click += new System.EventHandler(this.btn_CloseAll_Click);
            // 
            // pictureBox_select
            // 
            this.pictureBox_select.Location = new System.Drawing.Point(9, 352);
            this.pictureBox_select.Name = "pictureBox_select";
            this.pictureBox_select.Size = new System.Drawing.Size(100, 50);
            this.pictureBox_select.TabIndex = 3;
            this.pictureBox_select.TabStop = false;
            this.pictureBox_select.Visible = false;
            // 
            // radioButton_black
            // 
            this.radioButton_black.AutoSize = true;
            this.radioButton_black.Checked = true;
            this.radioButton_black.Location = new System.Drawing.Point(18, 359);
            this.radioButton_black.Name = "radioButton_black";
            this.radioButton_black.Size = new System.Drawing.Size(47, 16);
            this.radioButton_black.TabIndex = 4;
            this.radioButton_black.TabStop = true;
            this.radioButton_black.Text = "黑屏";
            this.radioButton_black.UseVisualStyleBackColor = true;
            this.radioButton_black.Visible = false;
            // 
            // radioButton_back
            // 
            this.radioButton_back.AutoSize = true;
            this.radioButton_back.Location = new System.Drawing.Point(18, 381);
            this.radioButton_back.Name = "radioButton_back";
            this.radioButton_back.Size = new System.Drawing.Size(71, 16);
            this.radioButton_back.TabIndex = 5;
            this.radioButton_back.Text = "解除黑屏";
            this.radioButton_back.UseVisualStyleBackColor = true;
            this.radioButton_back.Visible = false;
            // 
            // CloseComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(289, 420);
            this.Controls.Add(this.radioButton_back);
            this.Controls.Add(this.radioButton_black);
            this.Controls.Add(this.pictureBox_select);
            this.Controls.Add(this.btn_CloseAll);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "CloseComputer";
            this.Text = "CloseComputer";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_select)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_onlineComputer;
        private System.Windows.Forms.Button btn_CloseAll;
        private System.Windows.Forms.PictureBox pictureBox_select;
        private System.Windows.Forms.RadioButton radioButton_black;
        private System.Windows.Forms.RadioButton radioButton_back;
    }
}