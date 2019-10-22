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
    public interface IServices8HeadingButtons
    {
        EntityModel.Services8HeadingButtons Create(EntityModel.Services8HeadingButtons entity);

        IEnumerable<EntityModel.Services8HeadingButtons> FindBy(Expression<Func<EntityModel.Services8HeadingButtons, bool>> filter = null);

        EntityModel.Services8HeadingButtons GetById(long Id);

        IEnumerable<EntityModel.Services8HeadingButtons> GetAll();

        EntityModel.Services8HeadingButtons Update(EntityModel.Services8HeadingButtons entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services8HeadingButtons, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services8HeadingButtonsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services8HeadingButtons, bool>> filter = null);

      // IEnumerable<ViewModel.Services8HeadingButtonsDropdownListViewModel> GetDropdownList();
    }
}
