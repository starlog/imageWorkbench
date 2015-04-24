namespace ImageWorkbench
{
    partial class Account
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_ServerAddress = new System.Windows.Forms.TextBox();
            this.textBox_UserName = new System.Windows.Forms.TextBox();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_PasswordCheck = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox_BasePath = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "FTP 서버 주소";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "사용자 ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "사용자 비밀번호";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "기본 경로";
            // 
            // textBox_ServerAddress
            // 
            this.textBox_ServerAddress.Location = new System.Drawing.Point(125, 9);
            this.textBox_ServerAddress.Name = "textBox_ServerAddress";
            this.textBox_ServerAddress.Size = new System.Drawing.Size(318, 21);
            this.textBox_ServerAddress.TabIndex = 4;
            // 
            // textBox_UserName
            // 
            this.textBox_UserName.Location = new System.Drawing.Point(125, 43);
            this.textBox_UserName.Name = "textBox_UserName";
            this.textBox_UserName.Size = new System.Drawing.Size(318, 21);
            this.textBox_UserName.TabIndex = 5;
            // 
            // textBox_Password
            // 
            this.textBox_Password.Location = new System.Drawing.Point(125, 77);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(318, 21);
            this.textBox_Password.TabIndex = 6;
            // 
            // textBox_PasswordCheck
            // 
            this.textBox_PasswordCheck.Location = new System.Drawing.Point(125, 111);
            this.textBox_PasswordCheck.Name = "textBox_PasswordCheck";
            this.textBox_PasswordCheck.PasswordChar = '*';
            this.textBox_PasswordCheck.Size = new System.Drawing.Size(318, 21);
            this.textBox_PasswordCheck.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(287, 186);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(368, 186);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox_BasePath
            // 
            this.textBox_BasePath.Location = new System.Drawing.Point(125, 145);
            this.textBox_BasePath.Name = "textBox_BasePath";
            this.textBox_BasePath.Size = new System.Drawing.Size(318, 21);
            this.textBox_BasePath.TabIndex = 8;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 231);
            this.Controls.Add(this.textBox_BasePath);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_PasswordCheck);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.textBox_UserName);
            this.Controls.Add(this.textBox_ServerAddress);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Account";
            this.Text = "계정";
            this.Load += new System.EventHandler(this.FillData);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_ServerAddress;
        private System.Windows.Forms.TextBox textBox_UserName;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_PasswordCheck;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox_BasePath;
    }
}