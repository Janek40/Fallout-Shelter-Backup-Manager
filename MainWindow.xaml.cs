using System;
using System.Collections.Generic;
using System.IO;
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

namespace FalloutBackupApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                BackgroundImg.ImageSource = new BitmapImage(new Uri(Environment.CurrentDirectory + "//images//background.jpg", UriKind.Absolute));
            }
            catch(FileNotFoundException)
            {
                GenericMessage gm = new GenericMessage("Unable to load images//background.jpg", this);
            }
        }

        private void CopyFromTo(string source, string destination)
        {
            string fileName;
            string destFile;

            try
            {
                if (System.IO.Directory.Exists(source))
                {
                    string[] files = System.IO.Directory.GetFiles(source);

                    // Copy the files and overwrite destination files if they already exist. 
                    foreach (string s in files)
                    {
                        // Use static Path methods to extract only the file name from the path.
                        fileName = System.IO.Path.GetFileName(s);
                        destFile = System.IO.Path.Combine(destination, fileName);
                        System.IO.File.Copy(s, destFile, true);
                    }
                }
                else
                {
                    GenericMessage gm = new GenericMessage("Source path does not exist! Did you delete FOS_BACKUPS?", this);
                }
            }
            catch (DirectoryNotFoundException)
            {
                GenericMessage gm = new GenericMessage("Directory not found, have you installed the game? are there any saves?", this);
            }
            catch(Exception)
            {
                Backup_button.IsEnabled = false;
                Restore_button.IsEnabled = false;
                GenericMessage gm = new GenericMessage("YOU ARE NOT RUNNING AS AN ADMINISTRATOR", this);
            }
        }

        private void Backup_button_Click(object sender, RoutedEventArgs e)
        {
            string source = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\AppData\\Local\\FalloutShelter";
            string destination = "backups";
            CopyFromTo(source, destination);
        }

        private void Restore_button_Click(object sender, RoutedEventArgs e)
        {
            string destination = System.Environment.GetEnvironmentVariable("USERPROFILE") + "\\AppData\\Local\\FalloutShelter";
            string source = "backups";
            CopyFromTo(source, destination);
        }
    }
}
