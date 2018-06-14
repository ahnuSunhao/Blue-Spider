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
            this.btn_CloseAll = new System.Windows.Forms.Button();
            this.lb_onlineComputer = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_onlineComputer);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(355, 421);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可关机电脑：";
            // 
            // btn_CloseAll
            // 
            this.btn_CloseAll.Location = new System.Drawing.Point(117, 444);
            this.btn_CloseAll.Name = "btn_CloseAll";
            this.btn_CloseAll.Size = new System.Drawing.Size(140, 43);
            this.btn_CloseAll.TabIndex = 1;
            this.btn_CloseAll.Text = "全部关机";
            this.btn_CloseAll.UseVisualStyleBackColor = true;
            // 
            // lb_onlineComputer
            // 
            this.lb_onlineComputer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_onlineComputer.FormattingEnabled = true;
            this.lb_onlineComputer.ItemHeight = 15;
            this.lb_onlineComputer.Location = new System.Drawing.Point(18, 24);
            this.lb_onlineComputer.Name = "lb_onlineComputer";
            this.lb_onlineComputer.Size = new System.Drawing.Size(317, 379);
            this.lb_onlineComputer.TabIndex = 0;
            // 
            // CloseComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 499);
            this.Controls.Add(this.btn_CloseAll);
            this.Controls.Add(this.groupBox1);
            this.Name = "CloseComputer";
            this.Text = "CloseComputer";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_onlineComputer;
        private System.Windows.Forms.Button btn_CloseAll;
    }
}