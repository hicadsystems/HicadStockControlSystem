﻿using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_IssueApprove
    {
        Task CreateAsync(St_IssueApprove issueApprove);
        St_IssueApprove GetByCode(string itemCode);
        Task UpdateAsync(St_IssueApprove issueApprove);
        Task UpdateAsync(string itemCode);
        IEnumerable<St_IssueApprove> GetAll();
        Task DeleteAsync(string itemCode);
    }
}