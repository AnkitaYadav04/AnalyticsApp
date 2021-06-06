using Analytics.API.Core.Helpers;
using Analytics.API.Core.Interfaces.Database;
using Analytics.API.Core.Interfaces.Logic;
using Analytics.API.Data.DTO;
using Analytics.API.Models;
using Analytics.API.Models.Common;
using Analytics.API.Models.DTO;
using Analytics.API.Models.ViewModel.Metrice;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Logic.Implementation
{
    public class ModelMetriceLogic : IModelMetriceLogic
    {
        private readonly IModelDetailRepository _modelDetailRepository;
        public ModelMetriceLogic(IModelDetailRepository modelDetailRepository)
        {
            _modelDetailRepository = modelDetailRepository;
        }
        public async Task<IEnumerable<ModelMericeViewModel>> GetModelMetriceDetailsAsync()
        {
            var responseData = await _modelDetailRepository.GetModelDetails();

            var mertriceDetails = responseData.Select(response =>
            {
                var pnlLtdValue = GetPnLLTD(response.Details);
                double drawdownYTD = GetDrawdownYTD(pnlLtdValue.PnlLtds);
                return
                    new ModelMericeViewModel
                    {
                        Commodity = response.Commodity?.Trim(),
                        Model = response.Model?.Trim(),
                        TotalPnLLTD = pnlLtdValue.currentPnlLtd,
                        //PnlLtds = pnlLtdValue.PnlLtds,
                        DrawdownYTD = drawdownYTD,
                        Details = response.Details.OrderByDescending(x => x.Date).Select(details =>   // technically this record should be fetch on today day but as
                              new ModelDetails
                              {
                                  Price = details.Price,
                                  PnlDaily = details.PnlDaily,
                                  CurrentPosition = details.CurrentPosition,
                                  Date = details.Date,
                                  NewTradeAction = details.NewTradeAction,
                                  Contract = details.Contract
                              }).FirstOrDefault(),

                        PnLYTDDetails = CalculatePnlYTD(response.Details)

                    };
            });

            return mertriceDetails;
        }

        private static double GetDrawdownYTD(IEnumerable<double> pnlLtd)
        {
            return MetriceCalculationHelper.CalculateDrawdownYTD(pnlLtd);
        }

        private static (IEnumerable<double> PnlLtds, double currentPnlLtd) GetPnLLTD(IEnumerable<ModelDetailDTO> modelDetails)
        {
            var pnlDaily = modelDetails.OrderBy(x => x.Date).Select(s => s.PnlDaily);

            return MetriceCalculationHelper.CalculatePnLLTD(pnlDaily);

        }

        private static IEnumerable<PnLYTDDetails> CalculatePnlYTD(IEnumerable<ModelDetailDTO> modelDetails)
        {
            return modelDetails
                .GroupBy(group => new { group.Date.Year })
                .Select(details =>
                {
                    (IEnumerable<double> PnlLtds, double currentPnlLtd) pnlLtdDetails = GetPnLLTD(details);

                    return new PnLYTDDetails
                    {
                        Year = details.Key.Year,
                        //PnLYTD = pnlLtdDetails.PnlLtds, 
                        TotalPnLYTD = pnlLtdDetails.currentPnlLtd
                    };
                });
        }
    }
}
