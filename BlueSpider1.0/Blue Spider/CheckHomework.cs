using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blue_Spider
{
    public partial class CheckHomework : Form
    {
        public CheckHomework()
        {
            InitializeComponent();
        }

        private void CheckHomework_Load(object sender, EventArgs e)
        {
            //修改文件所在位置即可
            DirectoryInfo TheFolder = new DirectoryInfo(@"E:/");
            //遍历文件
            foreach (FileInfo NextFile in TheFolder.GetFiles())
                this.lb_Homework.Items.Add(NextFile.Name);
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"E:\");
        }

        private void lb_Homework_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start(@"E:\" + lb_Homework.Text);
        }
    }
}
