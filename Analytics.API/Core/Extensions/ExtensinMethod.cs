using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Core
{
    public static class ExtensinMethod
    {
        /// <summary>
        /// Calculates a cumulative value for decimal numbers
        /// </summary>
        /// <param name="numbers">Numbers to sum</param>
        /// <returns>Cumulative sum</returns>
        public static IEnumerable<double> CumulativeSum(this IEnumerable<double> sequence)
        {
            double sum = 0;
            foreach (var item in sequence)
            {
                sum += item;
                yield return sum;
            }
        }
    }
}
