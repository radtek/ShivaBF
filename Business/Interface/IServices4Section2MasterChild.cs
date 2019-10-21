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
    public interface IServices4Section2MasterChild
    {
        EntityModel.Services4Section2MasterChild Create(EntityModel.Services4Section2MasterChild entity);

        IEnumerable<EntityModel.Services4Section2MasterChild> FindBy(Expression<Func<EntityModel.Services4Section2MasterChild, bool>> filter = null);

        EntityModel.Services4Section2MasterChild GetById(long Id);

        IEnumerable<EntityModel.Services4Section2MasterChild> GetAll();

        EntityModel.Services4Section2MasterChild Update(EntityModel.Services4Section2MasterChild entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section2MasterChild, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section2MasterChildIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section2MasterChild, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section2MasterChildDropdownListViewModel> GetDropdownList();
    }
}
