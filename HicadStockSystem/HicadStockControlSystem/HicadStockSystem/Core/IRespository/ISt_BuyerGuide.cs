using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface ISt_BuyerGuide
    {
        Task CreateAsync(St_BuyerGuide buyerGuide);
        St_BuyerGuide GetByItemCode(string code);
        Task UpdateAsync(St_BuyerGuide buyerGuide);
        Task UpdateAsync(string code);
        IEnumerable<St_BuyerGuide> GetAll();
        Task DeleteAsync(string code);
    }
}
