using AngaloAmericanAnalytics.API.Data.DTO;
using AngaloAmericanAnalytics.API.Data.Entity;
using AngaloAmericanAnalytics.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Core.Interfaces.Database
{
    public interface IModelDetailRepository
    {
        Task<List<ModelMetericsDTO>> GetModelMetriceDetails();
        Task<List<ModelContractDetailDTO>> GetModelDetailsWithContract();
        Task<List<HistoryDTO>> GetHistoryDetails(DateTime? fromDate, DateTime? toDate, string filterModel, string filterCommodity);
    }
}
