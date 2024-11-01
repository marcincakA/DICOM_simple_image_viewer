using EvilDICOM.Core.Helpers;
using EvilDICOM.Core.IO.Reading;
using EvilDICOM.Core.Image;
using EvilDICOM.Core.Element;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Diagnostics;
using DICOM;
using FellowOakDicom;
using FellowOakDicom.Imaging;
using System;

namespace DICOM
{
    public partial class Form1 : Form
    {
        private string fileName;
        private List<string> dicomFilePaths;
        private int currentImageIndex = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        private void browseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                folderBrowserDialog.Description = "Select a DICOM files folder";
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    path.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            string folderPath = path.Text;
            dicomFilePaths = Directory.GetFiles(folderPath, "*.dcm").ToList();

            if (dicomFilePaths.Count > 0)
            {
                // Update slider to reflect the number of images
                imageSlider.Maximum = dicomFilePaths.Count - 1;
                currentImageIndex = 0;

                // Display the first image
                DisplayImage(currentImageIndex);
            }
        }

        private void DisplayImage(int index)
        {
            if(dicomFilePaths == null || dicomFilePaths.Count == 0)
            {
                return;
            }

            if (index >= 0 && index < dicomFilePaths.Count)
            {
                var file = DicomFile.Open(dicomFilePaths[index]);
                var dicomImage = new DicomImage(file.Dataset).RenderImage().As<Bitmap>();
                canvas.Image = (Image)dicomImage;
            }
        }

        private static void LogToDebugConsole(string informationToLog)
        {
            Debug.WriteLine(informationToLog);
        }

        public Bitmap createBitmap(int width, int height, ushort bitsAllocated, byte[] pixelData)
        {
            Bitmap bitmap;

            if (bitsAllocated == 8)
            {
                // Create an 8-bit grayscale bitmap
                bitmap = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

                // Set grayscale color palette
                ColorPalette palette = bitmap.Palette;
                for (int i = 0; i < 256; i++)
                {
                    palette.Entries[i] = Color.FromArgb(i, i, i);
                }
                bitmap.Palette = palette;

                // Lock the bitmap data for direct access
                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

                // Copy pixel data into the bitmap
                System.Runtime.InteropServices.Marshal.Copy(pixelData, 0, bmpData.Scan0, pixelData.Length);

                bitmap.UnlockBits(bmpData);
                return bitmap;
            }
            else if (bitsAllocated == 16)
            {
                // Create a 16-bit grayscale bitmap (not directly supported by Bitmap, so adjust)
                bitmap = new Bitmap(width, height, PixelFormat.Format16bppGrayScale);

                // Copy 16-bit pixel data (convert ushort array as needed)
                BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format16bppGrayScale);
                System.Runtime.InteropServices.Marshal.Copy(pixelData, 0, bmpData.Scan0, pixelData.Length);
                bitmap.UnlockBits(bmpData);
                return bitmap;
            }
            return null;
        }

        private void path_TextChanged(object sender, EventArgs e)
        {

        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void imageSlider_ValueChanged_1(object sender, EventArgs e)
        {
            currentImageIndex = imageSlider.Value;
            DisplayImage(currentImageIndex);
        }
    }
}
