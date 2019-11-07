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
    public interface IHomePageSection1
    {
        EntityModel.HomePageSection1 Create(EntityModel.HomePageSection1 entity);

        IEnumerable<EntityModel.HomePageSection1> FindBy(Expression<Func<EntityModel.HomePageSection1, bool>> filter = null);

        EntityModel.HomePageSection1 GetById(long Id);

        IEnumerable<EntityModel.HomePageSection1> GetAll();

        EntityModel.HomePageSection1 Update(EntityModel.HomePageSection1 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection1, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection1IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection1, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection1DropdownListViewModel> GetDropdownList();
    }
}
