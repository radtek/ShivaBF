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
    public interface IServices2Section4Master
    {
        EntityModel.Services2Section4Master Create(EntityModel.Services2Section4Master entity);

        IEnumerable<EntityModel.Services2Section4Master> FindBy(Expression<Func<EntityModel.Services2Section4Master, bool>> filter = null);

        EntityModel.Services2Section4Master GetById(long Id);

        IEnumerable<EntityModel.Services2Section4Master> GetAll();

        EntityModel.Services2Section4Master Update(EntityModel.Services2Section4Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services2Section4Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services2Section4MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services2Section4Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services2Section4MasterDropdownListViewModel> GetDropdownList();
    }
}
