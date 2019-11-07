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
    public interface IHomePageBanner
    {
        EntityModel.HomePageBanner Create(EntityModel.HomePageBanner entity);

        IEnumerable<EntityModel.HomePageBanner> FindBy(Expression<Func<EntityModel.HomePageBanner, bool>> filter = null);

        EntityModel.HomePageBanner GetById(long Id);

        IEnumerable<EntityModel.HomePageBanner> GetAll();

        EntityModel.HomePageBanner Update(EntityModel.HomePageBanner entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageBanner, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageBannerIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageBanner, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageBannerDropdownListViewModel> GetDropdownList();
    }
}
