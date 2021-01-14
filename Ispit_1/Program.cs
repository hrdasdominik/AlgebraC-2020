using System;
using System.Collections.Generic;

namespace Ispit_1
{
    class Program
    {
        static string ReadStringValueFromConsole(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }

        #region Zadatak 1
        static void Zadatak1()
        {
            Console.WriteLine("Unesite neki tekst.");
            string s = Console.ReadLine();
            char[] array = s.ToCharArray();
            Array.Reverse(array);
            Console.WriteLine(array);
            Console.WriteLine("Kraj zadatka 1.\n");
        }
        #endregion

        #region Zadatak 2
        static void Zadatak2()
        {
            int x = 1;
            List<int> listaBrojeva = new List<int>();
            List<int> brojeviDjeljiviS2 = new List<int>();
            List<int> brojeviDjeljiviS3 = new List<int>();
            List<int> brojeviDjeljiviS2i3 = new List<int>();
            List<int> ostaliBrojevi = new List<int>();

            while (x != 0)
            {
                Console.WriteLine("Unesite prirodni broj:");
                x = int.Parse(Console.ReadLine());
                if(x % 2 == 0 && x % 3 == 0)
                {
                    brojeviDjeljiviS2i3.Add(x);
                }
                else if(x % 2 == 0 && x % 3 != 0)
                {
                    brojeviDjeljiviS2.Add(x);
                }
                else if(x % 2 != 0 && x % 3 == 0)
                {
                    brojeviDjeljiviS3.Add(x);
                }
                else
                {
                    ostaliBrojevi.Add(x);
                }
            }

            Console.WriteLine("\nBrojevi koji su djeljivi s 2 i s 3:");
            brojeviDjeljiviS2i3.Sort();
            foreach (var item in brojeviDjeljiviS2i3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nBrojevi koji su djeljivi s 2");
            brojeviDjeljiviS2.Sort();
            foreach (var item in brojeviDjeljiviS2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nBrojevi koji su djeljivi s 3:");
            brojeviDjeljiviS3.Sort();
            foreach (var item in brojeviDjeljiviS3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nOstali brojevi:");
            ostaliBrojevi.Sort();
            foreach (var item in ostaliBrojevi)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\nKraj zadatka 2.\n");
        }
        #endregion

        #region Zadatak 3
        static void Zadatak3()
        {
            Ucenik ucenik = new Ucenik();

            ucenik.ime = ReadStringValueFromConsole("Unesite ime učenika:");
            ucenik.prezime = ReadStringValueFromConsole("Unesite prezime učenika:");

            ucenik.DatumRodjenja = DateTime.Parse(ReadStringValueFromConsole("\nUnesite datum rođenja učenika <dan.mjesec.godina>"));
            ucenik.Starost();

            ucenik.prosjek = double.Parse(ReadStringValueFromConsole("\nUnesite prosijek učenika:"));
            ucenik.ProsjekRijecima();

            ucenik.NaPromjenuDatumaRodjenja += new Ucenik.NaPromjenuDatumaRodjenjaDelegate(osoba_NaPromjenuDatumaRodjenja);

            Console.WriteLine("Želite li promjeniti datum rođenja učenika?\nDa/Ne");
            string s = Console.ReadLine();
            s.ToLower();
            if(s == "da")
            {
                ucenik.DatumRodjenja = DateTime.Parse(ReadStringValueFromConsole("Unesite datum rođenja učenika <dan.mjesec.godina>"));
                Console.WriteLine("");
                ucenik.Print();
            }
            else if(s == "ne")
            {
                ucenik.Print();
            }
            else
            {
                Console.WriteLine("Pogreška kod unosa.");
                ucenik.Print();
            }

            Console.WriteLine("\nKraj zadatka 3.\n");

            void osoba_NaPromjenuDatumaRodjenja(object sender, EventArgs e)
            {
                Console.WriteLine("Ucenik {0} je promjenio datum rođenja, novi datum rođenja: {1}", ucenik.ime, ((Ucenik)sender).DatumRodjenja.ToShortDateString());
                ucenik.Starost();
            }
        }

        
        #endregion

        static void Main(string[] args)
        {
            while (true)
            {
                switch(ReadStringValueFromConsole("IZBORNIK\n1 - Zadatak 1\n2 - Zadatak 2\n3 - Zadatak 3\n4 - Izlaz iz programa\n\nUnesite broj:"))
                {
                    case "1":
                        Zadatak1();
                        break;
                    case "2":
                        Zadatak2();
                        break;
                    case "3":
                        Zadatak3();
                        break;
                    case "4":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
