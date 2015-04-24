using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageWorkbench
{
    public partial class Upload : Form
    {
        public Upload()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetTextLine(string text)
        {
            textBox1.Text += text + Environment.NewLine;
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }
        private void SetText(string text)
        {
            textBox1.Text += text;
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private void Event_Load(object sender, EventArgs e)
        {
            try
            {
                using (var client = new WebClient())
                {
                    client.Credentials = new NetworkCredential(Storage.AccountId, Storage.AccountPassword);

                    foreach (var record in WorkImage.ConvertedImages)
                    {
                        var _basePath = "";

                        if (!Storage.BasePath.StartsWith("/"))
                        {
                            _basePath = "/" + Storage.BasePath;
                        }
                        else
                        {
                            _basePath = Storage.BasePath;
                        }

                        if (!Storage.BasePath.EndsWith("/"))
                        {
                            _basePath += "/";
                        }


                        var _localPath = @".\" + WorkImage.ImageFolderName + @"\" + record.FileName;

                        SetText(String.Format("파일 {0} 업로드 시작....", record.FileName));
                        client.UploadFile("ftp://" + Storage.FtpAddress + _basePath + record.FileName, "STOR", _localPath);
                        SetTextLine(String.Format("파일 {0} 업로드 완료", record.FileName));
                    }
                    SetTextLine("----------------------- 모든 파일 업로드 완료 -----------------------");
                    SetText("Enter로 이 화면을 닫을수 있습니다.");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Event_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
