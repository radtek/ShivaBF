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
    public interface IServices7Section4
    {
        EntityModel.Services7Section4 Create(EntityModel.Services7Section4 entity);

        IEnumerable<EntityModel.Services7Section4> FindBy(Expression<Func<EntityModel.Services7Section4, bool>> filter = null);

        EntityModel.Services7Section4 GetById(long Id);

        IEnumerable<EntityModel.Services7Section4> GetAll();

        EntityModel.Services7Section4 Update(EntityModel.Services7Section4 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services7Section4, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services7Section4IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services7Section4, bool>> filter = null);

      // IEnumerable<ViewModel.Services7Section4DropdownListViewModel> GetDropdownList();
    }
}
