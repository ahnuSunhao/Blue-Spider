using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;

namespace Blue_Spider
{
    public partial class screenCapturing : Form
    {
        private TcpListener tcp = null;
        private Socket socket = null;
        private NetworkStream ns = null;
        private StreamReader sr = null;
        private StreamWriter sw = null;
        private Thread tcpThread = null;

        private IPAddress aimSoc = null;

        private Dictionary<string, Socket> clientConnectionItems;

        private string hostName;
        private IPHostEntry localhost;
        private IPAddress localaddr;


        public screenCapturing(Dictionary<string, Socket> clientConnectionItems)
        {
            InitializeComponent();
            this.clientConnectionItems = clientConnectionItems;
            hostName = Dns.GetHostName();   //获取本机名
            localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址                                                       //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            localaddr = localhost.AddressList[0];
            textBox_adress.Text = localaddr.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
        }
        public void getRemote()
        {
            //IPAddress ip = IPAddress.Parse(textBox_adress.Text);//192.168.29.1

            //IPAddress ip = IPAddress.Parse("127.0.0.1");
            tcp = new TcpListener(localaddr, 8080);
            tcp.Start();
            socket = tcp.AcceptSocket();
            ns = new NetworkStream(socket);
            sr = new StreamReader(ns);
            sw = new StreamWriter(ns);
            if (socket.Connected)
            {
                try
                {
                    while (true)
                    {

                        byte[] b = new byte[1024 * 256];   //设置接收的大小 
                        int i = this.socket.Receive(b);//接收 
                        //把byte[]转化成内存流,在把内存流转化成Image, 
                        System.Drawing.Image myimage = System.Drawing.Image.FromStream(new MemoryStream(b));
                        this.Size = myimage.Size;
                        showScreen.Image = myimage; //显示 
                    }

                }
                catch (Exception ex)
                {
                    this.tcp.Stop();
                    MessageBox.Show("捕捉屏幕出错!server" + ex.Message);
                }
            }
        }

        private void btn_startMon_Click(object sender, EventArgs e)
        {
            aimSoc = IPAddress.Parse(textBox_adress.Text);
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                Console.WriteLine("IP：{0},Socket：{1}", socket.Key, socket.Value);
                if (socket.Key == textBox_adress.Text)
                {
                    socket.Value.Send(Encoding.UTF8.GetBytes("006"));
                    tcpThread = new Thread(new ThreadStart(getRemote));
                    tcpThread.Start();
                    break;
                }
            }
        }
    }
}
