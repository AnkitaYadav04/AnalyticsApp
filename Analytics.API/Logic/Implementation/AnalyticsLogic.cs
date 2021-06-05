using AngaloAmericanAnalytics.API.Core.Interfaces.Database;
using AngaloAmericanAnalytics.API.Core.Interfaces.Logic;
using AngaloAmericanAnalytics.API.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Logic.Implementation
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

        public async Task<IEnumerable<AnalyticsViewModel>> GetAnalyticsDetailsAsync()
        {
            var responseData = await _modelDetailRepository.GetModelMetriceDetails();

            var analyticResponseData = responseData.Select(response =>
                new AnalyticsViewModel
                {
                    Commodity = response.Commodity,
                    Model = response.Model,
                    Details = response.Details.Select(y =>
                        new AnalyticsDetails
                        {
                            Price = y.Price,
                            PnlDaily = y.PnlDaily,
                            CurrentPosition = y.CurrentPosition,
                            Date = y.Date
                        }),

                });

            return analyticResponseData;
        }
    }
}
