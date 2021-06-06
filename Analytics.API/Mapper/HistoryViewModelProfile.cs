using Analytics.API.Models;
using Analytics.API.Models.DTO;
using AutoMapper;

namespace Analytics.API.Mapper
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
