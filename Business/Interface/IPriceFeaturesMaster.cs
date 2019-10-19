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
    public interface IPriceFeaturesMaster
    {
        EntityModel.PriceFeaturesMaster Create(EntityModel.PriceFeaturesMaster entity);

        IEnumerable<EntityModel.PriceFeaturesMaster> FindBy(Expression<Func<EntityModel.PriceFeaturesMaster, bool>> filter = null);

        EntityModel.PriceFeaturesMaster GetById(long Id);

        IEnumerable<EntityModel.PriceFeaturesMaster> GetAll();

        EntityModel.PriceFeaturesMaster Update(EntityModel.PriceFeaturesMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.PriceFeaturesMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.PriceFeaturesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.PriceFeaturesMaster, bool>> filter = null);

      // IEnumerable<ViewModel.PriceFeaturesMasterDropdownListViewModel> GetDropdownList();
    }
}
