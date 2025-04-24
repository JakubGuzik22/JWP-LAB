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

namespace WpfApp3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>

public interface IObywatel
{
    string Identyfikator { get; }
}

public interface IStudent
{
    string Identyfikator { get; }
}

public class StudentPolitechniki : IObywatel, IStudent
{
    private readonly string pesel;
    private readonly string nrAlbumu;

    public StudentPolitechniki(string pesel, string nrAlbumu)
    {
        this.pesel = pesel;
        this.nrAlbumu = nrAlbumu;
    }

    string IObywatel.Identyfikator => pesel;
    string IStudent.Identyfikator => nrAlbumu;
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void btnClick_Click(object sender, RoutedEventArgs e)
    {
        StudentPolitechniki student = new("92010112345", "123456");

        //IObywatel pesel = student;
        //IStudent idStudenta = student;

        //lblPesel.Content = "PESEL: " + pesel.Identyfikator;
        //lblNrAlbumu.Content = "Numer albumu: " + idStudenta.Identyfikator;

        lblPesel.Content = "PESEL: " + ((IObywatel)student).Identyfikator;
        lblNrAlbumu.Content = "Numer albumu: " + ((IStudent)student).Identyfikator;
    }
}