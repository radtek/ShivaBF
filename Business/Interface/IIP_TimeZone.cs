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
    public interface ITimeZone
    {
        EntityModel.TimeZone Create(EntityModel.TimeZone entity);

        IEnumerable<EntityModel.TimeZone> FindBy(Expression<Func<EntityModel.TimeZone, bool>> filter = null);

        EntityModel.TimeZone GetById(long Id);

        IEnumerable<EntityModel.TimeZone> GetAll();

        EntityModel.TimeZone Update(EntityModel.TimeZone entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.TimeZone, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IP_TimeZoneIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.TimeZone, bool>> filter = null);

      // IEnumerable<ViewModel.TimeZoneDropdownListViewModel> GetDropdownList();
    }
}
