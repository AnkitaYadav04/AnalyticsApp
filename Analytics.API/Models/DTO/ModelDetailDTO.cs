using System;

namespace Analytics.API.Models.DTO
{
    public class ModelDetailDTO
    {
        public double CurrentPosition { get; set; }
        public double PnlDaily { get; set; }
        public double Price { get; set; }
        public double NewTradeAction { get; set; }
        public DateTime Date { get; set; }
        public string Contract { get; set; }
    }
}
