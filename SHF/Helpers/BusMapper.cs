using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Collection;
using AutoMapper.EntityFramework;
using AutoMapper.Collection.LinqToSQL;

namespace SHF
{
    public class BusMapper : AutoMapper.Profile
    {
        public BusMapper()
        {
            CreateMap<EntityModel.Tenant, ViewModel.TenantCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.AspNetUser, ViewModel.AspNetUserCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.AspNetRole, ViewModel.AspNetRoleCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.AspNetUserRole, ViewModel.AspNetUserRoleCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.SubMenu, ViewModel.SubMenuCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.AspNetRoleSubMenu, ViewModel.AspNetRoleSubMenuCreateOrEditViewModel>().ReverseMap();
           
            CreateMap<EntityModel.Message, ViewModel.MessageCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.BankMaster, ViewModel.BankMasterCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.CategoriesMaster, ViewModel.CategoriesMasterCreateOrEditViewModel>().ReverseMap();
            CreateMap<EntityModel.SubCategoriesMaster, ViewModel.SubCategoriesMasterCreateOrEditViewModel>().ReverseMap();
          
    }

        public static void RegisterMapper()
        {
            AutoMapper.Mapper.Initialize(map =>
            {
                map.AddProfile<BusMapper>();
            });
        }
    }
}
