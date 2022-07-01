using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    abstract class Funktionen
    {
        public static int Spielfeld_laenge { get; set; }
        public static int Spielfeld_breite { get; set; }

        public static string[,] Spielfeld_erstellen()
        {
            string[,] spielfeld = new string[Spielfeld_laenge, Spielfeld_breite];

            for (int x = 0; x < Spielfeld_laenge; x++)
            {
                for (int y = 0; y < Spielfeld_breite; y++)
                {
                    spielfeld[x,y] = "-";
                }
            }

            return spielfeld;
        }

        public static void Spielfeld_ausgeben(string[,] spielfeld)
        {
            Console.Write("   ");
            for (int z = 0; z < Spielfeld_laenge; z++)
            {
                if (z < 9) { Console.Write(" " + (z + 1) + " "); }
                else { Console.Write((z + 1) + " "); }
            }
            Console.WriteLine();

            for (int x = 0; x < Spielfeld_laenge; x++)
            {
                if (x < 9) { Console.Write(" " + (x + 1) + "  "); }
                else { Console.Write(x + 1 + "  "); }

                for (int y = 0; y < Spielfeld_breite; y++)
                {
                    Console.Write(spielfeld[y,x] + "  ");
                }
                Console.WriteLine();
            }
            
        }

        public static int GetNachbarn(string[,] spielfeld, int x, int y)
        {
            int nachbarn = 0;

            if ((x - 1) > 0 && (x + 1) < Spielfeld_laenge && 
                (y - 1) > 0 && (y + 1) < Spielfeld_breite)
            {
                if (spielfeld[y - 1, x - 1] == "+") { nachbarn += 1; }
                if (spielfeld[y    , x - 1] == "+") { nachbarn += 1; }
                if (spielfeld[y + 1, x - 1] == "+") { nachbarn += 1; }
                if (spielfeld[y - 1, x    ] == "+") { nachbarn += 1; }
                if (spielfeld[y + 1, x    ] == "+") { nachbarn += 1; }
                if (spielfeld[y - 1, x + 1] == "+") { nachbarn += 1; }
                if (spielfeld[y    , x + 1] == "+") { nachbarn += 1; }
                if (spielfeld[y + 1, x + 1] == "+") { nachbarn += 1; }
            }

            return nachbarn;
        }
    }
}
