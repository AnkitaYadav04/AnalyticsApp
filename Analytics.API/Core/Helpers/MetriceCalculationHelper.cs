using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Core.Helpers
{
    public static class MetriceCalculationHelper
    {
        public  static double CalculateDrawdownYTD(IEnumerable<double> pnlLtd)
        {
            double maxpnlLtd = pnlLtd.Select(x => x).Max();
            double currentPnLYTD = pnlLtd.LastOrDefault();
            double DrawdownYTD = currentPnLYTD - maxpnlLtd;
            CalculateVAR(pnlLtd);
            return DrawdownYTD;
        }

        public static (IEnumerable<double> PnlLtds,double currentPnlLtd) CalculatePnLLTD(IEnumerable<double> pnlLtds)
        {
            IEnumerable<double> pnlLtdValues =   pnlLtds.CumulativeSum();
            double currentPnlLtd = pnlLtdValues.LastOrDefault();

            return (pnlLtdValues, currentPnlLtd);

        }

        public static double CalculateVAR(IEnumerable<double> pnlLtd)
        {
            // Calculate the returns of the closing price Returns = Today’s Price -Yesterday’s Price / Yesterday’s Price
            //Calculate the mean of the returns using the average function
            //Calculate the standard deviation of the returns using STDEV function
            // Finally, we calculate the VaR for 90, 95, and 99 confidence level
            //     using NORM.INV function. This function has three parameters: probability, mean, and standard deviation.In probability,
            //     we use 0.1, 0.05, 0.01 respectively for the VaR(90), VaR(95), and VaR(99)
            List<double> list = new List<double>() { 10, 15, 17, 27 };


            var result = (from e in list

                          let nextindex = list.IndexOf(e) + 1

                          let nextelement = list.ElementAt(nextindex == list.Count ? nextindex - 1 : nextindex)

                          select ((e - nextelement)/ nextelement)).ToList();

            result.RemoveAt(list.Count - 1);

            var res = result;
            var average = res.Average();
            var standardDeviation = StandardDeviation(result);
            return 0;
        }

        public static double StandardDeviation(List<double> numbers)
        {
            // Step 1
            var meanOfNumbers = numbers.Average();

            // Step 2
            var squaredDifferences = new List<double>(numbers.Count);
            foreach (var number in numbers)
            {
                var difference = number - meanOfNumbers;
                var squaredDifference = Math.Pow(difference, 2);
                squaredDifferences.Add(squaredDifference);
            }

            // Step 3
            var meanOfSquaredDifferences = squaredDifferences
                .Average();

            // Step 4
            var standardDeviation = Math.Sqrt(meanOfSquaredDifferences);

            return standardDeviation;
        }
    }
}
