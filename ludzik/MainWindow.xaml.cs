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

namespace ludzik;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void CheckBoxChanged(object sender, RoutedEventArgs e)
    {
        RysujCzlowieka();
    }

    private void RysujCzlowieka()
    {
        cvRysunek.Children.Clear();
        Brush pedzel = Brushes.Black;

        if (chbGłowa.IsChecked == true)
            RysujElipsę(90, 10, 50, 50, 2, pedzel);

        if (chbTułów.IsChecked == true)
            RysujElipsę(80, 60, 60, 100, 2, pedzel);

        if (chbLRęka.IsChecked == true)
            RysujLinie(90, 70, 50, 120, 2, pedzel);

        if (chbPRęka.IsChecked == true)
            RysujLinie(130, 70, 170, 120, 2, pedzel);

        if (chbLNoga.IsChecked == true)
            RysujLinie(100, 160, 80, 220, 2, pedzel);

        if (chbPNoga.IsChecked == true)
            RysujLinie(120, 160, 140, 220, 2, pedzel);
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

    private void RysujElipsę(double x, double y, double szerokość, double wysokość, int grubość, Brush pędzel)
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


}