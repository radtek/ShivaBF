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
    public interface ISubMenu
    {
        EntityModel.SubMenu Create(EntityModel.SubMenu entity);


        IEnumerable<EntityModel.SubMenu> FindBy(long userId);

        IEnumerable<EntityModel.SubMenu> FindBy(Expression<Func<EntityModel.SubMenu, bool>> filter = null);


        EntityModel.SubMenu GetById(long Id);


        IEnumerable<EntityModel.SubMenu> GetAll();


        EntityModel.SubMenu Update(EntityModel.SubMenu entity);


        void Delete(long Id);


        void DeleteWhere(Expression<Func<EntityModel.SubMenu, bool>> filter = null);


        ViewModel.BusinessResultViewModel<ViewModel.SubMenuIndexViewModel> Index(HttpRequestBase Request, long Customer_ID = busConstant.Numbers.Integer.ZERO);
        Int32 Count(Expression<Func<EntityModel.SubMenu, bool>> filter = null);
        IEnumerable<ViewModel.SubMenuIndexViewModel> GetDropdownList();
       
    }
}
