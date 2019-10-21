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
    public interface IServices5Master
    {
        EntityModel.Services5Master Create(EntityModel.Services5Master entity);

        IEnumerable<EntityModel.Services5Master> FindBy(Expression<Func<EntityModel.Services5Master, bool>> filter = null);

        EntityModel.Services5Master GetById(long Id);

        IEnumerable<EntityModel.Services5Master> GetAll();

        EntityModel.Services5Master Update(EntityModel.Services5Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services5Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services5MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services5Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services5MasterDropdownListViewModel> GetDropdownList();
    }
}
