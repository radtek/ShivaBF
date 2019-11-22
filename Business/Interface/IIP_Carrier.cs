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
    public interface ICarrier
    {
        EntityModel.Carrier Create(EntityModel.Carrier entity);

        IEnumerable<EntityModel.Carrier> FindBy(Expression<Func<EntityModel.Carrier, bool>> filter = null);

        EntityModel.Carrier GetById(long Id);

        IEnumerable<EntityModel.Carrier> GetAll();

        EntityModel.Carrier Update(EntityModel.Carrier entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Carrier, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IP_CarrierIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Carrier, bool>> filter = null);

      // IEnumerable<ViewModel.CarrierDropdownListViewModel> GetDropdownList();
    }
}
