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
    public interface ISubCategoriesMaster
    {
        EntityModel.SubCategoriesMaster Create(EntityModel.SubCategoriesMaster entity);

        IEnumerable<EntityModel.SubCategoriesMaster> FindBy(Expression<Func<EntityModel.SubCategoriesMaster, bool>> filter = null);

        EntityModel.SubCategoriesMaster GetById(long Id);

        IEnumerable<EntityModel.SubCategoriesMaster> GetAll();

        EntityModel.SubCategoriesMaster Update(EntityModel.SubCategoriesMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.SubCategoriesMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.SubCategoriesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.SubCategoriesMaster, bool>> filter = null);

      // IEnumerable<ViewModel.SubCategoriesMasterDropdownListViewModel> GetDropdownList();
    }
}
