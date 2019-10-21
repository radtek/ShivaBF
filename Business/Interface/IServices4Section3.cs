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
    public interface IServices4Section3
    {
        EntityModel.Services4Section3 Create(EntityModel.Services4Section3 entity);

        IEnumerable<EntityModel.Services4Section3> FindBy(Expression<Func<EntityModel.Services4Section3, bool>> filter = null);

        EntityModel.Services4Section3 GetById(long Id);

        IEnumerable<EntityModel.Services4Section3> GetAll();

        EntityModel.Services4Section3 Update(EntityModel.Services4Section3 entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section3, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section3IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section3, bool>> filter = null);
    }
}
