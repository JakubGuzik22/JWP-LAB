using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kolos4B
{
    public class Kosmita : Istota
    {
        public string Gatunek { get; set; }
        public string Planeta { get; set; }

        public Kosmita()
        {
            Gatunek = "Zorgon";
            Planeta = "Xenon";
        }
        public override string Opis { get { return $"Gatunek:{Gatunek}\nPlaneta:{Planeta}"; } }
    }
}
