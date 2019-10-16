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
    public interface ISubSubCategoriesMaster
    {
        EntityModel.SubSubCategoriesMaster Create(EntityModel.SubSubCategoriesMaster entity);

        IEnumerable<EntityModel.SubSubCategoriesMaster> FindBy(Expression<Func<EntityModel.SubSubCategoriesMaster, bool>> filter = null);

        EntityModel.SubSubCategoriesMaster GetById(long Id);

        IEnumerable<EntityModel.SubSubCategoriesMaster> GetAll();

        EntityModel.SubSubCategoriesMaster Update(EntityModel.SubSubCategoriesMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.SubSubCategoriesMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.SubSubCategoriesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.SubSubCategoriesMaster, bool>> filter = null);

      // IEnumerable<ViewModel.SubSubCategoriesMasterDropdownListViewModel> GetDropdownList();
    }
}
