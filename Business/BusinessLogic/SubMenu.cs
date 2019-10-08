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
    public class SubMenu : BaseBusiness, ISubMenu
    {
        public Int32 Count(Expression<Func<EntityModel.SubMenu, bool>> filter = null)
        {
            try
            {
                return unitOfWork.SubMenuRepository.Count(filter);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public EntityModel.SubMenu Create(EntityModel.SubMenu entity)
        {
            try
            {
                unitOfWork.SubMenuRepository.Insert(entity);
                busCache.LoadSubMenu();
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
                unitOfWork.SubMenuRepository.Delete(Id);
                busCache.LoadSubMenu();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteWhere(Expression<Func<EntityModel.SubMenu, bool>> filter = null)
        {
            try
            {
                unitOfWork.SubMenuRepository.DeleteWhere(filter);
                busCache.LoadSubMenu();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<EntityModel.SubMenu> FindBy(Expression<Func<EntityModel.SubMenu, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.SubMenu> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.SubMenuRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.SubMenuRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<EntityModel.SubMenu> FindBy(long userId)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<EntityModel.SubMenu> GetAll()
        {
            try
            {
                return unitOfWork.SubMenuRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public EntityModel.SubMenu GetById(long Id)
        {
            try
            {
                EntityModel.SubMenu entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.SubMenuRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public ViewModel.BusinessResultViewModel<ViewModel.SubMenuIndexViewModel> Index(HttpRequestBase Request, long Customer_ID = 0)
        {
            List<ViewModel.SubMenuIndexViewModel> collection;
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
                totalRecords = unitOfWork.SubMenuRepository.Get().Count(x => x.ID.ToString().CaseInsensitiveContains(searchValue)
                        || x.Name.CaseInsensitiveContains(searchValue)
                        || x.Url.CaseInsensitiveContains(searchValue)
                        || x.IconClass.CaseInsensitiveContains(searchValue)
                        || x.OrderBy.ToString().CaseInsensitiveContains(searchValue)
                        || x.ParrentMenu_ID.ToString().CaseInsensitiveContains(searchValue)
                        || x.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CreatedOn.ToString().CaseInsensitiveContains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.UpdatedOn.ToString().CaseInsensitiveContains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.SubMenuRepository.Get().Where(x => x.ID.ToString().CaseInsensitiveContains(searchValue)
                         || x.Name.CaseInsensitiveContains(searchValue)
                         || x.Url.CaseInsensitiveContains(searchValue)
                         || x.IconClass.CaseInsensitiveContains(searchValue)
                         || x.OrderBy.ToString().CaseInsensitiveContains(searchValue)
                         || x.ParrentMenu_ID.ToString().CaseInsensitiveContains(searchValue)
                         || x.CreatedBy.CaseInsensitiveContains(searchValue)
                         || x.UpdatedBy.CaseInsensitiveContains(searchValue)
                         || x.CreatedOn.ToString().CaseInsensitiveContains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                         || x.UpdatedOn.ToString().CaseInsensitiveContains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue))
                    .OrderBy(sortColumn + " " + sortColumnDir).Skip(skip).Take(pageSize).ToList().Select(x => new ViewModel.SubMenuIndexViewModel
                    {
                        ID = x.ID,
                        Name = x.Name,
                        Url = x.Url,
                        IconClass = x.IconClass,
                        OrderBy = x.OrderBy,
                        ParrentMenu_ID = x.ParrentMenu_ID,
                        CreatedBy = x.CreatedBy,
                        CreatedOn = x.CreatedOn,
                        UpdatedBy = x.UpdatedBy,
                        UpdatedOn = x.UpdatedOn,
                        IsDeleted = x.IsDeleted
                    }).ToList();

                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.SubMenuIndexViewModel>
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

        public EntityModel.SubMenu Update(EntityModel.SubMenu entity)
        {
            try
            {
                unitOfWork.SubMenuRepository.Update(entity);
                busCache.LoadSubMenu();
                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<ViewModel.SubMenuIndexViewModel> GetDropdownList()
        {
            try
            {
                var subMenuIndexViewModel = unitOfWork.SubMenuRepository.Get().Select(x => new ViewModel.SubMenuIndexViewModel
                {
                    ID = x.ID,
                    Name = x.Name,
                    Url = x.Url,
                    IconClass = x.IconClass,
                    OrderBy = x.OrderBy,
                    ParrentMenu_ID = x.ParrentMenu_ID,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    UpdatedBy = x.UpdatedBy,
                    UpdatedOn = x.UpdatedOn,
                    IsDeleted = x.IsDeleted
                });

                return subMenuIndexViewModel;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }


    public class BusinessSubMenu
    {
        public static IEnumerable<EntityModel.SubMenu> GetChildMenuAsync(long userId, long parrentMenuId)
        {
            var param = new DynamicParameters();
            param.Add("@UserId", userId);
            param.Add("@ParrentMenu_ID", parrentMenuId);
            var x = DataAccess.GetCollection.ByStoredProcedure("[dbo].[usp_GetChildMenu]", param);
            return x;

        }

        public static IEnumerable<EntityModel.SubMenu> GetNavigationMenuAsync(long userId)
        {
            try
            {
                if (userId != default(long))
                {
                    var userRoleTable = busCache.AspNetUserRoleTable();
                    var roleSubmenuTable = busCache.AspNetRoleSubMenuTable();
                    var childMenuTable = busCache.SubMenuTable();
                    var parrentMenuTable = busCache.SubMenuTable();

                    if (userRoleTable.IsNotNull() && userRoleTable.Count() > busConstant.Numbers.Integer.ZERO && roleSubmenuTable.IsNotNull() && roleSubmenuTable.Count() > busConstant.Numbers.Integer.ZERO && childMenuTable.IsNotNull() && childMenuTable.Count() > busConstant.Numbers.Integer.ZERO && parrentMenuTable.IsNotNull() && parrentMenuTable.Count() > busConstant.Numbers.Integer.ZERO)
                    {
                        var joinResult = parrentMenuTable.Join(childMenuTable, parrentMenu => parrentMenu.ID, childMenu => childMenu.ParrentMenu_ID, (parrentMenu, childMenu) => new { parrentMenu, childMenu })
                                   .Join(roleSubmenuTable, parrentMenu_childMenu => parrentMenu_childMenu.childMenu.ID, roleSubmenu => roleSubmenu.SubMenu_ID, (parrentMenu_childMenu, roleSubmenu) => new { parrentMenu_childMenu, roleSubmenu })
                                   .Join(userRoleTable, parrentMenu_childMenu_roleSubmenu => parrentMenu_childMenu_roleSubmenu.roleSubmenu.AspNetRole_ID, userRole => userRole.AspNetRole_ID, (parrentMenu_childMenu_roleSubmenu, userRole) => new { parrentMenu_childMenu_roleSubmenu, userRole })
                                   .Where(where => where.userRole.AspNetUser_ID == userId && where.parrentMenu_childMenu_roleSubmenu.roleSubmenu.HasAccess == busConstant.Misc.TRUE && where.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.ParrentMenu_ID == null)
                                   .Select(select => new EntityModel.SubMenu
                                   {
                                       ID = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.ID,
                                       UseOnlyFor = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.UseOnlyFor,
                                       Url = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.Url,
                                       UpdateSeq = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.UpdateSeq,
                                       UpdatedOn = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.UpdatedOn,
                                       UpdatedBy = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.UpdatedBy,
                                       ParrentMenu_ID = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.ParrentMenu_ID,
                                       OrderBy = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.OrderBy,
                                       Name = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.Name,
                                       IsDeleted = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.IsDeleted,
                                       IsActive = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.IsActive,
                                       IconClass = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.IconClass,
                                       CreatedOn = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.CreatedOn,
                                       CreatedBy = select.parrentMenu_childMenu_roleSubmenu.parrentMenu_childMenu.parrentMenu.CreatedBy
                                   }).DistinctBy(distinct => distinct.ID);

                        return joinResult;

                    }
                    else
                    {
                        var param = new DynamicParameters();
                        param.Add("@UserId", userId);
                        var x = DataAccess.GetCollection.ByStoredProcedure("[dbo].[usp_GetNavigationMenu]", param);
                        return x;
                    }
                }
                else
                {
                    return new List<EntityModel.SubMenu>();
                }


            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static bool HasAccess(string route, long userId)
        {
            try
            {
                if (userId != default(long))
                {

                    var userRoleTable = busCache.AspNetUserRoleTable();
                    var roleSubmenuTable = busCache.AspNetRoleSubMenuTable();
                    var subMenuTable = busCache.SubMenuTable();

                    if (userRoleTable.IsNotNull() && userRoleTable.Count() > busConstant.Numbers.Integer.ZERO && roleSubmenuTable.IsNotNull() && roleSubmenuTable.Count() > busConstant.Numbers.Integer.ZERO && subMenuTable.IsNotNull() && subMenuTable.Count() > busConstant.Numbers.Integer.ZERO)
                    {
                        var joinResult = userRoleTable.Join(roleSubmenuTable, userRole => userRole.AspNetRole_ID, roleSubMenu => roleSubMenu.AspNetRole_ID, (userRole, roleSubMenu) => new { userRole, roleSubMenu })
                                    .Join(subMenuTable, userRole_roleSubMenu => userRole_roleSubMenu.roleSubMenu.SubMenu_ID, subMenu => subMenu.ID, (userRole_roleSubMenu, subMenu) => new { userRole_roleSubMenu, subMenu })
                                    .Count(cnt => cnt.userRole_roleSubMenu.userRole.AspNetUser_ID == userId && cnt.subMenu.Url == route && cnt.userRole_roleSubMenu.roleSubMenu.HasAccess == busConstant.Misc.TRUE);

                        return joinResult > busConstant.Numbers.Integer.ZERO ? busConstant.Misc.TRUE : busConstant.Misc.FALSE;
                    }
                    else
                    {
                        var param = new DynamicParameters();
                        param.Add("@UserId", userId);
                        param.Add("@Url", route);
                        param.Add("@HasAccess", busConstant.Misc.TRUE);
                        var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_HasAccess]", param);
                        return (bool)x;
                    }

                }
                else
                {
                    return busConstant.Misc.FALSE;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static IEnumerable<SHF.ViewModel.ActiveMenuViewModel> GetActiveMenuAsync(string url)
        {
            var param = new DynamicParameters();
            param.Add("@url", url);
            var x = DataAccess.GetCollection.ByStoredProcedureActiveMenu("[dbo].[usp_GetUpLineMenu]", param);
            return x;
        }
    }




}
