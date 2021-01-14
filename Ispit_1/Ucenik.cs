using System;

namespace Ispit_1
{
    internal class Ucenik
    {
        public string ime { get; internal set; }
        public string prezime { get; internal set; }
        private DateTime datumRodjenja;
        public DateTime DatumRodjenja
        {
            get { return datumRodjenja; }
            set
            {
                datumRodjenja = value;
                if (NaPromjenuDatumaRodjenja != null)
                    NaPromjenuDatumaRodjenja(this, null);
            }
        }
        public double prosjek { get; internal set; }

        public void Starost()
        {
            DateTime sadasnje = DateTime.Today;
            TimeSpan interval = sadasnje - datumRodjenja;
            DateTime starost = DateTime.MinValue + interval;
            int godine = starost.Year - 1;
            int mjeseci = starost.Month - 1;
            int dani = starost.Day - 2;
            Console.WriteLine("Ucenik {0} je star {1} godina, {2} mjeseci i {3} dana.", ime, godine, mjeseci, dani);
        }

        public void ProsjekRijecima()
        {
            if(prosjek > 5.0)
            {
                Console.WriteLine("Nevažeća vrijednost");
            }
            else if (prosjek >= 4.5)
            {
                Console.WriteLine("Odličan");
            }
            else if (prosjek >= 3.5)
            {
                Console.WriteLine("Vrlo dobar");
            }
            else if (prosjek >= 2.5)
            {
                Console.WriteLine("Dobar");
            }
            else if (prosjek >= 2)
            {
                Console.WriteLine("Dovoljan");
            }
            else if (prosjek >= 1)
            {
                Console.WriteLine("Nedovoljan");
            }
            else
            {
                Console.WriteLine("Nevažeća vrijednost");
            }
        }

        public void Print()
        {
            Console.WriteLine("Ime: {0}\nPrezime: {1}\nDatum rođenja: {2}\nProsjek: {3}", ime, prezime, datumRodjenja.ToShortDateString(), prosjek);
        }

        public delegate void NaPromjenuDatumaRodjenjaDelegate(object sender, EventArgs args);
        public event NaPromjenuDatumaRodjenjaDelegate NaPromjenuDatumaRodjenja;
    }
}