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
    public interface IServices2Section3DownloadMaster
    {
        EntityModel.Services2Section3DownloadMaster Create(EntityModel.Services2Section3DownloadMaster entity);

        IEnumerable<EntityModel.Services2Section3DownloadMaster> FindBy(Expression<Func<EntityModel.Services2Section3DownloadMaster, bool>> filter = null);

        EntityModel.Services2Section3DownloadMaster GetById(long Id);

        IEnumerable<EntityModel.Services2Section3DownloadMaster> GetAll();

        EntityModel.Services2Section3DownloadMaster Update(EntityModel.Services2Section3DownloadMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services2Section3DownloadMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services2Section3DownloadMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services2Section3DownloadMaster, bool>> filter = null);

      // IEnumerable<ViewModel.Services2Section3DownloadMasterDropdownListViewModel> GetDropdownList();
    }
}
