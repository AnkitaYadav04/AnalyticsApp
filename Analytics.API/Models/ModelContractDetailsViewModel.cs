using Analytics.API.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Models
{
    public class ModelContractDetailsViewModel
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public string Contract { get; set; }
        public IEnumerable<ModelDetails> ModelDetails { get; set; }
    }
}
