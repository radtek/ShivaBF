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
    public interface ICustomerMaster
    {
        EntityModel.CustomerMaster Create(EntityModel.CustomerMaster entity);

        IEnumerable<EntityModel.CustomerMaster> FindBy(Expression<Func<EntityModel.CustomerMaster, bool>> filter = null);

        EntityModel.CustomerMaster GetById(long Id);

        IEnumerable<EntityModel.CustomerMaster> GetAll();

        EntityModel.CustomerMaster Update(EntityModel.CustomerMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CustomerMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CustomerMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CustomerMaster, bool>> filter = null);

      // IEnumerable<ViewModel.CustomerMasterDropdownListViewModel> GetDropdownList();
    }
}
