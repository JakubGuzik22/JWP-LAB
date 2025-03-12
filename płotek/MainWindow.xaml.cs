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

namespace płotek;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
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
        cvPłotek.Children.Add(myLine);
    }
    private void cvPłotek_Initialized(object sender, EventArgs e)
    {
        RysujLinie(10, 100, 410, 100, 10, Brushes.Black);
        RysujLinie(10, 300, 410, 300, 10, Brushes.Black);

        for (int i = 0; i < 20; i++)
        {
            int x = 20 + i * 20;
            RysujLinie(x, 50, x, 350, 10, Brushes.Black); // Teraz linie są pionowe
        }
    }
}