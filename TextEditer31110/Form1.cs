using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace TextEditer31110
{
    public partial class Form1 : Form
    {
        //現在編集中のファイル名
        private string FileName = "";

        public Form1()
        { 
            InitializeComponent();
        }

        //新規作成
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        //開く
        private void LoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofdFIleOpen.ShowDialog() == DialogResult.OK) 
            {
                using (StreamReader sr = new StreamReader(ofdFIleOpen.FileName, Encoding.GetEncoding("utf-8"), false))
                {
                    rtTextArea.Text = sr.ReadToEnd();
                    FileName = ofdFIleOpen.FileName;
                }
          
            }

        }

        //上書き保存
        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //既存のファイルを開いていた場合、上書き保存を実行する
            if (this.FileName != "")
                File.WriteAllText(FileName, rtTextArea.Text);

            //ファイルを新規作成していた場合、名前を付けて保存を実行する
            else
                FileSave(sfdFileSave.FileName);

        }

        //名前を付けて保存
        private void NewSaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileSave(sfdFileSave.FileName);
        }


        //終了
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FileSave(string FileName)
        {
            if (sfdFileSave.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfdFileSave.FileName, false, Encoding.GetEncoding("utf-8")))
                {
                    sw.WriteLine(rtTextArea.Text);
                }
            }
        }

        
    }
}
