namespace motoryzacja
{
    public class Pojazd
    {
        private static int liczbaPojazdów = 0; 
        private int _liczbaKół;
        private double _prędkość;
        private int _lp;

        public string Nazwa { get; set; }

        public int LiczbaKół
        {
            get => _liczbaKół;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Proszę podać poprawną liczbę kół!");
                }
                _liczbaKół = value;
            }
        }

        public double Prędkość
        {
            get => _prędkość;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Proszę podać poprawną prędkość!");
                }
                _prędkość = value;
            }
        }

        public int Lp
        {
            get => _lp;
        }

        static Pojazd()
        {
            liczbaPojazdów = 0;
        }

    
        public Pojazd()
        {
            liczbaPojazdów++; 
            _lp = liczbaPojazdów; 
        }

    
        public Pojazd(string nazwa, int liczbaKół, double prędkość) : this()
        {
            Nazwa = nazwa;
            LiczbaKół = liczbaKół;
            Prędkość = prędkość;
        }

   
        public Pojazd(string nazwa, double prędkość) : this(nazwa, 4, prędkość) { }

        public override string ToString()
        {
            return $"{Nazwa}: {LiczbaKół} kół, {Prędkość} km/h, LP: {Lp}/{liczbaPojazdów}";
        }

        public static int LiczbaPojazdów
        {
            get => liczbaPojazdów;
        }
    }

    public class PojazdMechaniczny : Pojazd
    {
        private double _mocSilnika;

        public double MocSilnika
        {
            get => _mocSilnika;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Moc silnika musi być większa od zera!");
                }
                _mocSilnika = value;
            }
        }

        public PojazdMechaniczny() : base() { }

        public PojazdMechaniczny(string nazwa, int liczbaKół, double prędkość, double mocSilnika)
            : base(nazwa, liczbaKół, prędkość)
        {
            MocSilnika = mocSilnika;
        }

        public override string ToString()
        {
            return base.ToString() + $", Moc silnika: {MocSilnika} KM";
        }
    }

    public class Samochód : PojazdMechaniczny
    {
        private int _liczbaPasażerów;
        private string _marka;

        public int LiczbaPasażerów
        {
            get => _liczbaPasażerów;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Liczba pasażerów musi być większa od zera!");
                }
                _liczbaPasażerów = value;
            }
        }

        public string Marka
        {
            get => _marka;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Marka samochodu nie może być pusta!");
                }
                _marka = value;
            }
        }

        public Samochód() : base() { }

        public Samochód(string nazwa, int liczbaKół, double prędkość, double mocSilnika, int liczbaPasażerów, string marka)
            : base(nazwa, liczbaKół, prędkość, mocSilnika)
        {
            LiczbaPasażerów = liczbaPasażerów;
            Marka = marka;
        }

        public override string ToString()
        {
            return base.ToString() + $", Liczba pasażerów: {LiczbaPasażerów}, Marka: {Marka}";
        }
    }
}
