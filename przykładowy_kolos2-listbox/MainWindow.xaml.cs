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

namespace WpfApp4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private int[,] tablica = new int[4, 4];

    public MainWindow()
    {
        InitializeComponent();
        WypelnijTablice();
    }

    private void WypelnijTablice()
    {
        int liczba = 1;
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                tablica[i, j] = liczba++;
            }
        }
    }

    private void BtnWyswietl_Click(object sender, RoutedEventArgs e)
    {
        listBox.Items.Clear();
        for (int i = 0; i < 4; i++)
        {
            listBox.Items.Add(tablica[i, 2]); // Trzecia kolumna (indeks 2)
        }
    }
}