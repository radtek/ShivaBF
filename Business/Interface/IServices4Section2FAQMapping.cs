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
    public interface IServices4Section2FAQMapping
    {
        EntityModel.Services4Section2FAQMapping Create(EntityModel.Services4Section2FAQMapping entity);

        IEnumerable<EntityModel.Services4Section2FAQMapping> FindBy(Expression<Func<EntityModel.Services4Section2FAQMapping, bool>> filter = null);

        EntityModel.Services4Section2FAQMapping GetById(long Id);

        IEnumerable<EntityModel.Services4Section2FAQMapping> GetAll();

        EntityModel.Services4Section2FAQMapping Update(EntityModel.Services4Section2FAQMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section2FAQMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section2FAQMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section2FAQMapping, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section2FAQMappingDropdownListViewModel> GetDropdownList();
    }
}
