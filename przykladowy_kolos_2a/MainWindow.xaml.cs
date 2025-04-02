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

namespace przykladowy_kolos2a;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    enum Figury {Kwadrat, Koło, Trójkąt, Prostokąt}

    private void btnLosuj_Click(object sender, RoutedEventArgs e)
    {
        Figury[] tablicaFigur = { Figury.Kwadrat, Figury.Prostokąt, Figury.Koło, Figury.Prostokąt, Figury.Trójkąt, Figury.Trójkąt };

        Random rand = new Random();
        Figury wylosowanaFigura = tablicaFigur[rand.Next(tablicaFigur.Length)];

        MessageBox.Show($"Wylosowano: {wylosowanaFigura}", "Losowanie Figury", MessageBoxButton.OK, MessageBoxImage.Information);
    }
}