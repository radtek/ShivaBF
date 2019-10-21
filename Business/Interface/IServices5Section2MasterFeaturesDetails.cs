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
    public interface IServices5Section2MasterFeaturesDetails
    {
        EntityModel.Services5Section2MasterFeaturesDetails Create(EntityModel.Services5Section2MasterFeaturesDetails entity);

        IEnumerable<EntityModel.Services5Section2MasterFeaturesDetails> FindBy(Expression<Func<EntityModel.Services5Section2MasterFeaturesDetails, bool>> filter = null);

        EntityModel.Services5Section2MasterFeaturesDetails GetById(long Id);

        IEnumerable<EntityModel.Services5Section2MasterFeaturesDetails> GetAll();

        EntityModel.Services5Section2MasterFeaturesDetails Update(EntityModel.Services5Section2MasterFeaturesDetails entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services5Section2MasterFeaturesDetails, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services5Section2MasterFeaturesDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services5Section2MasterFeaturesDetails, bool>> filter = null);

      // IEnumerable<ViewModel.Services5Section2MasterFeaturesDetailsDropdownListViewModel> GetDropdownList();
    }
}
