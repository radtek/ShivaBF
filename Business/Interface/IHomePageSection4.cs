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
    public interface IHomePageSection4
    {
        EntityModel.HomePageSection4 Create(EntityModel.HomePageSection4 entity);

        IEnumerable<EntityModel.HomePageSection4> FindBy(Expression<Func<EntityModel.HomePageSection4, bool>> filter = null);

        EntityModel.HomePageSection4 GetById(long Id);

        IEnumerable<EntityModel.HomePageSection4> GetAll();

        EntityModel.HomePageSection4 Update(EntityModel.HomePageSection4 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection4, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection4IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection4, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection4DropdownListViewModel> GetDropdownList();
    }
}
