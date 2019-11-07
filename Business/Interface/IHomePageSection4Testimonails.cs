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
    public interface IHomePageSection4Testimonails
    {
        EntityModel.HomePageSection4Testimonails Create(EntityModel.HomePageSection4Testimonails entity);

        IEnumerable<EntityModel.HomePageSection4Testimonails> FindBy(Expression<Func<EntityModel.HomePageSection4Testimonails, bool>> filter = null);

        EntityModel.HomePageSection4Testimonails GetById(long Id);

        IEnumerable<EntityModel.HomePageSection4Testimonails> GetAll();

        EntityModel.HomePageSection4Testimonails Update(EntityModel.HomePageSection4Testimonails entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.HomePageSection4Testimonails, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.HomePageSection4TestimonailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.HomePageSection4Testimonails, bool>> filter = null);

      // IEnumerable<ViewModel.HomePageSection4TestimonailsDropdownListViewModel> GetDropdownList();
    }
}
