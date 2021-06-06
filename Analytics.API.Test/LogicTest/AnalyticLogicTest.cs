using Analytics.API.Core.Interfaces.Database;
using Analytics.API.Core.Interfaces.Logic;
using Analytics.API.Data.DTO;
using Analytics.API.Logic.Implementation;
using Analytics.API.Test.MockData;
using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Analytics.API.Test.LogicTest
{
    public class AnalyticLogicTest
    {
        private Mock<IModelDetailRepository> _modelDetailRepository = new Mock<IModelDetailRepository>();
        private readonly IAnalyticsLogic _analyticsLogic;
        private readonly IMapper _mapper ;
        public AnalyticLogicTest()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Startup));

            }).CreateMapper();

            _analyticsLogic = new AnalyticsLogic(_modelDetailRepository.Object, _mapper);
        }
        [Fact]
        public void AnalyticsLogic_GetAnalyticsDetailsAsync_NoRecordInDb_ShouldReturnEmptyList()
        {
            DateTime? fromDate = DateTime.Now.AddDays(-1);
            DateTime? toDate = DateTime.Now;
            string filterModel = string.Empty;
            string filterCommodity = null;

            _modelDetailRepository.Setup(x => x.GetModelDetailsWithFilter(It.IsAny<DateTime>(), It.IsAny<DateTime>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<ModelDTO>());

            var response = _analyticsLogic.GetAnalyticsDetailsAsync(fromDate, toDate, filterModel, filterCommodity).Result;

            Assert.NotNull(response);
        }

        [Fact]
        public void AnalyticsLogic_GetAnalyticsDetailsAsync_RecordExistInDb_ShouldReturnList()
        {
            DateTime? fromDate = DateTime.Now;
            DateTime? toDate = DateTime.Now.AddDays(-1);
            string filterModel = string.Empty;
            string filterCommodity = null;

            _modelDetailRepository.Setup(x => x.GetModelDetailsWithFilter(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(ModelTestData.GetModelTestData());


            var response = _analyticsLogic.GetAnalyticsDetailsAsync().Result;

            Assert.NotNull(response);
            Assert.NotEmpty(response);
        }
    }
}
