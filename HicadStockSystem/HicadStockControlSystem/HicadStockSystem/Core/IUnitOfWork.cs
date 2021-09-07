using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
        Task<bool> DoneAsync();
    }
}
