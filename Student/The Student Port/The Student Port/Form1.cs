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


namespace The_Student_Port
{
    public partial class Form1 : Form
    {
         static string shou="";
         Thread threadclient = null;
         Socket socketclient = null;
         private string strRevMsg = " ";
         public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            //关闭对文本框的非法线程操作检查  
            TextBox.CheckForIllegalCrossThreadCalls = false;
            init();
           // MessageBox.Show(shou);
             
           
        }

        private void init() {
            socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //连接服务器的IP地址  
            IPAddress address = IPAddress.Parse("192.168.43.179");
            //将获取的IP地址和端口号绑定在网络节点上  
            IPEndPoint point = new IPEndPoint(address, 8989);
            try
            {
                //客户端套接字连接到网络节点上，用的是Connect  
                socketclient.Connect(point);

            }
            catch (Exception)
            {
                Debug.WriteLine("连接失败\r\n");
                return;

            }
            threadclient = new Thread(ReceiveFromServer);
            threadclient.IsBackground = true;          
            threadclient.Start();
           
       
        }
        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            if (shou.Equals("002"))
                {
                    Online_news ol = new Online_news();
                    ol.Show();      
               }
                else
                    MessageBox.Show("老师没开启权限");
            
          
        }
        private void sendname()
        {
           
        }
        private void ReceiveFromServer()
        {
            int x = 0;
            //持续监听服务端发来的消息 
            
            while (true)
            {
                try
                {
                    //定义一个1M的内存缓冲区，用于临时性存储接收到的消息  
                    byte[] arrRecvmsg = new byte[1024 * 1024];

                    //将客户端套接字接收到的数据存入内存缓冲区，并获取长度  
                    int length = socketclient.Receive(arrRecvmsg);

                    //将套接字获取到的字符数组转换为人可以看懂的字符串  
                    strRevMsg = Encoding.UTF8.GetString(arrRecvmsg, 0, length);
                    shou=strRevMsg;
                   // MessageBox.Show(shou);
                    if (shou.Equals("002"))
                    {
                        MessageBox.Show("老师开启群聊");
                    }          
                    if (x == 1)
                    {
                        Debug.WriteLine("服务器:" + GetCurrentTime() + "\r\n" + strRevMsg + "\r\n\n");
                    }
                    else
                    {

                        Debug.WriteLine(strRevMsg + "\r\n\n");
                        x = 1;
                    }


                }
                catch (Exception ex)
                {
                    Debug.WriteLine("远程服务器已经中断连接" + "\r\n\n" + ex.ToString() + "\r\n\n");
                    break;
                }

            }
        }

        private DateTime GetCurrentTime()
        {
            DateTime currentTime = new DateTime();
            currentTime = DateTime.Now;
            return currentTime;
        }

      

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.ClientSendMsg("001");
          
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
          Sumbit_job job = new Sumbit_job();
            job.Show();
        }
        public void ClosWindow()
        {
            System.Diagnostics.Process bootProcess = new System.Diagnostics.Process();
            bootProcess.StartInfo.FileName = "shutdown";
            bootProcess.StartInfo.Arguments = "/s";
            bootProcess.Start();

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (shou.Equals("003"))
            {
                
                Send_name send = new Send_name();
                send.Show();
                timer1.Enabled = false;
            }
            if (shou.Equals("005"))
            {

                ClosWindow();
                timer1.Enabled = false;
            }
            if (shou.Equals("006"))
            {

                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       
       

    }
}
