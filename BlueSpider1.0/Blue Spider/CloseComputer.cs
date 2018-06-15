using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Blue_Spider
{
    public partial class CloseComputer : Form
    {
        Dictionary<string, Socket> clientConnectionItems;
        public CloseComputer()
        {
            InitializeComponent();
        }
        //传入套接字字典
        public CloseComputer(Dictionary<string, Socket> Items)
        {
            clientConnectionItems = Items;
            //将在线电脑IP地址显示出来
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                lb_onlineComputer.Items.Add(socket.Key.ToString());
            }

            InitializeComponent();
        }

        private void lb_onlineComputer_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                //匹配套接字
                if (socket.Key.ToString().Equals(lb_onlineComputer.Text))
                {
                    socket.Value.Send(Encoding.UTF8.GetBytes("005"));//发送关机信息
                }
            }
        }

        private void btn_CloseAll_Click(object sender, EventArgs e)
        {
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                socket.Value.Send(Encoding.UTF8.GetBytes("005"));//发送关机信息
            }
        }
    }
}
