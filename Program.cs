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
                int[] asc = new int[7];
                bool con = true;
                do //controlli
                {
                    Console.Clear();
                    string str;
                    Console.Write("Inserisci 7 caratteri:        |\b\b\b\b\b\b\b\b");
                    //Console.Write(Console.CursorLeft); //23
                    do
                    {
                        str = Console.ReadLine();
                        if (str.Length != 7)
                        {
                            Console.SetCursorPosition(23, 2);
                            Console.Write("non hai inserito 7 caratteri");
                            //Console.Write(Console.CursorLeft); //51
                            Console.SetCursorPosition(23, 1);
                            Console.Write("1234567");
                            Console.SetCursorPosition(23, 0);
                            Console.Write(new string(' ', str.Length));
                            Console.SetCursorPosition(23, 0);
                            Console.Write("       |\b\b\b\b\b\b\b\b");
                        }
                        else
                        {
                            Console.SetCursorPosition(23, 1);
                            Console.Write(new string(' ', 7) + "\n" + new string(' ', 51));
                            break;
                        }
                    } while (true);
                    //calcola il codice ASCII dei 7 caratteri
                    for (int i = 0; i < 7; i++) asc[i] = (int)str[i];
                    Console.SetCursorPosition(0, 2);
                    Console.Write("Il codice decimale ASCII: ");
                    foreach (int n in asc) Console.Write($"{n}|");

                    //controlli
                    for (int i = 0; i < 7; i++) if (asc[i] > 127)
                        {
                            Console.WriteLine($"\nil carattere {str[i]} è oltre 7 bit\npremi qualunque tasto per reinserire");
                            Console.ReadKey();
                            break;
                        }
                        else
                        {
                            con = false;
                            break;
                        }
                } while (con); // euro è fuori da 8 bit
                //converto in binario ASCII
                int[,] bin = Binario(asc);

                /*
                //converto in binario ASCII
                int[,] bin = Binario(asc);
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
                } */
            } while (true);
        }
        
        //restituisce la conversione in binario del valore intero decimale
        public static int[,] Binario(int[] dec)
        {
            int[,] bin = new int[8,8];

            for (int i = 6; i >= 0; i--)
            {
                bin[i,i] = dec % 2;
                dec /= 2;
            }
            //Array.Reverse(bin);
            return bin;
        }

        //restituisce il bit di parità pari o dispari
        public static int Parity(int[,] bin)
        {
            int s = 0;
            foreach (int b in bin) s += b;
            return s % 2;
        }
    }
}