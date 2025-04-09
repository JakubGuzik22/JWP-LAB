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

namespace WpfApp1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
/// 
public class Obywatel
{
    private string nazwisko;
    private string pesel;

    public static List<Obywatel> Obywatele = new List<Obywatel>();

    public Obywatel(string nazwisko, string pesel)
    {
        this.nazwisko = nazwisko;
        this.pesel = pesel;
        Obywatele.Add(this); 
    }

    public override string ToString()
    {
        return $"Nazwisko: {nazwisko}, PESEL: {pesel}";
    }
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
        new Obywatel("Kowalski", "90010112345");
        new Obywatel("Nowak", "85050567890");
        new Obywatel("Wiśniewski", "78031209876");

        lbxObywatele.Items.Clear();
        foreach (Obywatel o in Obywatel.Obywatele)
        {
            lbxObywatele.Items.Add(o.ToString());
        }
    }
}