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
using SHF.EntityModel;
using SHF.Helper;
using SHF.ViewModel;


namespace SHF.Business.BusinessLogic
{
    public class AspNetRole : BaseBusiness, IAspNetRole
    {
        public ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.AspNetRoleIndexViewModel> collection;
            // ArrayList arrayList;
            try
            {
                //Datatable parameter
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                //paging parameter
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //sorting parameter            
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();



                //Global filter parameter
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : busConstant.Numbers.Integer.ZERO;
                int skip = start != null ? Convert.ToInt32(start) : busConstant.Numbers.Integer.ZERO;
                int totalRecords = busConstant.Numbers.Integer.ZERO;

                //Count total Records meeting criteria
                totalRecords = unitOfWork.AspNetRoleRepository.Get().Join(unitOfWork.TenantRepository.Get(), aspnetRole => aspnetRole.Tenant_ID, tenant => tenant.ID, (aspnetRole, tenant) => new { aspnetRole, tenant })
                    .Count(x => (tenant_Id == null || x.aspnetRole.Tenant_ID == tenant_Id)
                    && (x.aspnetRole.ID.ToString().Contains(searchValue)
                || x.aspnetRole.DisplayName.CaseInsensitiveContains(searchValue)
                || x.tenant.Name.CaseInsensitiveContains(searchValue)
                || x.aspnetRole.CreatedBy.CaseInsensitiveContains(searchValue)
                || x.aspnetRole.UpdatedBy.CaseInsensitiveContains(searchValue)
                || x.aspnetRole.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                || x.aspnetRole.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.AspNetRoleRepository.Get().Join(unitOfWork.TenantRepository.Get(), aspnetRole => aspnetRole.Tenant_ID, tenant => tenant.ID, (aspnetRole, tenant) => new { aspnetRole, tenant })
                   .Where(x => (tenant_Id == null || x.aspnetRole.Tenant_ID == tenant_Id)
                    && (x.aspnetRole.ID.ToString().Contains(searchValue)
                             || x.aspnetRole.DisplayName.Contains(searchValue)
                             || x.tenant.Name.Contains(searchValue)
                             || x.aspnetRole.CreatedBy.Contains(searchValue)
                             || x.aspnetRole.UpdatedBy.Contains(searchValue)
                             || x.aspnetRole.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspnetRole.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.AspNetRoleIndexViewModel
                    {
                        ID = x.aspnetRole.ID,
                        Name = x.aspnetRole.Name,
                        DisplayName = x.aspnetRole.DisplayName,
                        TenantName = x.tenant.Name,
                        CreatedBy = x.aspnetRole.CreatedBy,
                        CreatedOn = x.aspnetRole.CreatedOn,
                        UpdatedBy = x.aspnetRole.UpdatedBy,
                        UpdatedOn = x.aspnetRole.UpdatedOn,
                        IsDeleted = x.aspnetRole.IsDeleted
                    }).ToList();

                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleIndexViewModel>
                {
                    Draw = draw,
                    RecordsFiltered = totalRecords,
                    RecordsTotal = totalRecords,
                    Data = collection
                };

                return businessResultViewModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                collection = null;
            }
        }

        public EntityModel.AspNetRole Create(EntityModel.AspNetRole entity)
        {
            try
            {
                return unitOfWork.AspNetRoleRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public EntityModel.AspNetRole GetById(long Id)
        {
            try
            {
                EntityModel.AspNetRole entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.AspNetRoleRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EntityModel.AspNetRole Update(EntityModel.AspNetRole entity)
        {
            try
            {
                return unitOfWork.AspNetRoleRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(long Id)
        {
            try
            {
                unitOfWork.AspNetRoleRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<EntityModel.AspNetRole> GetAll()
        {
            try
            {
                return unitOfWork.AspNetRoleRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<EntityModel.AspNetRole> FindBy(Expression<Func<EntityModel.AspNetRole, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.AspNetRole> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.AspNetRoleRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.AspNetRoleRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteWhere(Expression<Func<EntityModel.AspNetRole, bool>> filter = null)
        {
            try
            {
                unitOfWork.AspNetRoleRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<AspNetRoleDropDownListViewModel> GetRolesByUserId(long id)
        {
            try
            {
                var colletion = unitOfWork.AspNetRoleRepository.Get()
                                .Join(unitOfWork.AspNetUserRoleRepository.Get(), aspNetRole => aspNetRole.ID, aspNetUserRole => aspNetUserRole.AspNetRole_ID, (aspNetRole, aspNetUserRole) => new { aspNetRole, aspNetUserRole })
                                .Where(x => x.aspNetUserRole.AspNetUser_ID == id)
                                .Select(x => new ViewModel.AspNetRoleDropDownListViewModel
                                {
                                    ID = x.aspNetRole.ID,
                                    Name = x.aspNetRole.DisplayName
                                });

                return colletion;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 Count(Expression<Func<EntityModel.AspNetRole, bool>> filter = null)
        {
            try
            {
                return unitOfWork.AspNetRoleRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
