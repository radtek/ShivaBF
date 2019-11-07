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
    public interface IHomePageSection2
    {
        EntityModel.HomePageSection2 Create(EntityModel.HomePageSection2 entity);

        IEnumerable<EntityModel.HomePageSection2> FindBy(Expression<Func<EntityModel.HomePageSection2, bool>> filter = null);

        EntityModel.HomePageSection2 GetById(long Id);

        IEnumerable<EntityModel.HomePageSection2> GetAll();

        EntityModel.HomePageSection2 Update(EntityModel.HomePageSection2 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection2, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection2IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection2, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection2DropdownListViewModel> GetDropdownList();
    }
}
