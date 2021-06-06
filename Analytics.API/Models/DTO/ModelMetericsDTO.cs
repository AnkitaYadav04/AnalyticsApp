
using Analytics.API.Models;
using Analytics.API.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Data.DTO
{
    
    public class ModelMetericsDTO
    {
        public string Commodity { get; set; }
        public string Model { get; set; }

        public List<PnLYTDDetails> PnLYTDDetails { get; set; }

        public double PnLLTD { get; set; }
        public IEnumerable<ModelMericeDetailDTO> Details { get; set; }
        public double DrawdownYTD { get; set; }

    }

    public class ModelMericeDetailDTO
    {
        public double CurrentPosition { get; set; }
        public double PnlDaily { get; set; }
        public double Price { get; set; }
        public double NewTradeAction { get; set; }
        public DateTime Date { get; set; }
        public string Contract { get; set; }
    }

   
}
