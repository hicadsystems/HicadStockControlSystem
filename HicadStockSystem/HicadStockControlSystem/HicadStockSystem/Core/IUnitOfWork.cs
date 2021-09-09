using HicadStockSystem.Core.IRespository.IAccount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core
{
    public interface IUnitOfWork
    {
        IUserServices users { get; }
        Task CompleteAsync();
        Task<bool> DoneAsync();
    }
}
