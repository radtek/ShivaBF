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
    public interface IFooterLinks
    {
        EntityModel.FooterLinks Create(EntityModel.FooterLinks entity);

        IEnumerable<EntityModel.FooterLinks> FindBy(Expression<Func<EntityModel.FooterLinks, bool>> filter = null);

        EntityModel.FooterLinks GetById(long Id);

        IEnumerable<EntityModel.FooterLinks> GetAll();

        EntityModel.FooterLinks Update(EntityModel.FooterLinks entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.FooterLinks, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.FooterLinksIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.FooterLinks, bool>> filter = null);

      // IEnumerable<ViewModel.FooterLinksDropdownListViewModel> GetDropdownList();
    }
}
