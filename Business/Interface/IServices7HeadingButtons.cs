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
    public interface IServices7HeadingButtons
    {
        EntityModel.Services7HeadingButtons Create(EntityModel.Services7HeadingButtons entity);

        IEnumerable<EntityModel.Services7HeadingButtons> FindBy(Expression<Func<EntityModel.Services7HeadingButtons, bool>> filter = null);

        EntityModel.Services7HeadingButtons GetById(long Id);

        IEnumerable<EntityModel.Services7HeadingButtons> GetAll();

        EntityModel.Services7HeadingButtons Update(EntityModel.Services7HeadingButtons entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services7HeadingButtons, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services7HeadingButtonsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services7HeadingButtons, bool>> filter = null);

      // IEnumerable<ViewModel.Services7HeadingButtonsDropdownListViewModel> GetDropdownList();
    }
}
