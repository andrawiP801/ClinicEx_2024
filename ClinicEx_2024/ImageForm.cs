using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClinicEx_2024
{
    public partial class ImageForm : Form
    {
        private PictureBox pictureBox1;
        public ImageForm(string imagePath)
        {
            InitializeComponent();
            this.Width = 1200;
            this.Height = 700;
            pictureBox1 = new PictureBox();
            pictureBox1.Location = new Point(50, 50);
            pictureBox1.Size = new Size(this.Width - 100, this.Height - 100); 
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            this.Controls.Add(pictureBox1);
            try
            {
                pictureBox1.Image = new Bitmap(imagePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la imagen: " + ex.Message);
            }
        }
    }

}
