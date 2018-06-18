using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace The_Student_Port
{
    public partial class Sumbit_job : Form
    {
        public Sumbit_job()
        {
            InitializeComponent();
            TextBox.CheckForIllegalCrossThreadCalls = false;
        }
        Socket socketClient = null;
        Thread threadClient = null;


        private void RecMsg()
        {
            long fileLength = 0;
            string recStr = null;
            while (true)
            {
                int firstRcv = 0;
                byte[] buffer = new byte[8 * 1024];
                try
                {
                    if (socketClient != null) firstRcv = socketClient.Receive(buffer);

                    if (firstRcv > 0)
                    {
                        if (buffer[0] == 0)
                        {
                            recStr = Encoding.UTF8.GetString(buffer, 1, firstRcv - 1);
                            Message.AppendText("PYT: " + GetTime() + "\r\n" + recStr + "\r\n");
                        }

                        if (buffer[0] == 1)
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
                                        rec = socketClient.Receive(buffer);
                                        fs.Write(buffer, 0, rec);
                                        fs.Flush();
                                        recFileLength += rec;
                                    }
                                }
                                fs.Close();
                            }

                            string fName = savePath.Substring(savePath.LastIndexOf("\\") + 1);
                            string fPath = savePath.Substring(0, savePath.LastIndexOf("\\"));
                            Message.AppendText("ZXY: " + GetTime() + "\r\n你成功接收了文件..." + fName + "\r\n保存路径为：" + fPath + "\r\n");

                        }
                        if (buffer[0] == 2)
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
                    break;
                }
            }
        }


        private void ClientSend(string SendStr, byte symbol)
        {
            byte[] buffer = Encoding.UTF8.GetBytes(SendStr);
            byte[] newBuffer = new byte[buffer.Length + 1];
            newBuffer[0] = symbol;
            Buffer.BlockCopy(buffer, 0, newBuffer, 1, buffer.Length);
            socketClient.Send(newBuffer);
            Message.AppendText("ZXY: " + GetTime() + "\r\n" + SendStr + "\r\n");
        }


        string filePath = null;
        string fileName = null;



        private void SendFile(string fileFullPath)
        {
            if (string.IsNullOrEmpty(fileFullPath))
            {
                MessageBox.Show(@"请选择需要发送的文件...");
                return;
            }

            long fileLength = new FileInfo(fileFullPath).Length;
            string totalMsg = string.Format("{0}-{1}", fileName, fileLength);
            ClientSend(totalMsg, 2);

            byte[] buffer = new byte[2 * 1024];
            using (FileStream fs = new FileStream(fileFullPath, FileMode.Open, FileAccess.Read))
            {
                int readLength = 0;
                bool firstRead = true;
                long sentFileLength = 0;
                while ((readLength = fs.Read(buffer, 0, buffer.Length)) > 0 && sentFileLength < fileLength)
                {
                    sentFileLength += readLength;
                    if (firstRead)
                    {
                        byte[] firstBuffer = new byte[readLength + 1];
                        firstBuffer[0] = 1;
                        Buffer.BlockCopy(buffer, 0, firstBuffer, 1, readLength);

                        socketClient.Send(firstBuffer, 0, readLength + 1, SocketFlags.None);

                        firstRead = false;
                    }
                    else
                    {
                        socketClient.Send(buffer, 0, readLength, SocketFlags.None);
                    }
                }
                fs.Close();
            }
            Message.AppendText("ZXY:" + GetTime() + "\r\n你发送了文件：" + fileName + "\r\n");
        }

        public DateTime GetTime()
        {
            DateTime now = new DateTime();
            now = DateTime.Now;
            return now;
        }

        private void ThreadBction()
        {
            this.Invoke(new MethodInvoker(UIBction));    //在主线程上执行UIAction方法
        }

        private void UIBction()
        {
            this.Text = "ddd";    //不会报错  测试线程是否开启成功          
            SendFile(filePath);
        }

        private void BeginClient_Click(object sender, EventArgs e)
        {
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ip = IPAddress.Parse(textBox1.Text.Trim());
            IPEndPoint ipe = new IPEndPoint(ip, 5555);
            socketClient.Connect(ipe);
            threadClient = new Thread(RecMsg);
            threadClient.IsBackground = true;
            threadClient.Start();
            Message.AppendText("已经与服务端建立连接，可以开始通信...\r\n");

        }

        private void buttonfile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDialog = new OpenFileDialog();
            if (ofDialog.ShowDialog(this) == DialogResult.OK)
            {
                fileName = ofDialog.SafeFileName;
                File.Text = fileName;
                filePath = ofDialog.FileName;
            }
        }

        private void buttonsend_Click(object sender, EventArgs e)
        {
            new System.Threading.Thread(ThreadBction).Start();    //启动线程
        }

        private void Sumbit_job_Load(object sender, EventArgs e)
        {

        }










    }
}