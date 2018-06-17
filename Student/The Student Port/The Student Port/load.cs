using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace The_Student_Port
{
    public partial class load : Form
    {
        public load()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Socket socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //连接服务器的IP地址  
            IPAddress address = IPAddress.Parse(textBox_teaAddr.Text);
            //将获取的IP地址和端口号绑定在网络节点上  
            IPEndPoint point = new IPEndPoint(address, 8989);
            try
            {
                //客户端套接字连接到网络节点上，用的是Connect  
                socketclient.Connect(point);
                new Form1(textBox_teaAddr.Text, socketclient).ShowDialog();
                //this.Close();
            }
            catch (Exception)
            {               
                MessageBox.Show("failed to connet,please try another addr");
            }
        }
    }
}
