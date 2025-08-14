namespace Biograf_Opg
{
    internal class Program
    {
        const int AntalSale = 3;
        const int AntalSæde = 20;
        const int AnalRække = 10;


        static void Main(string[] args)
        {
            

            //Her opret en ny liste, der specifikt kan indeholde film objekter.
            List<Film> filmListe = new List<Film>();

            // Tilgøj film objekter til listen med alle de udvided.
            filmListe.Add(new Film(
              "Inception",
              "En tyv, der stjæler hemmeligheder fra underbevidstheden, får en sidste chance for at få sit liv tilbage.",
              "Christopher Nolan",
              "Sci-fi",
              "11+"
         ));

            filmListe.Add(new Film(
             "The Matrix",
             "En computerhacker opdager den chokerende sandhed om virkeligheden og hans egen rolle i krigen mod maskinerne.",
             "Lana Wachowski",
             "Sci-fi / Action",
             "15+"
         ));

            filmListe.Add(new Film(
              "Pulp Fiction",
              "Flere kriminelle historier flettes sammen i Los Angeles' underverden.",
              "Quentin Tarantino",
              "Krimi / Drama",
              "15+"
          ));


            // Her definder sal-objekter. HVer sal har sin egen film.
            List<Sal> saler = new List<Sal>();
            saler.Add(new Sal(1, AnalRække, AntalSæde, filmListe[0]));
            saler.Add(new Sal(2, AnalRække, AntalSæde, filmListe[1]));
            saler.Add(new Sal(3, AnalRække, AntalSæde, filmListe[2]));

            saler[0].BookSæde(9, 7);
            saler[0].BookSæde(10, 7);
            saler[0].BookSæde(11, 7);
            saler[0].BookSæde(12, 7);

            VisHovedMenu(saler, filmListe);
        }

        // Metode der booker et sæde. Den returnerer 'true', hvis det lykkes.

        private static void WriteCentered(string text, int topPadding = 0)
        {
            for (int i = 0; i < topPadding; i++)
            {
                Console.WriteLine();
            }
            int leftPadding = (Console.WindowWidth / 2) - (text.Length / 2);
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }

        static void VisHovedMenu(List<Sal> saler, List<Film> filmListe)
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                WriteCentered("***Velkommen til biografen!****",4 );

                
                
                //Vis alle salene og deres film
                for (int i = 0; i < saler.Count; i++)
                {

                    WriteCentered($"{i + 1}: Sal {saler[i].SalNummer} - '{saler[i].Film.Titel}'", 1);
                    
                }
                WriteCentered("D. Detejle filem:", 2);
                
                WriteCentered("Hvilken sal vil du du se film i?", 2);
                
                WriteCentered("q. Aflutte program?", 0);

                // Læs brugerens input
                string input = Console.ReadLine(); 

               switch (input)
                {
                    case "1":

                        VisSædeBooking(saler[0]);
                        break;

                    case "2":
                        VisSædeBooking(saler[1]);
                        break;

                    case "3":
                        VisSædeBooking(saler[2]);
                        break;
                    case "d":
                        VisFilmDetaljer(filmListe);
                        break;

                    case "q":
                        return;
                        break;
                    default:
                        Console.WriteLine("Ugyldigt valg. Tryk på en tast for at prøve igen...");
                        Console.ReadKey();
                        break;
                }

            }
        }
         static void VisFilmDetaljer(List<Film> filmListe)
        {
            Console.Clear();
            WriteCentered("***** Filmdetaljer *****", 4);
            Console.WriteLine();

            // Vis alle tilgængelige film, så brugeren kan vælge
            for (int i = 0; i < filmListe.Count; i++)
            {
                WriteCentered($"{i + 1}: {filmListe[i].Titel}");
            }

            Console.WriteLine();
            WriteCentered("Indtast nummeret på den film, du vil se detaljer for, eller 'm' for at gå tilbage til menuen:");

            string input = Console.ReadLine()?.ToLower();

            if (input == "m")
            {
                return;
            }

            if (int.TryParse(input, out int filmValg) && filmValg > 0 && filmValg <= filmListe.Count)
            {
                Film valgtFilm = filmListe[filmValg - 1];
                Console.Clear();
                WriteCentered($"----- Detaljer for '{valgtFilm.Titel}' -----", 4);
                Console.WriteLine();
                WriteCentered($"Beskrivelse: {valgtFilm.Beskrivelse}");
                WriteCentered($"Instruktør: {valgtFilm.Instruktør}");
                WriteCentered($"Genre: {valgtFilm.Genre}");
                WriteCentered($"Aldersgrænse: {valgtFilm.Aldersgrænse}");

                Console.WriteLine();
                WriteCentered("Tryk på en tast for at vende tilbage til menuen...");
                Console.ReadKey();
            }
            else
            {
                WriteCentered("Ugyldigt valg. Tryk på en tast for at prøve igen...");
                Console.ReadKey();
            }
        }


        static void VisSædeBooking(Sal valgtSal)
        {
            while (true)
            {
                valgtSal.TegnSædeoversigt(); // Vis sæderne
                Console.WriteLine();
                Console.WriteLine(" \n     M. Indtast for at vende tilbage til menuen, ");
                Console.WriteLine("    eller");
                Console.Write("     Indtast række og sæde for at booke (f.eks. 5 10): ");
                
                string input = Console.ReadLine();

                if (input.ToLower() == "m")
                {
                    break; // Gå tilbage til hovedmenuen
                }

                // Del input ved mellemrum
                string[] dele = input.Split(' '); 

                //Tjek om input er to tal
                if (dele.Length == 2 && int.TryParse(dele[0], out int række) && int.TryParse(dele[1], out int sæde))
                {
                    //Prøv at booke sædet
                    if (valgtSal.BookSæde(række, sæde))
                    {
                        Console.WriteLine($"Sæde Række {række}, Sæde {sæde} er nu booket!");
                    }
                    else
                    {
                        Console.WriteLine("Fejl: Sædet er optaget eller findes ikke. Prøv igen.");
                    }
                }
                else
                {
                    Console.WriteLine("Ugyldigt format. Tast 'række sæde'. Tryk på en tast...");
                }
                Console.ReadKey();
            }
        }

    }
}
