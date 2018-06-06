using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Blue_Spider
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tsbtn_OnlineDiscuss_Click(object sender, EventArgs e)
        {
            new OnlineDiscuss().ShowDialog();
        }

        private void tsbtn_ElectronicName_Click(object sender, EventArgs e)
        {
            new ElectronicName().ShowDialog();
        }

        private void btn_FileTransfer_Click(object sender, EventArgs e)
        {
            new file_transfer_1().ShowDialog();
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
