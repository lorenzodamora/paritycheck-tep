using System;
/*using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/

namespace paritycheck
{
    internal class Program
    {
        public static void Main()
        {
            do
            {
                int asc;
                do //controlli
                {
                    Console.Write("Inserisci un carattere: ");
                    char car = Console.ReadKey().KeyChar;
                    //calcola il codice ASCII
                    asc = (int)car;
                    Console.WriteLine($"\nIl codice decimale ASCII: {asc}");
                    if (asc < 0 || asc > 255)
                    {
                        Console.WriteLine("\t\t\t\tcarattere oltre 8 bit\npremi qualunque tasto per reinserire");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    else break;
                } while (true); // euro è fuori da 8 bit
                //converto in binario ASCII
                int[] bin = Binario(asc);
                //visualizzo
                Console.Write("Il codice binario con bit di parità: ");
                foreach (int b in bin) Console.Write(b);
                //calcolo il bit di parità
                Console.WriteLine($" {Parity(bin)}");

                Console.WriteLine("\nripetere la conversione?(scrivi (y)es per ripetere, altro per no");
                if (Console.ReadKey().KeyChar == 'y') Console.Clear();
                else
                {
                    Console.Write("\b \b");
                    break;
                }
            } while (true);
            Console.ReadKey();
        }

        //restituisce la conversione in binario del valore intero decimale
        public static int[] Binario(int dec)
        {
            int[] bin = new int[7];
            for (int i = 6; i >= 0; i--)
            {
                bin[i] = dec % 2;
                dec /= 2;
            }
            //Array.Reverse(bin);
            return bin;
        }

        //restituisce il bit di parità pari o dispari
        public static int Parity(int[] bin)
        {
            int s = 0;
            foreach (int b in bin) s += b;
            return s % 2;
        }
    }
}