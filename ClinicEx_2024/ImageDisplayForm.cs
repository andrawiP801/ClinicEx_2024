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
    public partial class ImageDisplayForm : Form
    {
        private PictureBox pictureBox;
        private float zoomFactor = 1.0f;

        public ImageDisplayForm(Image image)
        {
            InitializeComponent();
            this.AutoScroll = true; 

            pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(0, 0),
                Width = image.Width,
                Height = image.Height
            };
            this.Controls.Add(pictureBox);

            pictureBox.MouseWheel += PictureBox_MouseWheel;
            pictureBox.MouseEnter += (sender, e) => pictureBox.Focus(); 
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Width = 1200;
            this.Height = 700;
            this.pictureBox.Width = (int)(this.pictureBox.Image.Width * zoomFactor);
            this.pictureBox.Height = (int)(this.pictureBox.Image.Height * zoomFactor);
            AdjustScrollbars();
        }

        private void PictureBox_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta != 0)
            {
                zoomFactor += e.Delta > 0 ? 0.1f : -0.1f;
                if (zoomFactor < 0.1f) // Minimum zoom factor
                    zoomFactor = 0.1f;
                if (zoomFactor > 10f) // Maximum zoom factor
                    zoomFactor = 10f;

                pictureBox.Width = (int)(pictureBox.Image.Width * zoomFactor);
                pictureBox.Height = (int)(pictureBox.Image.Height * zoomFactor);
                AdjustScrollbars();
            }
        }

        private void AdjustScrollbars()
        {
            this.AutoScrollMinSize = new Size(pictureBox.Width, pictureBox.Height);
        }
    }


}
