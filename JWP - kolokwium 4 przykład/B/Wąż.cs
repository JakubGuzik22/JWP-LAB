using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos4B
{
    public class Wąż : Istota
    {
        public string Nazwa { get; set; }
        public int Długość { get; set; }

        public Wąż()
        {
            Nazwa = "Polak Mały";
            Długość = 102;
        }
        public override string Opis { get { return $"Nazwa:{Nazwa}\nDługość:{Długość}"; } }
    }
}
