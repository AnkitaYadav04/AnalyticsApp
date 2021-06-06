using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Data.Entity
{
    public class ModelContract
    {
        public int Id { get; set; }
        public int ModelId { get; set; }
        [StringLength(50), Required]
        public string Contract { get; set; }
        public IEnumerable<ModelDetail> ModelDetails { get; set; }
    }
}
