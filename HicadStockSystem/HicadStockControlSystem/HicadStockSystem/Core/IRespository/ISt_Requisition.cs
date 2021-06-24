using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
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
        St_Requisition GetByItemcode(string itemCode);
        Task UpdateAsync(St_Requisition requisition);
        Task UpdateAsync(string reqNo);
        //Task<IEnumerable<St_Requisition>> GetAll();
        Task<IEnumerable<string>> GetAll();
        Task DeleteAsync(string reqNo);

        Task<IEnumerable<Ac_CostCentre>> GetCostCentre();
        Task<ItemStockMasterViewModel> StockItemViewModels(string ItemCodes);

        Task<IEnumerable<St_ItemMaster>> GetItemCode();
        Task<RequesitionVM> RequesitionsVM(string itemCode);
        //Task<List<RequesitionVM>> RequesitionsVM(string reqNo);
        string GetDescription(string itemCode);
        string GenerateRequisitionNo();
        Task<IEnumerable<St_Requisition>> GetApproved();
        Task RequisitioApprovalAsync(St_Requisition requisition);

        //float? CheckCurrentBal(St_Requisition requisition);
        //Task<IEnumerable<string>> GetAllByReqNo(string reqno);
        float? CheckCurrentBal(CreateSt_RequisitionVM requisition);
        List<ItemListVM> ItemLists(string reqNo);

        St_Requisition GetByItemCode(string itemcode);
    }
}
