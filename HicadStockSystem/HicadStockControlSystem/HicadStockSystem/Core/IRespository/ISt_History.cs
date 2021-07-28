using HicadStockSystem.Core.Models;
using HicadStockSystem.Core.Utilities;
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
        IEnumerable<St_History> GetByReceiptNo(string docNo);
        Task UpdateAsync(St_History issueApprove);
        Task UpdateAsync(string itemCode);
        Task<IEnumerable<St_History>> GetAll();
        Task<string> GenerateDocNo();
        //IQueryable<St_History> GetAll();
        Task DeleteAsync(string itemCode);
        //string GenerateDocNo();
        string ReturnNo();
        int GetRemarkId(string remark);
        Task<IEnumerable<St_History>> GetAllReceipt();
        //St_History GetDocNo(string docNo);
        IEnumerable<string> GetAllReceiptNo();
        IEnumerable<St_History> GetItemByReceiptNo(string receiptNo);
        St_History ReverseByItemCode(string docNo, string itemcode);
        Task DeleteReversedReceiptByDocNo(string docNo);
        Task DeleteReversedItem(string docNo, string Itemcode);
        
       
    }
}
