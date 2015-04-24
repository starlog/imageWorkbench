using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageWorkbench
{
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox_Password.Text != textBox_PasswordCheck.Text)
            {
                MessageBox.Show(@"비밀번호가 일치하지 않습니다");
            }

            Storage.AccountId = textBox_UserName.Text;
            Storage.FtpAddress = textBox_ServerAddress.Text;
            if (!string.IsNullOrEmpty(textBox_Password.Text))
            {
                Storage.AccountPassword = textBox_Password.Text;
            }
            Storage.BasePath = textBox_BasePath.Text;
            ConfigSaver.Save();
            ConfigSaver.Load();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FillData(object sender, EventArgs e)
        {
            textBox_ServerAddress.Text = Storage.FtpAddress;
            textBox_UserName.Text = Storage.AccountId;
            textBox_BasePath.Text = Storage.BasePath;
        }
    }
}
