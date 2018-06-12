using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Net.NetworkInformation;//命名空间
using System.Net;
using System.Net.Sockets;
using System.Threading;


namespace Blue_Spider
{
    public partial class Form1 : Form
    {
        static Label[] pb = new Label[10];
        static int[] online = new int[10];
        #region 对于socket的定义
        private Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket>();
        private TCP tcp;
        #endregion 对于socket的定义结束
        public Form1()
        {
            tcp = new TCP();
            InitializeComponent();
            clientConnectionItems = tcp.GetKeyValuePairs();

            //存储所有图片为彩色（即为主机在线）
            for (int i = 0; i < 10; i++)
            {
                online[i] = 1;
            }

            System.Windows.Forms.Control.CheckForIllegalCrossThreadCalls = false;//线程间操作无效：从不是创建控件listBox1的线程访问它
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

        public Label SetLight(Label temp)
        {
            string imagename = "学生.png";//imagename原路径（相对路径）
            temp.Image = null;//清空
            temp.Image = Image.FromFile(imagename);
            return temp;
        }

        //图片变灰
        public void SetGrey(Label temp)
        {
            int Height = temp.Image.Height;
            int Width = temp.Image.Width;
            Bitmap bitmap = new Bitmap(Width, Height);
            Bitmap MyBitmap = (Bitmap)temp.Image;
            Color pixel;
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    pixel = MyBitmap.GetPixel(x, y);
                    int r, g, b, Result = 0;
                    r = pixel.R;
                    g = pixel.G;
                    b = pixel.B;
                    //实例程序以加权平均值法产生黑白图像  
                    int iType = 2;
                    switch (iType)
                    {
                        case 0://平均值法  
                            Result = ((r + g + b) / 3);
                            break;
                        case 1://最大值法  
                            Result = r > g ? r : g;
                            Result = Result > b ? Result : b;
                            break;
                        case 2://加权平均值法  
                            Result = ((int)(0.7 * r) + (int)(0.2 * g) + (int)(0.1 * b));
                            break;
                    }
                    bitmap.SetPixel(x, y, Color.FromArgb(Result, Result, Result));
                }
            temp.Image = bitmap;
        }

        public String DispInfo(PingReply reply)
        {
            if (reply.Status == IPStatus.Success)
            {
                return String.Format("字节={0} 时间={1}ms TTL={2}", reply.Buffer.Length, reply.RoundtripTime, reply.Options.Ttl);
            }
            else
            {
                return String.Format("{0}", reply.Status);
            }

        }

        public void MyPing(String IP, int n)
        {
            Byte[] IPByte = IPAddress.Parse(IP).GetAddressBytes();
            for (int i = 0; i < n; i++)
            {
                String who;
                who = String.Format("{0}.{1}.{2}.{3}", IPByte[0], IPByte[1], IPByte[2], IPByte[3] + i);
                Ping p = new Ping();
                try
                {
                    PingReply reply = p.Send(who);
                   // listBox1.Items.Add("来自" + who + "的回复： \t" + DispInfo(reply));
                    if (reply.Status != IPStatus.Success)
                    {
                        online[i] = 0;//超时设置为灰色  
                    }
                }
                catch (PingException e)
                {
                    Console.WriteLine("IP{0}异常{1}", who, e.Message);
                }
            }
        }

        private void btn_HostScanning_Click(object sender, EventArgs e)
        {
            labelst1_1 = SetLight(labelst1_1);
            labelst1_2 = SetLight(labelst1_2);
            labelst1_3 = SetLight(labelst1_3);
            labelst1_4 = SetLight(labelst1_4);
            labelst1_5 = SetLight(labelst1_5);
            labelst1_6 = SetLight(labelst1_6);
            labelst1_7 = SetLight(labelst1_7);
            labelst1_8 = SetLight(labelst1_8);
            labelst1_9 = SetLight(labelst1_9);
            labelst1_10 = SetLight(labelst1_10);
            for (int i = 0; i < 10; i++)
            {
                online[i] = 1;
            }
            pb[0] = labelst1_1;
            pb[1] = labelst1_2;
            pb[2] = labelst1_3;
            pb[3] = labelst1_4;
            pb[4] = labelst1_5;
            pb[5] = labelst1_6;
            pb[6] = labelst1_7;
            pb[7] = labelst1_8;
            pb[8] = labelst1_9;
            pb[9] = labelst1_10;

            MyPing("172.16.93.41", 10);

            for (int i = 0; i < 10; i++)
            {
                if (online[i] == 0)
                {
                    SetGrey(pb[i]);
                }
            }
        }

    }
}
