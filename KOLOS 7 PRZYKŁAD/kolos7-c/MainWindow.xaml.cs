using Microsoft.Win32;
using System.IO;
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

namespace _7c;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnLoadImage_Click(object sender, RoutedEventArgs e)
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        openFileDialog.Filter = "Obrazy BMP (*.bmp)|*.bmp|Obrazy PNG (*.png)|*.png|Wszystkie pliki (*.*)|*.*";

        if (openFileDialog.ShowDialog() == true)
        {
            string filePath = openFileDialog.FileName;

            byte[] headerBytes = new byte[16];
            try
            {
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    fs.Read(headerBytes, 0, 16);
                }

                lstHeaderBytes.Items.Clear();
                foreach (byte b in headerBytes)
                {
                    lstHeaderBytes.Items.Add(b.ToString("X2")); // Wyświetlenie w formacie heksadecymalnym
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd przy wczytywaniu pliku: " + ex.Message);
            }
        }
    }
}