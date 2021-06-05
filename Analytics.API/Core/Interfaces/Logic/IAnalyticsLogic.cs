using AngaloAmericanAnalytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Core.Interfaces.Logic
{
    public interface IAnalyticsLogic
    {
        Task<IEnumerable<AnalyticsViewModel>> GetAnalyticsDetailsAsync();
    }
}
