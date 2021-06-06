using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Data.Entity
{
    public class ModelDetail
    {
        public int Id { get; set; }
        public int ModelContractId { get; set; }
        public DateTime Date { get; set; }
        public Double Price { get; set; }
        public Double Position { get; set; }
        public Double NewTradeAction { get; set; }
        public Double PnlDaily { get; set; }
    }
}
