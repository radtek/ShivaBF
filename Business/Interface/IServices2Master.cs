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
    public interface IServices2Master
    {
        EntityModel.Services2Master Create(EntityModel.Services2Master entity);

        IEnumerable<EntityModel.Services2Master> FindBy(Expression<Func<EntityModel.Services2Master, bool>> filter = null);

        EntityModel.Services2Master GetById(long Id);

        IEnumerable<EntityModel.Services2Master> GetAll();

        EntityModel.Services2Master Update(EntityModel.Services2Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services2Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services2Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services2MasterDropdownListViewModel> GetDropdownList();
    }
}
