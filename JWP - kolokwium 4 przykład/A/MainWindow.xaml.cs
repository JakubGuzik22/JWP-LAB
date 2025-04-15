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

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnPokaż_Click(object sender, RoutedEventArgs e)
    {
        double[] liczby = new double[] { 3.14, 2.71, 1.41, 0.577, 4.669 };

        DrugieOkno okno = new DrugieOkno();
        okno.Liczby = liczby;
        okno.ShowDialog();
    }
}