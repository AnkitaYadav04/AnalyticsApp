using AngaloAmericanAnalytics.API.Core.Helpers;
using AngaloAmericanAnalytics.API.Core.Interfaces.Database;
using AngaloAmericanAnalytics.API.Core.Interfaces.Logic;
using AngaloAmericanAnalytics.API.Data.DTO;
using AngaloAmericanAnalytics.API.Models;
using AngaloAmericanAnalytics.API.Models.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Logic.Implementation
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
            var responseData = await _modelDetailRepository.GetModelMetriceDetails();

            var mertriceDetails = responseData.Select(response =>
            {
                var pnlLtdValue = GetPnLLTD(response.Details);
                double drawdownYTD = GetDrawdownYTD(pnlLtdValue.PnlLtds);
                return
                    new ModelMericeViewModel
                    {
                        Commodity = response.Commodity,
                        Model = response.Model,
                        TotalPnLLTD = pnlLtdValue.currentPnlLtd,
                        //PnlLtds = pnlLtdValue.PnlLtds,
                        DrawdownYTD = drawdownYTD,
                        Details = response.Details.OrderBy(x => x.Date).Select(details =>   // technically this record should be fetch on today day but as
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

        private static (IEnumerable<double> PnlLtds, double currentPnlLtd) GetPnLLTD(IEnumerable<ModelMericeDetailDTO> modelDetails)
        {
            var pnlDaily = modelDetails.OrderBy(x => x.Date).Select(s => s.PnlDaily);

            return MetriceCalculationHelper.CalculatePnLLTD(pnlDaily);

        }

        private static IEnumerable<PnLYTDDetails> CalculatePnlYTD(IEnumerable<ModelMericeDetailDTO> modelDetails)
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
