using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;

namespace Kol7A
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void WczytajObraz_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                Filter = "Pliki graficzne (*.bmp;*.png)|*.bmp;*.png"
            };

            if (dialog.ShowDialog() == true)
            {
                try
                {
                    byte[] headerBytes = new byte[16];
                    using (FileStream fs = new FileStream(dialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        fs.Read(headerBytes, 0, headerBytes.Length);
                    }

                    HeaderListBox.Items.Clear();
                    for (int i = 0; i < headerBytes.Length; i++)
                    {
                        HeaderListBox.Items.Add($"Bajt {i + 1}: {headerBytes[i]:X2}"); //X2 - hex
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Błąd podczas odczytu pliku: " + ex.Message);
                }
            }
        }
    }
}
