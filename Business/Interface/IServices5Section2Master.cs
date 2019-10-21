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
    public interface IServices5Section2Master
    {
        EntityModel.Services5Section2Master Create(EntityModel.Services5Section2Master entity);

        IEnumerable<EntityModel.Services5Section2Master> FindBy(Expression<Func<EntityModel.Services5Section2Master, bool>> filter = null);

        EntityModel.Services5Section2Master GetById(long Id);

        IEnumerable<EntityModel.Services5Section2Master> GetAll();

        EntityModel.Services5Section2Master Update(EntityModel.Services5Section2Master entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services5Section2Master, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services5Section2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services5Section2Master, bool>> filter = null);

      // IEnumerable<ViewModel.Services5Section2MasterDropdownListViewModel> GetDropdownList();
    }
}
