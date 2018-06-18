using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace The_Student_Port
{
    public partial class blackScreen : Form
    {
        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);


        public blackScreen()
        {
            InitializeComponent();
        }

        private void blackScreen_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
        }
    }
}
