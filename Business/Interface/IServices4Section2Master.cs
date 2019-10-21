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
    public interface IServices4Section2Master
    {
        EntityModel.Services4Section2Master Create(EntityModel.Services4Section2Master entity);

        IEnumerable<EntityModel.Services4Section2Master> FindBy(Expression<Func<EntityModel.Services4Section2Master, bool>> filter = null);

        EntityModel.Services4Section2Master GetById(long Id);

        IEnumerable<EntityModel.Services4Section2Master> GetAll();

        EntityModel.Services4Section2Master Update(EntityModel.Services4Section2Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section2Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section2Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section2MasterDropdownListViewModel> GetDropdownList();
    }
}
