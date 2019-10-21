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
    public interface IServices3Section4
    {
        EntityModel.Services3Section4 Create(EntityModel.Services3Section4 entity);

        IEnumerable<EntityModel.Services3Section4> FindBy(Expression<Func<EntityModel.Services3Section4, bool>> filter = null);

        EntityModel.Services3Section4 GetById(long Id);

        IEnumerable<EntityModel.Services3Section4> GetAll();

        EntityModel.Services3Section4 Update(EntityModel.Services3Section4 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services3Section4, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services3Section4IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services3Section4, bool>> filter = null);

      // IEnumerable<ViewModel.Services3Section4DropdownListViewModel> GetDropdownList();
    }
}
