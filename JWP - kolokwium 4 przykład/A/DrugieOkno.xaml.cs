using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy DrugieOkno.xaml
    /// </summary>
    public partial class DrugieOkno : Window
    {
        public DrugieOkno()
        {
            InitializeComponent();
        }

        public double[] Liczby
        {
            set
            {
                if (value != null)
                {
                    foreach (double liczba in value)
                    {
                        lbxLiczby.Items.Add(liczba);
                    }
                }
            }
        }
    }
}
