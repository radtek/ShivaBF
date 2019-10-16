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
    public interface IFAQMaster
    {
        EntityModel.FAQMaster Create(EntityModel.FAQMaster entity);

        IEnumerable<EntityModel.FAQMaster> FindBy(Expression<Func<EntityModel.FAQMaster, bool>> filter = null);

        EntityModel.FAQMaster GetById(long Id);

        IEnumerable<EntityModel.FAQMaster> GetAll();

        EntityModel.FAQMaster Update(EntityModel.FAQMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.FAQMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.FAQMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.FAQMaster, bool>> filter = null);

      // IEnumerable<ViewModel.FAQMasterDropdownListViewModel> GetDropdownList();
    }
}
