using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_Requisition : IRespositoryMaster<St_Requisition, string>
    {
        //Task CreateAsync(St_Requisition requisition);
        St_Requisition GetByReqNo(string reqNo);
        //Task UpdateAsync(St_Requisition requisition);
        //Task UpdateAsync(string reqNo);
        //Task<IEnumerable<St_Requisition>> GetAll();
        //Task DeleteAsync(string reqNo);
        //string  RandomString(int length);
    }
}
