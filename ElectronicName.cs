using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Blue_Spider
{
    public partial class ElectronicName : Form
    {
        /// <summary>
        /// 电子点名的功能实现：采用UDP编程，通过广播的方式向所有的学生端发送指令
        /// 电子点名功能的端口实现：7788
        /// </summary>
        private Socket socket;
        private int count = 0;
        private Dictionary<string, Socket> clientConnectionItems ;

        public ElectronicName(Dictionary<string, Socket> clientConnectionItems)
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            this.clientConnectionItems = clientConnectionItems;
            list_title.Items.Add("    学生IP" +"          "+
                "   学生姓名" + "           " + 
                "   时间" 
                );
            
        }
        /// <summary>
        /// 电子点名的初始化操作（端口号为8888）
        /// </summary>
        private void initElectroinc() {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);//初始化一个Scoket实习,采用UDP传输
            socket.SetSocketOption(SocketOptionLevel.Socket,SocketOptionName.Broadcast,1);
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse("192.168.1.100"), 8888);

            Thread thread = new Thread(new ThreadStart(ReceiveElecMessage));
            thread.IsBackground = true;
            thread.Start();

        }
        /// <summary>
        /// UDP 接收数据
        /// </summary>
        private void ReceiveElecMessage()
        {
            UdpClient clientRec = new UdpClient(new IPEndPoint(IPAddress.Any, 8888));
            IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
            while (true)
            {
                if ((list_electronic_name.Items.Count == count) && count > 0)
                {
                    MessageBox.Show("点名已结束");
                }
                else
                {
                    byte[] buffer = clientRec.Receive(ref endpoint);
                    string msg = Encoding.UTF8.GetString(buffer);
                    list_electronic_name.Items.Add(endpoint.ToString().Substring(0, endpoint.ToString().IndexOf(":")) + "           " +
                        msg + "          " +
                        GetCurrentTime() + "");
                }
            }
        }

        /// <summary>
        /// 开始点名
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_start_name_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                socket.Value.Send(Encoding.UTF8.GetBytes("003"));
                count++;
            }
            initElectroinc();
            MessageBox.Show("点名信息已发送");
        }

        private void ElectronicName_FormClosing(object sender, FormClosingEventArgs e)
        {
            socket.Close();
        }

        /// <summary>
        /// 获取当前系统时间 
        /// return time
        /// </summary>
        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }
    }
}
