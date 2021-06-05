using AngaloAmericanAnalytics.API.Core.Interfaces.Logic;
using AngaloAmericanAnalytics.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngaloAmericanAnalytics.API.Controllers
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

        [HttpGet("", Name = "GetModelAnalytics")]
        public async Task<ActionResult<List<AnalyticsViewModel>>> GetModelAnalytics(int pageNumber = 1, int pageSize = 50)
        {
            var respone = await _analyticsLogic.GetAnalyticsDetailsAsync();

            return Ok(respone);
        }
    }
}
