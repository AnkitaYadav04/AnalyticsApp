using Analytics.API.Test.MockData;
using Analytics.API.Core.Interfaces.Database;
using Analytics.API.Data.DTO;
using Analytics.API.Logic.Implementation;
using Analytics.API.Models.Common;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Analytics.API.Test.LogicTest
{
    public class ModelMetriceLogicTest
    {
        private Mock<IModelDetailRepository> _modelDetailRepository = new Mock<IModelDetailRepository>();
        private readonly ModelMetriceLogic _modelMetriceLogic;
        public ModelMetriceLogicTest()
        {
            _modelMetriceLogic = new ModelMetriceLogic(_modelDetailRepository.Object);
        }
        [Fact]
        public void ModelMetriceLogic_GetModelMetriceDetailsAsync_NoRecordInDb_ShouldReturnEmptyList()
        {
            _modelDetailRepository.Setup(x => x.GetModelDetails())
                .ReturnsAsync(new List<Analytics.API.Data.DTO.ModelDTO>());

            var response = _modelMetriceLogic.GetModelMetriceDetailsAsync().Result;

            Assert.Empty(response);
        }

        [Fact]
        public void ModelMetriceLogic_GetModelMetriceDetailsAsync_RecordExistInDb_ShouldReturnList()
        {
            _modelDetailRepository.Setup(x => x.GetModelDetails())
                .ReturnsAsync(ModelTestData.GetModelTestData());


            var response = _modelMetriceLogic.GetModelMetriceDetailsAsync().Result;

            Assert.NotNull(response);
            Assert.NotEmpty(response);
        }


        [Fact]
        public void ModelMetriceLogic_GetModelMetriceDetailsAsync_RecordExistInDb_ShouldReturnLatestDetails()
        {
            _modelDetailRepository.Setup(x => x.GetModelDetails())
                .ReturnsAsync(ModelTestData.GetModelTestData());


            var response = _modelMetriceLogic.GetModelMetriceDetailsAsync().Result;
            var IsLastestRecord = response.Any(x =>!( x.Details.Date.Date < DateTime.Now.Date));

            Assert.NotNull(response);
            Assert.NotEmpty(response);
            Assert.True(IsLastestRecord);
            
        }
    }
}
