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
    public interface IServices4Section345Master
    {
        EntityModel.Services4Section345Master Create(EntityModel.Services4Section345Master entity);

        IEnumerable<EntityModel.Services4Section345Master> FindBy(Expression<Func<EntityModel.Services4Section345Master, bool>> filter = null);

        EntityModel.Services4Section345Master GetById(long Id);

        IEnumerable<EntityModel.Services4Section345Master> GetAll();

        EntityModel.Services4Section345Master Update(EntityModel.Services4Section345Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section345Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section345Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section345MasterDropdownListViewModel> GetDropdownList();
    }
}
