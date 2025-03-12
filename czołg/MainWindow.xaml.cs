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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace czolg;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void RysujProstokąt(double x, double y, double szerokość, double wysokość,int grubość, Brush pędzel)
    {
        var myRectangle = new Rectangle();
        myRectangle.Stroke = pędzel;
        myRectangle.StrokeThickness = grubość;
        myRectangle.Width = szerokość;
        myRectangle.Height = wysokość;
        myRectangle.Fill = pędzel;

        Canvas.SetLeft(myRectangle, x);
        Canvas.SetTop(myRectangle, y);

        cvRysunek.Children.Add(myRectangle);
    }

    private void RysujKolo(double x, double y, double promień, int grubość, Brush pędzel)
    {
        var myEllipse = new Ellipse();
        myEllipse.Stroke = pędzel;
        myEllipse.StrokeThickness = grubość;
        myEllipse.Width = promień*2;
        myEllipse.Height = promień*2;
        myEllipse.Fill = pędzel;

        Canvas.SetLeft(myEllipse, x);
        Canvas.SetTop(myEllipse, y);

        cvRysunek.Children.Add(myEllipse);
    }
    private void btnRysuj_Click(object sender, RoutedEventArgs e)
    {
        RysujProstokąt(50,50,200,150,2, Brushes.Green);
        RysujProstokąt(250,70,130,50,2, Brushes.Green);
     

        for (int i = 0; i < 4; i++)
        {
            RysujKolo(50+(i*50), 200, 25, 2, Brushes.Green);
        }
    }

}