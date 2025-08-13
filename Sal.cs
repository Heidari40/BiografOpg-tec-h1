using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biograf_Opg
{
    internal class Sal
    {
        public int SalNummer {  get; set; }
        public int AntalRække { get; set; }
        public int AntalSæde {  get; set; }
        public Film Film { get; set; }

        public bool[,] Sæder;

        public Sal(int salNummer, int antalRække, int antalSæds, Film film)
        {
            SalNummer = salNummer;
            AntalRække = antalRække;
            AntalSæde = antalSæds;
            Film = film;
            Sæder = new bool[antalRække, antalSæds];
        }


        // Metode der booker et sæde. Den returnerer 'true', hvis det lykkes.
        public bool BookSæde(int række, int sæde)
        {
            // Tjekker, om sædenummeret er gyldigt
            if (række > 0 && række <= AntalRække && sæde > 0 && sæde <= AntalSæde)
            {
                // Hvis sædet er ledigt (! foran betyder "ikke")
                if (!Sæder[række - 1, sæde - 1])
                {
                    // Markér sædet som optaget
                    Sæder[række - 1, sæde - 1] = true; 

                    // Booking lykkedes
                    return true; 
                }
            }
            // Booking fejlede
            return false; 
        }
        public void TegnSædeoversigt()
        {
            Console.Clear();
            Console.WriteLine($"--- Sædeoversigt for Sal {SalNummer}: {Film.Titel} ---");
            Console.WriteLine();

            // Udskriv sædenumre i toppen
            Console.Write("   ");
            for (int sæde = 0; sæde < AntalSæde; sæde++)
            {
                Console.WriteLine($"{(sæde + 1).ToString().PadLeft(2)} ");
            }
            Console.WriteLine();
            Console.WriteLine("    " + new string('_', AntalSæde* 3));

            // Gå gennem alle rækker og sæder og tegn dem
            for (int række = 0; række < AntalRække; række++)
            {
                Console.Write($"R{række + 1} | ");
                for (int sæde = 0; sæde < AntalSæde; sæde++)
                {
                    if (Sæder[række, sæde])
                    {
                        // Hvis sædet er optaget, farv det rødt
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        // Hvis sædet er ledigt, farv det grønt
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    // Udskriv et farvet kvadrat
                    Console.WriteLine(" ⬛ ");
                    // Sørg for at farven nulstilles efter sædet
                    Console.ResetColor();
                    Console.WriteLine(" ");
                }
                Console.WriteLine();
            }
        }
    }
}

