﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SHF.Helper;

namespace SHF.Business.Interface
{
    public interface IHomePageSection3
    {
        EntityModel.HomePageSection3 Create(EntityModel.HomePageSection3 entity);

        IEnumerable<EntityModel.HomePageSection3> FindBy(Expression<Func<EntityModel.HomePageSection3, bool>> filter = null);

        EntityModel.HomePageSection3 GetById(long Id);

        IEnumerable<EntityModel.HomePageSection3> GetAll();

        EntityModel.HomePageSection3 Update(EntityModel.HomePageSection3 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection3, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection3IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection3, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection3DropdownListViewModel> GetDropdownList();
    }
}
