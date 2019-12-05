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
    public interface ICustomerServiceOrder
    {
        EntityModel.CustomerServiceOrder Create(EntityModel.CustomerServiceOrder entity);

        IEnumerable<EntityModel.CustomerServiceOrder> FindBy(Expression<Func<EntityModel.CustomerServiceOrder, bool>> filter = null);

        EntityModel.CustomerServiceOrder GetById(long Id);

        IEnumerable<EntityModel.CustomerServiceOrder> GetAll();

        EntityModel.CustomerServiceOrder Update(EntityModel.CustomerServiceOrder entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CustomerServiceOrder, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CustomerServiceOrderIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CustomerServiceOrder, bool>> filter = null);

      // IEnumerable<ViewModel.CustomerServiceOrderDropdownListViewModel> GetDropdownList();
    }
}
