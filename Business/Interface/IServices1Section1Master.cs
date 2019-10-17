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
    public interface IServices1Section1Master
    {
        EntityModel.Services1Section1Master Create(EntityModel.Services1Section1Master entity);

        IEnumerable<EntityModel.Services1Section1Master> FindBy(Expression<Func<EntityModel.Services1Section1Master, bool>> filter = null);

        EntityModel.Services1Section1Master GetById(long Id);

        IEnumerable<EntityModel.Services1Section1Master> GetAll();

        EntityModel.Services1Section1Master Update(EntityModel.Services1Section1Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services1Section1Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services1Section1MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services1Section1Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services1Section1MasterDropdownListViewModel> GetDropdownList();
    }
}
