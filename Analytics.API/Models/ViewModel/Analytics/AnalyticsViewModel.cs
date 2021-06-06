using Analytics.API.Models.ViewModel.Analytics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Models.ViewModel.Analytics
{
    public class AnalyticsViewModel
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public IEnumerable<AnalyticsDetailsViewModel> Details { get; set; }
    }

}
