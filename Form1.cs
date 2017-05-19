using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace I_Want_To_Say
{
    public partial class 大声说出来 : Form
    {
        public 大声说出来()
        {
            InitializeComponent();
        }

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = "请输入你想要说的话！";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string dir = Directory.GetCurrentDirectory() + "content.vbs"; //获取应用程序的当前工作目录
                FileStream fs = new FileStream(dir, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                string str = "CreateObject(\"SAPI.SpVoice\").Speak \"" + textBox1.Text + "\"";
                sw.Write(str);
                fs.Flush();
                sw.Close();
                fs.Close();
                process1.StartInfo.FileName = dir;
            }
            catch { }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                process1.Start();
            }
            catch { }
        }
    }
}
