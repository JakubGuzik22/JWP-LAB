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

namespace prostokatLubElipsa;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void rbtnElipsa_Checked(object sender, RoutedEventArgs e){}private void rbtnProstokat_Checked(object sender, RoutedEventArgs e){}
   
    
    private bool PobierzWartość(TextBox txtBox, out double wartość)
    {
        return double.TryParse(txtBox.Text, out wartość) && wartość >= 0;
    }
    private void RysujLinie(double x1, double y1, double x2, double y2, int grubość, Brush pędzel)
    {
        var myLine = new Line();
        myLine.Stroke = pędzel;
        myLine.X1 = x1;
        myLine.X2 = x2;
        myLine.Y1 = y1;
        myLine.Y2 = y2;

        myLine.StrokeThickness = grubość;
        cvRysunek.Children.Add(myLine);
    }

    private void RysujElipsę(double x, double y, double szerokość, double wysokość, int grubość,Brush pędzel)
    {
        var myEllipse = new Ellipse();
        myEllipse.Stroke = pędzel;
        myEllipse.StrokeThickness = grubość;
        myEllipse.Width = szerokość;
        myEllipse.Height = wysokość;

        Canvas.SetLeft(myEllipse, x);
        Canvas.SetTop(myEllipse, y);

        cvRysunek.Children.Add(myEllipse);
    }
    private void btnRysuj_Click(object sender, RoutedEventArgs e)
    {
        double x, y, rozmiarA, rozmiarB;

        if (!PobierzWartość(txtXPoczatkowy, out x) ||
        !PobierzWartość(txtYPoczatkowy, out y) ||
        !PobierzWartość(txtRozmiarA, out rozmiarA) ||
        !PobierzWartość(txtRozmiarB, out rozmiarB))
        {
            MessageBox.Show("Wprowadź poprawne wartości liczbowe większe lub równe 0.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (rbtnProstokat.IsChecked == true)
        {
            RysujLinie(x, y, x+rozmiarA, y, 2, Brushes.Green);
            RysujLinie(x, y, x , y + rozmiarB, 2, Brushes.Green);
            RysujLinie(x, y + rozmiarB, x + rozmiarA, y + rozmiarB, 2, Brushes.Green);
            RysujLinie(x + rozmiarA, y , x + rozmiarA, y + rozmiarB, 2, Brushes.Green);

        }

        if (rbtnElipsa.IsChecked == true)
        {
            RysujElipsę(x, y, rozmiarA, rozmiarB, 2,Brushes.Red);
        }
    }

    private void btnCzysc_Click(object sender, RoutedEventArgs e)
    {
        cvRysunek.Children.Clear();
    }
}