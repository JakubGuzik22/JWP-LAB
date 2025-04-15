using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Kolos4B
{
    public abstract class Istota
    {
        public abstract string Opis { get; }

        public void Wyświetl()
        {
            MessageBox.Show($"{Opis}","Istota");
        }
    }
}
