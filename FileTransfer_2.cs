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
using System.Threading;
using System.IO;

namespace Blue_Spider
{
    public partial class FileTransfer_2 : Form
    {

        Thread threadWatch = null;
        Socket socketWatch = null;

        Socket socketConnect = null;

        string recStr = null;


        string filePath = null;
        string fileName = null;
        //定义一个集合，存储客户端信息(以字典的形式)
        Dictionary<string, Socket> fileclientConnectionItems = new Dictionary<string, Socket>();
        // clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());
        public FileTransfer_2()
        {
            InitializeComponent();
            //关闭对文本框的非法线程操作检查  
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }

       

        private void btn_select_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            if (ofDialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = ofDialog.SafeFileName;//获取选取文件的文件名  
                File.Text = fileName;//将文件名显示在文本框上  
                filePath = ofDialog.FileName;//获取包含文件名的全路径  
            }
        }

        //屏幕启动时自动开启监听端口
        private void FileTransfer_2_Load(object sender, EventArgs e)
        {
            //定义一个套接字，监听发来的信息，包含3个参数（IP4寻址协议，流式连接，TCP协议）  
            socketWatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = Convert.ToInt32("5555");
            IPAddress ip = IPAddress.Parse(GetIpAddress());//通过GetIpAddress获得本机IP地址
            Message.Text += GetIpAddress() + "\r\n";
            //绑定IP地址和端口号  
            IPEndPoint ipe = new IPEndPoint(ip, port);
            socketWatch.Bind(ipe);
            socketWatch.Listen(20);//监听队列长度，20  
            //负责监听的线程  
            threadWatch = new Thread(WatchConnect);

            threadWatch.IsBackground = true;
            threadWatch.Start();
            Message.AppendText("服务器已经启动，开始监听..." + "\r\n");
        }



        private void WatchConnect()
        {
            while (true)
            {
                try
                {
                    socketConnect = socketWatch.Accept();
                }
                catch (Exception ex)
                {
                    Message.AppendText(ex.Message);
                    break;
                }
                Message.AppendText("客户端连接成功，可以开始通信..." + "\r\n");

                IPAddress clientIP = (socketConnect.RemoteEndPoint as IPEndPoint).Address;//获取客户端的IP和端口号  
                int clientPort = (socketConnect.RemoteEndPoint as IPEndPoint).Port;

                string remoteEndPoint = socketConnect.RemoteEndPoint.ToString();//IP+Port

                //添加到列表中显示连接的IP+Port 
                lb_IPPort.Items.Add(remoteEndPoint);

                //将连接的客户端套接字存入字典中
                fileclientConnectionItems.Add(remoteEndPoint, socketConnect);//添加客户端信息 

                //创建通信线程，感觉这个和Thread的区别，就是这个有参数
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ServerRec);
                Thread thr = new Thread(pts);
                thr.IsBackground = true;   //设置为后台线程，随着主线程退出而退出 
                thr.Start(socketConnect);

            }
        }


        private void ServerRec(object obj)
        {
            Socket socketServer = obj as Socket;
            long fileLength = 0;

            while (true)
            {
                int firstRcv = 0;
                byte[] buffer = new byte[8 * 1024];
                try
                {
                    //获取接受数据的长度，存入内存缓冲区，返回一个字节数组的长度  
                    if (socketServer != null) firstRcv = socketServer.Receive(buffer);

                    if (firstRcv > 0)//大于0，说明有东西传过来  
                    {
                        if (buffer[0] == 0)//0对应文字信息  
                        {
                            recStr = Encoding.UTF8.GetString(buffer, 1, firstRcv - 1);
                            Message.AppendText("Stuent: " + GetTime() + "  " + recStr + "\r\n");
                        }

                        if (buffer[0] == 1)//1对应文件信息  
                        {
                            string filenameSuffix = recStr.Substring(recStr.LastIndexOf("."));
                            SaveFileDialog sfDialog = new SaveFileDialog()
                            {
                                Filter = "(*" + filenameSuffix + ")|*" + filenameSuffix + "",
                                FileName = recStr
                            };

                            string savePath = "E:\\" + recStr;
                            int rec = 0;
                            long recFileLength = 0;
                            bool firstWrite = true;
                            using (FileStream fs = new FileStream(savePath, FileMode.Create, FileAccess.Write))
                            {
                                while (recFileLength < fileLength)
                                {
                                    if (firstWrite)
                                    {
                                        fs.Write(buffer, 1, firstRcv - 1);
                                        fs.Flush();
                                        recFileLength += firstRcv - 1;
                                        firstWrite = false;
                                    }
                                    else
                                    {
                                        rec = socketServer.Receive(buffer);
                                        fs.Write(buffer, 0, rec);
                                        fs.Flush();
                                        recFileLength += rec;
                                    }
                                }
                                fs.Close();
                            }
                            string fName = savePath.Substring(savePath.LastIndexOf("\\") + 1);
                            string fPath = savePath.Substring(0, savePath.LastIndexOf("\\"));
                            Message.AppendText("Student: " + GetTime() + "    你成功接收了文件..." + fName + "\r\n保存路径为：" + fPath + "\r\n");
                        }
                        if (buffer[0] == 2)//2对应文件名字和长度  
                        {
                            string fileNameWithLength = Encoding.UTF8.GetString(buffer, 1, firstRcv - 1);
                            recStr = fileNameWithLength.Split('-').First();
                            fileLength = Convert.ToInt64(fileNameWithLength.Split('-').Last());
                        }
                    }
                }
                catch (Exception ex)
                {
                    Message.AppendText("系统异常..." + ex.Message);

                    //******************************//
                    //清除listBox的内容
                    lb_IPPort.Items.Clear();

                    break;
                }
            }
        }
        private void SendFile(string fileFullPath)
        {
            if (string.IsNullOrEmpty(fileFullPath))
            {
                MessageBox.Show(@"请选择需要发送的文件!");
                return;
            }

            //发送文件前，将文件名和长度发过去  
            long fileLength = new FileInfo(fileFullPath).Length;
            string totalMsg = string.Format("{0}-{1}", fileName, fileLength);
            ServerSend(totalMsg, 2);

            byte[] buffer = new byte[8 * 1024];

            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                int readLength = 0;
                bool firstRead = true;
                long sentFileLength = 0;
                while ((readLength = fs.Read(buffer, 0, buffer.Length)) > 0 && sentFileLength < fileLength)
                {
                    sentFileLength += readLength;
                    //第一次发送的字节流上加个前缀1  
                    if (firstRead)
                    {
                        byte[] firstBuffer = new byte[readLength + 1];
                        //标记1，代表为文件  
                        firstBuffer[0] = 1;
                        Buffer.BlockCopy(buffer, 0, firstBuffer, 1, readLength);

                        socketConnect.Send(firstBuffer, 0, readLength + 1, SocketFlags.None);

                        firstRead = false;
                        continue;
                    }
                    socketConnect.Send(buffer, 0, readLength, SocketFlags.None);
                }
                fs.Close();
            }
            Message.AppendText("SoFlash:" + GetTime() + "    您发送了文件:" + fileName + "\r\n");
        }




        private void ServerSend(string SendStr, byte symbol)
        {
            //用UTF8能接受文字信息  
            byte[] buffer = Encoding.UTF8.GetBytes(SendStr);
            //实际发送的字节数组比实际输入的长度多1，用于存取标识符  
            byte[] newBuffer = new byte[buffer.Length + 1];
            //标识符添加在位置为0的地方  
            newBuffer[0] = symbol;
            Buffer.BlockCopy(buffer, 0, newBuffer, 1, buffer.Length);
            socketConnect.Send(newBuffer);
            Message.AppendText("Teacher:" + GetTime() + "  " + SendStr + "\r\n");
        }

        //ServerSend的重载——>用于对某一个客户端（tempsoket）发送信息
        private void ServerSend(string SendStr, byte symbol, Socket tempsoket)
        {
            //用UTF8能接受文字信息  
            byte[] buffer = Encoding.UTF8.GetBytes(SendStr);
            //实际发送的字节数组比实际输入的长度多1，用于存取标识符  
            byte[] newBuffer = new byte[buffer.Length + 1];
            //标识符添加在位置为0的地方  
            newBuffer[0] = symbol;
            Buffer.BlockCopy(buffer, 0, newBuffer, 1, buffer.Length);
            tempsoket.Send(newBuffer);
            Message.AppendText("Teacher:" + GetTime() + "  " + SendStr + "\r\n");
        }



        //获取系统时间  
        public DateTime GetTime()
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            return now;
        }

        private void btn_send1_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(ThreadBction).Start();    //启动线程
        }

        private void ThreadBction()
        {
            this.Invoke(new MethodInvoker(UIBction));    //在主线程上执行UIAction方法
        }
        private void UIBction()
        {
            SendFile(filePath);
        }

        //SendFile的重载——>用于一对多发送文件
        private void SendFile(string fileFullPath, Socket tempsocket)
        {
            if (string.IsNullOrEmpty(fileFullPath))
            {
                MessageBox.Show(@"请选择需要发送的文件!");
                return;
            }

            //发送文件前，将文件名和长度发过去  
            long fileLength = new FileInfo(fileFullPath).Length;
            string totalMsg = string.Format("{0}-{1}", fileName, fileLength);

            //套接字改为tempsocket
            ServerSend(totalMsg, 2, tempsocket);

            byte[] buffer = new byte[8 * 1024];

            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                int readLength = 0;
                bool firstRead = true;
                long sentFileLength = 0;
                while ((readLength = fs.Read(buffer, 0, buffer.Length)) > 0 && sentFileLength < fileLength)
                {
                    sentFileLength += readLength;
                    //第一次发送的字节流上加个前缀1  
                    if (firstRead)
                    {
                        byte[] firstBuffer = new byte[readLength + 1];
                        //标记1，代表为文件  
                        firstBuffer[0] = 1;
                        Buffer.BlockCopy(buffer, 0, firstBuffer, 1, readLength);

                        tempsocket.Send(firstBuffer, 0, readLength + 1, SocketFlags.None);

                        firstRead = false;
                        continue;
                    }
                    tempsocket.Send(buffer, 0, readLength, SocketFlags.None);
                }
                fs.Close();
            }
            Message.AppendText("SoFlash:" + GetTime() + "   您发送了文件:" + fileName + "\r\n");
        }

        private void btn_SendN_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(ThreadCction).Start();    //启动线程
        }

        private void ThreadCction()
        {
            this.Invoke(new MethodInvoker(UICction));    //在主线程上执行UIAction方法
        }

        private void UICction()
        {
            foreach (KeyValuePair<string, Socket> socket in fileclientConnectionItems)
            {
                // textBox1.AppendText("IP：" + socket.Key);
                //逐个发送文件
                SendFile(filePath, socket.Value);
            }
        }

        private string GetIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址
            IPAddress localaddr = localhost.AddressList[2];

            return localaddr.ToString();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
