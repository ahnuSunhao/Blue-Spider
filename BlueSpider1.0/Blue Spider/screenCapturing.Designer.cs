namespace Blue_Spider
{
    partial class screenCapturing
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
            this.showScreen = new System.Windows.Forms.PictureBox();
            this.btn_startMon = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_adress = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.showScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // showScreen
            // 
            this.showScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.showScreen.Location = new System.Drawing.Point(0, 0);
            this.showScreen.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.showScreen.Name = "showScreen";
            this.showScreen.Size = new System.Drawing.Size(707, 595);
            this.showScreen.TabIndex = 0;
            this.showScreen.TabStop = false;
            // 
            // btn_startMon
            // 
            this.btn_startMon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btn_startMon.Location = new System.Drawing.Point(384, 26);
            this.btn_startMon.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_startMon.Name = "btn_startMon";
            this.btn_startMon.Size = new System.Drawing.Size(100, 29);
            this.btn_startMon.TabIndex = 1;
            this.btn_startMon.Text = "监视";
            this.btn_startMon.UseVisualStyleBackColor = false;
            this.btn_startMon.Click += new System.EventHandler(this.btn_startMon_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 31);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "地址:";
            // 
            // textBox_adress
            // 
            this.textBox_adress.Location = new System.Drawing.Point(88, 26);
            this.textBox_adress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox_adress.Name = "textBox_adress";
            this.textBox_adress.Size = new System.Drawing.Size(268, 25);
            this.textBox_adress.TabIndex = 3;
            // 
            // screenCapturing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 595);
            this.Controls.Add(this.textBox_adress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_startMon);
            this.Controls.Add(this.showScreen);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "screenCapturing";
            this.Text = "screenCapturing";
            ((System.ComponentModel.ISupportInitialize)(this.showScreen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox showScreen;
        private System.Windows.Forms.Button btn_startMon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_adress;
    }
}