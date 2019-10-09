using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SHF.Helper;
//using Omu.AwesomeMvc;
using SHF.Web.Filters;
using System.Transactions;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using System.Net;
using SHF.Models;
using SHF.ViewModel;

namespace SHF.Controllers
{
    public class RolesController : BaseController
    {

        #region [Field & Contructor]

        private Business.Interface.IAspNetRole businessAspNetRole;
        private Business.Interface.ISubMenu businessSubMenu;
        private Business.Interface.IAspNetRoleSubMenu businessAspNetRoleSubMenu;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public RolesController(Business.Interface.IAspNetRole IaspNetRole, Business.Interface.ISubMenu IsubMenu, Business.Interface.IAspNetRoleSubMenu IaspNetRoleSubMenu)
        {
            this.businessAspNetRole = IaspNetRole;
            this.businessSubMenu = IsubMenu;
            this.businessAspNetRoleSubMenu = IaspNetRoleSubMenu;
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


        [HttpGet]
        [Access]
        [OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Configurations/Security/Roles/Index")]
        [Route("Settings/Security/Roles/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }


        [HttpPost]
        [Route("Post/Roles/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.AspNetRoleIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessAspNetRole.Index(Request, tenantId);
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
        [Route("Post/Roles/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.AspNetRoleCreateOrEditViewModel model)
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
                            var entity = new EntityModel.AspNetRole();
                            model.Name = Guid.NewGuid().ToString();
                            Mapper.Map(model, entity);

                            if (this.businessAspNetRole.Count(x => x.DisplayName == entity.DisplayName && x.Tenant_ID == entity.Tenant_ID) > busConstant.Numbers.Integer.ZERO)
                            {
                                transaction.Complete();

                                var res = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.VALIDATION,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST,
                                    MessageCode = busConstant.Messages.MessageCode.ROLE_ALREADY_EXIST
                                };

                                return Json(res);
                            }

                            this.businessAspNetRole.Create(entity);

                            var subMenus = this.businessSubMenu.GetAll().Where(x => x.Url.IsNotNullOrEmpty());
                            subMenus.ForEach(subMenu =>
                            {
                                var aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                {
                                    AspNetRole_ID = entity.ID,
                                    SubMenu_ID = subMenu.ID,
                                    HasAccess = busConstant.Misc.FALSE,
                                    IsActive = busConstant.Misc.TRUE,
                                    IsDeleted = busConstant.Misc.FALSE,
                                    Tenant_ID = entity.Tenant_ID
                                };
                                var entityAspNetRoleSubMenu = new EntityModel.AspNetRoleSubMenu();
                                Mapper.Map(aspNetRoleSubMenuCreateOrEditViewModel, entityAspNetRoleSubMenu);
                                this.businessAspNetRoleSubMenu.Create(entityAspNetRoleSubMenu);
                            });

                            transaction.Complete();

                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Icon = busConstant.Messages.Icon.SUCCESS,
                                Title = busConstant.Messages.Title.SUCCESS,
                                Message = busConstant.Messages.Type.Responses.SAVE,
                                MessageCode = busConstant.Messages.MessageCode.SAVE
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


        [HttpGet]
        [Route("Get/Roles/EditAsync")]
        public async Task<ActionResult> EditAsync(long Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == default(long))
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Icon = busConstant.Messages.Icon.ERROR,
                                Title = busConstant.Messages.Title.ERROR,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessAspNetRole.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.AspNetRoleCreateOrEditViewModel();

                                Mapper.Map(entity, model);

                                var response = new JsonResponse<AspNetRoleCreateOrEditViewModel>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Entity = model
                                };
                                transaction.Complete();

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Title = busConstant.Messages.Title.ERROR
                                };
                                transaction.Complete();

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
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
                //unitOfWork.Dispose();
            }
        }


        [HttpPost]
        [Audit]
        [ValidateAntiForgeryTokens]
        [Route("Post/Roles/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.AspNetRoleCreateOrEditViewModel model)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("UpdatedOn");
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
                            var entity = new EntityModel.AspNetRole();

                            Mapper.Map(model, entity);

                            if (this.businessAspNetRole.Count(x => x.DisplayName == entity.DisplayName && x.Tenant_ID == entity.Tenant_ID && x.ID != entity.ID) > busConstant.Numbers.Integer.ZERO)
                            {
                                transaction.Complete();

                                var res = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.VALIDATION,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Title = busConstant.Messages.Title.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.ROLE_ALREADY_EXIST
                                };
                                return Json(res);
                            }
                            this.businessAspNetRole.Update(entity);

                            transaction.Complete();

                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Message = busConstant.Messages.Type.Responses.SAVE,
                                Icon = busConstant.Messages.Icon.SUCCESS,
                                Title = busConstant.Messages.Title.SUCCESS,
                                MessageCode = busConstant.Messages.MessageCode.SAVE
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


        [HttpGet]
        [Route("Get/Roles/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetRolesByTenantIdAsync(long Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == default(long))
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                                Icon = busConstant.Messages.Icon.ERROR,
                                Title = busConstant.Messages.Title.ERROR
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entities = this.businessAspNetRole.FindBy(role => role.Tenant_ID == Id).Select(x => new ViewModel.AspNetRoleDropDownListViewModel
                            {
                                ID = x.ID,
                                Name = x.DisplayName
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.AspNetRoleDropDownListViewModel>>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Entity = entities
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND
                                };
                                transaction.Complete();

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    catch (Exception ex)
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
        }


        [HttpGet]
        [Route("Get/Roles/AssignedRolesOfUserAsync")]
        public async Task<ActionResult> GetRolesByUserIdAsync(long Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == default(long))
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                                Icon = busConstant.Messages.Icon.ERROR,
                                Title = busConstant.Messages.Title.ERROR
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entities = this.businessAspNetRole.GetRolesByUserId(Id);

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.AspNetRoleDropDownListViewModel>>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Entity = entities
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    catch (Exception ex)
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
        }


        [HttpGet]
        [Route("Get/Roles/NameDropdownListbyTenantId")]
        public async Task<ActionResult> GetNameAsync(long Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == default(long))
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                                Icon = busConstant.Messages.Icon.ERROR,
                                Title = busConstant.Messages.Title.ERROR
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entities = this.businessAspNetRole.FindBy(role => role.Tenant_ID == Id).Select(x => new ViewModel.AspNetRoleDropDownListViewModel
                            {
                                ID = x.ID,
                                Name = x.Name
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.AspNetRoleDropDownListViewModel>>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Entity = entities
                                };

                                transaction.Complete();
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND,
                                    Errors = null,
                                    Entity = null
                                };
                                transaction.Complete();

                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                        }
                    }
                    catch (Exception ex)
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
        }


        [HttpGet]
        public JsonResult isExistsRole(string value)
        {
            var userId = User.Identity.GetUserId<long>();
            var TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            var RoleExists = businessAspNetRole.FindBy(role => role.DisplayName == value && role.Tenant_ID == TenantID).FirstOrDefault();
          
            if (RoleExists.IsNotNull())
            {
                var responseData = new { isValid = busConstant.Misc.FALSE, value = value };
                return Json(responseData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var responseData = new { isValid = busConstant.Misc.TRUE, value = value };
                return Json(responseData, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion


    }
}