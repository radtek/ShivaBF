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
    public interface IServices1Section5Master
    {
        EntityModel.Services1Section5Master Create(EntityModel.Services1Section5Master entity);

        IEnumerable<EntityModel.Services1Section5Master> FindBy(Expression<Func<EntityModel.Services1Section5Master, bool>> filter = null);

        EntityModel.Services1Section5Master GetById(long Id);

        IEnumerable<EntityModel.Services1Section5Master> GetAll();

        EntityModel.Services1Section5Master Update(EntityModel.Services1Section5Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services1Section5Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services1Section5MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services1Section5Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services1Section5MasterDropdownListViewModel> GetDropdownList();
    }
}
