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

namespace WpfApp2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Policz(out double suma, out int ilosc, params double[] liczby)
    {
        suma = 0;
        ilosc = 0;

        foreach (double liczba in liczby)
        {
            suma += liczba;
            ilosc++;
        }
    }
    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
        Policz(out double suma, out int ilosc, 5, 3, 3, 543, 5, 9, 12);
        double srednia = ilosc > 0 ? suma / ilosc : 0;

        MessageBox.Show($"Suma: {suma:F2}, \n Ilość: {ilosc},\n Średnia: {srednia:F2}");
    }
}