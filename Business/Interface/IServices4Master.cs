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
    public interface IServices4Master
    {
        EntityModel.Services3Master Create(EntityModel.Services3Master entity);

        IEnumerable<EntityModel.Services3Master> FindBy(Expression<Func<EntityModel.Services3Master, bool>> filter = null);

        EntityModel.Services3Master GetById(long Id);

        IEnumerable<EntityModel.Services3Master> GetAll();

        EntityModel.Services3Master Update(EntityModel.Services3Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services3Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services3MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services3Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services3MasterDropdownListViewModel> GetDropdownList();
    }
}
