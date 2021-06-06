using Analytics.API.Core.Interfaces.Database;
using Analytics.API.Core.Interfaces.Logic;
using Analytics.API.Data.DTO;
using Analytics.API.Models;
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

        public async Task<IEnumerable<AnalyticsViewModel>> GetAnalyticsDetailsAsync()
        {
            var responseData = await _modelDetailRepository.GetModelMetriceDetails();

            var analyticResponseData = responseData.Select(response =>
                new AnalyticsViewModel
                {
                    Commodity = response.Commodity,
                    Model = response.Model,
                    Details = response.Details.Select(y =>
                        new AnalyticsDetailsViewModel
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
