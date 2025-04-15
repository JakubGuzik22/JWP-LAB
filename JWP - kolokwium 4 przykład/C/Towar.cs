using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Towar
    {
        public int Ilosc { get; set; }
        public double Cena { get; set; }

        public override string ToString()
        {
            return $"Ilość: {Ilosc}, Cena: {Cena:F2}";
        }

        public static Towar operator +(Towar t1, Towar t2)
        {
            return new Towar
            {
                Ilosc = t1.Ilosc + t2.Ilosc,
                Cena = (t1.Cena + t2.Cena) / 2
            };
        }
    }
}
