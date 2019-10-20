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
    public interface IServices1Section10BankMapping
    {
        EntityModel.Services1Section10BankMapping Create(EntityModel.Services1Section10BankMapping entity);

        IEnumerable<EntityModel.Services1Section10BankMapping> FindBy(Expression<Func<EntityModel.Services1Section10BankMapping, bool>> filter = null);

        EntityModel.Services1Section10BankMapping GetById(long Id);

        IEnumerable<EntityModel.Services1Section10BankMapping> GetAll();

        EntityModel.Services1Section10BankMapping Update(EntityModel.Services1Section10BankMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services1Section10BankMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services1Section10BankMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services1Section10BankMapping, bool>> filter = null);

      // IEnumerable<ViewModel.Services1Section10BankMappingDropdownListViewModel> GetDropdownList();
    }
}
