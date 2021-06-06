using Analytics.API.Models.ViewModel.Analytics;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Logic
{
    public interface IAnalyticsLogic
    {
        Task<IEnumerable<AnalyticsViewModel>> GetAnalyticsDetailsAsync();
    }
}
