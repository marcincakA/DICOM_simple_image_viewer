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
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.FileName = "Select a DICOM files folder";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path.Text = openFileDialog.FileName;
                }
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            string folderPath = path.Text;
            

            if (File.Exists(filePath) && (Path.GetExtension(filePath).Equals(".dcm", StringComparison.OrdinalIgnoreCase) || 
                Path.GetExtension(filePath).Equals(".dicom", StringComparison.OrdinalIgnoreCase))) 
            { 
                try
                {
                    LogToDebugConsole($"Attempting to extract information from DICOM file:{filePath}...");

                    var file = DicomFile.Open(filePath);
                    foreach (var tag in file.Dataset)
                    {
                        LogToDebugConsole($" {tag} '{file.Dataset.GetValueOrDefault(tag.Tag, 0, "")}'");
                    }
                    var dicomImage = new DicomImage(file.Dataset).RenderImage().As<Bitmap>();

                    canvas.Image = (Image)dicomImage;


                    LogToDebugConsole($"Extract operation from DICOM file successful");

                    //var dcm = EvilDICOM.Core.DICOMObject.Read(filePath);
                    //string photo = dcm.FindFirst(TagHelper.PhotometricInterpretation).DData.ToString();
                    //ushort bitsAllocated = (ushort)dcm.FindFirst(TagHelper.BitsAllocated).DData;
                    //ushort highBit = (ushort)dcm.FindFirst(TagHelper.HighBit).DData;
                    //ushort bitsStored = (ushort)dcm.FindFirst(TagHelper.BitsStored).DData;
                    //ushort rows = (ushort)dcm.FindFirst(TagHelper.Rows).DData;
                    //ushort colums = (ushort)dcm.FindFirst(TagHelper.Columns).DData;
                    //ushort pixelRepresentation = (ushort)dcm.FindFirst(TagHelper.PixelRepresentation).DData;
                    //List<byte> pixelData = (List<byte>)dcm.FindFirst(TagHelper.PixelData).DData_;
                    //List<byte> pixelDataUpdated = (List<byte>)dcm.FindFirst(TagHelper.PixelData).DData_;
                    //int windowWidth = Convert.ToInt32(dcm.FindFirst(TagHelper.WindowWidth).DData);
                    //int windowCenter = Convert.ToInt32(dcm.FindFirst(TagHelper.WindowCenter).DData);
                    //ushort bitsPerPixel = (ushort)dcm.FindFirst(TagHelper.BitsStored).DData;
                    //int minVal = 0;
                    //int maxVal = 255;
                    //int index = 0;

                    //for (int i = 0; i < pixelData.Count; i++)
                    //{
                    //    int adjustedValue;
                    //    if(bitsPerPixel == 8)
                    //    {
                    //        adjustedValue = (pixelData[i] - windowCenter + (windowWidth / 2)) * 255 / windowWidth;
                    //    }

                    //    else if(bitsPerPixel == 12)
                    //    {
                    //        adjustedValue = (pixelData[i] - windowCenter + (windowWidth / 2)) * 4095 / windowWidth;
                    //    }

                    //    else
                    //    {
                    //        adjustedValue = (pixelData[i] - windowCenter + (windowWidth / 2)) * 65535 / windowWidth;
                    //    }
                    //    pixelDataUpdated[i] = (byte)Math.Clamp(adjustedValue, 0, 255);
                    //}

                    //Bitmap bmap = this.createBitmap(colums, rows, bitsAllocated, pixelDataUpdated.ToArray());
                    //Image img = bmap;
                    //canvas.Image = img;

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            else
            {
                MessageBox.Show("Please select a valid PNG file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
