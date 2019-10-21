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
    public interface IServices4Master
    {
        EntityModel.Services4Master Create(EntityModel.Services4Master entity);

        IEnumerable<EntityModel.Services4Master> FindBy(Expression<Func<EntityModel.Services4Master, bool>> filter = null);

        EntityModel.Services4Master GetById(long Id);

        IEnumerable<EntityModel.Services4Master> GetAll();

        EntityModel.Services4Master Update(EntityModel.Services4Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services4MasterDropdownListViewModel> GetDropdownList();
    }
}
