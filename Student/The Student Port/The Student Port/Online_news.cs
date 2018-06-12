using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Threading;
namespace The_Student_Port
{
    public partial class Online_news : Form
    {
        public static bool ss = true;
        Socket socket;
        Thread recvThread;
        IPAddress address = IPAddress.Parse("234.5.6.7");
        IPEndPoint multiIPEndPoint;
        public Online_news()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            this.textBox1.Text = "";
            multiIPEndPoint = new IPEndPoint(address, 6788);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Any, 6788);
            EndPoint ep = (EndPoint)iep;
            socket.Bind(ep);
            socket.SetSocketOption(SocketOptionLevel.IP,
                SocketOptionName.AddMembership, new MulticastOption(address));
            socket.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.MulticastTimeToLive, 32);
            recvThread = new Thread(new ThreadStart(ReceiveMessage));
            //设置该线程在后台运行
            recvThread.IsBackground = true;
            recvThread.Start();
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes("#");
            socket.SendTo(bytes, SocketFlags.None, multiIPEndPoint);
        }
        private void ReceiveMessage()
        {
            EndPoint ep = (EndPoint)multiIPEndPoint;
            byte[] bytes = new byte[1024];
            string str;
            int length;
            while (true)
            {
                length = socket.ReceiveFrom(bytes, ref ep);
                string epAddress = ep.ToString();
                epAddress = epAddress.Substring(0, epAddress.LastIndexOf(":"));
                str = System.Text.Encoding.Unicode.GetString(bytes, 0, length);
                switch (str[0])
                {
                    case '#':
                        lb_text_content.Items.Add("[" + epAddress + "]进入。");
                        string str1 = "&:" + epAddress;
                        for (int i = 0; i < lb_text_people.Items.Count; i++)
                        {
                            str1 += ":" + lb_text_people.Items[i].ToString();
                        }
                        byte[] users = System.Text.Encoding.Unicode.GetBytes(str1);
                        socket.SendTo(users, SocketFlags.None, multiIPEndPoint);
                        break;
                    case '@':
                        lb_text_content.Items.Add("[" + epAddress + "]退出。");
                        lb_text_people.Items.Remove(epAddress);
                        break;
                    case '&':
                        string[] strArray = str.Split(':');
                        for (int i = 1; i < strArray.Length; i++)
                        {
                            bool isExist = false;
                            for (int j = 0; j < lb_text_people.Items.Count; j++)
                            {
                                if (strArray[i] == lb_text_people.Items[j].ToString())
                                {
                                    isExist = true;
                                    break;
                                }
                            }
                            if (isExist == false)
                            {
                                lb_text_people.Items.Add(strArray[i]);
                            }
                        }
                        break;
                    case '!':
                        lb_text_content.Items.Add("[" + epAddress + "]说：");
                        lb_text_content.Items.Add(str.Substring(1));
                        lb_text_content.SelectedIndex = lb_text_content.Items.Count - 1;

                        break;
                }
            }
        }
        int x = 0;
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (x == 0)
            {

                if (this.textBox1.Text.Trim().Length > 0)
                {
                    byte[] bytes = System.Text.Encoding.Unicode.GetBytes("!" + this.textBox1.Text);
                    this.textBox1.Text = "";
                    socket.SendTo(bytes, SocketFlags.None, multiIPEndPoint);
                }
            }
            else
            {
                textBox1.Text = " ";
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Online_news_Load(object sender, EventArgs e)
        {

        }

        private void Online_news_FormClosing(object sender, FormClosingEventArgs e)
        {
            ss = false;
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes("@" + this.textBox1.Text);
            this.textBox1.Text = "";
            socket.SendTo(bytes, SocketFlags.None, multiIPEndPoint);
            x = 1;
            recvThread.Abort();
            socket.Close();

        }

       
    }
}
