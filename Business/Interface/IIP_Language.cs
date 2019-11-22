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
    public interface ILanguage
    {
        EntityModel.Language Create(EntityModel.Language entity);

        IEnumerable<EntityModel.Language> FindBy(Expression<Func<EntityModel.Language, bool>> filter = null);

        EntityModel.Language GetById(long Id);

        IEnumerable<EntityModel.Language> GetAll();

        EntityModel.Language Update(EntityModel.Language entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Language, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IP_LanguageIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Language, bool>> filter = null);

      // IEnumerable<ViewModel.LanguageDropdownListViewModel> GetDropdownList();
    }
}
