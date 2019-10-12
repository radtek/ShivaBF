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
    public interface IBankMaster
    {
        EntityModel.BankMaster Create(EntityModel.BankMaster entity);

        IEnumerable<EntityModel.BankMaster> FindBy(Expression<Func<EntityModel.BankMaster, bool>> filter = null);

        EntityModel.BankMaster GetById(long Id);

        IEnumerable<EntityModel.BankMaster> GetAll();

        EntityModel.BankMaster Update(EntityModel.BankMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.BankMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.BankMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.BankMaster, bool>> filter = null);

      // IEnumerable<ViewModel.BankMasterDropdownListViewModel> GetDropdownList();
    }
}
