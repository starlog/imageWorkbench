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
using ImageProcessor.Imaging.Formats;

namespace ImageWorkbench
{
    public partial class ImageDisplay : Form
    {
        private string _title;
        private Image _image;

        public ImageDisplay()
        {
            _title = null;
            InitializeComponent();
            panel1.AutoScroll = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        public ImageDisplay(string title, Image displayImage)
        {
            _title = title;
            _image = displayImage;

            InitializeComponent();
            panel1.AutoScroll = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
        }

        private void Process_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(_title))
            {
                this.Text
                    = string.Format("{0} ({1}✕{2})",
                        _title,
                        _image.Width.ToString("N0"),
                        _image.Height.ToString("N0"));
            }

            if (_image != null)
            {
                pictureBox1.Image = _image;
            }
        }
    }
}
