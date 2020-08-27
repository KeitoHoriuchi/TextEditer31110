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
        int s = 0;
        public Form1()
        { 
            InitializeComponent();

        }


        //新規作成
        private void NewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtTextArea.Text != "")
            {
                DialogResult = MessageBox.Show("現在のファイルは保存されていません。このファイルの変更内容を保存しますか?",
                               "注意!",
                               MessageBoxButtons.YesNoCancel,
                               MessageBoxIcon.Exclamation);
                if (DialogResult == DialogResult.Yes)
                {
                    //既存のファイルを開いていた場合、上書き保存を実行する
                    if (this.FileName != "")
                        File.WriteAllText(FileName, rtTextArea.Text);

                    //ファイルを新規作成していた場合、名前を付けて保存を実行する
                    else
                        FileSave(sfdFileSave.FileName);

                    rtTextArea.Text = "";
                }

                else if (DialogResult == DialogResult.No)
                {
                    rtTextArea.Text = "";
                }

                else if (DialogResult == DialogResult.Cancel) { }

            }
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

            s++;
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

        //元に戻す
        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Undo();
        }

        //やり直し
        private void RedoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Redo();
        }

        private void EditMenuMaskCheck()
        {
            UndoToolStripMenuItem.Enabled = rtTextArea.CanUndo;
            RedoToolStripMenuItem.Enabled = rtTextArea.CanRedo;
            CutToolStripMenuItem.Enabled = (rtTextArea.SelectionLength > 0);
            CopeToolStripMenuItem.Enabled = (rtTextArea.SelectionLength > 0);
            PastToolStripMenuItem.Enabled = Clipboard.GetDataObject().GetDataPresent(DataFormats.Rtf);
        }

        //テキストが入力された際に元に戻す、やり直しの有効化
        //テキストが全て消えた場合に元に戻す、やり直しの無効化
        private void rtTextArea_TextChanged(object sender, EventArgs e)
        {
            UndoToolStripMenuItem.Enabled = true;
            RedoToolStripMenuItem.Enabled = true;

            
            if (rtTextArea.Text == "")
            {
                UndoToolStripMenuItem.Enabled = false;
                RedoToolStripMenuItem.Enabled = false;
            }
        }
        
        //削除
        private void DeleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.SelectedText = "";
        }

        //切り取り
        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Cut();
            PastToolStripMenuItem.Enabled = true;
        }

        //コピー
        private void CopeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Copy();
            PastToolStripMenuItem.Enabled = true;
        }

        //貼り付け
        private void PastToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtTextArea.Paste();
        }

        private void ColorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
