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
    public interface IServices1Section4Master
    {
        EntityModel.Services1Section4Master Create(EntityModel.Services1Section4Master entity);

        IEnumerable<EntityModel.Services1Section4Master> FindBy(Expression<Func<EntityModel.Services1Section4Master, bool>> filter = null);

        EntityModel.Services1Section4Master GetById(long Id);

        IEnumerable<EntityModel.Services1Section4Master> GetAll();

        EntityModel.Services1Section4Master Update(EntityModel.Services1Section4Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services1Section4Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services1Section4MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services1Section4Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services1Section4MasterDropdownListViewModel> GetDropdownList();
    }
}
