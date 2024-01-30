using System.IO;
using System.IO.IsolatedStorage;
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

namespace Task4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

       

        private void SaveDataInIsolatedStorage(object sender, RoutedEventArgs e)
        {
            IsolatedStorageFile isolatedStorage = IsolatedStorageFile.GetUserStoreForAssembly();
            var isolatedStorageStream = new IsolatedStorageFileStream(FileNameText.Text, FileMode.Create, isolatedStorage);
            using (StreamWriter writer = new StreamWriter(isolatedStorageStream))
            {
                writer.WriteLine(ContentToSave.Text);
            }

            string[] files = isolatedStorage.GetFileNames(FileNameText.Text);
            if (files.Length > 0)
            {
                isolatedStorageStream = new IsolatedStorageFileStream(FileNameText.Text, FileMode.Open, isolatedStorage);
                using (StreamReader reader = new StreamReader(isolatedStorageStream))
                {
                    MessageBox.Show("Storage content:\n" + reader.ReadToEnd());
                }
            }
        }
    }
}