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
    public interface IServices1Section8FAQMapping
    {
        EntityModel.Services1Section8FAQMapping Create(EntityModel.Services1Section8FAQMapping entity);

        IEnumerable<EntityModel.Services1Section8FAQMapping> FindBy(Expression<Func<EntityModel.Services1Section8FAQMapping, bool>> filter = null);

        EntityModel.Services1Section8FAQMapping GetById(long Id);

        IEnumerable<EntityModel.Services1Section8FAQMapping> GetAll();

        EntityModel.Services1Section8FAQMapping Update(EntityModel.Services1Section8FAQMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services1Section8FAQMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services1Section8FAQMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services1Section8FAQMapping, bool>> filter = null);

      // IEnumerable<ViewModel.Services1Section8FAQMappingDropdownListViewModel> GetDropdownList();
    }
}
