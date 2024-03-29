﻿using Analytics.API.Core.Interfaces.Logic;
using Analytics.API.Models;
using Analytics.API.Models.ViewModel.Metrice;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetriceController : ControllerBase
    {
        private readonly ILogger<MetriceController> _logger;
        private readonly IModelMetriceLogic _modelMetriceLogic;
        public MetriceController(ILogger<MetriceController> logger, IModelMetriceLogic modelMetriceLogic)
        {
            _logger = logger;
            _modelMetriceLogic = modelMetriceLogic;
        }

        /// <summary>
        /// This Api returns all the model Metrices
        /// </summary>
        /// <returns></returns>
        [HttpGet("",Name = "GetModelMatertics")]
        public async Task<ActionResult<List<ModelMericeViewModel>>> GetModelMatertics()
        {
            var respone = await _modelMetriceLogic.GetModelMetriceDetailsAsync();

            return Ok(respone);
        }
    }
}
