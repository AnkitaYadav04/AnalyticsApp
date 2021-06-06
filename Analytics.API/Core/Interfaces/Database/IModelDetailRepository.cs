using Analytics.API.Data.DTO;
using Analytics.API.Models.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Database
{
    public interface IModelDetailRepository
    {
        Task<List<ModelDTO>> GetModelDetails();
        Task<List<HistoryDTO>> GetHistoryDetails(DateTime? fromDate, DateTime? toDate, string filterModel, string filterCommodity);
        Task<List<ModelDTO>> GetModelDetailsWithFilter(DateTime? fromDate = null,
            DateTime? toDate = null,
            string filterModel = null, string filterCommodity = null);
    }
}
