using System.Text;
using System.Windows;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab6___zadanie_B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public enum Kategoria
    {
        Elektronika,
        Odzież,
        Spożywcze
    }
    public class Towar
    {
        public string Nazwa { get; set; } = string.Empty;
        public decimal Cena { get; set; } = 0;
        public int Ilość { get; set; } = 0;
        public Kategoria Kategoria { get; set; } = new Kategoria();

        public Towar(string nazwa, decimal cena, int ilość, Kategoria kategoria)
        {
            Nazwa = nazwa;
            Cena = cena;
            Ilość = ilość;
            Kategoria = kategoria;
        }

        public override string ToString()
        {
            return $"{Nazwa} | {Cena:C} | Ilość: {Ilość} | Kategoria: {Kategoria}";
        }
    }
    public partial class MainWindow : Window
    {
        private List<Towar> towary = new List<Towar>
        {
            new Towar("Laptop", 2500.99m, 10, Kategoria.Elektronika),
            new Towar("T-shirt", 59.99m, 20, Kategoria.Odzież),
            new Towar("Chleb", 3.49m, 50, Kategoria.Spożywcze),
            new Towar("Smartphone", 1799.99m, 2, Kategoria.Elektronika),
            new Towar("Sukienka", 150.00m, 4, Kategoria.Odzież),
            new Towar("Mleko", 2.89m, 15, Kategoria.Spożywcze)
        };
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrzycisk1_Click(object sender, RoutedEventArgs e)
        {
            var wyniki = towary
                .Where(t => t.Ilość > 5)
                .OrderByDescending(t => t.Ilość)
                .ToList();

            lbxWynik1.Items.Clear();
            foreach (var towar in wyniki)
            {
                lbxWynik1.Items.Add(towar.ToString());
            }
        }
    }
}