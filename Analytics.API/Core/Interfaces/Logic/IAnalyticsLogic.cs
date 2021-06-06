using Analytics.API.Models.ViewModel.Analytics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Logic
{
    public interface IAnalyticsLogic
    {
        Task<IEnumerable<AnalyticsViewModel>> GetAnalyticsDetailsAsync(DateTime? fromDate = null, DateTime? toDate = null,
            string filterModel = null, string filterCommodity = null);
    }
}
