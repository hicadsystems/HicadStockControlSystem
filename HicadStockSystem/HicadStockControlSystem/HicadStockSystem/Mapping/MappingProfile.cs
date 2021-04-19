using AutoMapper;
using HicadStockSystem.Controllers.ResourcesVM;
using HicadStockSystem.Controllers.ResourcesVM.St_StkSystem;
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
            //Domain To API Resource
            CreateMap<St_StkSystem, CreateSt_StkSystemVM>();

            //API Resource To Domain
            CreateMap<CreateSt_StkSystemVM, St_StkSystem>();
            CreateMap<UpdateSt_StkSystemVM, St_StkSystem>();
        }
    }
}
