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
    public interface IBlogMaster
    {
        EntityModel.BlogMaster Create(EntityModel.BlogMaster entity);

        IEnumerable<EntityModel.BlogMaster> FindBy(Expression<Func<EntityModel.BlogMaster, bool>> filter = null);

        EntityModel.BlogMaster GetById(long Id);

        IEnumerable<EntityModel.BlogMaster> GetAll();

        EntityModel.BlogMaster Update(EntityModel.BlogMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.BlogMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.BlogMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.BlogMaster, bool>> filter = null);

      // IEnumerable<ViewModel.BlogMasterDropdownListViewModel> GetDropdownList();
    }
}
