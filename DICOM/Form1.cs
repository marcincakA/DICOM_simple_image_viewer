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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DICOM
{
    public partial class Form1 : Form
    {
        private string fileName;
        private List<string> dicomFilePaths;
        private int currentImageIndex = 0;
        private FullSizedPicture fullSizedPicture;

        public Form1()
        {
            InitializeComponent();
            this.fullSizedPicture = new FullSizedPicture();
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
                DisplayDescription(currentImageIndex);
                DisplayImage(currentImageIndex);
            }
        }

        private void DisplayDescription(int index)
        {
            imageContext.Text = "";
            if (dicomFilePaths == null || dicomFilePaths.Count == 0)
            {
                return;
            }
            if (index >= 0 && index < dicomFilePaths.Count)
            {
                string text = "";
                try
                {
                var file = DicomFile.Open(dicomFilePaths[index]);
                foreach (var tag in file.Dataset)
                {
                    text += ($" {tag}: '{file.Dataset.GetValueOrDefault(tag.Tag, 0, "")}'\n");
                }
                imageContext.Text = text;
                }
                catch (Exception e)
                {
                    LogToDebugConsole($"Error displaying image: {e.Message}");
                }
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
                try
                {
                    var file = DicomFile.Open(dicomFilePaths[index]);
                    var dicomImage = new DicomImage(file.Dataset).RenderImage().As<Bitmap>();
                    this.fullSizedPicture.SetImage(dicomImage);
                    if (!fullSizedPicture.Visible)
                    {
                        fullSizedPicture.Show();

                    }
                }
                catch (Exception e)
                {
                    LogToDebugConsole($"Error displaying image: {e.Message}");
                }
                
            }
        }

        private static void LogToDebugConsole(string informationToLog)
        {
            Debug.WriteLine(informationToLog);
        }

        private void path_TextChanged(object sender, EventArgs e)
        {

        }

        private void canvas_Click(object sender, EventArgs e)
        {

        }

        private void imageSlider_ValueChanged_1(object sender, EventArgs e)
        {
            imageSlider.Enabled = false;
            currentImageIndex = imageSlider.Value;
            DisplayImage(currentImageIndex);
            DisplayDescription(currentImageIndex);
            imageSlider.Enabled = true;
        }
    }
}
