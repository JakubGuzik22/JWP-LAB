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

namespace lab2_a
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

        private double Kwadrat(double x)
        {
            return Iloczyn(x,x);
        }
        private double Iloczyn(double x, double y)
        {
            return x * y;
        }

        private double PoleKoła(double x)
        {
            return Kwadrat(x) * double.Pi;
        }

        private double ObjętośćWalca(double x,double y)
        {
            return Iloczyn(Kwadrat(x),y) * double.Pi;
        }

        private double ObjętośćWalca(double x)
        {
            return ObjętośćWalca(x, x);
        }


        private void btnIloczyn_Click(object sender, RoutedEventArgs e)
        {
            double liczba1=0, liczba2=0;

            if (!double.TryParse(txtLiczba1.Text, out liczba1) || liczba1 <= 0)
            {
                MessageBox.Show("Błąd: Liczba1 (a lub r) musi być liczbą dodatnią.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (!double.TryParse(txtLiczba2.Text, out liczba2) || liczba2 <= 0)
            {
                MessageBox.Show("Błąd: Liczba2 (b lub H) musi być liczbą dodatnią.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            lblWynik.Content = $"Iloczyn liczb wynosi: {Iloczyn(liczba1, liczba2):F2}";
            lblKwadrat.Content = $"Kwadrat liczby pierwszej wynosi: {Kwadrat(liczba1):F2}";
            lblKoło.Content = $"Pole koła (gdzie r = liczba1) \n wynosi:{PoleKoła(liczba1):F2}";
            lblWalec.Content = $"Objętość walca wynosi: {ObjętośćWalca(liczba1,liczba2):F2}";
            lblWalec2.Content = $"Objętość walca wynosi: {ObjętośćWalca(liczba1):F2}";
        }

        private void btnTest1_Click(object sender, RoutedEventArgs e)
        {
            lbxTest.Items.Add($"Iloczyn liczb wynosi: {Iloczyn(5, 2):F2}");
            lbxTest.Items.Add($"Kwadrat liczby pierwszej wynosi: {Kwadrat(5):F2}");
            lbxTest.Items.Add($"Pole koła (gdzie r = liczba1) \n wynosi:{PoleKoła(5):F2}");
            lbxTest.Items.Add($"Objętość walca wynosi: {ObjętośćWalca(5, 2):F2}");
            lbxTest.Items.Add($"Objętość walca wynosi: {ObjętośćWalca(5):F2}");
        }
    }
}