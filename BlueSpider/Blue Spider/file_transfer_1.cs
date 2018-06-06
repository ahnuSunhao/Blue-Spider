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
    public partial class file_transfer_1 : Form
    {
        public file_transfer_1()
        {
            InitializeComponent();
        }

        private void btn_continue_Click(object sender, EventArgs e)
        {
            new file_transfer_2().ShowDialog();
        }
    }
}
