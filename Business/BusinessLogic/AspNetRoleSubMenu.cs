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


namespace SHF.Business.BusinessLogic
{
    public class AspNetRoleSubMenu : BaseBusiness, IAspNetRoleSubMenu
    {
        public void Save()
        {
            try
            {
                unitOfWork.AspNetRoleSubMenuRepository.SaveChanges();
                busCache.LoadAspNetRoleSubMenu();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Add(EntityModel.AspNetRoleSubMenu entity)
        {
            try
            {
                unitOfWork.AspNetRoleSubMenuRepository.Add(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EntityModel.AspNetRoleSubMenu Create(EntityModel.AspNetRoleSubMenu entity)
        {
            try
            {
                unitOfWork.AspNetRoleSubMenuRepository.Insert(entity);
                busCache.LoadAspNetRoleSubMenu();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Delete(long Id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWhere(Expression<Func<EntityModel.AspNetRoleSubMenu, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntityModel.AspNetRoleSubMenu> FindBy(long userId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EntityModel.AspNetRoleSubMenu> FindBy(Expression<Func<EntityModel.AspNetRoleSubMenu, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.AspNetRoleSubMenu> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.AspNetRoleSubMenuRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.AspNetRoleSubMenuRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<EntityModel.AspNetRoleSubMenu> GetAll()
        {
            throw new NotImplementedException();
        }

        public EntityModel.AspNetRoleSubMenu GetById(long Id)
        {
            try
            {
                EntityModel.AspNetRoleSubMenu entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.AspNetRoleSubMenuRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleSubMenuIndexViewModel> Index(HttpRequestBase Request, long? tenantId, long? aspNetRoleId)
        {
            List<ViewModel.AspNetRoleSubMenuIndexViewModel> collection;

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
                totalRecords = unitOfWork.AspNetRoleRepository.Get().Join(unitOfWork.AspNetRoleSubMenuRepository.Get(), aspNetRole => aspNetRole.ID, aspNetRoleSubMenu => aspNetRoleSubMenu.AspNetRole_ID, (aspNetRole, aspNetRoleSubMenu) => new { aspNetRole, aspNetRoleSubMenu })
                    .Join(unitOfWork.SubMenuRepository.Get(), aspNetRole_aspNetRoleSubMenu => aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.SubMenu_ID, subMenu => subMenu.ID, (aspNetRole_aspNetRoleSubMenu, subMenu) => new { aspNetRole_aspNetRoleSubMenu, subMenu })
                    .Join(unitOfWork.TenantRepository.Get(), aspNetRole_aspNetRoleSubMenu_subMenu => aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.Tenant_ID, tenant => tenant.ID, (aspNetRole_aspNetRoleSubMenu_subMenu, tenant) => new { aspNetRole_aspNetRoleSubMenu_subMenu, tenant })
                      .Count(x => (tenantId == null || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.Tenant_ID == tenantId)
                             && (aspNetRoleId == null || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.ID == aspNetRoleId)
                            && (x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Url.IsNotNullOrEmpty())
                            && (x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.ID.ToString().Contains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.DisplayName.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Name.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Url.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.IconClass.CaseInsensitiveContains(searchValue)
                             || x.tenant.Name.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue))
                          );

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.AspNetRoleRepository.Get().Join(unitOfWork.AspNetRoleSubMenuRepository.Get(), aspNetRole => aspNetRole.ID, aspNetRoleSubMenu => aspNetRoleSubMenu.AspNetRole_ID, (aspNetRole, aspNetRoleSubMenu) => new { aspNetRole, aspNetRoleSubMenu })
                    .Join(unitOfWork.SubMenuRepository.Get(), aspNetRole_aspNetRoleSubMenu => aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.SubMenu_ID, subMenu => subMenu.ID, (aspNetRole_aspNetRoleSubMenu, subMenu) => new { aspNetRole_aspNetRoleSubMenu, subMenu })
                    .Join(unitOfWork.TenantRepository.Get(), aspNetRole_aspNetRoleSubMenu_subMenu => aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.Tenant_ID, tenant => tenant.ID, (aspNetRole_aspNetRoleSubMenu_subMenu, tenant) => new { aspNetRole_aspNetRoleSubMenu_subMenu, tenant })
                    .Where(x => (tenantId == null || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.Tenant_ID == tenantId)
                             && (aspNetRoleId == null || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.ID == aspNetRoleId)
                            && (x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Url.IsNotNullOrEmpty())
                            && (x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.ID.ToString().Contains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.DisplayName.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Name.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Url.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.IconClass.CaseInsensitiveContains(searchValue)
                             || x.tenant.Name.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedBy.CaseInsensitiveContains(searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                             || x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.AspNetRoleSubMenuIndexViewModel
                    {
                        ID = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.ID,
                        AspNetRole_ID = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.ID,
                        AspNetRoleDisplayName = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRole.DisplayName,
                        SubMenu_ID = x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.ID,
                        SubMenuName = x.aspNetRole_aspNetRoleSubMenu_subMenu.subMenu.Name,
                        HasAccess = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.HasAccess,
                        Tenant_ID = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.Tenant_ID,
                        TenantName = x.tenant.Name,
                        CreatedBy = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedBy,
                        CreatedOn = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.CreatedOn,
                        UpdatedBy = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedBy,
                        UpdatedOn = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdatedOn,
                        IsDeleted = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.IsDeleted,
                        IsActive = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.IsActive,
                        UpdateSeq = x.aspNetRole_aspNetRoleSubMenu_subMenu.aspNetRole_aspNetRoleSubMenu.aspNetRoleSubMenu.UpdateSeq
                    }).ToList();



                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleSubMenuIndexViewModel>
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

        public EntityModel.AspNetRoleSubMenu Update(EntityModel.AspNetRoleSubMenu entity)
        {
            try
            {
                unitOfWork.AspNetRoleSubMenuRepository.Update(entity);
                busCache.LoadAspNetRoleSubMenu();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Int32 Count(Expression<Func<EntityModel.AspNetRoleSubMenu, bool>> filter = null)
        {
            try
            {
                return unitOfWork.AspNetRoleSubMenuRepository.Count(filter);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
