using Analytics.API.Data.DTO;
using Analytics.API.Data.Entity;
using Analytics.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Database
{
    public interface IModelDetailRepository
    {
        Task<List<ModelMetericsDTO>> GetModelMetriceDetails();
        Task<List<HistoryDTO>> GetHistoryDetails(DateTime? fromDate, DateTime? toDate, string filterModel, string filterCommodity);
    }
}
