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

namespace WpfApp2;

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
        Stack<IWyświetlana> stos = new();

        stos.Push(new Towar("Chleb", "Spożywcze"));
        stos.Push(new Towar("Mleko", "Nabiał"));
        stos.Push(new Towar("Masło", "Nabiał"));

        stos.Push(new Mieszkanie("ul. Kwiatowa 5", 3));
        stos.Push(new Mieszkanie("ul. Długa 7", 2));
        stos.Push(new Mieszkanie("ul. Krótka 1", 1));

        lbxDane.Items.Clear();

        foreach (var element in stos)
        {
            ((IWyświetlana)element).WyświetlDane(lbxDane);
        }
    }

    public interface IWyświetlana
    {
        void WyświetlDane(ListBox listBox);
    }

    public class Towar : IWyświetlana
    {
        public string Nazwa { get; set; }
        public string Kategoria { get; set; }

        public Towar(string nazwa, string kategoria)
        {
            Nazwa = nazwa;
            Kategoria = kategoria;
        }

        void IWyświetlana.WyświetlDane(ListBox listBox)
        {
            listBox.Items.Add($"Towar: {Nazwa}, Kategoria: {Kategoria}");
        }
    }

    public class Mieszkanie : IWyświetlana
    {
        public string Adres { get; set; }
        public int LiczbaPokoi { get; set; }

        public Mieszkanie(string adres, int liczbaPokoi)
        {
            Adres = adres;
            LiczbaPokoi = liczbaPokoi;
        }

        void IWyświetlana.WyświetlDane(ListBox listBox)
        {
            listBox.Items.Add($"Mieszkanie: {Adres}, Pokoje: {LiczbaPokoi}");
        }
    }
}