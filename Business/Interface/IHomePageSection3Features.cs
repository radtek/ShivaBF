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
    public interface IHomePageSection3Features
    {
        EntityModel.HomePageSection3Features Create(EntityModel.HomePageSection3Features entity);

        IEnumerable<EntityModel.HomePageSection3Features> FindBy(Expression<Func<EntityModel.HomePageSection3Features, bool>> filter = null);

        EntityModel.HomePageSection3Features GetById(long Id);

        IEnumerable<EntityModel.HomePageSection3Features> GetAll();

        EntityModel.HomePageSection3Features Update(EntityModel.HomePageSection3Features entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection3Features, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection3FeaturesIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection3Features, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection3FeaturesDropdownListViewModel> GetDropdownList();
    }
}
