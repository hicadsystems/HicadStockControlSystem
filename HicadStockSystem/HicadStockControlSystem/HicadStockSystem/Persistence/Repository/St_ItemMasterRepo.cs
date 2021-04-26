using HicadStockSystem.Core.IRespository;
using HicadStockSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_ItemMasterRepo : ISt_ItemMaster
    {
        public Task CreateAsync(St_ItemMaster itemMaster)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<St_ItemMaster> GetAll()
        {
            throw new NotImplementedException();
        }

        public St_ItemMaster GetByCode(string itemCode)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(St_ItemMaster itemMaster)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string code)
        {
            throw new NotImplementedException();
        }
        public Task DeleteAsync(string itemCode)
        {
            throw new NotImplementedException();
        }
    }
}
