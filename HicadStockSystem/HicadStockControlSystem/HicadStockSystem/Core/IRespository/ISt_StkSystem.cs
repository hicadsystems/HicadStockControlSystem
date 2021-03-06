using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
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
        Task<IEnumerable<St_StkSystem>> GetAll();
        Task<IEnumerable<StateList>> GetAllState();
        Task<IEnumerable<Ac_CostCentre>> GetCostCenter();
        Task<IEnumerable<Ac_BusinessLine>> GetBusLine();
        Task<IEnumerable<AccChart>> GetAccChart();
        Task<IEnumerable<AccChart>> GetCreditorCode();
        Task<IEnumerable<AccChart>> GetGLCode();
        Task<IEnumerable<AccChart>> GetExpenseCode();
        St_StkSystem GetSingle();
        GetSt_System GetSystem();

    }
}
