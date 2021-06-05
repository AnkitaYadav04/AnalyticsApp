using AngaloAmericanAnalytics.API.Core.Interfaces.Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AngaloAmericanAnalytics.API.Controllers
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
        [HttpGet]
        [Route("")]
        public async Task<ActionResult> GetHistoryDetailsAsync(DateTime? fromDate = null, DateTime? toDate = null, string filterModel = null, string filterCommodity = null )
        {
            var respone = await _historyLogic.GetHistoryDetailsAsync(fromDate, toDate, filterModel, filterCommodity);

            return Ok(respone);
        }
    }
}
