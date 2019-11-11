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
    public interface IServices4Section345MasterFeaturesDetails
    {
        EntityModel.Services4Section345MasterFeaturesDetails Create(EntityModel.Services4Section345MasterFeaturesDetails entity);

        IEnumerable<EntityModel.Services4Section345MasterFeaturesDetails> FindBy(Expression<Func<EntityModel.Services4Section345MasterFeaturesDetails, bool>> filter = null);

        EntityModel.Services4Section345MasterFeaturesDetails GetById(long Id);

        IEnumerable<EntityModel.Services4Section345MasterFeaturesDetails> GetAll();

        EntityModel.Services4Section345MasterFeaturesDetails Update(EntityModel.Services4Section345MasterFeaturesDetails entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section345MasterFeaturesDetails, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section345MasterFeaturesDetailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section345MasterFeaturesDetails, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section345MasterFeaturesDetailsDropdownListViewModel> GetDropdownList();
    }
}
