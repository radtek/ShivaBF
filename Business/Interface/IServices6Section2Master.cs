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
    public interface IServices6Section2Master
    {
        EntityModel.Services6Section2Master Create(EntityModel.Services6Section2Master entity);

        IEnumerable<EntityModel.Services6Section2Master> FindBy(Expression<Func<EntityModel.Services6Section2Master, bool>> filter = null);

        EntityModel.Services6Section2Master GetById(long Id);

        IEnumerable<EntityModel.Services6Section2Master> GetAll();

        EntityModel.Services6Section2Master Update(EntityModel.Services6Section2Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services6Section2Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services6Section2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services6Section2Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services6Section2MasterDropdownListViewModel> GetDropdownList();
    }
}
