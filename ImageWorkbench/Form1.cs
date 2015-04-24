using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ImageProcessor;
using ImageProcessor.Imaging.Formats;

namespace ImageWorkbench
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            toolStripStatusLabel1.Text = @"시스템 준비완료";
        }

        private void Menu_File_Open(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    WorkImage.OriginalImageBytes = File.ReadAllBytes(openFileDialog.FileName);

                    using (var inStream = new MemoryStream(WorkImage.OriginalImageBytes))
                    {
                        using (var outStream = new MemoryStream())
                        {
                            using (var imageFactory = new ImageFactory(true))
                            {
                                ISupportedImageFormat format = new JpegFormat();

                                var image = imageFactory.Load(inStream);
                                WorkImage.OriginalFileName = openFileDialog.FileName; //Save org file name

                                image.Format(format).Save(outStream);

                                WorkImage.OriginalImage = Image.FromStream(outStream);

                                var filename1 = WorkImage.OriginalFileName.Split('\\').ToArray();
                                var filename2 = filename1[filename1.Count() - 1];


                                WorkImage.OriginalImage.Save(WorkImage.ImageFolderName + @"\" + filename2);

                                var xx = new ImageDisplay("원본 이미지", WorkImage.OriginalImage)
                                {
                                    StartPosition = FormStartPosition.CenterParent,
                                    MdiParent = this
                                };

                                xx.Show();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    toolStripStatusLabel1.Text = ex.Message;
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xx = new AboutBox
            {
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };
            xx.Show();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void accountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xx = new Account
            {
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };
            xx.Show();
        }

        private void imageResolutionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var xx = new ImageResolution
            {
                StartPosition = FormStartPosition.CenterScreen,
                TopMost = true
            };

            xx.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (WorkImage.OriginalImage != null)
            {

                var xx = new Convert
                {
                    StartPosition = FormStartPosition.CenterParent,
                    MdiParent = this
                };
                xx.Show();
            }
            else
            {
                toolStripStatusLabel1.Text = @"먼저 원본 이미지를 로드하세요.";
            }

        }

        private void build_environment(object sender, EventArgs e)
        {
            if (!Directory.Exists(WorkImage.ImageFolderName))
            {
                Directory.CreateDirectory(WorkImage.ImageFolderName);
            }
        }

        private void Window_CloseAll(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }
        }

        private void openOriginalToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (WorkImage.OriginalImage != null)
            {
                var xx = new ImageDisplay("원본 이미지", WorkImage.OriginalImage)
                {
                    StartPosition = FormStartPosition.CenterParent,
                    MdiParent = this
                };

                xx.Show();
            }
            else
            {
                toolStripStatusLabel1.Text =  @"먼저 원본 이미지를 로드하세요.";
            }

        }

        private void uploadAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (WorkImage.OriginalImage == null)
            {
                toolStripStatusLabel1.Text = @"먼저 원본 이미지를 로드하세요.";
                return;
            }

            if (WorkImage.ConvertedImages.Count == 0)
            {
                toolStripStatusLabel1.Text = @"먼저 이미지를 변환하세요.";
                return;                
            }

            var xx = new Upload()
            {
                StartPosition = FormStartPosition.CenterParent,
                MdiParent = this
            };

            xx.Show();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }
    }
}