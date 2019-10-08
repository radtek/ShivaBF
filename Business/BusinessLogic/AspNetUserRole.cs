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
    public class AspNetUserRole : BaseBusiness, IAspNetUserRole
    {
        public ViewModel.BusinessResultViewModel<ViewModel.AspNetUserRoleIndexViewModel> Index(HttpRequestBase Request)
        {
            List<ViewModel.AspNetUserRoleIndexViewModel> collection;
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
                totalRecords = unitOfWork.AspNetUserRoleRepository.Get()
                    .Join(unitOfWork.AspNetUserRepository.Get(), aspNetUserRole => aspNetUserRole.AspNetUser_ID, aspNetUser => aspNetUser.ID, (aspNetUserRole, aspNetUser) => new { aspNetUserRole, aspNetUser })
                    .Join(unitOfWork.AspNetRoleRepository.Get(), aspNetUserRole_aspNetUser => aspNetUserRole_aspNetUser.aspNetUserRole.AspNetRole_ID, aspNetRole => aspNetRole.ID, (aspNetUserRole_aspNetUser, aspNetRole) => new { aspNetUserRole_aspNetUser, aspNetRole })
                    .Join(unitOfWork.TenantRepository.Get(), aspNetUserRole_aspNetUser_aspNetRole => aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.Tenant_ID, tenant => tenant.ID, (aspNetUserRole_aspNetUser_aspNetRole, tenant) => new { aspNetUserRole_aspNetUser_aspNetRole, tenant })
                    .Count(x => x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUser.UserName.CaseInsensitiveContains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetRole.DisplayName.CaseInsensitiveContains(searchValue)
                             || x.tenant.Name.CaseInsensitiveContains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.CreatedBy.Contains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.UpdatedBy.Contains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.CreatedOn.ToString().Contains(searchValue)//searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.UpdatedOn.ToString().Contains(searchValue));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.AspNetUserRoleRepository.Get()
                    .Join(unitOfWork.AspNetUserRepository.Get(), aspNetUserRole => aspNetUserRole.AspNetUser_ID, aspNetUser => aspNetUser.ID, (aspNetUserRole, aspNetUser) => new { aspNetUserRole, aspNetUser })
                    .Join(unitOfWork.AspNetRoleRepository.Get(), aspNetUserRole_aspNetUser => aspNetUserRole_aspNetUser.aspNetUserRole.AspNetRole_ID, aspNetRole => aspNetRole.ID, (aspNetUserRole_aspNetUser, aspNetRole) => new { aspNetUserRole_aspNetUser, aspNetRole })
                    .Join(unitOfWork.TenantRepository.Get(), aspNetUserRole_aspNetUser_aspNetRole => aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.Tenant_ID, tenant => tenant.ID, (aspNetUserRole_aspNetUser_aspNetRole, tenant) => new { aspNetUserRole_aspNetUser_aspNetRole, tenant })
                    .Where(x => x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUser.UserName.CaseInsensitiveContains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetRole.DisplayName.CaseInsensitiveContains(searchValue)
                             || x.tenant.Name.CaseInsensitiveContains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.CreatedBy.Contains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.UpdatedBy.Contains(searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.CreatedOn.ToString().Contains(searchValue)//searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.UpdatedOn.ToString().Contains(searchValue))//searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.AspNetUserRoleIndexViewModel
                    {
                        UserName = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUser.UserName,
                        RoleName = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetRole.DisplayName,
                        TenantName = x.tenant.Name,
                        CreatedBy = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.CreatedBy,
                        CreatedOn = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.CreatedOn,
                        UpdatedBy = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.UpdatedBy,
                        UpdatedOn = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.UpdatedOn,
                        IsDeleted = x.aspNetUserRole_aspNetUser_aspNetRole.aspNetUserRole_aspNetUser.aspNetUserRole.IsDeleted
                    }).ToList();

                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.AspNetUserRoleIndexViewModel>
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



        public EntityModel.AspNetUserRole Create(EntityModel.AspNetUserRole entity)
        {
            try
            {
                unitOfWork.AspNetUserRoleRepository.Insert(entity);
                busCache.LoadAspNetUserRole();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public async Task<EntityModel.AspNetUserRole> CreateAsync(EntityModel.AspNetUserRole entity)
        {
            try
            {
                await unitOfWork.AspNetUserRoleRepository.InsertAsync(entity);
                busCache.LoadAspNetUserRole();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }

        }



        public EntityModel.AspNetUserRole GetById(long Id)
        {
            try
            {
                EntityModel.AspNetUserRole entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.AspNetUserRoleRepository.GetByID(Id);

                return entity;
            }
            catch
            {
                throw;
            }
        }
        public async Task<EntityModel.AspNetUserRole> GetByIdAsyc(long Id)
        {
            try
            {
                EntityModel.AspNetUserRole entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = await unitOfWork.AspNetUserRoleRepository.GetByIDAsync(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public EntityModel.AspNetUserRole Update(EntityModel.AspNetUserRole entity)
        {
            try
            {
                unitOfWork.AspNetUserRoleRepository.Update(entity);
                busCache.LoadAspNetUserRole();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<EntityModel.AspNetUserRole> UpdateAsync(EntityModel.AspNetUserRole entity)
        {
            try
            {
                await unitOfWork.AspNetUserRoleRepository.UpdateAsync(entity);
                busCache.LoadAspNetUserRole();
                return entity;
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
                unitOfWork.AspNetUserRoleRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task DeleteAsync(long Id)
        {
            try
            {
                await unitOfWork.AspNetUserRoleRepository.DeleteAsync(Id);
                busCache.LoadAspNetUserRole();                
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.AspNetUserRole> GetAll()
        {
            try
            {
                return unitOfWork.AspNetUserRoleRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public async Task<IEnumerable<EntityModel.AspNetUserRole>> GetAllAsync()
        {
            try
            {
                return await unitOfWork.AspNetUserRoleRepository.GetAsync();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.AspNetUserRole> FindBy(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.AspNetUserRole> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.AspNetUserRoleRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.AspNetUserRoleRepository.Get();
                }

                return entities;
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<EntityModel.AspNetUserRole>> FindByAsyc(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.AspNetUserRole> entities;
                if (filter.IsNotNull())
                {
                    entities = await unitOfWork.AspNetUserRoleRepository.GetAsync(filter);
                }
                else
                {
                    entities = await unitOfWork.AspNetUserRoleRepository.GetAsync();
                }

                return entities;
            }
            catch
            {
                throw;
            }
        }

        public void DeleteWhere(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null)
        {
            try
            {
                unitOfWork.AspNetUserRoleRepository.DeleteWhere(filter);
                busCache.LoadAspNetUserRole();                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteWhereAsync(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null)
        {
            try
            {
                await unitOfWork.AspNetUserRoleRepository.DeleteWhereAsync(filter);
                busCache.LoadAspNetUserRole();
                
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 Count(Expression<Func<EntityModel.AspNetUserRole, bool>> filter = null)
        {
            try
            {
                return unitOfWork.AspNetUserRoleRepository.Count(filter);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
