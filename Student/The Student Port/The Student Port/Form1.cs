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
using System.Runtime.InteropServices;


namespace The_Student_Port
{
    public partial class Form1 : Form
    {
         static string shou="";
         Thread threadclient = null;
         Socket socketclient = null;
         private string strRevMsg = " ";
         private string teaAddr = null;
         private NetworkStream ns = null;
         private StreamReader sr = null;
         private StreamWriter sw = null;
         private Thread tcpThread = null;
         private TcpClient tcpclient = null;
         MemoryStream ms = null;
         bool isCon = false;
         bool isError = false;


         public Form1(string teaAddr , Socket socket)
         {
             InitializeComponent();
             StartPosition = FormStartPosition.CenterScreen;
             //关闭对文本框的非法线程操作检查  
             TextBox.CheckForIllegalCrossThreadCalls = false;

             this.teaAddr = teaAddr;
             this.socketclient = socket;

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
            byte[] arrClientSendMsg = Encoding.UTF8.GetBytes("001");
            //调用客户端套接字发送字节数组     
            socketclient.Send(arrClientSendMsg);
          
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
                
                Send_name send = new Send_name(teaAddr);
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
                if (!isCon)
                {
                    con();
                    if (!isError)
                    {
                        timer1.Enabled = false;
                        tcpThread = new Thread(new ThreadStart(connect));
                        tcpThread.Start();

                    }
                    isError = false;
                }
            }
            if (shou.Equals("007"))
            {
                blackScreen();
                //timer1.Enabled = false;
            }
            if (shou.Equals("008"))
            {
                backScreen();
                //timer1.Enabled = false;
            }
        }

        public void connect()
        {
            try
            {
                while (true)
                {
                    capture();
                }
            }
            catch (Exception ex)
            {
                //   MessageBox.Show(ex.Message); 
                //   MessageBox.Show("错误!===\\\\"+ex.Message ); 
                sw.Dispose();
                sr.Dispose();
                ns.Dispose();
                isCon = false;
                isError = false;
                timer1.Enabled = true;
                //this.label1.Text += "远程主机被断开~!";
            }
        }

        public void con()
        {
            try
            {
                tcpclient = new TcpClient();
                tcpclient.Connect(teaAddr, 8080);//127.0.0.1
                if (tcpclient.Connected)
                {
                    ns = tcpclient.GetStream();
                    sr = new StreamReader(ns);
                    sw = new StreamWriter(ns);
                    isCon = true;
                    //this.label1.Text += "连接成功\r\n";
                }
                //isError = true; 
            }
            catch
            {
                isError = true;
                //this.label1.Text += "连接失败!\r\n";
                MessageBox.Show("连接失败!\r\n");
            }
        }


        blackScreen b;
        int flag_black = 0;
        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);

        public void blackScreen()
        {
            if (flag_black == 0)
            {
                flag_black++;
                BlockInput(true);
                b = new blackScreen();
                b.ShowDialog();
            }
            

        }

        public void backScreen()
        {
            if (flag_black == 1)
            {
                flag_black--;
                BlockInput(false);
                b.Close();
            }
        }

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr CreateDC(
              string lpszDriver, // 驱动名称 
              string lpszDevice, // 设备名称 
              string lpszOutput, // 无用，可以设定位"NULL" 
              IntPtr lpInitData // 任意的打印机数据 
            );
        [System.Runtime.InteropServices.DllImportAttribute("gdi32.dll")]
        private static extern bool BitBlt(
        IntPtr hdcDest, //目标设备的句柄 
        int nXDest, // 目标对象的左上角的X坐标 
        int nYDest, // 目标对象的左上角的X坐标 
        int nWidth, // 目标对象的矩形的宽度 
        int nHeight, // 目标对象的矩形的长度 
        IntPtr hdcSrc, // 源设备的句柄 
        int nXSrc, // 源对象的左上角的X坐标 
        int nYSrc, // 源对象的左上角的X坐标 
        System.Int32 dwRop // 光栅的操作值 
        );


        public void capture()
        {
            //this.Visible = false; 
            IntPtr dc1 = CreateDC("DISPLAY", null, null, (IntPtr)null);
            //创建显示器的DC 
            Graphics g1 = Graphics.FromHdc(dc1);
            //由一个指定设备的句柄创建一个新的Graphics对象 
            System.Drawing.Image MyImage = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, g1);
            //根据屏幕大小创建一个与之相同大小的Bitmap对象 
            Graphics g2 = Graphics.FromImage(MyImage);
            //获得屏幕的句柄 
            IntPtr dc3 = g1.GetHdc();
            //获得位图的句柄 
            IntPtr dc2 = g2.GetHdc();
            //把当前屏幕捕获到位图对象中 
            BitBlt(dc2, 0, 0, Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height, dc3, 0, 0, 13369376);
            //把当前屏幕拷贝到位图中 
            g1.ReleaseHdc(dc3);
            //释放屏幕句柄 
            g2.ReleaseHdc(dc2);
            //释放位图句柄 
            ms = new MemoryStream();
            MyImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] b = ms.GetBuffer();
            ns.Write(b, 0, b.Length);
            ms.Flush();
            // this.pictureBox1.Image = Image.FromStream(ms); 
            //this.Visible = true; 
            Thread.Sleep(10);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }    
    }
}
