using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Models
{
    public class HistoryViewModel
    {
        public string Model { get; set; }
        public string Commodity { get; set; }
        public IEnumerable<HistoryDetailsViewModel> HistoryDetails { get; set; }
        //public string Contract { get; set; }
    }

    public class HistoryDetailsViewModel
    {
        public Double NewTradeAction { get; set; }
        public DateTime Date { get; set; }
    }
}
