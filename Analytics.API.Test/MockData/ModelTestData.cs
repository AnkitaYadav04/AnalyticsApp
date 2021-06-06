using Analytics.API.Data.DTO;
using Analytics.API.Models.Common;
using Analytics.API.Models.DTO;
using System;
using System.Collections.Generic;

namespace Analytics.API.Test.MockData
{
    public static class ModelTestData
    {

        public static List<ModelMetericsDTO> GetModelMetricsTestData()
        {
            var modelMetericsRecord = new List<ModelMetericsDTO>()
            {
                new ModelMetericsDTO
                {
                    Commodity = "CommodityTest",
                    Model ="ModelTest",
                    DrawdownYTD = 1,
                    PnLLTD = 1,
                    PnLYTDDetails = new List<PnLYTDDetails>
                    {
                       new PnLYTDDetails
                       {
                            PnLYTD = new List<Double>{ 12},
                            TotalPnLYTD =11,
                            Year = 2021
                       }
                    },
                    Details = new List<ModelMericeDetailDTO>
                    {
                        new ModelMericeDetailDTO
                        {
                            Contract = "Contract1",
                            CurrentPosition = 1,
                            Date = DateTime.Now,
                            NewTradeAction = 1,
                            PnlDaily= 100,
                            Price = 100

                        },
                         new ModelMericeDetailDTO
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
