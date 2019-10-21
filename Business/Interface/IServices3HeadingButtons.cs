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
    public interface IServices3HeadingButtons
    {
        EntityModel.Services3HeadingButtons Create(EntityModel.Services3HeadingButtons entity);

        IEnumerable<EntityModel.Services3HeadingButtons> FindBy(Expression<Func<EntityModel.Services3HeadingButtons, bool>> filter = null);

        EntityModel.Services3HeadingButtons GetById(long Id);

        IEnumerable<EntityModel.Services3HeadingButtons> GetAll();

        EntityModel.Services3HeadingButtons Update(EntityModel.Services3HeadingButtons entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services3HeadingButtons, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services3HeadingButtonsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services3HeadingButtons, bool>> filter = null);

      // IEnumerable<ViewModel.Services3HeadingButtonsDropdownListViewModel> GetDropdownList();
    }
}
