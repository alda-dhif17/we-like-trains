using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gueterzug
{
    class Program
    {

        public static String ef(String tset, int sorted)
        {
            int minIndex = tset.IndexOf(tset.Substring(sorted).ToCharArray().Min());
            String g1 = tset.Substring(minIndex);

            String g2 = tset.Substring(sorted, minIndex-sorted);

            tset = tset.Substring(0, sorted);
            tset += g1 + g2;
            sorted++;

            if (sorted < tset.Length)
            {
                return ef(tset, sorted);
            }
            else
            {
                return tset;
            }
        }

        public static String genString(int length)
        {
            String str = "";
            Random rand = new Random();

            for(int i = 0;i < length; i++)
            {
                int choice = rand.Next(0, 2);

                if(choice == 0)
                {
                    str += (char)(rand.Next('a', 'z'));
                }
                else
                {
                    str += (char)(rand.Next('A', 'Z'));
                }
            }

            char[] chArray = str.ToCharArray();
            IEnumerable<Char> chEnum = chArray.Distinct();
            str = "";
            foreach(char c in chEnum)
            {
                str += c;
            }

            return str;
        }
        static void Main(string[] args) {
            Console.Write("Länge (ist nicht unbedingt finale Länge, weil nicht doppeltes vorkommen soll): ");
            int length = Int32.Parse(Console.ReadLine());

            String input = genString(length);
            Console.WriteLine("\nGenerierte Zeichenfolge: {0}\n" +
                "Länge der Zeichenfolge {1}", input, input.Length);

            String output = ef(input, 0);
            Console.WriteLine("\nSortierte Zeichenfolge (Großbuchstaben kommen zuerst): {0}",output);
            Console.ReadLine();
        }
    }
}
