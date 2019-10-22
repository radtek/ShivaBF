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
    public interface IServices7Section6PriceMaster
    {
        EntityModel.Services7Section6PriceMaster Create(EntityModel.Services7Section6PriceMaster entity);

        IEnumerable<EntityModel.Services7Section6PriceMaster> FindBy(Expression<Func<EntityModel.Services7Section6PriceMaster, bool>> filter = null);

        EntityModel.Services7Section6PriceMaster GetById(long Id);

        IEnumerable<EntityModel.Services7Section6PriceMaster> GetAll();

        EntityModel.Services7Section6PriceMaster Update(EntityModel.Services7Section6PriceMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services7Section6PriceMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services7Section6PriceMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services7Section6PriceMaster, bool>> filter = null);

      // IEnumerable<ViewModel.Services7Section6PriceMasterDropdownListViewModel> GetDropdownList();
    }
}
