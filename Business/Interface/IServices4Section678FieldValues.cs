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
    public interface IServices4Section678FieldValues
    {
        EntityModel.Services4Section678FieldValues Create(EntityModel.Services4Section678FieldValues entity);

        IEnumerable<EntityModel.Services4Section678FieldValues> FindBy(Expression<Func<EntityModel.Services4Section678FieldValues, bool>> filter = null);

        EntityModel.Services4Section678FieldValues GetById(long Id);

        IEnumerable<EntityModel.Services4Section678FieldValues> GetAll();

        EntityModel.Services4Section678FieldValues Update(EntityModel.Services4Section678FieldValues entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section678FieldValues, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section678FieldValuesIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section678FieldValues, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section678FieldValuesDropdownListViewModel> GetDropdownList();
    }
}
