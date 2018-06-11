using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
namespace The_Student_Port
{
    public partial class Send_name : Form
    {
        private UdpClient client;
        private IPEndPoint endpoint;
        private IPEndPoint iep;
        private Socket socket;
        public Send_name()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            initUDP();

        }
        private void initUDP()
        {
            TextBox.CheckForIllegalCrossThreadCalls = false;
            iep = new IPEndPoint(IPAddress.Parse("192.168.1.106"), 8888);//初始化一个发送广播和指定端口的网络端口实例
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//初始化一个Scoket实习,采用UDP传输
        }
        /// <summary>
        /// 发送代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_send_name_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_stu_name.Text))
            {
                MessageBox.Show("输入错误");
            }
            else
            {
                byte[] bytes = Encoding.UTF8.GetBytes(txt_stu_name.Text);
                socket.SendTo(bytes, iep);
                MessageBox.Show("点名成功");
                socket.Close();
                this.Close();
            }
        }

       
    }
}

