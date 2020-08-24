using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditer31110
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //新規作成


        //開く
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdFIleOpen.ShowDialog() == DialogResult.OK) 
            {
                using (StreamReader sr = new StreamReader(ofdFIleOpen.FileName, Encoding.GetEncoding("utf-8"), false))
                {
                    rtTextArea.Text = sr.ReadToEnd();
                }
          
            }

        }

        //上書き保存


        //名前を付けて保存
        private void NewSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfdFileSave.FileName, false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(rtTextArea.Text);
                }
            }
        }

        //終了
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
