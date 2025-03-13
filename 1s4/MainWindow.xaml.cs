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






Oto kod w języku C# dla aplikacji WPF, który definiuje metodę Prostokat, oblicza pole, obwód i przekątną prostokąta na podstawie wartości wprowadzonych w TextBox i wyświetla wynik w MessageBox.

Kod XAML (MainWindow.xaml)

Dodaj dwa TextBox do wprowadzania szerokości i wysokości, oraz Button, który wywoła test metody.

<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="Prostokąt" Height="200" Width="300">
    <Grid>
        <StackPanel Margin="20">
            <TextBox x:Name="txtSzerokosc" PlaceholderText="Podaj szerokość"/>
            <TextBox x:Name="txtWysokosc" PlaceholderText="Podaj wysokość"/>
            <Button Content="Test3" Click="Test3_Click"/>
        </StackPanel>
    </Grid>
</Window>

Kod C# (MainWindow.xaml.cs)

using System;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Metoda Prostokat obliczająca pole, obwód i przekątną
        void Prostokat(double szerokosc, double wysokosc, out double pole, out double obwod, out double przekatna)
        {
            pole = szerokosc * wysokosc;
            obwod = 2 * (szerokosc + wysokosc);
            przekatna = Math.Sqrt(szerokosc * szerokosc + wysokosc * wysokosc);
        }

        private void Test3_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtSzerokosc.Text, out double szerokosc) &&
                double.TryParse(txtWysokosc.Text, out double wysokosc))
            {
                Prostokat(szerokosc, wysokosc, out double pole, out double obwod, out double przekatna);

                string wynik = $"Pole: {pole:F2}\nObwód: {obwod:F2}\nPrzekątna: {przekatna:F2}";
                MessageBox.Show(wynik, "Wyniki", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne liczby!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

using System;
using System.Windows;

namespace WpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Metoda Prostokat obliczająca pole, obwód i przekątną
        void Prostokat(double szerokosc, double wysokosc, out double pole, out double obwod, out double przekatna)
        {
            pole = szerokosc * wysokosc;
            obwod = 2 * (szerokosc + wysokosc);
            przekatna = Math.Sqrt(szerokosc * szerokosc + wysokosc * wysokosc);
        }

        private void Test3_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(txtSzerokosc.Text, out double szerokosc) &&
                double.TryParse(txtWysokosc.Text, out double wysokosc))
            {
                Prostokat(szerokosc, wysokosc, out double pole, out double obwod, out double przekatna);

                string wynik = $"Pole: {pole:F2}\nObwód: {obwod:F2}\nPrzekątna: {przekatna:F2}";
                MessageBox.Show(wynik, "Wyniki", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Wprowadź poprawne liczby!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
