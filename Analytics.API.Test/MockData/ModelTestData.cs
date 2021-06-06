using Analytics.API.Data.DTO;
using Analytics.API.Models.Common;
using Analytics.API.Models.DTO;
using System;
using System.Collections.Generic;

namespace Analytics.API.Test.MockData
{
    public static class ModelTestData
    {

        public static List<ModelDTO> GetModelMetricsTestData()
        {
            var modelMetericsRecord = new List<ModelDTO>()
            {
                new ModelDTO
                {
                    Commodity = "CommodityTest",
                    Model ="ModelTest",
                    Details = new List<ModelDetailDTO>
                    {
                        new ModelDetailDTO
                        {
                            Contract = "Contract1",
                            CurrentPosition = 1,
                            Date = DateTime.Now,
                            NewTradeAction = 1,
                            PnlDaily= 100,
                            Price = 100

                        },
                         new ModelDetailDTO
                         {
                            Contract = "Contract2",
                            CurrentPosition = 2,
                            Date = DateTime.Now.AddDays(-1),
                            NewTradeAction = 2,
                            PnlDaily= 200,
                            Price = 200

                         }
                    }
                }
            };

            return modelMetericsRecord;
        }

        public static List<HistoryDTO> GetHistoryTestData()
        {
            return new List<HistoryDTO>
            {
                new HistoryDTO
                {
                    Commodity ="TestCommodity",
                    Model = "TestModel",
                    HistoryDetails = new List<HistoryDetails>
                    {
                        new HistoryDetails
                        {
                         Date = DateTime.Today,
                         NewTradeAction = 1
                        },
                         new HistoryDetails
                        {
                         Date = DateTime.Today.AddDays(-1),
                         NewTradeAction = 2
                        }
                    }
                }

            };
        }
    }
}
