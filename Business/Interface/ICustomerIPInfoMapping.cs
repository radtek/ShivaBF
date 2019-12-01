using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SHF.Helper;

namespace SHF.Business.Interface
{
    public interface ICustomerIPInfoMapping
    {
        EntityModel.CustomerIPInfoMapping Create(EntityModel.CustomerIPInfoMapping entity);

        IEnumerable<EntityModel.CustomerIPInfoMapping> FindBy(Expression<Func<EntityModel.CustomerIPInfoMapping, bool>> filter = null);

        EntityModel.CustomerIPInfoMapping GetById(long Id);

        IEnumerable<EntityModel.CustomerIPInfoMapping> GetAll();

        EntityModel.CustomerIPInfoMapping Update(EntityModel.CustomerIPInfoMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CustomerIPInfoMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CustomerIPInfoMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CustomerIPInfoMapping, bool>> filter = null);

      // IEnumerable<ViewModel.CustomerIPInfoMappingDropdownListViewModel> GetDropdownList();
    }
}
