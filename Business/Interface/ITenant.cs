using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Dapper;
using SHF.Business.Interface;
using SHF.Helper;


namespace SHF.Business.Interface
{
    public interface ITenant
    {
        //Task<PaggedObjectList<EntityModel.Tenant>> IndexAsync(GridParams grdParams, string search, CustomerIndexViewModel filter);

        EntityModel.Tenant Create(EntityModel.Tenant entity);
        Task<EntityModel.Tenant> CreateAsync(EntityModel.Tenant entity);

        IEnumerable<EntityModel.Tenant> FindBy(Expression<Func<EntityModel.Tenant, bool>> filter = null);
        Task<IEnumerable<EntityModel.Tenant>> FindByAsyc(Expression<Func<EntityModel.Tenant, bool>> filter = null);


        EntityModel.Tenant GetById(long Id);
        Task<EntityModel.Tenant> GetByIdAsyc(long Id);

        IEnumerable<EntityModel.Tenant> GetAll();
        Task<IEnumerable<EntityModel.Tenant>> GetAllAsync();

        EntityModel.Tenant Update(EntityModel.Tenant entity);
        Task<EntityModel.Tenant> UpdateAsync(EntityModel.Tenant entity);

        void Delete(long Id);
        Task DeleteAsync(long id);

        void DeleteWhere(Expression<Func<EntityModel.Tenant, bool>> filter = null);
        Task DeleteWhereAsync(Expression<Func<EntityModel.Tenant, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.TenantIndexViewModel> Index(HttpRequestBase Request);
        
        IEnumerable<ViewModel.TenantDropdownListViewModel> GetDropdownList();
        

    }
}
