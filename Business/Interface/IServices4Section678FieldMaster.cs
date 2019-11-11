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
    public interface IServices4Section678FieldMaster
    {
        EntityModel.Services4Section678FieldMaster Create(EntityModel.Services4Section678FieldMaster entity);

        IEnumerable<EntityModel.Services4Section678FieldMaster> FindBy(Expression<Func<EntityModel.Services4Section678FieldMaster, bool>> filter = null);

        EntityModel.Services4Section678FieldMaster GetById(long Id);

        IEnumerable<EntityModel.Services4Section678FieldMaster> GetAll();

        EntityModel.Services4Section678FieldMaster Update(EntityModel.Services4Section678FieldMaster entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section678FieldMaster, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section678FieldMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section678FieldMaster, bool>> filter = null);
    }
}
