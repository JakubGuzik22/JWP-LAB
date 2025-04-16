using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Generyki
{
    internal class Student:IComparable<Student>
    {
        public string Nazwisko { get; set; }
        public double Ocena { get; set; }

        public Student(string nazwisko, double ocena)
        {
            Nazwisko = nazwisko;
            Ocena = ocena;
        }
        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return Ocena.CompareTo(other.Ocena);
        }

        public override string ToString()
        {
            return $"{Nazwisko} ({Ocena})";
        }
    }


    public static class Porównania
    {
        public static T ZnajdźWiększy<T>(T a, T b) where T : IComparable<T>
        {
            if (a.CompareTo(b) > 0)
                return a;
            else if (a.CompareTo(b) < 0)
                return b;
            else
                return a;
        }
    }

    public class Regał<T> where T : IComparable<T>
    {
        public T Półka1 { get; set; } = default!;
        public T Półka2 { get; set; } = default!;
        public T Półka3 { get; set; } = default!;

        public Regał() { }

        public override string ToString()
        {
            return $"Półka1: {Półka1}, \nPółka2: {Półka2}, \nPółka3: {Półka3}";
        }

        public void WstawNaWolnąPółkę(T item)
        {
            if (Półka1 == null || Półka1.Equals(default(T))) 
            {
                Półka1 = item;
            }
            else if (Półka2 == null ||Półka2.Equals(default(T)))
            {
                Półka2 = item;
            }
            else if (Półka3 == null || Półka3.Equals(default(T)))
            {
                Półka3 = item;
            }
            else
            {
                MessageBox.Show("Brak wolnej półki.");
            }
        }
        public T WolnaPółka
        {
            set
            {
                WstawNaWolnąPółkę(value);
            }
        }
    }
}

