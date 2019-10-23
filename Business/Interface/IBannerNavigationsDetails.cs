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
        EntityModel.BannerNavigationsDetails Create(EntityModel.BannerNavigationsDetails entity);

        IEnumerable<EntityModel.BannerNavigationsDetails> FindBy(Expression<Func<EntityModel.BannerNavigationsDetails, bool>> filter = null);

        EntityModel.BannerNavigationsDetails GetById(long Id);

        IEnumerable<EntityModel.BannerNavigationsDetails> GetAll();

        EntityModel.BannerNavigationsDetails Update(EntityModel.BannerNavigationsDetails entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.BannerNavigationsDetails, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.BannerNavigationsDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.BannerNavigationsDetails, bool>> filter = null);

      // IEnumerable<ViewModel.BannerNavigationsDetailsDropdownListViewModel> GetDropdownList();
    }
}
