using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.Business.Interface
{
    public interface IAspNetUserRole
    {
        EntityModel.AspNetUserRole Create(EntityModel.AspNetUserRole entity);
        Task<EntityModel.AspNetUserRole> CreateAsync(EntityModel.AspNetUserRole entity);

        IEnumerable<EntityModel.AspNetUserRole> FindBy(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null);
        Task<IEnumerable<EntityModel.AspNetUserRole>> FindByAsyc(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null);


        EntityModel.AspNetUserRole GetById(long Id);
        Task<EntityModel.AspNetUserRole> GetByIdAsyc(long Id);

        IEnumerable<EntityModel.AspNetUserRole> GetAll();
        Task<IEnumerable<EntityModel.AspNetUserRole>> GetAllAsync();

        EntityModel.AspNetUserRole Update(EntityModel.AspNetUserRole entity);
        Task<EntityModel.AspNetUserRole> UpdateAsync(EntityModel.AspNetUserRole entity);

        void Delete(long Id);
        Task DeleteAsync(long id);

        void DeleteWhere(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null);
        Task DeleteWhereAsync(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.AspNetUserRoleIndexViewModel> Index(HttpRequestBase Request);
        Int32 Count(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null);
    }
}
