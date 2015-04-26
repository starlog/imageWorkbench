using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageWorkbench
{
    public partial class ImageDisplay : Form
    {
        private readonly string _title;
        private readonly Image _image;

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
                Text
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

        private void Handle_MouseScroll(object sender, MouseEventArgs e)
        {
            if (!panel1.Focused)
            {
                panel1.Focus();
            }
        }
    }
}
