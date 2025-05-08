using lab8a__EF.Model;
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

namespace lab8a__EF
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

        private void btnWczytaj_Click(object sender, RoutedEventArgs e)
        {
            var db = new DBUczelniaJG();

            foreach (var student in db.Studenci.OrderByDescending(s=>s.Ocena))
            {
                lbxStudenci.Items.Add(student);
            }
        }
    }
}