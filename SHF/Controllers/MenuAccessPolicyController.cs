using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System.Transactions;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using SHF.Helper;
using SHF.Web.Filters;
using SHF.Models;

namespace SHF.Controllers
{
    public class MenuAccessPolicyController : BaseController
    {

        #region [Field & Contructor]

        private Business.Interface.IAspNetRoleSubMenu businessAspNetRoleSubMenu;
        private Business.Interface.IAspNetRole businessAspNetRole;
        private Business.Interface.ISubMenu businessSubMenu;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;



        public MenuAccessPolicyController(Business.Interface.IAspNetRoleSubMenu IaspNetRoleSubMenu, Business.Interface.IAspNetRole IaspNetRole, Business.Interface.ISubMenu IsubMenu)
        {
            this.businessAspNetRoleSubMenu = IaspNetRoleSubMenu;
            this.businessAspNetRole = IaspNetRole;
            this.businessSubMenu = IsubMenu;
        }




        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }


        #endregion


        #region [Action Method]



        // GET: MenuAccessPolicy
        [HttpGet]
        [Access]
        [OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Configurations/Security/MenuAccessPolicy/Index")]
        [Route("Settings/Security/MenuAccessPolicy/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryTokens]
        [Route("Post/MenuAccessPolicy/IndexAsync")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult> IndexAsync()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            ViewModel.BusinessResultViewModel<ViewModel.AspNetRoleSubMenuIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;
                        long? aspNetRoleId = Request.Form.AllKeys.Contains("aspNetRoleId") ? Convert.ToInt64(Request.Form.GetValues("aspNetRoleId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        aspNetRoleId = aspNetRoleId > busConstant.Numbers.Integer.ZERO ? aspNetRoleId : null;

                        businessResult = this.businessAspNetRoleSubMenu.Index(Request, tenantId, aspNetRoleId);
                        transaction.Complete();
                    }
                    catch
                    {
                        transaction.Dispose();
                        throw;
                    }
                }

                var response = new { draw = businessResult.Draw, recordsFiltered = businessResult.RecordsFiltered, recordsTotal = businessResult.RecordsTotal, data = businessResult.Data };

                return Json(data: response);
            }
            catch (Exception ex)
            {
                //ExceptionResponse(ex);
                var response = new { draw = Request.Form.GetValues("draw").FirstOrDefault(), recordsFiltered = 0, recordsTotal = 0, data = string.Empty, error = ex.Message };

                return Json(data: response);
            }
            finally
            {
                businessResult = null;
            }


        }



        [HttpPost]
        [Audit]
        [ValidateAntiForgeryTokens]
        [Route("Post/MenuAccessPolicy/EditAsync")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult> EditAsync(ViewModel.AspNetRoleSubMenuCreateOrEditViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    using (var transaction = new TransactionScope())
                    {
                        try
                        {
                            long id = model.ID.GetValueOrDefault();
                            var entityAspNetRoleSubMenu = this.businessAspNetRoleSubMenu.FindBy(x => x.ID == id).FirstOrDefault();
                            var entityRole = this.businessAspNetRole.FindBy(role => role.ID == entityAspNetRoleSubMenu.AspNetRole_ID).FirstOrDefault();

                            entityAspNetRoleSubMenu.HasAccess = !model.HasAccess;
                            entityAspNetRoleSubMenu.Tenant_ID = entityRole.Tenant_ID;

                            this.businessAspNetRoleSubMenu.Update(entityAspNetRoleSubMenu);

                            transaction.Complete();

                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Icon=busConstant.Messages.Icon.SUCCESS,
                                Title=busConstant.Messages.Title.SUCCESS,
                                MessageCode=busConstant.Messages.MessageCode.SAVE,
                                Message = busConstant.Messages.Type.Responses.SAVE
                            };
                            return Json(response);
                        }
                        catch
                        {
                            transaction.Dispose();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                // unitOfWork.Dispose();
            }
        }


        [HttpPost]
        [Audit]
        [ValidateAntiForgeryTokens]
        [Route("Post/MenuAccessPolicy/UpdatePolicyAsync")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult> UpdatePolicy()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            try
            {
                using (var transaction = new TransactionScope())
                {
                    try
                    {

                        var menus = this.businessSubMenu.FindBy(menu => menu.UseOnlyFor == busConstant.Misc.TENANT);
                        var roles = this.businessAspNetRole.FindBy(role => role.Name != busConstant.Settings.AspNetRoles.DEVLOPMENT && role.Name != busConstant.Settings.AspNetRoles.SUPPORT);

                        menus.ForEach(menu =>
                        {

                            roles.ForEach(role =>
                            {

                                var existsMappings = this.businessAspNetRoleSubMenu.FindBy(map => map.AspNetRole_ID == role.ID && map.SubMenu_ID == menu.ID).FirstOrDefault();
                                if (existsMappings.IsNull() || (existsMappings.IsNotNull() && existsMappings.ID == busConstant.Numbers.Integer.ZERO))
                                {
                                    ViewModel.AspNetRoleSubMenuCreateOrEditViewModel aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                    {
                                        AspNetRole_ID = role.ID,
                                        SubMenu_ID = menu.ID,
                                        Tenant_ID = role.Tenant_ID
                                    };

                                    if (role.DisplayName == busConstant.Settings.AspNetRoles.ADMIN)
                                    {
                                        aspNetRoleSubMenuCreateOrEditViewModel.HasAccess = busConstant.Misc.TRUE;
                                    }
                                    else
                                    {
                                        aspNetRoleSubMenuCreateOrEditViewModel.HasAccess = busConstant.Misc.FALSE;
                                    }
                                    var entityAspNetRoleSubMenu = new EntityModel.AspNetRoleSubMenu();
                                    Mapper.Map(aspNetRoleSubMenuCreateOrEditViewModel, entityAspNetRoleSubMenu);

                                    this.businessAspNetRoleSubMenu.Add(entityAspNetRoleSubMenu);
                                }
                            });
                        });

                        this.businessAspNetRoleSubMenu.Save();

                        transaction.Complete();

                        var response = new JsonResponse<dynamic>()
                        {
                            Type = busConstant.Messages.Type.RESPONSE,
                            Message = busConstant.Messages.Type.Responses.SAVE
                        };
                        return Json(response);
                    }
                    catch
                    {
                        transaction.Dispose();
                        throw;
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {

            }
        }


        [HttpGet]
        [Route("Get/MenuAccessPolicy/GetMenuAccessPolicyAsync")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult> GetMenuAccessPolicy()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            var userId = User.Identity.GetUserId<long>();
            var roleMenus = Business.busCache.AspNetRoleSubMenuTable().ToList();
            var userRoles = Business.busCache.AspNetUserRoleTable().Where(user_role => user_role.AspNetUser_ID == userId).ToList();

            var result = roleMenus.Join(userRoles, rm => rm.AspNetRole_ID, ur => ur.AspNetRole_ID, (rm, ur) => new { rm, ur }).Select(x => x.rm);

            var response = new JsonResponse<dynamic>()
            {
                Type = busConstant.Messages.Type.RESPONSE,
                Entity = result
            };
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        #endregion


    }
}