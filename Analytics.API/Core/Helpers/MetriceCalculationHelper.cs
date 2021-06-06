using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Core.Helpers
{
    public static class MetriceCalculationHelper
    {
        public  static double CalculateDrawdownYTD(IEnumerable<double> pnlLtd)
        {
            double peakpnlLtd = pnlLtd.Select(x => x).Max();
            double currentPnLYTD = pnlLtd.LastOrDefault();
            double DrawdownYTD = currentPnLYTD - peakpnlLtd;

            return DrawdownYTD;
        }

        public static (IEnumerable<double> PnlLtds,double currentPnlLtd) CalculatePnLLTD(IEnumerable<double> pnlLtds)
        {
            IEnumerable<double> pnlLtdValues =   pnlLtds.CumulativeSum();
            double currentPnlLtd = pnlLtdValues.LastOrDefault();

            return (pnlLtdValues, currentPnlLtd);

        }

        public static double CalculateVAR(List<double> pnlLtd)
        {
            // Calculate the returns of the closing price Returns = Today’s Price -Yesterday’s Price / Yesterday’s Price
            //Calculate the mean of the returns using the average function
            //Calculate the standard deviation of the returns using STDEV function
            // Finally, we calculate the VaR for 90, 95, and 99 confidence level
            //     using NORM.INV function. This function has three parameters: probability, mean, and standard deviation.In probability,
            //     we use 0.1, 0.05, 0.01 respectively for the VaR(90), VaR(95), and VaR(99)
            
            List<double> returns = CalculateReturns(pnlLtd);
            var average = returns.Average();
            var standardDeviation = StandardDeviation(returns);

            return 0;
        }

        private static List<double> CalculateReturns(List<double> list)
        {
            var response  = (from e in list

                    let nextindex = list.IndexOf(e) + 1

                    let nextelement = list.ElementAt(nextindex == list.Count ? nextindex - 1 : nextindex)

                    select ((e - nextelement) / nextelement)).ToList();

            response.RemoveAt(response.Count - 1);

            return response;
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
