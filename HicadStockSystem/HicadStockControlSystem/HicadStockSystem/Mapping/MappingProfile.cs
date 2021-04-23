using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM;
using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
using HicadStockSystem.Controllers.ResourcesVM.St_StockClass;
using HicadStockSystem.Controllers.ResourcesVM.St_StockMaster;
using HicadStockSystem.Core.Models;
using HicadStockSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HicadStockSystem.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //API Resource To Domain and Domain To API Resource(Two way mapping)
            CreateMap<CreateSt_StkSystemVM, St_StkSystem>();
            CreateMap<UpdateSt_StkSystemVM, St_StkSystem>();

            CreateMap<CreateStockClassVM, St_StockClass>().ReverseMap();
            CreateMap<UpdateStockClassVM, St_StockClass>().ReverseMap();

            CreateMap<CreateStockMasterVM, St_StockMaster>().ReverseMap();
            CreateMap<UpdateStockMasterVM, St_StockMaster>().ReverseMap();
        }
    }
}
