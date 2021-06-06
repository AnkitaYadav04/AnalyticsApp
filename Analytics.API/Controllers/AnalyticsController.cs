using Analytics.API.Core.Interfaces.Logic;
using Analytics.API.Models;
using Analytics.API.Models.ViewModel.Analytics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Analytics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalyticsController : Controller
    {
        private readonly ILogger<MetriceController> _logger;
        private readonly IAnalyticsLogic _analyticsLogic;
        public AnalyticsController(ILogger<MetriceController> logger, IAnalyticsLogic analyticsLogic)
        {
            _logger = logger;
            _analyticsLogic = analyticsLogic;
        }

        /// <summary>
        /// This API returns all the model details for Analytics
        /// </summary>
        /// <param name="fromDate">Model Start Date</param>
        /// <param name="toDate">Model End Date</param>
        /// <param name="filterModel">Model Name </param>
        /// <param name="filterCommodity">Commodity Name</param>
        /// <returns></returns>
        [HttpGet("", Name = "GetModelAnalytics")]
        public async Task<ActionResult<List<AnalyticsViewModel>>> GetModelAnalytics(DateTime? fromDate = null, DateTime? toDate = null, string filterModel = null, string filterCommodity = null)
        {
            var respone = await _analyticsLogic.GetAnalyticsDetailsAsync(fromDate, toDate, filterModel, filterCommodity);

            return Ok(respone);
        }
    }
}
