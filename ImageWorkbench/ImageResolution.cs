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
    public partial class ImageResolution : Form
    {
        public ImageResolution()
        {
            InitializeComponent();
        }

        private void populate_grid(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Storage.ImageSetups;
            dataGridView1.Refresh();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConfigSaver.Save();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
