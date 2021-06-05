using System;
using System.Collections.Generic;

namespace AngaloAmericanAnalytics.API.Models.Common
{
    public class PnLYTDDetails
    {
        public int Year { get; set; }
        public double TotalPnLYTD { get; set; }
        public IEnumerable<double> PnLYTD { get; set; }
    }
}
