using Analytics.API.Models;
using Analytics.API.Models.ViewModel.Metrice;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Logic
{
    public interface IModelMetriceLogic
    {
        Task<IEnumerable<ModelMericeViewModel>> GetModelMetriceDetailsAsync();
    }
}
