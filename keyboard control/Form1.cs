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
using file_ini;


namespace keyboard_control
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// MFC函数 
        /// </summary>
        /// <param name="bVk">keyboard_event</param>
        /// <param name="bScan">按键扫描码</param>
        /// <param name="dwFlags">按键行为</param>
        /// <param name="dwExtraInfo"></param>
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
                        button1.Text = "打开串口";

                    }
                    MessageBox.Show(ex.Message);

                }
            }
            else
            {
                serialPort1.Close();
                serialPort1.Dispose();
                button1.Text = "打开串口";
                timer1.Enabled = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (receivedata.Count != 0)
            {
                keyboard_sent(receivedata[0]);
            }
        }

        private void Receive(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
            int n = serialPort1.BytesToRead;
            byte[] buf = new byte[n];
            serialPort1.Read(buf, 0, n);
            receivedata.AddRange(buf);
        }

        private void ehshall_start()
        {
            //声明一个程序类
            System.Diagnostics.ProcessStartInfo Info = new System.Diagnostics.ProcessStartInfo();

            var namepath = System.Windows.Forms.Application.StartupPath;

            //设置外部程序名
            Info.FileName = namepath + "\\VD2.exe";

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

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //恢复最小化的窗口
            this.WindowState = FormWindowState.Normal;
        }

        protected override void OnClosed(EventArgs e)
        {
            //释放托盘区图标占用的资源
            notifyIcon1.Dispose();
            base.OnClosed(e);
        }

        private void open(object sender, EventArgs e)
        {
            button1_Click(sender, e);
            ToolStripMenuItem1.Text = "关闭串口";
        }

        private void close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var filepath = System.Environment.CurrentDirectory;
            var filename = filepath + "\\keyboard_control.ini";
            Inioperate settings = new Inioperate(filename);

        }

        private void keyboard_sent(byte operatenum)
        {
            //检索匹配操作类型
            switch (operatenum)
            {
                case 0:
                    ehshall_start();
                    receivedata.RemoveAt(0);
                    break;
                case 1:
                    keybd_event((byte)Keys.G, 0, 0, 0);
                    keybd_event((byte)Keys.G, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 2:
                    keybd_event((byte)Keys.H, 0, 0, 0);
                    keybd_event((byte)Keys.H, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 3:
                    keybd_event((byte)Keys.J, 0, 0, 0);
                    keybd_event((byte)Keys.J, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 4:
                    keybd_event((byte)Keys.K, 0, 0, 0);
                    keybd_event((byte)Keys.K, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 5:
                    keybd_event((byte)186, 0, 0, 0);
                    keybd_event((byte)186, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 6:
                    keybd_event((byte)222, 0, 0, 0);
                    keybd_event((byte)222, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 7:
                    keybd_event((byte)Keys.V, 0, 0, 0);
                    keybd_event((byte)Keys.V, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 8:
                    keybd_event((byte)Keys.B, 0, 0, 0);
                    keybd_event((byte)Keys.B, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 9:
                    keybd_event((byte)Keys.N, 0, 0, 0);
                    keybd_event((byte)Keys.N, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 10:
                    keybd_event((byte)Keys.M, 0, 0, 0);
                    keybd_event((byte)Keys.M, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 11:
                    keybd_event((byte)Keys.X, 0, 0, 0);
                    keybd_event((byte)Keys.X, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 12:
                    keybd_event((byte)Keys.C, 0, 0, 0);
                    keybd_event((byte)Keys.C, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 13:
                    keybd_event((byte)Keys.D, 0, 0, 0);
                    keybd_event((byte)Keys.D, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 14:
                    keybd_event((byte)Keys.L, 0, 0, 0);
                    keybd_event((byte)Keys.L, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                case 15:
                    keybd_event((byte)Keys.Z, 0, 0, 0);
                    keybd_event((byte)Keys.Z, 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                //关闭
                case 16:
                    //实现组合键
                    keybd_event((byte)(18), 0, 0, 0);
                    keybd_event((byte)(Keys.F4), 0, 0, 0);
                    keybd_event((byte)(18), 0, 0x2, 0);
                    keybd_event((byte)(Keys.F4), 0, 0x2, 0);
                    receivedata.RemoveAt(0);
                    break;
                ////启动wmc
                //case 0:
                //    ehshall_start();
                //    receivedata.RemoveAt(0);
                //    break;
                ////Enter确定
                //case 1:
                //    keybd_event((byte)Keys.Enter, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////上一首
                //case 2:
                //    keybd_event((byte)Keys.MediaPreviousTrack, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////方向键左
                //case 3:
                //    keybd_event((byte)Keys.Left, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////方向键上
                //case 4:
                //    keybd_event((byte)Keys.Up, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////方向键下
                //case 5:
                //    keybd_event((byte)Keys.Down, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////下一首
                //case 6:
                //    keybd_event((byte)Keys.MediaNextTrack, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////方向键右
                //case 7:
                //    keybd_event((byte)Keys.Right, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////关闭
                //case 8:
                //    //实现组合键
                //    keybd_event((byte)(18), 0, 0, 0);
                //    keybd_event((byte)(Keys.F4), 0, 0, 0);
                //    keybd_event((byte)(18), 0, 0x2, 0);
                //    keybd_event((byte)(Keys.F4), 0, 0x2, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////后退
                //case 9:
                //    keybd_event((byte)Keys.Back, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////暂停
                //case 10:
                //    keybd_event((byte)Keys.MediaPlayPause, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////音量减
                //case 11:
                //    keybd_event((byte)Keys.VolumeDown, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
                ////音量加
                //case 12:
                //    keybd_event((byte)Keys.VolumeUp, 0, 0, 0);
                //    receivedata.RemoveAt(0);
                //    break;
            }

        }

        private void notifyIcon1_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            //if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Minimized;
            //else
            //    this.WindowState = FormWindowState.Maximized;
        }
    }

}
