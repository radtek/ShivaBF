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
    public interface IPageViewsReport
    {
        EntityModel.PageViewsReport Create(EntityModel.PageViewsReport entity);

        IEnumerable<EntityModel.PageViewsReport> FindBy(Expression<Func<EntityModel.PageViewsReport, bool>> filter = null);

        EntityModel.PageViewsReport GetById(long Id);

        IEnumerable<EntityModel.PageViewsReport> GetAll();

        EntityModel.PageViewsReport Update(EntityModel.PageViewsReport entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.PageViewsReport, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.PageViewsReportIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.PageViewsReport, bool>> filter = null);

      // IEnumerable<ViewModel.PageViewsReportDropdownListViewModel> GetDropdownList();
    }
}
