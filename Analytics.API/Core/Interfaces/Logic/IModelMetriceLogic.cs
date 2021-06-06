using Analytics.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Logic
{
    public interface IModelMetriceLogic
    {
        Task<IEnumerable<ModelMericeViewModel>> GetModelMetriceDetailsAsync();
    }
}
