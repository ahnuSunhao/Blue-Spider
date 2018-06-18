using Blue_Spider.tools;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Blue_Spider
{
    public class TCP
    {
        // 创建一个和客户端通信的套接字
        private Socket socketlisten = null;
        //定义一个集合，存储客户端信息(以字典的形式)
        Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> ();
        /// <summary>
        /// 构造函数
        /// </summary>
        /// 
        public TCP(){
            socketlisten = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); 
            IPAddress address = IPAddress.Parse(GetIpAddress());  
            
            IPEndPoint point = new IPEndPoint(address, 8989);  
            socketlisten.Bind(point); 
            socketlisten.Listen(20);  
            Thread threadlisten = new Thread(ListenConnecting);  
            threadlisten.IsBackground = true;     
            threadlisten.Start();
        }
        /// <summary>
        /// TCP的监听
        /// </summary>
        private void ListenConnecting()
        {
            Socket connection = null;    
            while (true){
                try{
                    connection = socketlisten.Accept();
                }catch (Exception ex){
                    Until.Log(ex.Message);
                    break;
                }
                IPAddress clientIP = (connection.RemoteEndPoint as IPEndPoint).Address;//获取客户端的IP和端口号  
                int clientPort = (connection.RemoteEndPoint as IPEndPoint).Port; 
                //string sendmsg = "连接服务端成功！\r\n" + "本地IP:" + clientIP + "，本地端口" + clientPort.ToString();
                //byte[] arrSendMsg = Encoding.UTF8.GetBytes(sendmsg);
                //connection.Send(arrSendMsg);  
                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                Until.Log("成功与" + remoteEndPoint + "客户端建立连接！\t\n");
                clientConnectionItems.Add(remoteEndPoint, connection);//添加客户端信息 

                IPEndPoint netpoint = connection.RemoteEndPoint as IPEndPoint;    
                ParameterizedThreadStart pts = new ParameterizedThreadStart(ReceiveFromClient);//创建一个通信线程
                Thread thread = new Thread(pts);
                thread.IsBackground = true;   //设置为后台线程，随着主线程退出而退出 
                thread.Start(connection);
            }
            
        }
        /// <summary>
        /// 接收客户端发来的信息，客户端套接字对象
        /// </summary>
        /// <param name="obj"></param>
        private void ReceiveFromClient(object obj)
        {
            Socket socketServer = obj as Socket;
            while (true)
            {    
                byte[] arrServerRecMsg = new byte[1024 * 1024];   
                try
                {
                    int length = socketServer.Receive(arrServerRecMsg);
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    IPAddress ip = (socketServer.RemoteEndPoint as IPEndPoint).Address;
                    Form1.ShowMessageBox(ip,strSRecMsg);
                    socketServer.Send(Encoding.UTF8.GetBytes(strSRecMsg));
                }catch (Exception ex){
                    clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());
                    socketServer.Close();
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

        public Dictionary<string, Socket> GetKeyValuePairs()
        {
            return clientConnectionItems;
        }

        public string GetIpAddress()
        {
            string hostName = Dns.GetHostName();   //获取本机名
            IPHostEntry localhost = Dns.GetHostByName(hostName);    //方法已过期，可以获取IPv4的地址                                                       //IPHostEntry localhost = Dns.GetHostEntry(hostName);   //获取IPv6地址
            IPAddress localaddr = localhost.AddressList[0];
            Until.Log(localaddr.ToString());
            return localaddr.ToString();
        }

    }
}
