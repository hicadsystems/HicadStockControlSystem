﻿using HicadStockSystem.Core.Models;
using HicadStockSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Repository.IRepository
{
    public interface ISt_StkSystem
    {
        Task CreateAsync(St_StkSystem stkSystem);
        St_StkSystem GetByCompanyCode(string compcode);
        Task UpdateAsync(St_StkSystem stkSystem);
        Task UpdateAsync(string compcode);
        Task Delete(string compcode);
        IEnumerable<St_StkSystem> GetAll();
        IEnumerable<StateList> GetAllState();
    }
}