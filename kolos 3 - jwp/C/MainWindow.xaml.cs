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

namespace WpfApp10;

public class Prostopadloscian
{
    public double Wysokosc { get; set; }
    public double Szerokosc { get; set; }
    public double Grubosc { get; set; }

    public Prostopadloscian(double wysokosc, double szerokosc, double grubosc)
    {
        Wysokosc = wysokosc;
        Szerokosc = szerokosc;
        Grubosc = grubosc;
    }

    public Prostopadloscian(double bok) : this(bok, bok, bok)
    {
    }

    public override string ToString()
    {
        return $"Wysokość: {Wysokosc}, Szerokość: {Szerokosc}, Grubość: {Grubosc}";
    }
}

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
        Prostopadloscian[] figury = new Prostopadloscian[]
   {
        new Prostopadloscian(10, 5, 2), 
        new Prostopadloscian(3),
        new Prostopadloscian(7, 4, 3),
        new Prostopadloscian(6)
   };

        lbxProstopadłościan.Items.Clear();

        foreach (var i in figury)
        {
            lbxProstopadłościan.Items.Add(i);
        }
    }
}