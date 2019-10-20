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
    public interface IServices2Section2FAQMapping
    {
        EntityModel.Services2Section2FAQMapping Create(EntityModel.Services2Section2FAQMapping entity);

        IEnumerable<EntityModel.Services2Section2FAQMapping> FindBy(Expression<Func<EntityModel.Services2Section2FAQMapping, bool>> filter = null);

        EntityModel.Services2Section2FAQMapping GetById(long Id);

        IEnumerable<EntityModel.Services2Section2FAQMapping> GetAll();

        EntityModel.Services2Section2FAQMapping Update(EntityModel.Services2Section2FAQMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services2Section2FAQMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services2Section2FAQMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services2Section2FAQMapping, bool>> filter = null);

      // IEnumerable<ViewModel.Services2Section2FAQMappingDropdownListViewModel> GetDropdownList();
    }
}
