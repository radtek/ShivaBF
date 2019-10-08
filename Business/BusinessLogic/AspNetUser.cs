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
    public class AspNetUser : BaseBusiness, IAspNetUser
    {
        public ViewModel.BusinessResultViewModel<ViewModel.AspNetUserIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.AspNetUserIndexViewModel> collection;
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
                totalRecords = unitOfWork.AspNetUserRepository.Get()
                    .Join(unitOfWork.TenantRepository.Get(), aspnetUser => aspnetUser.Tenant_ID, tenant => tenant.ID, (aspnetUser, tenant) => new { aspnetUser, tenant })
                         .Count(x => (tenant_Id == null || x.aspnetUser.Tenant_ID == tenant_Id)
                            && (x.aspnetUser.ID.ToString().Contains(searchValue)
                             || x.aspnetUser.UserName.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.Email.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.EmailConfirmed.ToString().CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.PhoneNumber.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.PhoneNumberConfirmed.ToString().CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.LockoutEndDateUtc.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspnetUser.LockoutEnabled.ToString().CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.AccessFailedCount.ToString().CaseInsensitiveContains(searchValue)
                             || x.tenant.Name.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.CreatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.UpdatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspnetUser.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                           ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.AspNetUserRepository.Get()
                    .Join(unitOfWork.TenantRepository.Get(), aspnetUser => aspnetUser.Tenant_ID, tenant => tenant.ID, (aspnetUser, tenant) => new { aspnetUser, tenant })
                    .Where(x => (tenant_Id == null || x.aspnetUser.Tenant_ID == tenant_Id)
                            && (x.aspnetUser.ID.ToString().Contains(searchValue)
                             || x.aspnetUser.UserName.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.Email.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.EmailConfirmed.ToString().CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.PhoneNumber.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.PhoneNumberConfirmed.ToString().CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.LockoutEndDateUtc.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspnetUser.LockoutEnabled.ToString().CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.AccessFailedCount.ToString().CaseInsensitiveContains(searchValue)
                             || x.tenant.Name.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.CreatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.UpdatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspnetUser.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspnetUser.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                           ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.AspNetUserIndexViewModel
                    {
                        ID = x.aspnetUser.ID,
                        FirstName = x.aspnetUser.FirstName,
                        LastName = x.aspnetUser.LastName,
                        UserName = x.aspnetUser.UserName,
                        Email = x.aspnetUser.Email,
                        EmailConfirmed = x.aspnetUser.EmailConfirmed,
                        PhoneNumber = x.aspnetUser.PhoneNumber,
                        PhoneNumberConfirmed = x.aspnetUser.PhoneNumberConfirmed,
                        LockoutEndDateUtc = x.aspnetUser.LockoutEndDateUtc,
                        LockoutEnabled = x.aspnetUser.LockoutEnabled,
                        AccessFailedCount = x.aspnetUser.AccessFailedCount,
                        Tenant_ID = x.aspnetUser.Tenant_ID,
                        TenantName = x.tenant.Name,
                        CreatedBy = x.aspnetUser.CreatedBy,
                        CreatedOn = x.aspnetUser.CreatedOn,
                        UpdatedBy = x.aspnetUser.UpdatedBy,
                        UpdatedOn = x.aspnetUser.UpdatedOn,
                        IsDeleted = x.aspnetUser.IsDeleted
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.AspNetUserIndexViewModel>
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


        public EntityModel.AspNetUser GetById(long Id)
        {
            try
            {
                EntityModel.AspNetUser entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.AspNetUserRepository.GetByID(Id);

                return entity;
            }
            catch
            {
                throw;
            }
        }


        public EntityModel.AspNetUser Update(EntityModel.AspNetUser entity)
        {
            try
            {
                return unitOfWork.AspNetUserRepository.Update(entity);
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
                unitOfWork.AspNetUserRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.AspNetUser> GetAll()
        {
            try
            {
                return unitOfWork.AspNetUserRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.AspNetUser> FindBy(Expression<Func<EntityModel.AspNetUser, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.AspNetUser> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.AspNetUserRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.AspNetUserRepository.Get();
                }

                return entities;
            }
            catch
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.AspNetUser, bool>> filter = null)
        {
            try
            {
                unitOfWork.AspNetUserRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public Int32 Count(Expression<Func<EntityModel.AspNetUser, bool>> filter = null)
        {
            try
            {
                return unitOfWork.AspNetUserRepository.Count(filter);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
