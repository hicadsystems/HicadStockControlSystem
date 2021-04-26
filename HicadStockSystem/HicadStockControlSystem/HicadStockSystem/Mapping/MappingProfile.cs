using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM;
using HicadStockSystem.Controllers.ResourcesVM.St_BusinessLine;
using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Controllers.ResourcesVM.St_StkJournal;
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

            CreateMap<CreateBusinessLineVM, St_BusinessLine>().ReverseMap();
            CreateMap<UpdateBusinessLineVM, St_BusinessLine>().ReverseMap();

            CreateMap<CreateSt_RequisitionVM, St_Requisition>().ReverseMap();
            CreateMap<UpdateSt_RequisitionVM, St_Requisition>().ReverseMap();

            CreateMap<CreateSt_StkJournalVM, St_StkJournal>().ReverseMap();
            CreateMap<UpdateSt_StkJournalVM, St_StkJournal>().ReverseMap();

        }
    }
}
