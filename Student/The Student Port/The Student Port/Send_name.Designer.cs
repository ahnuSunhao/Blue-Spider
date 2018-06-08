namespace The_Student_Port
{
    partial class Send_name
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btn_send_name = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "请输入你的姓名：";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(145, 27);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(171, 25);
            this.tb_name.TabIndex = 1;
            // 
            // btn_send_name
            // 
            this.btn_send_name.Location = new System.Drawing.Point(241, 80);
            this.btn_send_name.Name = "btn_send_name";
            this.btn_send_name.Size = new System.Drawing.Size(75, 23);
            this.btn_send_name.TabIndex = 2;
            this.btn_send_name.Text = "确定";
            this.btn_send_name.UseVisualStyleBackColor = true;
            // 
            // Send_name
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 132);
            this.Controls.Add(this.btn_send_name);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.label1);
            this.Name = "Send_name";
            this.Text = "Send_name";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_name;
        private System.Windows.Forms.Button btn_send_name;
    }
}