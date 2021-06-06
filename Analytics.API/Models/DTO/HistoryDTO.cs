using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Models.DTO
{
    public class HistoryDTO
    {
        public string Model { get; set; }
        public string Commodity { get; set; }
        public IEnumerable<HistoryDetails> HistoryDetails { get; set; }
        //public string Contract { get; set; }
    }

   
}
