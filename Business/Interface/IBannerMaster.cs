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
    public interface IBannerMaster
    {
        EntityModel.BannerMaster Create(EntityModel.BannerMaster entity);

        IEnumerable<EntityModel.BannerMaster> FindBy(Expression<Func<EntityModel.BannerMaster, bool>> filter = null);

        EntityModel.BannerMaster GetById(long Id);

        IEnumerable<EntityModel.BannerMaster> GetAll();

        EntityModel.BannerMaster Update(EntityModel.BannerMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.BannerMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.BannerMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.BannerMaster, bool>> filter = null);

      // IEnumerable<ViewModel.BannerMasterDropdownListViewModel> GetDropdownList();
    }
}
