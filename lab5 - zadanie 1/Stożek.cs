using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorium5
{
    internal class Stożek
    {
        public delegate void ObsługaBłędu(string opisBłędu);

        public event ObsługaBłędu ZdarzenieBłędu;

        private double promień;
        private double wysokość;

        public double Promień
        {
            get => promień;
            set
            {
                if (value < 0)
                {
                    if (ZdarzenieBłędu != null)
                    {
                        ZdarzenieBłędu("Promień nie może być ujemny.");
                    }
                }
                else
                {
                    promień = value;
                }
            }
        }

        public double Wysokość
        {
            get => wysokość;
            set
            {
                if (value < 0)
                {
                    if (ZdarzenieBłędu != null)
                    {
                        ZdarzenieBłędu("Wysokość nie może być ujemna.");
                    }
                }
                else
                {
                    wysokość = value;
                }
            }
        }
    }
}
