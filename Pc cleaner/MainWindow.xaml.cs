using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Net;




namespace Pc_cleaner
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

            try
            {
                if (!webClient.DownloadString("https://pastebin.com/raw/Js93htRS").Contains("1.0.0"))
                {
                    if (MessageBox.Show("Looks like there is an update! Do you want to download it?", "Update", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes) using (var client = new WebClient())
                        {
                            Process.Start("Update.exe");
                            this.Close();
                        }
                }
            }
            catch
            {

            }
        }

        //Analyser
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            lastDate.Text = DateTime.Now.ToLongDateString();
            lastTime.Text = DateTime.Now.ToLongTimeString();
            progressbar.Visibility = Visibility.Visible;

            Thread.Sleep(1000);
            progressbar.Value = 0;

            Task.Run(() =>
            {
                for (int i = 0; i <= 100; i++)
                {
                    Thread.Sleep(50);
                    this.Dispatcher.Invoke(() =>
                    {
                        progressbar.Value = i;
                        if (i == 99)
                        {
                            ProgressTextBlock.Text = "Analyse terminée";
                        }

                    });
                }

            });


            DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Temp");
            FileInfo[] fiArr = di.GetFiles();
            long b = 0;
            foreach (var fi in fiArr)
            {
                b += fi.Length;
            }

            lbl_TaskStatus.Text = "The size of " + di.Name + " is " + b / 100 + " MB.\n";

        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }


        //Nettoyer
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Temp");
            FileInfo[] fiArr = di.GetFiles();

            foreach (FileInfo file in di.GetFiles())
            {
                try
                {
                    file.Delete();
                }
                catch (Exception)
                {

                }

            }
            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                try
                {
                    dir.Delete(true);
                }
                catch (Exception)
                {

                }

            }

        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {


        }


        private void progressbar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {





        }

        //historique
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

            String line;
            StreamReader sr = new StreamReader(@"C:\Users\Youcode\Desktop\VS\Historique.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                statusAnalyse_date.Text = line;
                line = sr.ReadLine();
            }
            sr.Close();


            DirectoryInfo di = new DirectoryInfo(@"C:\Windows\Temp");
            long size = 0;
            foreach (FileInfo fi in di.GetFiles("*", SearchOption.AllDirectories))
            {
                size += fi.Length;
            }
            double result = size / 1000000;
            File.AppendAllText(@"C:\Users\Youcode\Desktop\VS\Historique.txt", DateTime.Now.ToString() + " " + result.ToString() + " MBs" + Environment.NewLine);
        }
    }
    }




