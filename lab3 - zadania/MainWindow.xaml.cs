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

using motoryzacja;

namespace lab3_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnZadanieA_Click(object sender, RoutedEventArgs e)
        {
            try{
                Pojazd[] pojazdy =
                {
                    new Pojazd("Rower", 2, 10),
                    new Pojazd("Samochód", 4, 100),
                    new Pojazd("Motocykl", 2, 60),
                    new Pojazd("Samochód miejski", 4, 50),
                    new Pojazd("Ciężarówka", 8, 70)
                };

                PojazdMechaniczny[] pojazdy2 =
                {
                    new PojazdMechaniczny("Rower", 2, 10, 15)
                };

                Samochód[] pojazdy3 =
                {
                    new Samochód("Rower", 2, 10, 10, 10, "BMW")
                };

                wyświetlPojazdy(pojazdy);
                wyświetlPojazdy(pojazdy2);
                wyświetlPojazdy(pojazdy3);
            }
            catch(ArgumentException ex) {
                MessageBox.Show($"Błąd: {ex.Message}");
            }
        }

        private void wyświetlPojazdy(IEnumerable<Pojazd> kolekcja)
        {
            //lbxPojazdy.Items.Clear();
            foreach(var pojazd in kolekcja)
            {
                lbxPojazdy.Items.Add(pojazd);
            }
        }

    }
}
