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
    public interface IBlogCommentsDetails
    {
        EntityModel.BlogCommentsDetails Create(EntityModel.BlogCommentsDetails entity);

        IEnumerable<EntityModel.BlogCommentsDetails> FindBy(Expression<Func<EntityModel.BlogCommentsDetails, bool>> filter = null);

        EntityModel.BlogCommentsDetails GetById(long Id);

        IEnumerable<EntityModel.BlogCommentsDetails> GetAll();

        EntityModel.BlogCommentsDetails Update(EntityModel.BlogCommentsDetails entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.BlogCommentsDetails, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.BlogCommentsDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.BlogCommentsDetails, bool>> filter = null);

      // IEnumerable<ViewModel.BlogCommentsDetailsDropdownListViewModel> GetDropdownList();
    }
}
