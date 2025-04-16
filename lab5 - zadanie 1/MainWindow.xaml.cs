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

namespace laboratorium5
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
        private void Stozek_ZdarzenieBłędu(string opisBłędu)
        {
            MessageBox.Show(opisBłędu, "Błąd");

            lblOpisBłędu.Content = $"Opis błędu: \n {opisBłędu}";
        }
        private void btnUtwórzStożek_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                double promień = Convert.ToDouble(txtPromień.Text);
                double wysokość = Convert.ToDouble(txtWysokość.Text);

                Stożek stozek = new Stożek();

                stozek.ZdarzenieBłędu += Stozek_ZdarzenieBłędu;

                stozek.Promień = promień;
                stozek.Wysokość = wysokość;
            }
            catch (FormatException)
            {
                MessageBox.Show("Proszę podać prawidłowe liczby w polach promienia i wysokości.", "Błąd danych");
            }
        }
    }
}