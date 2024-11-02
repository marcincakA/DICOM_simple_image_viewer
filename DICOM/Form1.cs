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
        private FullSizedPicture fullSizedPicture;

        public Form1()
        {
            InitializeComponent();
            this.fullSizedPicture = new FullSizedPicture();
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            // Update to use OpenFileDialog for a single file selection
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "DICOM files (*.dcm)|*.dcm";
            openFileDialog.Title = "Select a DICOM file";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                path.Text = openFileDialog.FileName; // Store the selected file path
            }
        }

        private void load_Click(object sender, EventArgs e)
        {
            string filePath = path.Text;

            if (!string.IsNullOrEmpty(filePath) && System.IO.File.Exists(filePath))
            {
                DisplayDescription(filePath);
                DisplayImage(filePath);
            }
            else
            {
                LogToDebugConsole("Invalid file path or file does not exist.");
            }
        }

        private void DisplayDescription(string filePath)
        {
            imageContext.Text = "";
            try
            {
                var file = DicomFile.Open(filePath);
                string text = "";

                foreach (var tag in file.Dataset)
                {
                    text += ($" {tag}: '{file.Dataset.GetValueOrDefault(tag.Tag, 0, "")}'\n");
                }

                imageContext.Text = text;
            }
            catch (Exception e)
            {
                LogToDebugConsole($"Error displaying description: {e.Message}");
            }
        }

        private void DisplayImage(string filePath)
        {
            try
            {
                var file = DicomFile.Open(filePath);
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

        private static void LogToDebugConsole(string informationToLog)
        {
            Debug.WriteLine(informationToLog);
        }
    }
}
