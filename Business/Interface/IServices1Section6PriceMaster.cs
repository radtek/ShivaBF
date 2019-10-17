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
    public interface IServices1Section6PriceMaster
    {
        EntityModel.Services1Section6PriceMaster Create(EntityModel.Services1Section6PriceMaster entity);

        IEnumerable<EntityModel.Services1Section6PriceMaster> FindBy(Expression<Func<EntityModel.Services1Section6PriceMaster, bool>> filter = null);

        EntityModel.Services1Section6PriceMaster GetById(long Id);

        IEnumerable<EntityModel.Services1Section6PriceMaster> GetAll();

        EntityModel.Services1Section6PriceMaster Update(EntityModel.Services1Section6PriceMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services1Section6PriceMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services1Section6PriceMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services1Section6PriceMaster, bool>> filter = null);

      // IEnumerable<ViewModel.Services1Section6PriceMasterDropdownListViewModel> GetDropdownList();
    }
}
