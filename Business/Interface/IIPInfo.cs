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
    public interface IIPInfo
    {
        EntityModel.IPInfo Create(EntityModel.IPInfo entity);

        IEnumerable<EntityModel.IPInfo> FindBy(Expression<Func<EntityModel.IPInfo, bool>> filter = null);

        EntityModel.IPInfo GetById(long Id);

        IEnumerable<EntityModel.IPInfo> GetAll();

        EntityModel.IPInfo Update(EntityModel.IPInfo entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.IPInfo, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.IPInfoIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.IPInfo, bool>> filter = null);

      // IEnumerable<ViewModel.IPInfoDropdownListViewModel> GetDropdownList();
    }
}
