using Analytics.API.Models.DTO;
using System.Collections.Generic;

namespace Analytics.API.Data.DTO
{
    public class ModelDTO
    {
        public string Commodity { get; set; }
        public string Model { get; set; }
        public IEnumerable<ModelDetailDTO> Details { get; set; }
    }
}
