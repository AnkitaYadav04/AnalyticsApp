﻿using Analytics.API.Models;
using Analytics.API.Models.ViewModel.History;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Analytics.API.Core.Interfaces.Logic
{
    public interface IHistoryLogic
    {
        Task<List<HistoryViewModel>> GetHistoryDetailsAsync(DateTime? fromDay , DateTime? toDate , string filterModel, string filterCommodity);
    }
}
