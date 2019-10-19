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
    public interface IStateMaster
    {
        EntityModel.StateMaster Create(EntityModel.StateMaster entity);

        IEnumerable<EntityModel.StateMaster> FindBy(Expression<Func<EntityModel.StateMaster, bool>> filter = null);

        EntityModel.StateMaster GetById(long Id);

        IEnumerable<EntityModel.StateMaster> GetAll();

        EntityModel.StateMaster Update(EntityModel.StateMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.StateMaster, bool>> filter = null);

       // ViewModel.BusinessResultViewModel<ViewModel.StateMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.StateMaster, bool>> filter = null);

      // IEnumerable<ViewModel.StateMasterDropdownListViewModel> GetDropdownList();
    }
}
