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
    public interface IServices7Master
    {
        EntityModel.Services7Master Create(EntityModel.Services7Master entity);

        IEnumerable<EntityModel.Services7Master> FindBy(Expression<Func<EntityModel.Services7Master, bool>> filter = null);

        EntityModel.Services7Master GetById(long Id);

        IEnumerable<EntityModel.Services7Master> GetAll();

        EntityModel.Services7Master Update(EntityModel.Services7Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services7Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services7MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services7Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services7MasterDropdownListViewModel> GetDropdownList();
    }
}
