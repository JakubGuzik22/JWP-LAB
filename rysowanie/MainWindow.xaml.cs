using System;
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

namespace rysowanie_1s4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RysujLinie(int x1, int y1, int x2, int y2, int grubość, Brush pędzel) {
            var myLine = new Line();
            myLine.Stroke = pędzel;
            myLine.X1 = x1;
            myLine.X2 = x2;
            myLine.Y1 = y1;
            myLine.Y2 = y2;

            myLine.StrokeThickness = grubość;
            cvRysunek.Children.Add(myLine);
        }

        private void RysujKolo(int x1, int y1, int promień, Brush pędzel)
        {

            var elips = new Ellipse();
            elips.Stroke = pędzel;
           
            elips.Width = promień*2;
            elips.Height = promień * 2;
            cvRysunek.Children.Add(elips);
            Canvas.SetLeft(elips, 50);
            Canvas.SetTop(elips, 50);

            for (int i = 0; i < 72; i++)
            {
                Line line = new Line();
                line.Stroke = pędzel;
                line.X1 = 150;
                line.Y1 = 150;
                line.X2 = 250;
                line.Y2 = 150;

                line.RenderTransform = new RotateTransform(5 * i, 150, 150);
                cvRysunek.Children.Add(line);
            }

        }

        private void btnRysuj_Click(object sender, RoutedEventArgs e)
        {
            RysujLinie(0, 150, 300, 150, 2, Brushes.Aqua);
            RysujLinie(150, 150, 150, 300, 2, Brushes.Aqua);

        }

        private void btnRysujKrzyżyk_Click(object sender, RoutedEventArgs e)
        {
            int środekX = Convert.ToInt16(txtŚrodek.Text);
            int środekY = Convert.ToInt16(txtŚrodek_Kopiuj.Text);
            RysujLinie(środekX-50, środekY, środekX+50,środekY, 2, Brushes.Aqua);
            RysujLinie(środekX, środekY-50, środekX, środekY+50, 2, Brushes.Aqua);


        }

        private void txtŚrodek_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnRysujDrzewo_Click(object sender, RoutedEventArgs e)
        {
            int środekX = Convert.ToInt16(txtŚrodek.Text);
            int środekY = Convert.ToInt16(txtŚrodek_Kopiuj.Text);
            int promień = Convert.ToInt16(txtPromień.Text);
            RysujKolo(środekX,środekY,promień, Brushes.Aqua);
            //RysujLinie(środekX, środekY - promień, środekX, środekY - promień - promień*2, 2, Brushes.Aqua);
        }
    }
}