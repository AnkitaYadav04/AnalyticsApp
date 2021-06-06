using Analytics.API.Test.MockData;
using Analytics.API;
using Analytics.API.Core.Interfaces.Database;
using Analytics.API.Logic.Implementation;
using Analytics.API.Models;
using Analytics.API.Models.DTO;
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
    public class HistoryLogicTest
    {

        private Mock<IModelDetailRepository> _modelDetailRepository = new Mock<IModelDetailRepository>();
        private readonly HistoryLogic _HistoryLogic;
        private IMapper _mapper;

        public HistoryLogicTest()
        {
            _mapper = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(typeof(Startup));

            }).CreateMapper();

            _HistoryLogic = new HistoryLogic(_modelDetailRepository.Object, _mapper);
        }

        [Fact]
        public void HistoryLogic_GetHistoryDetailsAsync_NoRecordInDb_ShouldReturnEmptyList()
        {
            DateTime? fromDate = null;
            DateTime? toDate = null;
            string filterModel = string.Empty;
            string filterCommodity = string.Empty;

            _modelDetailRepository.Setup(x => x.GetHistoryDetails(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<HistoryDTO>());

            var response = _HistoryLogic.GetHistoryDetailsAsync(fromDate, toDate, filterModel, filterCommodity).Result;

            Assert.NotNull(response);
            Assert.Empty(response);
        }

        [Fact]
        public async Task HistoryLogic_GetHistoryDetailsAsync_InvalidDateRange_ShouldThrowException()
        {
            DateTime? fromDate = DateTime.Now;
            DateTime? toDate = DateTime.Now.AddDays(-1);
            string filterModel = string.Empty;
            string filterCommodity = string.Empty;

            _modelDetailRepository.Setup(x => x.GetHistoryDetails(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(new List<HistoryDTO>());

            var exception = await Record.ExceptionAsync(() =>
               _HistoryLogic.GetHistoryDetailsAsync(fromDate, toDate, filterModel, filterCommodity));

            ///Assert
            Assert.NotNull(exception);
            Assert.Equal("Invalid Date Range", exception.Message);
        }



        [Fact]
        public void HistoryLogic_GetHistoryDetailsAsync_RecordInDb_ShouldReturnHistoryDetails()
        {
            DateTime? toDate = DateTime.Now;
            DateTime? fromDate = DateTime.Now.AddDays(-1);
            string filterModel = string.Empty;
            string filterCommodity = null;

            _modelDetailRepository.Setup(x => x.GetHistoryDetails(It.IsAny<DateTime?>(), It.IsAny<DateTime?>(),
                It.IsAny<string>(), It.IsAny<string>()))
                    .ReturnsAsync(ModelTestData.GetHistoryTestData());

            var response = _HistoryLogic.GetHistoryDetailsAsync(fromDate, toDate, filterModel, filterCommodity).Result;

            Assert.NotNull(response);
            Assert.NotEmpty(response);
        }


    }
}
