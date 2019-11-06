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
    public interface IBannerNavigationsDetails
    {
        EntityModel.BlogBannerNavigationsDetails Create(EntityModel.BlogBannerNavigationsDetails entity);

        IEnumerable<EntityModel.BlogBannerNavigationsDetails> FindBy(Expression<Func<EntityModel.BlogBannerNavigationsDetails, bool>> filter = null);

        EntityModel.BlogBannerNavigationsDetails GetById(long Id);

        IEnumerable<EntityModel.BlogBannerNavigationsDetails> GetAll();

        EntityModel.BlogBannerNavigationsDetails Update(EntityModel.BlogBannerNavigationsDetails entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.BlogBannerNavigationsDetails, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.BannerNavigationsDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.BlogBannerNavigationsDetails, bool>> filter = null);

      // IEnumerable<ViewModel.BannerNavigationsDetailsDropdownListViewModel> GetDropdownList();
    }
}
