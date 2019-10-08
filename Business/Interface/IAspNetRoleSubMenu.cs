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
    public interface IAspNetRoleSubMenu
    {
        void Save();

        void Add(EntityModel.AspNetRoleSubMenu entity);

        EntityModel.AspNetRoleSubMenu Create(EntityModel.AspNetRoleSubMenu entity);

        IEnumerable<EntityModel.AspNetRoleSubMenu> FindBy(long userId);

        IEnumerable<EntityModel.AspNetRoleSubMenu> FindBy(Expression<Func<EntityModel.AspNetRoleSubMenu, bool>> filter = null);

        EntityModel.AspNetRoleSubMenu GetById(long Id);

        IEnumerable<EntityModel.AspNetRoleSubMenu> GetAll();

        EntityModel.AspNetRoleSubMenu Update(EntityModel.AspNetRoleSubMenu entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.AspNetRoleSubMenu, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleSubMenuIndexViewModel> Index(HttpRequestBase Request, long? tenantId, long? aspNetRoleID);
        Int32 Count(Expression<Func<EntityModel.AspNetRoleSubMenu, bool>> filter = null);
    }
}
