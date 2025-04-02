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

namespace WpfApp3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private double Suma(params double[] liczby)
    {
        if (liczby == null || liczby.Length == 0)
            throw new ArgumentException("Podaj co najmniej jeden parametr.");
        if (liczby.Any(x => x < 0))
            throw new ArgumentException("Parametry nie mogą być ujemne.");

        return liczby.Sum();
    }

    private double ObwódProstokąta(double bok1, double bok2)
    {
        if (bok1 <= 0 || bok2 <= 0)
            throw new ArgumentException("Boki prostokąta muszą być większe od zera.");

        return Suma(2 * bok1, 2 * bok2);
    }

    private void btnOblicz_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            double bok1 = double.Parse(txtBok1.Text);
            double bok2 = double.Parse(txtBok2.Text);

            txtWynik.Text = $"Obwód: {ObwódProstokąta(bok1, bok2)}";
        }
        catch (FormatException)
        {
            MessageBox.Show("Proszę podać poprawne liczby.", "Błąd formatu");
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show(ex.Message, "Błąd argumentu");
        }
        catch (Exception)
        {
            MessageBox.Show("Wystąpił nieoczekiwany błąd.", "Błąd");
        }
    }
}