using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DICOM
{
    public partial class FullSizedPicture : Form
    {
        public FullSizedPicture()
        {
            InitializeComponent();
        }

        public void SetImage(Image image)
        {
            pictureBoxFullImage.Image = image;
            pictureBoxFullImage.SizeMode = PictureBoxSizeMode.Zoom;
            this.ClientSize = new Size(image.Width, image.Height);
        }
    }
}
