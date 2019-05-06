using System;
using System.Collections.Generic;
using System.Linq;

namespace cw
{
    class Program
    {
        delegate bool MeDelegate(int x); //declare delegate (predicate)

        static void Main(string[] args)
        {
        }

        //todo to be removed later
        private static List<double> GetRandomNumbersWithConstraints(int n, int upperLimit, int lowerLimit, double finalSum, int precision = 6)
        {
            if (upperLimit <= lowerLimit || n < 1) //todo improve here
                throw new ArgumentOutOfRangeException();

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            List<double> randomNumbers = new List<double>();

            int adj = (int)Math.Pow(10, precision);

            bool flag = true;
            List<double> weights = new List<double>();
            while (flag)
            {
                foreach (var d in randomNumbers.Where(x => x <= upperLimit && x >= lowerLimit).ToList())
                {
                    if (!weights.Contains(d))  //only distinct
                        weights.Add(d);
                }

                if (weights.Count() == n && weights.Max() <= upperLimit && weights.Min() >= lowerLimit && Math.Round(weights.Sum(), precision) == finalSum)
                    return weights;

                /* worst case - if the largest sum of the missing elements (ie we still need to find 3 elements, 
                 * then the largest sum is 3*upperlimit) is smaller than (finalSum - sumOfValid)
                 */
                if (((n - weights.Count()) * upperLimit < (finalSum - weights.Sum())) ||
                    ((n - weights.Count()) * lowerLimit > (finalSum - weights.Sum())))
                {
                    weights = weights.Where(x => x != weights.Max()).ToList();
                    weights = weights.Where(x => x != weights.Min()).ToList();
                }

                int nValid = weights.Count();
                double sumOfValid = weights.Sum();

                int numberToSearch = n - nValid;
                double sum = finalSum - sumOfValid;

                double j = finalSum - weights.Sum();
                if (numberToSearch == 1 && (j <= upperLimit || j >= lowerLimit))
                {
                    weights.Add(finalSum - weights.Sum());
                }
                else
                {
                    randomNumbers.Clear();
                    int min = lowerLimit;
                    int max = upperLimit;
                    for (int k = 0; k < numberToSearch; k++)
                    {
                        randomNumbers.Add((double)rand.Next(min * adj, max * adj) / adj);
                    }

                    if (sum != 0 && randomNumbers.Sum() != 0)
                        randomNumbers = randomNumbers.ConvertAll<double>(x => x * sum / randomNumbers.Sum());
                }
            }

            return randomNumbers;
        }

    }
}
