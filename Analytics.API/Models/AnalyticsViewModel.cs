using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Models
{
    public class AnalyticsViewModel
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public IEnumerable<AnalyticsDetails> Details { get; set; }
    }

    public class AnalyticsDetails
    {
        public double CurrentPosition { get; set; }
        public double PnlDaily { get; set; }
        public double Price { get; set; }
        public double NewTradeAction { get; set; }
        public DateTime Date { get; set; }
    }
}
