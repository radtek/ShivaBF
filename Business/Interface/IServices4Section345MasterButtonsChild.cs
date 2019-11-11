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
    public interface IServices4Section345MasterButtonsChild
    {
        EntityModel.Services4Section345MasterButtonsChild Create(EntityModel.Services4Section345MasterButtonsChild entity);

        IEnumerable<EntityModel.Services4Section345MasterButtonsChild> FindBy(Expression<Func<EntityModel.Services4Section345MasterButtonsChild, bool>> filter = null);

        EntityModel.Services4Section345MasterButtonsChild GetById(long Id);

        IEnumerable<EntityModel.Services4Section345MasterButtonsChild> GetAll();

        EntityModel.Services4Section345MasterButtonsChild Update(EntityModel.Services4Section345MasterButtonsChild entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section345MasterButtonsChild, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterButtonsChildIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section345MasterButtonsChild, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section345MasterButtonsChildDropdownListViewModel> GetDropdownList();
    }
}
