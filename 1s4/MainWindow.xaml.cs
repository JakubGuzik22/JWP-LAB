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

namespace _1s4
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

        private void btnOblicz_Click(object sender, RoutedEventArgs e)
        {
            double r, h, V, poleP = 0, l = 0;
            try
            {
                r = Convert.ToDouble(txtPromień.Text);
                h = Convert.ToDouble(txtWysokość.Text);

                if (r > 0 && h > 0)
                {
                    if (chkObliczanieObjętośći.IsChecked == true)
                    {
                        switch (cbxRodzajBryły.SelectedIndex)
                        {
                            case 0:
                                V = Math.PI * Math.Pow(r, 2) * h;
                                break;
                            case 1:
                                V = 1.0 / 3.0 * Math.PI * Math.Pow(r, 2) * h;

                                break;
                            case 2:
                                V = 4.0 / 3.0 * Math.PI * Math.Pow(r, 3);

                                break;
                            default: throw new NotImplementedException();
                        }
                        lblPierwsza.Content = $"Objętość wynosi: {V:F2}";
                    }
                    poleP = 2 * Math.PI * Math.Pow(r, 2) + 2 * Math.PI * r * h;
                    lblPolePowierzchni.Content = $"Pole powierzchni wynosi: {poleP:F2}";
                }
            }
            catch 
            {
                MessageBox.Show("Zły format danych");
            }
        }

        private void cbxRodzajBryły_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cbxRodzajBryły.SelectedIndex == 2)
            {
                txtWysokość.Visibility = Visibility.Hidden;
            }
            else
            {
                txtWysokość.Visibility = Visibility.Visible;
            }

           // txtWysokość.Visibility = cbxRodzajBryły.SelectedIndex == 2 ? Visibility.Hidden : Visibility.Visible;
        }

        private void btnZamknij_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy jesteś pewien?", "Zamykanie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}