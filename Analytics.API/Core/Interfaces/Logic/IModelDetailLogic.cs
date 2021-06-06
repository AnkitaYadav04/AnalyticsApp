using Analytics.API.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Logic.Interface
{
    public interface IModelDetailLogic
    {
        Task<List<Model>> GetModelDetails();
    }
}
