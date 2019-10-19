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
    public interface IPriceFeaturesMapping
    {
        EntityModel.PriceFeaturesMapping Create(EntityModel.PriceFeaturesMapping entity);

        IEnumerable<EntityModel.PriceFeaturesMapping> FindBy(Expression<Func<EntityModel.PriceFeaturesMapping, bool>> filter = null);

        EntityModel.PriceFeaturesMapping GetById(long Id);

        IEnumerable<EntityModel.PriceFeaturesMapping> GetAll();

        EntityModel.PriceFeaturesMapping Update(EntityModel.PriceFeaturesMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.PriceFeaturesMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.PriceFeaturesMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.PriceFeaturesMapping, bool>> filter = null);

      // IEnumerable<ViewModel.PriceFeaturesMappingDropdownListViewModel> GetDropdownList();
    }
}
