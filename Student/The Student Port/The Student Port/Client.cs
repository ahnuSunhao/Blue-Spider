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
   public class Client
    {
          Thread threadclient = null;
          Socket socketclient = null;
          private string strRevMsg ="";
          public Client()
          {
              socketclient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
              //连接服务器的IP地址  
              IPAddress address = IPAddress.Parse("192.168.1.106");
              //将获取的IP地址和端口号绑定在网络节点上  
              IPEndPoint point = new IPEndPoint(address, 8989);
              try
              {
                  //客户端套接字连接到网络节点上，用的是Connect  
                  socketclient.Connect(point);
                  MessageBox.Show("连接成功");

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
                      MessageBox.Show(strRevMsg);
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
          public void ClientSendMsg(string sendMsg)
          {
              //将输入的内容字符串转换为机器可以识别的字节数组     
              byte[] arrClientSendMsg = Encoding.UTF8.GetBytes(sendMsg);
              //调用客户端套接字发送字节数组     
              socketclient.Send(arrClientSendMsg);
              MessageBox.Show(sendMsg);
              //将发送的信息追加到聊天内容文本框中     
              Debug.WriteLine("hello...." + ": " + GetCurrentTime() + "\r\n" + sendMsg + "\r\n\n");
          }
          private DateTime GetCurrentTime()
          {
              DateTime currentTime = new DateTime();
              currentTime = DateTime.Now;
              return currentTime;
          }

          public string getRecMes() 
          {
             return  strRevMsg; 
          }


    }
}
