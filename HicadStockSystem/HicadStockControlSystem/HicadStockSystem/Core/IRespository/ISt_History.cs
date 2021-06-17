﻿using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_History 
    {
        Task CreateAsync(St_History issueApprove);
        St_History GetByDocNo(string docNo);
        Task UpdateAsync(St_History issueApprove);
        Task UpdateAsync(string itemCode);
        Task<IEnumerable<St_History>> GetAll();

        //IQueryable<St_History> GetAll();
        Task DeleteAsync(string itemCode);
        string GenerateDocNo();
        string ReturnNo();
        //St_History GetDocNo(string docNo);
    }
}
