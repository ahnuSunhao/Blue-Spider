namespace Blue_Spider
{
    partial class CheckHomework
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
            this.lb_Homework = new System.Windows.Forms.ListBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Homework);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(611, 383);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "作业提交信息：";
            // 
            // lb_Homework
            // 
            this.lb_Homework.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_Homework.FormattingEnabled = true;
            this.lb_Homework.ItemHeight = 15;
            this.lb_Homework.Location = new System.Drawing.Point(6, 22);
            this.lb_Homework.Name = "lb_Homework";
            this.lb_Homework.Size = new System.Drawing.Size(597, 349);
            this.lb_Homework.TabIndex = 0;
            // 
            // btn_Find
            // 
            this.btn_Find.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_Find.Location = new System.Drawing.Point(231, 410);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(168, 40);
            this.btn_Find.TabIndex = 1;
            this.btn_Find.Text = "查看作业文件";
            this.btn_Find.UseVisualStyleBackColor = false;
            // 
            // CheckHomework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 462);
            this.Controls.Add(this.btn_Find);
            this.Controls.Add(this.groupBox1);
            this.Name = "CheckHomework";
            this.Text = "作业提交状况";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_Homework;
        private System.Windows.Forms.Button btn_Find;
    }
}