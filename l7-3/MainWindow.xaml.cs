using Microsoft.Win32;
using System.IO;
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
using System.Xml.Serialization;
using System.Text.Json;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public class Student
    {
        public string Nazwisko { get; set; }
        public double Ocena { get; set; }
        public Student() {}
        public Student(string nazwisko, double ocena)
        {
            Nazwisko = nazwisko;
            Ocena = ocena;
        }
    }
    public class Grupa
    {
        public string Nazwa { get; set; }
        public List<Student> Studenci { get; set; }
        public Grupa()
        {
            Studenci = new List<Student>();
        }
        public Grupa(string nazwa)
        {
            Nazwa = nazwa;
            Studenci = new List<Student>();
        }

        public int LiczbaStudentów => Studenci.Count;

        public double? ŚredniaOcen
        {
            get
            {
                if (Studenci.Count == 0)
                {
                    return null;
                }
                else
                {
                    return Studenci.Average(s => s.Ocena);
                }
            }
        }

        public void Wyświetl(ListBox listBox)
        {

            listBox.Items.Add($"Grupa: {Nazwa}");

            foreach (var student in Studenci)
            {
                listBox.Items.Add($"{student.Nazwisko} {student.Ocena:F1}");
            }

            listBox.Items.Add($"Liczba studentów: {LiczbaStudentów}");

            if (ŚredniaOcen != null)
            {
                listBox.Items.Add($"Średnia ocen: {ŚredniaOcen.Value:F1}");
            }
            else
            {
                listBox.Items.Add("Średnia ocen: Brak danych");
            }
        }
    }

    public partial class MainWindow : Window
    {

        Grupa Przykładowa = new Grupa("I16");
        public MainWindow()
        {
            InitializeComponent();

            Przykładowa.Studenci.Add(new Student("Kowalski", 4.5));
            Przykładowa.Studenci.Add(new Student("Wiśniewski", 5.0));
            Przykładowa.Studenci.Add(new Student("Nowak", 4.0));

            Przykładowa.Wyświetl(lbxWynik);
        }

        private void btnZapiszXML_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki XML (*.xml)|*.xml";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Grupa));

                        using (StreamWriter writer = new StreamWriter(fs, Encoding.UTF8))
                        {
                            serializer.Serialize(writer, Przykładowa);
                        }
                    }

                    MessageBox.Show("Zapisano dane do pliku.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
        }

        private void btnWczytajXML_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki XML (*.xml)|*.xml";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(Grupa));

                        Grupa grupa = (Grupa)serializer.Deserialize(fs);

                        lbxWynik.Items.Clear();
                        grupa.Wyświetl(lbxWynik);
                    }

                    MessageBox.Show("Pomyślnie wczytano dane z pliku.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
        }

        private void btnZapiszJSON_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki JSON (*.json)|*.json";

            if (saveFileDialog.ShowDialog() == true)
            {
                try
                {
                    var json = JsonSerializer.Serialize(Przykładowa);
                    File.WriteAllText(saveFileDialog.FileName, json, Encoding.UTF8);

                    MessageBox.Show("Zapisano dane do pliku JSON.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
        }

        private void btnWczytajJSON_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki JSON (*.json)|*.json";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    var json = File.ReadAllText(openFileDialog.FileName, Encoding.UTF8);

                    Grupa grupa = JsonSerializer.Deserialize<Grupa>(json);
                    lbxWynik.Items.Clear();
                    grupa.Wyświetl(lbxWynik);

                    MessageBox.Show("Pomyślnie wczytano dane z pliku JSON.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Wystąpił błąd: {ex.Message}");
                }
            }
        }
    }
}