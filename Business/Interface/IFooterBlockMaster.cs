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
    public interface IFooterBlockMaster
    {
        EntityModel.FooterBlockMaster Create(EntityModel.FooterBlockMaster entity);

        IEnumerable<EntityModel.FooterBlockMaster> FindBy(Expression<Func<EntityModel.FooterBlockMaster, bool>> filter = null);

        EntityModel.FooterBlockMaster GetById(long Id);

        IEnumerable<EntityModel.FooterBlockMaster> GetAll();

        EntityModel.FooterBlockMaster Update(EntityModel.FooterBlockMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.FooterBlockMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.FooterBlockMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.FooterBlockMaster, bool>> filter = null);

      // IEnumerable<ViewModel.FooterBlockMasterDropdownListViewModel> GetDropdownList();
    }
}
