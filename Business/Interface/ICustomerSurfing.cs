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
    public interface ICustomerSurfing
    {
        EntityModel.CustomerSurfing Create(EntityModel.CustomerSurfing entity);

        IEnumerable<EntityModel.CustomerSurfing> FindBy(Expression<Func<EntityModel.CustomerSurfing, bool>> filter = null);

        EntityModel.CustomerSurfing GetById(long Id);

        IEnumerable<EntityModel.CustomerSurfing> GetAll();

        EntityModel.CustomerSurfing Update(EntityModel.CustomerSurfing entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CustomerSurfing, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CustomerSurfingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CustomerSurfing, bool>> filter = null);

      // IEnumerable<ViewModel.CustomerSurfingDropdownListViewModel> GetDropdownList();
    }
}
