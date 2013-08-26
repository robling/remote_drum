using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace keyboard_control
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll")]
        public static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 接收数据缓存
        /// </summary>
        List<byte> receivedata = new List<byte>();

        /// <summary>
        /// 打开/关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                try
                {
                    serialPort1.PortName = com_Box.Text;
                    serialPort1.BaudRate = int.Parse(comboBox2.Text);
                    serialPort1.Open();
                    button1.Text = "关闭串口";
                    timer1.Enabled = true;

                }
                catch (System.Exception ex)
                {
                    if (serialPort1.IsOpen)
                    {
                        serialPort1.Close();
                    }
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                serialPort1.Close();
                serialPort1.Dispose();
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (receivedata.Count != 0)
            {
                switch (receivedata[0])
                {
                    case 0:
                        ehshall_start();
                        receivedata.RemoveAt(0);
                        break;
                    case 1:
                        keybd_event((byte)Keys.Select, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                    case 2:
                        keybd_event((byte)Keys.MediaPreviousTrack, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                    case 3:
                        keybd_event((byte)Keys.Left, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                    case 4:
                        keybd_event((byte)Keys.Up, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                    case 5:
                        keybd_event((byte)Keys.Down, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                    case 6:
                        keybd_event((byte)Keys.MediaNextTrack, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                    case 7:
                        keybd_event((byte)Keys.Right, 0, 0, 0);
                        receivedata.RemoveAt(0);
                        break;
                }
                //receivedata.RemoveAt(0);
            }
        }

        private void Receive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int n = serialPort1.BytesToRead;
            byte[] buf = new byte[n];
            serialPort1.Read(buf, 0, n);
            receivedata.AddRange(buf);
        }

        //private void button2_Click(object sender, EventArgs e)
        //{
        //    keybd_event((byte)Keys.SelectMedia, 0, 0, 0);
        //}

        private void ehshall_start()
        {
            //声明一个程序类
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

            //设置外部程序名
            Info.FileName = "C:\\Windows\\ehome\\ehshell.exe";

            //声明一个程序类
            System.Diagnostics.Process Proc;

            //
            //启动外部程序
            //
            try
            {
                Proc = System.Diagnostics.Process.Start(Info);
            }
            catch (System.ComponentModel.Win32Exception)
            {
                MessageBox.Show("找不到指定程序");
            }
        }
    }

}
