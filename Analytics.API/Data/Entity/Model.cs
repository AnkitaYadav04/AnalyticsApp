using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Data.Entity
{
    public class Model
    {
        public int Id { get; set; }
        [StringLength(50),Required]
        public string ModelName { get; set; }
        [StringLength(50), Required]
        public string Commodity { get; set; }
        public IEnumerable<ModelContract> ModelContracts { get; set; }
    }
}
