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
            this.lb_OnlineComputer = new System.Windows.Forms.ListBox();
            this.btn_CloseAll = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_OnlineComputer);
            this.groupBox1.Location = new System.Drawing.Point(9, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(336, 382);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "可关机电脑：";
            // 
            // lb_OnlineComputer
            // 
            this.lb_OnlineComputer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.lb_OnlineComputer.FormattingEnabled = true;
            this.lb_OnlineComputer.ItemHeight = 15;
            this.lb_OnlineComputer.Location = new System.Drawing.Point(20, 22);
            this.lb_OnlineComputer.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lb_OnlineComputer.Name = "lb_OnlineComputer";
            this.lb_OnlineComputer.Size = new System.Drawing.Size(293, 349);
            this.lb_OnlineComputer.TabIndex = 0;
            this.lb_OnlineComputer.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lb_OnlineComputer_MouseDoubleClick);
            // 
            // btn_CloseAll
            // 
            this.btn_CloseAll.Location = new System.Drawing.Point(118, 398);
            this.btn_CloseAll.Name = "btn_CloseAll";
            this.btn_CloseAll.Size = new System.Drawing.Size(106, 38);
            this.btn_CloseAll.TabIndex = 2;
            this.btn_CloseAll.Text = "全部关机";
            this.btn_CloseAll.UseVisualStyleBackColor = true;
            this.btn_CloseAll.Click += new System.EventHandler(this.btn_CloseAll_Click);
            // 
            // CloseComputer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 440);
            this.Controls.Add(this.btn_CloseAll);
            this.Controls.Add(this.groupBox1);
            this.Name = "CloseComputer";
            this.Text = "CloseComputer";
           
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lb_OnlineComputer;
        private System.Windows.Forms.Button btn_CloseAll;
    }
}