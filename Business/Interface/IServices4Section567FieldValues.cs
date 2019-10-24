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
    public interface IServices4Section567FieldValues
    {
        EntityModel.Services4Section567FieldValues Create(EntityModel.Services4Section567FieldValues entity);

        IEnumerable<EntityModel.Services4Section567FieldValues> FindBy(Expression<Func<EntityModel.Services4Section567FieldValues, bool>> filter = null);

        EntityModel.Services4Section567FieldValues GetById(long Id);

        IEnumerable<EntityModel.Services4Section567FieldValues> GetAll();

        EntityModel.Services4Section567FieldValues Update(EntityModel.Services4Section567FieldValues entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.Services4Section567FieldValues, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.Services4Section567FieldValuesIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.Services4Section567FieldValues, bool>> filter = null);

      // IEnumerable<ViewModel.Services4Section567FieldValuesDropdownListViewModel> GetDropdownList();
    }
}
