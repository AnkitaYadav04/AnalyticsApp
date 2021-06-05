using AngaloAmericanAnalytics.API.Core.Interfaces.Database;
using AngaloAmericanAnalytics.API.Data.DTO;
using AngaloAmericanAnalytics.API.Models.Common;
using AngaloAmericanAnalytics.API.Models.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Data.Repository
{
    public class ModelDetailRepository : IModelDetailRepository
    {
        private readonly AngaloAmericanAnalyticsDbContext _dbContext;
        public ModelDetailRepository(AngaloAmericanAnalyticsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<HistoryDTO>> GetHistoryDetails(DateTime? fromDate, DateTime? toDate, string filterModel, string filterCommodity)
        {
            try
            {
                var response = await (from details in _dbContext.ModelDetails.Where(x => (fromDate==null || x.Date >= fromDate) && (toDate==null ||x.Date <= toDate))
                                      join contract in _dbContext.ModelContracts on details.ModelContractId equals contract.Id
                                      join model in _dbContext.Models on contract.ModelId equals model.Id
                                      where (filterModel == null || filterModel.ToLower().Equals(model.ModelName.ToLower()))
                                      && (filterCommodity == null || filterCommodity.ToLower().Equals(model.Commodity.ToLower()) )
                                      orderby details.Date descending
                                      select new
                                      {
                                          Commodity = model.Commodity,
                                          Model = model.ModelName,
                                          Details = details,
                                      }).ToListAsync();

                var historyResponse = response.GroupBy(x => new { x.Model, x.Commodity })
                 .Select(y => new HistoryDTO
                 {
                     Model = y.Key.Model,
                     Commodity = y.Key.Commodity,
                     HistoryDetails = y.Select(x => 
                     new HistoryDetails
                        { 
                            Date = x.Details.Date,
                            NewTradeAction = x.Details.NewTradeAction
                        })

                 }).ToList();

                return historyResponse;
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<List<ModelMetericsDTO>> GetModelMetriceDetails()
        {

            var response =  await (from details in _dbContext.ModelDetails
                                  join contract in _dbContext.ModelContracts on details.ModelContractId equals contract.Id
                                  join model in _dbContext.Models on contract.ModelId equals model.Id
                                  orderby details.Date descending
                                  select new {
                                      Commodity = model.Commodity,
                                      Model = model.ModelName,
                                      Details = details,
                                      contractName = contract.Contract
                                  }).ToListAsync();

            var modelResponse = response.GroupBy(x => new { x.Model, x.Commodity })
             .Select(y => new ModelMetericsDTO
             {
                 Model = y.Key.Model,
                 Commodity = y.Key.Commodity,
                 Details = y.Select(x =>
                 new ModelMericeDetailDTO
                 {
                     Date = x.Details.Date,
                     NewTradeAction = x.Details.NewTradeAction,
                     CurrentPosition =x.Details.Position,
                     PnlDaily = x.Details.PnlDaily,
                     Price = x.Details.Price,
                     Contract = x.contractName
                     
                 })

             }).ToList();

            return modelResponse;
        }


        public async Task<List<ModelContractDetailDTO>> GetModelDetailsWithContract()
        {

            var response = await (from details in _dbContext.ModelDetails
                                  join contract in _dbContext.ModelContracts on details.ModelContractId equals contract.Id
                                  join model in _dbContext.Models on contract.ModelId equals model.Id
                                  orderby details.Date descending
                                  select new
                                  {
                                      Commodity = model.Commodity,
                                      Model = model.ModelName,
                                      Details = details,
                                      ContractName = contract.Contract
                                  }).ToListAsync();

            var modelResponse = response.GroupBy(x => new { x.Model, x.Commodity, x.ContractName})
             .Select(y => new ModelContractDetailDTO
             {
                 Model = y.Key.Model,
                 Commodity = y.Key.Commodity,
                 Contract = y.Key.ContractName,


                 ModelDetails = y.Select(x =>
                 new ModelDetails
                 {
                     Date = x.Details.Date,
                     NewTradeAction = x.Details.NewTradeAction,
                     CurrentPosition = x.Details.Position,
                     PnlDaily = x.Details.PnlDaily,
                     Price = x.Details.Price
                 })

             }).ToList();

            return modelResponse;
        }
    }
}
