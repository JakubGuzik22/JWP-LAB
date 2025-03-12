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

namespace losoweLinie;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Random rand = new Random();
    public MainWindow()
    {
        InitializeComponent();
    }
    private void RysujLinie(int x1, int y1, int x2, int y2, int grubość, Brush pędzel)
    {
        var myLine = new Line
        {
            Stroke = pędzel,
            X1 = x1,
            Y1 = y1,
            X2 = x2,
            Y2 = y2,
            StrokeThickness = grubość
        };
        cvRysunek.Children.Add(myLine);
    }

    private void btnRysuj_Click(object sender, RoutedEventArgs e)
    {
        cvRysunek.Children.Clear();

        if (int.TryParse(txtLiczbaLinii.Text, out int liczbaLinii) && liczbaLinii > 0)
        {
            for (int i = 0; i < liczbaLinii; i++)
            {
                int x1 = rand.Next((int)cvRysunek.ActualWidth);
                int y1 = rand.Next((int)cvRysunek.ActualHeight);
                int x2 = rand.Next((int)cvRysunek.ActualWidth);
                int y2 = rand.Next((int)cvRysunek.ActualHeight);

                RysujLinie(x1, y1, x2, y2, 2, Brushes.Red);
            }
        }
        else
        {
            MessageBox.Show("Proszę wprowadzić poprawną liczbę linii!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}