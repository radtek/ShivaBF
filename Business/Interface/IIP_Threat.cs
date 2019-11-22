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
    public interface IThreat
    {
        EntityModel.Threat Create(EntityModel.Threat entity);

        IEnumerable<EntityModel.Threat> FindBy(Expression<Func<EntityModel.Threat, bool>> filter = null);

        EntityModel.Threat GetById(long Id);

        IEnumerable<EntityModel.Threat> GetAll();

        EntityModel.Threat Update(EntityModel.Threat entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Threat, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IP_ThreatIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Threat, bool>> filter = null);

      // IEnumerable<ViewModel.ThreatDropdownListViewModel> GetDropdownList();
    }
}
