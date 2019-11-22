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
    public interface ICurrency
    {
        EntityModel.Currency Create(EntityModel.Currency entity);

        IEnumerable<EntityModel.Currency> FindBy(Expression<Func<EntityModel.Currency, bool>> filter = null);

        EntityModel.Currency GetById(long Id);

        IEnumerable<EntityModel.Currency> GetAll();

        EntityModel.Currency Update(EntityModel.Currency entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Currency, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IP_CurrencyIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Currency, bool>> filter = null);

      // IEnumerable<ViewModel.CurrencyDropdownListViewModel> GetDropdownList();
    }
}
