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

namespace WpfApp4;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public class Pudelko<T>
{
    private T[] przegrody;

    public Pudelko(int liczbaPrzegródek)
    {
        if (liczbaPrzegródek <= 0)
            throw new ArgumentException("Liczba przegródek musi być większa niż 0.");
        przegrody = new T[liczbaPrzegródek];
    }

    public void Włóż(T element, int nrPrzegródki)
    {
        if (nrPrzegródki < 0 || nrPrzegródki >= przegrody.Length)
            throw new ArgumentException("Numer przegródki poza zakresem.");
        przegrody[nrPrzegródki] = element;
    }

    public T Wyciągnij(int nrPrzegródki)
    {
        if (nrPrzegródki < 0 || nrPrzegródki >= przegrody.Length)
            throw new ArgumentException("Numer przegródki poza zakresem.");
        return przegrody[nrPrzegródki];
    }
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
        try
        {
            var mojePudełko = new Pudelko<string>(10);

            mojePudełko.Włóż("Jabłko", 0);
            mojePudełko.Włóż("Banan", 1);
            mojePudełko.Włóż("Gruszka", 2);

            lbxWynik.Items.Clear();
            lbxWynik.Items.Add(mojePudełko.Wyciągnij(0));
            lbxWynik.Items.Add(mojePudełko.Wyciągnij(1));
            lbxWynik.Items.Add(mojePudełko.Wyciągnij(2));
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show($"Błąd: {ex.Message}");
        }
    }
}