using System.Reflection.Emit;
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

public class Stozek
{
    private double promien;
    private double wysokosc;

    public double Promien
    {
        get => promien;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Promień musi być większy od zera.");
            promien = value;
        }
    }

    public double Wysokosc
    {
        get => wysokosc;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Wysokość musi być większa od zera.");
            wysokosc = value;
        }
    }

    public Stozek() { }

    public double Objetosc()
    {
        return (1.0 / 3.0) * Math.PI * promien * promien * wysokosc;
    }

    public double PolePowierzchni()
    {
        double l = Math.Sqrt(promien * promien + wysokosc * wysokosc); // tworząca
        return Math.PI * promien * (promien + l);
    }

    public override string ToString()
    {
        return $"Stożek:\n" +
               $"- Promień: {promien}\n" +
               $"- Wysokość: {wysokosc}\n" +
               $"- Objętość: {Objetosc():F2}\n" +
               $"- Pole powierzchni: {PolePowierzchni():F2}";
    }
}

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
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
            var stozek = new Stozek
            {
                Promien = 5,
                Wysokosc = 10
            };

            lblStożek.Content = stozek.ToString();
        }
        catch (ArgumentException ex)
        {
            MessageBox.Show($"Błąd: {ex.Message}");
        }
    }
}