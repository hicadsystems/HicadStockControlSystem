using HicadStockSystem.Core.Utilities.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Core.IRespository
{
    public interface IDocumentSearch
    {
        DocumentSearchVM DocumentSearch(string DocNo);
    }
}
