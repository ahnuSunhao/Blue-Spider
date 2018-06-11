using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Blue_Spider
{
    public partial class OnlineDiscuss : Form
    {
        Socket socket;
        Thread recvThread;
        IPAddress address = IPAddress.Parse("234.5.6.7");
        IPEndPoint multiIPEndPoint;
        int x = 0;
        public OnlineDiscuss()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
            init();
            AddOnlineDiscuss();
        }
        /// <summary>
        /// 系统初始化操作
        /// </summary>
        private void init() {
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
        /// <summary>
        /// 加入-群聊
        /// </summary>
        private void AddOnlineDiscuss() {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes("#" + this.textBox1.Text);
            this.textBox1.Text = "";
            socket.SendTo(bytes, SocketFlags.None, multiIPEndPoint);
            x = 0;
        }
        /// <summary>
        /// 退出群聊
        /// </summary>
        private void CloseOnlineDiscuss() {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes("@" + this.textBox1.Text);
            this.textBox1.Text = "";
            socket.SendTo(bytes, SocketFlags.None, multiIPEndPoint);
            x = 1;
        }
        /// <summary>
        /// 接收消息
        /// </summary>
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
                        this.lb_text_content.Items.Add("[" + epAddress + "]进入。");
                        string str1 = "&:" + epAddress;
                        for (int i = 0; i < this.lb_text_people.Items.Count; i++)
                        {
                            str1 += ":" + this.lb_text_people.Items[i].ToString();
                        }
                        byte[] users = System.Text.Encoding.Unicode.GetBytes(str1);
                        socket.SendTo(users, SocketFlags.None, multiIPEndPoint);
                        break;
                    case '@':
                        this.lb_text_content.Items.Add("[" + epAddress + "]退出。");
                        this.lb_text_people.Items.Remove(epAddress);
                        break;
                    case '&':
                        string[] strArray = str.Split(':');
                        for (int i = 1; i < strArray.Length; i++)
                        {
                            bool isExist = false;
                            for (int j = 0; j < this.lb_text_people.Items.Count; j++)
                            {
                                if (strArray[i] == this.lb_text_people.Items[j].ToString())
                                {
                                    isExist = true;
                                    break;
                                }
                            }
                            if (isExist == false)
                            {
                                this.lb_text_people.Items.Add(strArray[i]);
                            }
                        }
                        break;
                    case '!':
                        this.lb_text_content.Items.Add("[" + epAddress + "]说：");
                        this.lb_text_content.Items.Add(str.Substring(1));
                        this.lb_text_content.SelectedIndex = this.lb_text_content.Items.Count - 1;

                        break;
                }
            }
        }
        /// <summary>
        /// 发送消息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (x == 0){
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
        /// <summary>
        /// 多人聊天的关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnlineDiscuss_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes("@");
            socket.SendTo(bytes, SocketFlags.None, multiIPEndPoint);
            recvThread.Abort();
            socket.Close();
        }
    }
}
