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
    public interface IServices4Section567FieldMaster
    {
        EntityModel.Services4Section567FieldMaster Create(EntityModel.Services4Section567FieldMaster entity);

        IEnumerable<EntityModel.Services4Section567FieldMaster> FindBy(Expression<Func<EntityModel.Services4Section567FieldMaster, bool>> filter = null);

        EntityModel.Services4Section567FieldMaster GetById(long Id);

        IEnumerable<EntityModel.Services4Section567FieldMaster> GetAll();

        EntityModel.Services4Section567FieldMaster Update(EntityModel.Services4Section567FieldMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section567FieldMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section567FieldMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section567FieldMaster, bool>> filter = null);
    }
}
