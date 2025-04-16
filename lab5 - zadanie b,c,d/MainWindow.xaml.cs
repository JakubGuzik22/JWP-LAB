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
using Generyki;

namespace lab_5___zadanie_B
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Dictionary<int, Student> studenci;
        public MainWindow()
        {
            InitializeComponent();

            studenci = new Dictionary<int, Student>
            {
                { 12345, new Student("Kowalski", 4.5) },
                { 23456, new Student("Nowak", 5.0) },
                { 34567, new Student("Wiśniewski", 3.8) },
                { 45678, new Student("Lewandowski", 4.2) }
            };
        }

        private void btnSzukaj_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(txtNrAlbumu.Text, out int numerAlbumu))
            {
                if (studenci.ContainsKey(numerAlbumu))
                {
                    Student student = studenci[numerAlbumu];
                    MessageBox.Show($"Student: {student.Nazwisko}, Ocena: {student.Ocena}");
                }
                else
                {
                    MessageBox.Show("Nie znaleziono");
                }
            }
            else
            {
                MessageBox.Show("Proszę podać poprawny numer albumu.");
            }
        }

        private void btnPorównaj_Click(object sender, RoutedEventArgs e)
        {
            int a = 10;
            int b = 20;

            int result = Porównania.ZnajdźWiększy(a, b);
            MessageBox.Show($"Większa liczba: {result}");

            string c = "Jabłko";
            string d = "Gruszka";

            string result2 = Porównania.ZnajdźWiększy(c, d);
            MessageBox.Show($"Większy ciąg: {result2}");


            Student student1 = new Student("Kowalski", 6.5);
            Student student2 = new Student("Nowak", 5.0);

            Student resultStudent = Porównania.ZnajdźWiększy(student1, student2);
            MessageBox.Show($"Większy student: {resultStudent.Nazwisko}, ocena: {resultStudent.Ocena}");
        }

        private void btnRegały_Click(object sender, RoutedEventArgs e)
        {
            Regał<double> regałDouble = new Regał<double>();
            regałDouble.Półka1 = 3.14;
            //regałDouble.WolnaPółka = 40.40;
            regałDouble.WstawNaWolnąPółkę(2.71);
            //regałDouble.WstawNaWolnąPółkę(30.30);
            regałDouble.WolnaPółka = 1.41;
            MessageBox.Show(regałDouble.ToString());

            //sprawdzzemie czy wolna półka
            regałDouble.WolnaPółka = 15.23;
            MessageBox.Show(regałDouble.ToString());


            Regał<int> regałInt = new Regał<int>();
            regałInt.Półka1 = 3;
            regałInt.WstawNaWolnąPółkę(2);
            regałInt.WolnaPółka = 1;
            MessageBox.Show(regałInt.ToString());

            Regał<Student> regałStudent = new Regał<Student>();
            regałStudent.Półka1 = new Student("Kowalski", 4.5);
            regałStudent.WstawNaWolnąPółkę(new Student("Nowak", 5.0));
            regałStudent.WolnaPółka = new Student("Wiśniewski", 3.8);
            MessageBox.Show(regałStudent.ToString());
        }
    }
}