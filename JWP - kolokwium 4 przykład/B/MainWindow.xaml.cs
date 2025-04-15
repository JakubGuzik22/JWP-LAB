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

namespace Kolos4B;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnWyświetl_Click(object sender, RoutedEventArgs e)
    {
        Istota mentzen = new Kosmita();
        Istota wąż = new Wąż();

        mentzen.Wyświetl();
        wąż.Wyświetl();
    }
}