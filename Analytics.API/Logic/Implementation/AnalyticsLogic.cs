using Analytics.API.Core.Interfaces.Database;
using Analytics.API.Core.Interfaces.Logic;
using Analytics.API.Models.ViewModel.Analytics;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Logic.Implementation
{

    public class AnalyticsLogic : IAnalyticsLogic
    {
        private readonly IModelDetailRepository _modelDetailRepository;
        private readonly IMapper _mapper;
        public AnalyticsLogic(IModelDetailRepository modelDetailRepository, IMapper mapper)
        {
            _modelDetailRepository = modelDetailRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<AnalyticsViewModel>> GetAnalyticsDetailsAsync(DateTime? fromDate = null, DateTime? toDate = null, string filterModel = null, string filterCommodity = null)
        {
            if (fromDate != null && toDate != null && fromDate > toDate)
                throw new InvalidOperationException("Invalid Date range");

            var responseData = await _modelDetailRepository.GetModelDetailsWithFilter(fromDate,toDate,filterModel,filterCommodity);

            var analyticResponseData = responseData.Select(response =>
                new AnalyticsViewModel
                {
                    Commodity = response.Commodity?.Trim(),
                    Model = response.Model?.Trim(),
                    Details = response.Details.Select(details =>
                        new AnalyticsDetailsViewModel
                        {
                            Price = details.Price,
                            PnlDaily = details.PnlDaily,
                            CurrentPosition = details.CurrentPosition,
                            Date = details.Date,
                            NewTradeAction = details.NewTradeAction
                        }),

                });

            return analyticResponseData;
        }
    }
}
