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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_Homework = new System.Windows.Forms.ListBox();
            this.btn_Find = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_Find);
            this.groupBox2.Controls.Add(this.lb_Homework);
            this.groupBox2.Location = new System.Drawing.Point(12, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox2.Size = new System.Drawing.Size(531, 385);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "作业提交信息：";
            // 
            // lb_Homework
            // 
            this.lb_Homework.FormattingEnabled = true;
            this.lb_Homework.ItemHeight = 15;
            this.lb_Homework.Location = new System.Drawing.Point(6, 23);
            this.lb_Homework.Name = "lb_Homework";
            this.lb_Homework.Size = new System.Drawing.Size(519, 289);
            this.lb_Homework.TabIndex = 0;
            this.lb_Homework.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_Homework_MouseDoubleClick);
            // 
            // btn_Find
            // 
            this.btn_Find.Location = new System.Drawing.Point(164, 333);
            this.btn_Find.Name = "btn_Find";
            this.btn_Find.Size = new System.Drawing.Size(162, 37);
            this.btn_Find.TabIndex = 1;
            this.btn_Find.Text = "查看作业文件";
            this.btn_Find.UseVisualStyleBackColor = true;
            this.btn_Find.Click += new System.EventHandler(this.btn_Find_Click);
            // 
            // CheckHomework
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 393);
            this.Controls.Add(this.groupBox2);
            this.Name = "CheckHomework";
            this.Text = "作业提交状况";
            this.Load += new System.EventHandler(this.CheckHomework_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lb_Homework;
        private System.Windows.Forms.Button btn_Find;
    }
}