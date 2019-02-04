using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasTheTrain
{
    class Program
    {

        static List<String> trainSort(String z)
        {
            return trainSort(z, 0);
        }
        static List<String> trainSort(String z, int sorted)
        {
            List<String> pA = new List<String>();
            return trainSort(z, sorted, pA);
        }
        static List<String> trainSort(String train, int sorted, List<String> pastActions)
        {
            int minIndex = train.IndexOf(train.Substring(sorted).ToCharArray().Min(), sorted);

            String g1 = train.Substring(minIndex);
            pastActions.Add(sorted + ".1 Wagons [" + g1 + "] auf Gleis 1!");
            train = train.Substring(0, minIndex);

            String g2 = train.Substring(sorted);
            if (g2.Length > 0)
                pastActions.Add(sorted + ".2 Wagons [" + g2 + "] auf Gleis 2!");
            train = train.Substring(0, sorted);


            train += g1;
            train += g2;
            sorted++;

            if (sorted < train.Length)
            {
                return trainSort(train, sorted, pastActions);
            }
            else
            {
                pastActions.Add("");
                pastActions.Add(train);
                return pastActions;
            }
        }

        static void Main(string[] args)
        {
            String train_raw = "DEBCA";
            String train = String.Join("", train_raw.ToCharArray().Distinct());

            foreach(var s in trainSort(train))
            {
                Console.WriteLine(s);
            }
            Console.ReadLine();
        }
    }
}
