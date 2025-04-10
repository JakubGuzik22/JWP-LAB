using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace lab4___zadanie_1 //Geometria
{
    public interface IWyświetl
    {
        string PobierzIdentyfikator();
    }
    public static class ListBoxExtensions
    {
        public static void Dodaj(this ListBox listBox, IWyświetl obiekt)
        {
            listBox.Items.Add(obiekt.PobierzIdentyfikator());
        }
    }
    public class Student : IWyświetl
    {
        public string Imię { get; set; }
        public string Nazwisko { get; set; }

        public Student(string imię, string nazwisko)
        {
            Imię = imię;
            Nazwisko = nazwisko;
        }

        public string PobierzIdentyfikator()
        {
            return $"{Imię} {Nazwisko}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Student innyStudent)
            {
                return this.Nazwisko.CompareTo(innyStudent.Nazwisko);
            }
            return -1;
        }
    }
    public abstract class Bryła: IWyświetl
    {
        public string Nazwa { get; }
        public double Gęstość { get; }
        public double CenaZaKg { get; }

        public Bryła(string nazwa, double gęstość, double cenaZaKg)
        {
            Nazwa = nazwa;
            Gęstość = gęstość;
            CenaZaKg = cenaZaKg;
        }

        public abstract double ObliczObjętość();
        public double ObliczMasę() {
            return ObliczObjętość() * Gęstość;
        }
        public double ObliczCenę()
        {
            return ObliczMasę() * CenaZaKg;
        }

        public string PobierzIdentyfikator()
        {
            return $"Nazwa: {Nazwa:F2}, \nGęstość: {Gęstość:F2} kg/m³, \nCena za kg: {CenaZaKg:F2} PLN, " +
                   $"\nObjętość: {ObliczObjętość():F2} m³, \nMasa: {ObliczMasę():F2} kg, \nCena: {ObliczCenę():F2} PLN";
        }

        public int CompareTo(object obj)
        {
            if (obj is Bryła innaBryla)
            {
                return innaBryla.ObliczObjętość().CompareTo(this.ObliczObjętość());
            }
            return 1;
        }
    }

    public class Kula : Bryła
    {
        public double Promień { get; }

        public Kula(string nazwa, double gęstość, double cenaZaKg, double promień)
            : base(nazwa, gęstość, cenaZaKg)
        {
            Promień = promień;
        }

        public override double ObliczObjętość()
        {
            return (4.0 / 3.0) * Math.PI * Math.Pow(Promień, 3);
        }
    }

    public class Stożek : Bryła
    {
        public double Promień { get; }
        public double Wysokość { get; }

        public Stożek(string nazwa, double gęstość, double cenaZaKg, double promień, double wysokość)
            : base(nazwa, gęstość, cenaZaKg)
        {
            Promień = promień;
            Wysokość = wysokość;
        }

        public override double ObliczObjętość()
        {
            return (1.0 / 3.0) * Math.PI * Math.Pow(Promień, 2) * Wysokość;
        }
    }


}
