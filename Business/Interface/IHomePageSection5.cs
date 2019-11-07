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
    public interface IHomePageSection5
    {
        EntityModel.HomePageSection5 Create(EntityModel.HomePageSection5 entity);

        IEnumerable<EntityModel.HomePageSection5> FindBy(Expression<Func<EntityModel.HomePageSection5, bool>> filter = null);

        EntityModel.HomePageSection5 GetById(long Id);

        IEnumerable<EntityModel.HomePageSection5> GetAll();

        EntityModel.HomePageSection5 Update(EntityModel.HomePageSection5 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection5, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection5IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection5, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection5DropdownListViewModel> GetDropdownList();
    }
}
