using Analytics.API.Core.Interfaces.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Analytics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryLogic _historyLogic;
        public HistoryController(IHistoryLogic historyLogic)
        {
            _historyLogic = historyLogic;
        }
        /// <summary>
        /// This API return all the model and commodity History details
        /// </summary>
        /// <param name="fromDate">Model Start Date</param>
        /// <param name="toDate">Model End Date</param>
        /// <param name="filterModel">Model Name </param>
        /// <param name="filterCommodity">Commodity Name</param>
        /// <returns></returns>
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetHistoryDetailsAsync(DateTime? fromDate = null, DateTime? toDate = null, string filterModel = null, string filterCommodity = null )
        {
            var respone = await _historyLogic.GetHistoryDetailsAsync(fromDate, toDate, filterModel, filterCommodity);

            return Ok(respone);
        }
    }
}
