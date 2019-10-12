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
    public interface ICategoriesMaster
    {
        EntityModel.CategoriesMaster Create(EntityModel.CategoriesMaster entity);

        IEnumerable<EntityModel.CategoriesMaster> FindBy(Expression<Func<EntityModel.CategoriesMaster, bool>> filter = null);

        EntityModel.CategoriesMaster GetById(long Id);

        IEnumerable<EntityModel.CategoriesMaster> GetAll();

        EntityModel.CategoriesMaster Update(EntityModel.CategoriesMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CategoriesMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CategoriesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CategoriesMaster, bool>> filter = null);

      // IEnumerable<ViewModel.CategoriesMasterDropdownListViewModel> GetDropdownList();
    }
}
