using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.IO.Compression;

namespace Update
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            WebClient webClient = new WebClient();
            var client = new WebClient();

            try
            {
                System.Threading.Thread.Sleep(5000);
                File.Delete(@".\Pc cleaner.exe");
                client.DownloadFile("http://download1322.mediafire.com/2k3gktfdhk9g/uxi4i9vw40sbhj8/Pc+cleaner.zip", @"Pc cleaner.zip");
                string zipPath = @".\Pc cleaner.zip";
                string extractPath = @".\";
                ZipFile.ExtractToDirectory(zipPath, extractPath);
                File.Delete(@".\Pc cleaner.zip");
                Process.Start(@".\Pc cleaner.exe");
                this.Close();
            }
            catch
            {
                Process.Start("Pc cleaner.exe");
                this.Close();
            }

        }
    }
}
