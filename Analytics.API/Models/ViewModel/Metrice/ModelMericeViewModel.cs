using Analytics.API.Models.Common;
using System;
using System.Collections.Generic;

namespace Analytics.API.Models.ViewModel.Metrice
{
    public class ModelMericeViewModel
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public IEnumerable<PnLYTDDetails> PnLYTDDetails { get; set; }
        public IEnumerable<Double> PnlLtds { get; set; }
        public double TotalPnLLTD { get; set; }
        public ModelDetails Details { get; set; }
        public double DrawdownYTD { get; set; }

    }
}
