using Analytics.API.Models.DTO;
using Analytics.API.Models.ViewModel.History;
using AutoMapper;

namespace Analytics.API.Mapper
{
    public class HistoryViewModelProfile : Profile
    {
        public HistoryViewModelProfile()
        {
            CreateMap<HistoryDTO, HistoryViewModel>()
                .ForMember(x => x.Model, opt => opt.MapFrom(y => y.Model.Trim()))
                .ForMember(x => x.Commodity, opt => opt.MapFrom(y => y.Commodity.Trim()));
            CreateMap<HistoryDetails, HistoryDetailsViewModel>();
        }
    }
}
