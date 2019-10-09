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
    public class SubMenuController : BaseController
    {
        #region [Field & Contructor]       

        private Business.Interface.ISubMenu businessSubMenu;
        private Business.Interface.IAspNetRole businessAspNetRole;
        private Business.Interface.IAspNetRoleSubMenu businessAspNetRoleSubMenu;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;



        public SubMenuController(Business.Interface.ISubMenu IsubMenu, Business.Interface.IAspNetRole IaspNetRole, Business.Interface.IAspNetRoleSubMenu IaspNetRoleSubMenu)
        {
            this.businessSubMenu = IsubMenu;
            this.businessAspNetRole = IaspNetRole;
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
        [Route("Configurations/Master/Navigation/Index")]
        public ActionResult Index()
        {
            if (!HasAccess())
            {
                return View("AccessDenined");
            }
            return View();
        }


        [HttpPost]
        [Route("Post/Navigation/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            ViewModel.BusinessResultViewModel<ViewModel.SubMenuIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        businessResult = this.businessSubMenu.Index(Request);
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
        [Route("Post/Navigation/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.SubMenuCreateOrEditViewModel model)
        {
            var response = new JsonResponse<dynamic>();
            try
            {
                long subMenuId;
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
                            var entitySubMenu = new EntityModel.SubMenu();
                            Mapper.Map(model, entitySubMenu);
                            entitySubMenu.ParrentMenu = null;
                            this.businessSubMenu.Create(entitySubMenu);
                            subMenuId = entitySubMenu.ID;

                            if (entitySubMenu.Url.IsNotNullOrEmpty())
                            {
                                var aspntRoles = this.businessAspNetRole.GetAll();

                                aspntRoles.ForEach(aspNetRole =>
                                {
                                    ViewModel.AspNetRoleSubMenuCreateOrEditViewModel aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel();
                                    EntityModel.AspNetRoleSubMenu entityAspNetRoleSubMenu = new EntityModel.AspNetRoleSubMenu();

                                    if (entitySubMenu.UseOnlyFor == busConstant.Settings.NavigationFor.TENANT)
                                    {
                                        if (aspNetRole.Name.NoneOfThis(busConstant.Settings.AspNetRoles.DEVLOPMENT, busConstant.Settings.AspNetRoles.SUPPORT))
                                        {
                                            if (aspNetRole.DisplayName == busConstant.Settings.AspNetRoles.ADMIN)
                                            {
                                                aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                                {
                                                    AspNetRole_ID = aspNetRole.ID,
                                                    SubMenu_ID = subMenuId,
                                                    HasAccess = busConstant.Misc.TRUE,
                                                    Tenant_ID = aspNetRole.Tenant_ID
                                                };

                                            }
                                            else
                                            {
                                                aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                                {
                                                    AspNetRole_ID = aspNetRole.ID,
                                                    SubMenu_ID = subMenuId,
                                                    HasAccess = busConstant.Misc.FALSE,
                                                    Tenant_ID = aspNetRole.Tenant_ID
                                                };

                                            }
                                        }
                                    }
                                    if (entitySubMenu.UseOnlyFor == busConstant.Settings.NavigationFor.DEVLOPMENT)
                                    {
                                        aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                        {
                                            AspNetRole_ID = aspNetRole.ID,
                                            SubMenu_ID = subMenuId,
                                            HasAccess = busConstant.Misc.TRUE,
                                            Tenant_ID = aspNetRole.Tenant_ID
                                        };
                                    }

                                    if (aspNetRoleSubMenuCreateOrEditViewModel.IsNotNull())
                                    {
                                        Mapper.Map(aspNetRoleSubMenuCreateOrEditViewModel, entityAspNetRoleSubMenu);
                                        this.businessAspNetRoleSubMenu.Create(entityAspNetRoleSubMenu);
                                    }

                                });
                            }

                            transaction.Complete();

                            response.Type = busConstant.Messages.Type.RESPONSE;
                            response.Message = busConstant.Messages.Type.Responses.SAVE;

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
                response = null;
            }
        }


        [HttpGet]
        [Route("Get/Navigation/EditAsync")]
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
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

                            transaction.Complete();

                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessSubMenu.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.SubMenuCreateOrEditViewModel();

                                Mapper.Map(entity, model);

                                var response = new JsonResponse<ViewModel.SubMenuCreateOrEditViewModel>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
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
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND
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
        [Route("Post/Navigation/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.SubMenuCreateOrEditViewModel model)
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
                            var entity = new EntityModel.SubMenu();

                            Mapper.Map(model, entity);
                            entity.ParrentMenu = null;

                            this.businessSubMenu.Update(entity);

                            if (entity.UseOnlyFor == busConstant.Settings.NavigationFor.DEVLOPMENT)
                            {
                                var aspNetRole = this.businessAspNetRole.FindBy(role => role.DisplayName == busConstant.Settings.AspNetRoles.DEVLOPMENT).FirstOrDefault();

                                var aspNetRoleSubMenus = this.businessAspNetRoleSubMenu.FindBy(x => x.SubMenu_ID == entity.ID && x.AspNetRole_ID != aspNetRole.ID);

                                aspNetRoleSubMenus.ForEach(x =>
                                {
                                    this.businessAspNetRoleSubMenu.Delete(x.ID);
                                });



                            }

                            if (entity.UseOnlyFor == busConstant.Settings.NavigationFor.TENANT)
                            {
                                var aspNetRoles = this.businessAspNetRole.FindBy(role => role.DisplayName.AnyOfThis(busConstant.Settings.AspNetRoles.DEVLOPMENT, busConstant.Settings.AspNetRoles.SUPPORT));

                                var aspNetRoleSubMenus = this.businessAspNetRoleSubMenu.FindBy(x => x.SubMenu_ID == entity.ID);



                                aspNetRoleSubMenus.ForEach(x =>
                                {
                                    aspNetRoles.ForEach(r =>
                                    {
                                        this.businessAspNetRoleSubMenu.DeleteWhere(nav => nav.SubMenu_ID == x.ID && nav.AspNetRole_ID == r.ID);
                                    });


                                });
                            }


                            transaction.Complete();

                            var response = new JsonResponse<ViewModel.SubMenuCreateOrEditViewModel>()
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
        [Route("Get/Navigation/ParrentDropdownListAsync")]
        public async Task<ActionResult> ParrentDropdownListAsync()
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        var entities = this.businessSubMenu.GetDropdownList().Where(subMenu => subMenu.Url.IsNullOrEmpty()).Select(x => new ViewModel.SubMenuDropdownListViewModel
                        {
                            ID = x.ID,
                            Name = x.Name
                        });


                        if (entities.IsNotNull())
                        {
                            var response = new JsonResponse<IEnumerable<ViewModel.SubMenuDropdownListViewModel>>()
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
                                Message = busConstant.Messages.Type.Exceptions.NOT_FOUND
                            };

                            transaction.Complete();
                            return Json(response, JsonRequestBehavior.AllowGet);
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
        [AllowAnonymous]
        [Route("Get/Navigation/GetAllMenuAsync")]
        public async Task<ActionResult> GetAllMenu()
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        var subMenus = Business.busCache.SubMenuTable();
                        transaction.Complete();
                        var response = new JsonResponse<IEnumerable<EntityModel.SubMenu>>()
                        {
                            Type = busConstant.Messages.Type.RESPONSE,
                            Entity = subMenus
                        };
                        return Json(response, JsonRequestBehavior.AllowGet);
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
                throw ex;
            }
        }

        #endregion
    }
}