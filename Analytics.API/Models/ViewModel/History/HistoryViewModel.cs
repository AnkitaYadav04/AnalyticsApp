using System.Collections.Generic;

namespace Analytics.API.Models.ViewModel.History
{
    public class HistoryViewModel
    {
        public string Model { get; set; }
        public string Commodity { get; set; }
        public IEnumerable<HistoryDetailsViewModel> HistoryDetails { get; set; }
    }

   
}
