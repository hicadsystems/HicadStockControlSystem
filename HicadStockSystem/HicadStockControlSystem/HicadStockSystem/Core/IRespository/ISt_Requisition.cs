using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_Requisition 
    {
        Task CreateAsync(St_Requisition requisition);
        St_Requisition GetByReqNo(string reqNo);
        Task UpdateAsync(St_Requisition requisition);
        Task UpdateAsync(string reqNo);
        Task<IEnumerable<St_Requisition>> GetAll();
        Task DeleteAsync(string reqNo);

        Task<IEnumerable<Ac_CostCentre>> GetCostCentre();
        Task<ItemStockMasterViewModel> StockItemViewModels(string ItemCodes);

        Task<IEnumerable<St_ItemMaster>> GetItemCode();
        
        string GetDescription(string itemCode);
        string GenerateRequisitionNo();
    }
}
