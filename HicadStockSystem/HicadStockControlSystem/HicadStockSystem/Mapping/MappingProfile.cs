using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM;
using HicadStockSystem.Controllers.ResourcesVM.Ac_BusinessLine;
using HicadStockSystem.Controllers.ResourcesVM.Ac_CostCentre;
using HicadStockSystem.Controllers.ResourcesVM.St_BusinessLine;
using HicadStockSystem.Controllers.ResourcesVM.St_BuyerGuide;
using HicadStockSystem.Controllers.ResourcesVM.St_CostCentre;
using HicadStockSystem.Controllers.ResourcesVM.St_History;
using HicadStockSystem.Controllers.ResourcesVM.St_IssueApprove;
using HicadStockSystem.Controllers.ResourcesVM.St_IssueRequisition;
using HicadStockSystem.Controllers.ResourcesVM.St_ItemMaster;
using HicadStockSystem.Controllers.ResourcesVM.St_RecordTable;
using HicadStockSystem.Controllers.ResourcesVM.St_Requisition;
using HicadStockSystem.Controllers.ResourcesVM.St_StkJournal;
using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
using HicadStockSystem.Controllers.ResourcesVM.St_StockClass;
using HicadStockSystem.Controllers.ResourcesVM.St_StockMaster;
using HicadStockSystem.Controllers.ResourcesVM.St_Supplier;
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

            CreateMap<CreateSt_SupplierVM, St_Supplier>().ReverseMap();
            CreateMap<UpdateSt_SupplierVM, St_Supplier>().ReverseMap();

            CreateMap<CreateSt_RecordTableVM, St_RecordTable>().ReverseMap();
            CreateMap<UpdateSt_RecordTableVM, St_RecordTable>().ReverseMap();

            CreateMap<CreateSt_ItemMasterVM, St_ItemMaster>().ReverseMap();
            CreateMap<UpdateSt_ItemMasterVM, St_ItemMaster>().ReverseMap();

            CreateMap<CreateSt_IssueRequisitionVM, St_IssueRequisition>().ReverseMap();
            CreateMap<UpdateSt_IssueRequisitionVM, St_IssueRequisition>().ReverseMap();

            CreateMap<CreateSt_HistoryVM, St_History>().ReverseMap();
            CreateMap<UpdateSt_HistoryVM, St_History>().ReverseMap();

            CreateMap<CreateSt_IssueApproveVM, St_IssueApprove>();
            CreateMap<UpdateSt_IssueApproveVM, St_IssueApprove>();

            CreateMap<CreateSt_BuyerGuideVM, St_BuyerGuide>();
            CreateMap<UpdateSt_BuyerGuideVM, St_BuyerGuide>();

            CreateMap<CreateSt_CostCentreVM, St_CostCentre>();
            CreateMap<UpdateSt_CostCentreVM, St_CostCentre>();

            CreateMap<CreateAc_BusinessLineVM, Ac_BusinessLine>();
            CreateMap<UpdateAc_BusinessLineVM, Ac_BusinessLine>();


            CreateMap<CreateAc_CostCentreVM, Ac_CostCentre>();
            CreateMap<UpdateAc_CostCentreVM, Ac_CostCentre>();
        }
    }
}
