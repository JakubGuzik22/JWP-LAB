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
using Microsoft.Data.SqlClient;

namespace lab8a
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

        private void btnPryzcisk_Click(object sender, RoutedEventArgs e)
        {
            using (var połączenie = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Sklep;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"))
            {
                SqlCommand command = new SqlCommand("SELECT * FROM TOWARY", połączenie);
                połączenie.Open();

                SqlDataReader czytnik = command.ExecuteReader();

                lbxTowary.Items.Clear();

                while (czytnik.Read()) {
                    lbxTowary.Items.Add($"{czytnik["Ilosc"]} - Ilość: {czytnik["Nazwa"]} - Cena: {czytnik["Cena"]} zł");
                }
               
                czytnik.Close();
                połączenie.Close();
            }

        }
    }
}