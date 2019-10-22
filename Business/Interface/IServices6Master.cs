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
    public interface IServices6Master
    {
        EntityModel.Services6Master Create(EntityModel.Services6Master entity);

        IEnumerable<EntityModel.Services6Master> FindBy(Expression<Func<EntityModel.Services6Master, bool>> filter = null);

        EntityModel.Services6Master GetById(long Id);

        IEnumerable<EntityModel.Services6Master> GetAll();

        EntityModel.Services6Master Update(EntityModel.Services6Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services6Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services6MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services6Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services6MasterDropdownListViewModel> GetDropdownList();
    }
}
