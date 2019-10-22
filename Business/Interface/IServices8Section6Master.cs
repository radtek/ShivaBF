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
    public interface IServices8Section6Master
    {
        EntityModel.Services8Section6Master Create(EntityModel.Services8Section6Master entity);

        IEnumerable<EntityModel.Services8Section6Master> FindBy(Expression<Func<EntityModel.Services8Section6Master, bool>> filter = null);

        EntityModel.Services8Section6Master GetById(long Id);

        IEnumerable<EntityModel.Services8Section6Master> GetAll();

        EntityModel.Services8Section6Master Update(EntityModel.Services8Section6Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services8Section6Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services8Section6MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services8Section6Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services8Section6MasterDropdownListViewModel> GetDropdownList();
    }
}
