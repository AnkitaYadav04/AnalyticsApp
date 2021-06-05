using AngaloAmericanAnalytics.API.Core.Interfaces.Database;
using AngaloAmericanAnalytics.API.Core.Interfaces.Logic;
using AngaloAmericanAnalytics.API.Models;
using AngaloAmericanAnalytics.API.Models.DTO;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Logic.Implementation
{
    public class HistoryLogic : IHistoryLogic
    {
        private readonly IModelDetailRepository _modelDetailRepository;
        private readonly IMapper _mapper;
        public HistoryLogic(IModelDetailRepository modelDetailRepository, IMapper mapper)
        {
            _modelDetailRepository = modelDetailRepository;
            _mapper = mapper;
        }
       

        public async Task<List<HistoryViewModel>> GetHistoryDetailsAsync(DateTime? fromDate, DateTime? toDate, string filterModel, string filterCommodity)
        {
           
            var response = await _modelDetailRepository.GetHistoryDetails(fromDate, toDate, filterModel, filterCommodity);

            return _mapper.Map<List<HistoryDTO>, List<HistoryViewModel>>(response);
        }
    }
}
