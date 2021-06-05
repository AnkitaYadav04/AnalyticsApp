using AngaloAmericanAnalytics.API.Models;
using AngaloAmericanAnalytics.API.Models.DTO;
using AutoMapper;

namespace AngaloAmericanAnalytics.API.Mapper
{
    public class HistoryViewModelProfile : Profile
    {
        public HistoryViewModelProfile()
        {
            CreateMap<HistoryDTO, HistoryViewModel>();
            CreateMap<HistoryDetails, HistoryDetailsViewModel>();
        }
    }
}
