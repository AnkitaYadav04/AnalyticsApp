using System;

namespace Analytics.API.Models.ViewModel.Analytics
{
    public class AnalyticsDetailsViewModel
    {
        public double CurrentPosition { get; set; }
        public double PnlDaily { get; set; }
        public double Price { get; set; }
        public double NewTradeAction { get; set; }
        public DateTime Date { get; set; }
    }
}
