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
    public interface ICustomerMasterInfo
    {
        EntityModel.CustomerMasterInfo Create(EntityModel.CustomerMasterInfo entity);

        IEnumerable<EntityModel.CustomerMasterInfo> FindBy(Expression<Func<EntityModel.CustomerMasterInfo, bool>> filter = null);

        EntityModel.CustomerMasterInfo GetById(long Id);

        IEnumerable<EntityModel.CustomerMasterInfo> GetAll();

        EntityModel.CustomerMasterInfo Update(EntityModel.CustomerMasterInfo entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CustomerMasterInfo, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CustomerMasterInfoIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CustomerMasterInfo, bool>> filter = null);

      // IEnumerable<ViewModel.CustomerMasterInfoDropdownListViewModel> GetDropdownList();
    }
}
