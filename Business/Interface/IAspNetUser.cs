using SHF.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.Business.Interface
{
    public interface IAspNetUser
    {       

        IEnumerable<EntityModel.AspNetUser> FindBy(Expression<Func<EntityModel.AspNetUser, bool>> filter = null);        

        EntityModel.AspNetUser GetById(long Id);        

        IEnumerable<EntityModel.AspNetUser> GetAll();        

        EntityModel.AspNetUser Update(EntityModel.AspNetUser entity);        

        void Delete(long Id);        

        void DeleteWhere(Expression<Func<EntityModel.AspNetUser, bool>> filter = null);       

        ViewModel.BusinessResultViewModel<ViewModel.AspNetUserIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.AspNetUser, bool>> filter = null);
    }
}
