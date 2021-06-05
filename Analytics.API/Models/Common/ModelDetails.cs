using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Models.Common
{
    public class ModelDetails
    {
        public double CurrentPosition { get; set; }
        public double PnlDaily { get; set; }
        public double Price { get; set; }
        public double NewTradeAction { get; set; }
        public DateTime Date { get; set; }
        public string Contract { get; set; }
    }
}
    