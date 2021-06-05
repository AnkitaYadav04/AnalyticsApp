using AngaloAmericanAnalytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Core.Interfaces.Logic
{
    public interface IModelMetriceLogic
    {
        Task<IEnumerable<ModelMericeViewModel>> GetModelMetriceDetailsAsync();
    }
}
