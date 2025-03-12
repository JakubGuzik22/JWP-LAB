using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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

    private void btnObliczBMI_Click(object sender, RoutedEventArgs e)
    {
        double wzrost = 0, waga = 0, bmi = 0;
        //wzrost = Convert.ToDouble(txtWzrost.Text);
        //waga = Convert.ToDouble(txtWaga.Text);

        if (!double.TryParse(txtWzrost.Text, out wzrost) || wzrost <= 0)
        {
            MessageBox.Show("Błąd: Wzrost musi być liczbą dodatnią.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (!double.TryParse(txtWaga.Text, out waga) || waga <= 0)
        {
            MessageBox.Show("Błąd: Waga musi być liczbą dodatnią.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        bmi = waga / (wzrost * wzrost);

        if (bmi < 18.5)
        {
            lblWynik.Content = $"{bmi:F2}, niedowaga";
        }
        else if (bmi >= 18.5 && bmi < 25.0)
        {
            lblWynik.Content = $"{bmi:F2}, waga prawidłowa";
        }
        else
        {
            lblWynik.Content = $"{bmi:F2}, nadwaga";
        }

    }
}