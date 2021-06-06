using Analytics.API.Data.DTO;
using Analytics.API.Models;
using Analytics.API.Models.ViewModel.Analytics;
using AutoMapper;

namespace Analytics.API.Mapper
{
    public class AnalyticsViewModelProfile: Profile
    {
        public AnalyticsViewModelProfile()
        {
            CreateMap<ModelDTO, AnalyticsViewModel>();
        }
    }
}
