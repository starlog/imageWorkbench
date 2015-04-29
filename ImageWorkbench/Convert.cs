using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Runtime;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging;
using ImageProcessor.Imaging.Formats;

namespace ImageWorkbench
{
    public partial class Convert : Form
    {
        public Convert()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetText(string text)
        {
            textBox1.Text += text + Environment.NewLine;
            textBox1.SelectionStart = textBox1.TextLength;
            textBox1.ScrollToCaret();
        }

        private string SetFileName(string filename, string postfix)
        {
            var filename1 = filename.Split('\\').ToArray();
            var filename2 = filename1[filename1.Count() - 1];

            string[] list = filename2.Split('.');

            StringBuilder sb = new StringBuilder();

            for (var i = 0; i < (list.Count()-1); i++)
            {
                sb.Append(list[i]).Append(".");
            }

            var result = sb.ToString().TrimEnd('.');

            return result + postfix + "." + list[list.Count() - 1];
        }
        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Event_Load(object sender, EventArgs e)
        {
            // Delete all image first
            WorkImage.ConvertedImages.Clear();
            textBox1.Text = "";
            SetText(@"변환 시작");

            foreach (var convertinfo in Storage.ImageSetups)
            {
                try
                {
                    var targetImage = new TargetImage
                    {
                        FileName = SetFileName(WorkImage.OriginalFileName, convertinfo.Postfix)
                    };

                    using (var inStream = new MemoryStream(WorkImage.OriginalImageBytes))
                    {
                        using (var outStream = new MemoryStream())
                        {
                            using (var imageFactory = new ImageFactory(true))
                            {
                                ISupportedImageFormat format = new JpegFormat();
                                var image = imageFactory.Load(inStream);
                                var targetSize = new Size(int.Parse(convertinfo.SizeX), int.Parse(convertinfo.SizeY));

                                image.Resize(targetSize).Format(format).Quality(convertinfo.Quality).Save(outStream);

                                targetImage.Image = Image.FromStream(outStream);

                                targetImage.Image.Save(WorkImage.ImageFolderName + @"\" + targetImage.FileName);

                                WorkImage.ConvertedImages.Add(targetImage);
                            }
                        }
                    }
                    var xx = new ImageDisplay(targetImage.FileName, targetImage.Image)
                    {
                        StartPosition = FormStartPosition.CenterParent,
                        MdiParent = this.Parent.FindForm()
                    };

                    xx.Show();

                    SetText(String.Format(@"{0}x{1} 크기 생성({2})", targetImage.Image.Width, targetImage.Image.Height, targetImage.FileName));

                }
                catch (Exception ex)
                {
                    SetText(ex.ToString());
                }
            }
            SetText("Enter로 이 화면을 닫을수 있습니다.");
        }

        private void Convert_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Close();
            }
        }
    }
}
