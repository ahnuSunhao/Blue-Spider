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
        private int flag =0;//0表示关机   1表示黑屏
        public CloseComputer()
        {
            InitializeComponent();
        }
        //传入套接字字典
        public CloseComputer(Dictionary<string, Socket> Items, int flag)
        {
            InitializeComponent();
            clientConnectionItems = Items;
            //将在线电脑IP地址显示出来
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                lb_onlineComputer.Items.Add(socket.Key.ToString());
            }

            if (flag == 1)
            {
                this.flag = flag;
                btn_CloseAll.Location = new System.Drawing.Point(157, 354);
                btn_CloseAll.Text = "全部黑屏";
                groupBox1.Text = "选择黑屏的机器";
                pictureBox_select.Visible = true;
                radioButton_black.Visible = true;
                radioButton_back.Visible = true;
                radioButton_back.Enabled = false;
                this.Text = "black screen";
            }
        }

        private void lb_onlineComputer_MouseDoubleClick(object sender, MouseEventArgs e)
        {                
            foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
            {
                //匹配套接字
                if (socket.Key.ToString().Equals(lb_onlineComputer.Text))
                {
                    if(flag == 0)
                        socket.Value.Send(Encoding.UTF8.GetBytes("005"));//发送关机信息
                    else if (flag == 1)
                    {
                        if (radioButton_black.Checked == true)
                        {
                            socket.Value.Send(Encoding.UTF8.GetBytes("007"));//黑屏
                            radioButton_back.Enabled = true;
                            radioButton_black.Enabled = false;
                            radioButton_back.Checked = true;
                        }
                        else
                        {
                            radioButton_back.Enabled = false;
                            radioButton_black.Enabled = true;
                            radioButton_black.Checked = true;
                            socket.Value.Send(Encoding.UTF8.GetBytes("008"));
                        }
                    }
                }
            }
        }

        private void btn_CloseAll_Click(object sender, EventArgs e)
        {
            if (flag == 0)
                foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
                    socket.Value.Send(Encoding.UTF8.GetBytes("005"));//发送关机信息
            else if (flag == 1)
            {
                if (radioButton_black.Checked == true)
                {
                    radioButton_back.Enabled = true;
                    radioButton_black.Enabled = false;
                    radioButton_back.Checked = true;
                    foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
                        socket.Value.Send(Encoding.UTF8.GetBytes("007"));//黑屏
                }
                else
                {
                    radioButton_back.Enabled = false;
                    radioButton_black.Enabled = true;
                    radioButton_black.Checked = true;
                    foreach (KeyValuePair<string, Socket> socket in clientConnectionItems)
                        socket.Value.Send(Encoding.UTF8.GetBytes("008"));
                }
            } 
        }
    }
}
