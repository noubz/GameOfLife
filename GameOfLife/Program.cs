using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Program : Funktionen
    {
        static void Main(string[] args)
        {
            // Größe des Spielfeldes festlegen
            // max. 78 laenge & breite
            Spielfeld_laenge = 21;
            Spielfeld_breite = 21;

            // Spielfeld erstellen
            string[,] spielfeld_aktuell = Spielfeld_erstellen();
            string[,] spielfeld_neu = Spielfeld_erstellen();
            
            int generation = 1;
            int nachbarn;

            string lebewesen = "+";
            string nichts = "-";
            string eingabe_spielfeld_fertig;
            string eingabex;
            string eingabey;

            bool eingabe_gueltig = false;

            // Setzen der Generation 0
            do {
                Console.WriteLine("Spielfeld erstellen: \n");
                Spielfeld_ausgeben(spielfeld_aktuell);

                do
                {
                    Console.WriteLine("\nBitte x-Koordinate eingeben: ");
                    eingabex = Console.ReadLine();
                    if (!(double.TryParse(eingabex, out _)) || (Convert.ToInt32(eingabex) - 1) > 21 || (Convert.ToInt32(eingabex) - 1) < 0)
                    {
                        Console.WriteLine("Bitte nur gültige Zahlen eingeben!");
                    }
                    else { eingabe_gueltig = true; };
                } while (!eingabe_gueltig);

                eingabe_gueltig = false;

                do
                {
                    Console.WriteLine("Bitte y-Koordinate eingeben: ");
                    eingabey = Console.ReadLine();
                    if (!(double.TryParse(eingabey, out _)) || (Convert.ToInt32(eingabey) - 1) > 21 || (Convert.ToInt32(eingabey) - 1) < 0)
                    {
                        Console.WriteLine("Bitte nur gültige Zahlen eingeben!");
                    }
                    else { eingabe_gueltig = true; }
                } while (!eingabe_gueltig);

                spielfeld_aktuell[Convert.ToInt32(eingabex) - 1, Convert.ToInt32(eingabey) - 1] = lebewesen;

                Console.WriteLine("\nFertig? ('j' für ja, oder eingabe um weiterzumachen)");
                eingabe_spielfeld_fertig = Console.ReadLine().ToLower();
                Console.Clear();
            } while (eingabe_spielfeld_fertig != "j");

            // Ausgabe des Spielfeldes
            Console.WriteLine("                 ~ ~ ~ G A M E   O F   L I F E ~ ~ ~ \n");
            Console.WriteLine("                            Generation 0");
            Spielfeld_ausgeben(spielfeld_aktuell);

            //neue Generation
            Console.WriteLine("\nBeliebige Taste zum fortfahren drücken\n ('quit zum Abbrechen')");
            Console.ReadKey(true);
            Console.Clear();

            // Schleife für die jeweilige Generation
            while (true)
            {
                // Testen, ob Lebewesen(+) sterben und ob neue geboren werden
                // und setzen bzw. töten dieser Lebewesen(+)
                for (int x = 0; x < Spielfeld_laenge; x++)
                {
                    for (int y = 0; y < Spielfeld_breite; y++)
                    {
                        nachbarn = GetNachbarn(spielfeld_aktuell, x, y);

                        if (nachbarn == 2 || nachbarn == 3)
                        {
                            if (spielfeld_aktuell[y, x] == "-" && nachbarn == 2) {
                                spielfeld_neu[y, x] = nichts;
                            }
                            else { spielfeld_neu[y, x] = lebewesen; }
                        }
                    }
                }

                // Ausgabe des Spielfeldes, der jeweiligen Generation
                Console.WriteLine("                 ~ ~ ~ G A M E   O F   L I F E ~ ~ ~ \n");
                Console.WriteLine("                            " + generation + "-te Generation");

                Spielfeld_ausgeben(spielfeld_neu);

                // Spielende bzw. neue Generation
                Console.WriteLine("\nBeliebige Taste zum fortfahren drücken\n ('quit zum Abbrechen')");
                string eingabe = Console.ReadLine().ToLower();
                if (eingabe == "quit") { break; }

                int anzahl_lebewesen = 0;
                for (int x = 0; x < Spielfeld_laenge; x++)
                {
                    for (int y = 0; y < Spielfeld_breite; y++)
                    {
                        if (spielfeld_neu[y, x] == "+") { anzahl_lebewesen += 1; }
                    }
                }
                if (anzahl_lebewesen <= 0) { break; }

                // Vorbereiten für neue Generation
                Console.Clear();
                spielfeld_aktuell = spielfeld_neu;
                spielfeld_neu = Spielfeld_erstellen();
                generation += 1;
            }

            Console.WriteLine("Das Volk hat " + generation + " Generationen gelebt!");
        }
    }
}
