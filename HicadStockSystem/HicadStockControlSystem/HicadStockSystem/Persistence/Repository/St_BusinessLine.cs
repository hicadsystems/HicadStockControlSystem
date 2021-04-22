using HicadStockSystem.Core.IRespository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Persistence.Repository
{
    public class St_BusinessLine : ISt_BusinessLine
    {
        public Task CreateAsync(Core.Models.St_BusinessLine busLine)
        {
            throw new NotImplementedException();
        }

        public Task Delete(string busLine)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Core.Models.St_BusinessLine> GetAllBusLine()
        {
            throw new NotImplementedException();
        }

        public Core.Models.St_BusinessLine GetByBusLine(string busLine)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Core.Models.St_BusinessLine busLine)
        {
            throw new NotImplementedException();
        }
    }
}
