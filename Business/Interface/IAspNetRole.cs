using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.Business.Interface
{
    public interface IAspNetRole
    {
        EntityModel.AspNetRole Create(EntityModel.AspNetRole entity);


        IEnumerable<EntityModel.AspNetRole> FindBy(Expression<Func<EntityModel.AspNetRole, bool>> filter = null);


        EntityModel.AspNetRole GetById(long Id);


        IEnumerable<EntityModel.AspNetRole> GetAll();


        EntityModel.AspNetRole Update(EntityModel.AspNetRole entity);


        void Delete(long Id);


        void DeleteWhere(Expression<Func<EntityModel.AspNetRole, bool>> filter = null);


        ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);


        IEnumerable<ViewModel.AspNetRoleDropDownListViewModel> GetRolesByUserId(long id);


        Int32 Count(Expression<Func<EntityModel.AspNetRole, bool>> filter = null);

    }
}
