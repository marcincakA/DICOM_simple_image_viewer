using FellowOakDicom;
using FellowOakDicom.Imaging;

namespace DICOM
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            new DicomSetupBuilder().RegisterServices(s => s.AddFellowOakDicom().AddImageManager<WinFormsImageManager>()).Build();
            Application.Run(new Form1());
        }
    }
}