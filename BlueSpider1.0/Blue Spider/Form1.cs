using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace Blue_Spider
{
    public partial class Form1 : Form
    {
        #region 对于socket的定义
        private Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket>();
        private TCP tcp;
        #endregion 对于socket的定义结束
        public Form1()
        {
            tcp = new TCP();
            InitializeComponent();
            clientConnectionItems = tcp.GetKeyValuePairs();
        }

        /// <summary>
        /// 联机讨论的功能实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtn_OnlineDiscuss_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                Console.WriteLine("IP：{0},Socket：{1}", socket.Key, socket.Value);
                socket.Value.Send(Encoding.UTF8.GetBytes("002"));
            }
            new OnlineDiscuss().ShowDialog();
        }

        /// <summary>
        /// 电子点名功能的实现
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsbtn_ElectronicName_Click(object sender, EventArgs e)
        {
            new ElectronicName(clientConnectionItems).ShowDialog();
        
        }

        /// <summary>
        /// 接收客户端传输来的消息的处理函数
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="message"></param>
        public static void ShowMessageBox(IPAddress ip, string message)
        {
            MessageBox.Show("IP地址为：" + ip + "\r\n" + "发来消息：" + message);
            //判断是否是举手行为
            MessageBox.Show(message.Substring(0, 3));
            switch (message.Substring(0, 3))
            {
                case "001":
                    MessageBox.Show("IP地址为：" + ip + "\r\n" + "发来举手请求：");
                    break;
                default:
                    break;
            }
        }

        private void btn_FileTransfer_Click(object sender, EventArgs e)
        {
            new FileTransfer_2().ShowDialog();
        }

        private void btn_quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
