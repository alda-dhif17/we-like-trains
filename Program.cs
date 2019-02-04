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
        static void Main(string[] args) {
            List<char> inputList = "ahdzempz".ToCharArray().ToList();
            IEnumerable<Char> inputEnum = inputList.Distinct();
            String input = "";

            foreach(char ch in inputEnum)
            {
                input += ch;
            }


            String output = ef(input, 0);
            Console.WriteLine(output);
            Console.ReadLine();
        }
    }
}
