using System;
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

namespace WpfApp5;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public class Armata
{
    public double Kaliber { get; set; }
    public double Masa { get; set; }

    public override string ToString()
    {
        return $"Kaliber: {Kaliber} mm, Masa: {Masa} kg";
    }
}

public partial class MainWindow : Window
{
    private Random random = new Random();

    public MainWindow()
    {
        InitializeComponent();
    }

    private T JedenZTrzech<T>(T pierwszy, T drugi, T trzeci)
    {
        int wybór = random.Next(3);

        switch (wybór)
        {
            case 0:
                return pierwszy;
            case 1:
                return drugi;
            case 2:
                return trzeci;
            default:
                return pierwszy;
        }
    }

    private void btnTestString_Click(object sender, RoutedEventArgs e)
    {
        string wynik = JedenZTrzech("Jabłko", "Banan", "Gruszka");
        MessageBox.Show($"Wylosowano: {wynik}", "Wynik losowania (String)");
    }

    private void btnTestArmata_Click(object sender, RoutedEventArgs e)
    {
        var armata1 = new Armata { Kaliber = 75, Masa = 1500 };
        var armata2 = new Armata { Kaliber = 88, Masa = 2000 };
        var armata3 = new Armata { Kaliber = 120, Masa = 3500 };

        Armata wynik = JedenZTrzech(armata1, armata2, armata3);
        MessageBox.Show($"Wylosowano: {wynik}", "Wynik losowania (Armata)");
    }
}