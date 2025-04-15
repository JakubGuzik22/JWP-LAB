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

    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
        Towar t1 = new Towar { Ilosc = 10, Cena = 15.0 };
        Towar t2 = new Towar { Ilosc = 5, Cena = 20.0 };

        Towar t3 = t1 + t2;

        lblWynik.Content = t3.ToString();
    }
}
