using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
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
        St_Requisition GetByItemcode(string itemCode);
        Task UpdateAsync(string reqNo);
        IEnumerable<St_Requisition> GetAllRequisition();
        IEnumerable<string> GetAll();
        Task DeleteAsync(string reqNo);
        Task DeleteUnissuedRequisition();

        Task<IEnumerable<Ac_CostCentre>> GetCostCentre();
        Task<ItemStockMasterViewModel> StockItemViewModels(string ItemCodes);

      
        RequesitionVM RequesitionsVM(string itemCode);
       
        string GetDescription(string itemCode);
        Task<string> GenerateRequisitionNo();
      
        IEnumerable<string> GetApproved();
        Task RequisitioApprovalAsync(St_Requisition requisition);

       
        float? CheckCurrentBal(string itemcode);
        List<ItemViewModel> ItemLists(string reqNo);

        List<St_Requisition> GetByItemCode(string requisitionNo, string itemcode);
        List<St_Requisition> GetByReqNoForApproval(string reqNo);
        Task<IEnumerable<string>> GetUnissuedReqisition();
        IEnumerable<St_Requisition> GetByReqNos(string reqNo);
        Task<IEnumerable<St_Requisition>> GetByDate(DateTime? date);
        
        St_Requisition GetReqNo(string reqNo);
    
    }
}
