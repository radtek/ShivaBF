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
    public interface IServices8Master
    {
        EntityModel.Services8Master Create(EntityModel.Services8Master entity);

        IEnumerable<EntityModel.Services8Master> FindBy(Expression<Func<EntityModel.Services8Master, bool>> filter = null);

        EntityModel.Services8Master GetById(long Id);

        IEnumerable<EntityModel.Services8Master> GetAll();

        EntityModel.Services8Master Update(EntityModel.Services8Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services8Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services8MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services8Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services8MasterDropdownListViewModel> GetDropdownList();
    }
}
