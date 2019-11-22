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
    public interface IAsn
    {
        EntityModel.Asn Create(EntityModel.Asn entity);

        IEnumerable<EntityModel.Asn> FindBy(Expression<Func<EntityModel.Asn, bool>> filter = null);

        EntityModel.Asn GetById(long Id);

        IEnumerable<EntityModel.Asn> GetAll();

        EntityModel.Asn Update(EntityModel.Asn entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Asn, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IP_AsnIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Asn, bool>> filter = null);

      // IEnumerable<ViewModel.AsnDropdownListViewModel> GetDropdownList();
    }
}
