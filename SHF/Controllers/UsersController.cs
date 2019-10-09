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
    public class UsersController : BaseController
    {

        #region [Field & Contructor]        

        private Business.Interface.IAspNetUser businessAspNetUser;
        private Business.Interface.IAspNetUserRole businessAspNetUserRole;
        private Business.Interface.IAspNetRole businessAspNetRole;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public UsersController(Business.Interface.IAspNetUser IaspNetUser, Business.Interface.IAspNetUserRole IaspNetUserRole, Business.Interface.IAspNetRole IaspNetRole)
        {
            this.businessAspNetUser = IaspNetUser;
            this.businessAspNetUserRole = IaspNetUserRole;
            this.businessAspNetRole = IaspNetRole;
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
        [Route("Configurations/Security/Users/Index")]
        [Route("Settings/Security/Users/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View("Index");
        }


        [HttpPost]
        [Route("Post/Users/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.AspNetUserIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessAspNetUser.Index(Request, tenantId);
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
        [Route("Post/Users/CreateAsync")]
        public async Task<ActionResult> CreateAsync(RegisterOrEditViewModel model)
        {
            var response = new JsonResponse<dynamic>();
            long userId = 0;
            try
            {

                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    var entityApplicationUser = new ApplicationUser
                    {
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        UserName = model.Username,
                        Email = model.Email,
                        PhoneNumber = model.PhoneNumber,
                        Tenant_ID = model.Tenant_ID,
                        CreatedBy = _activityBy,
                        CreatedOn = _activityDateTime,
                        UpdatedBy = _activityBy,
                        UpdatedOn = _activityDateTime,
                        IsActive = busConstant.Misc.TRUE,
                        IsDeleted = busConstant.Misc.FALSE,
                        UpdateSeq = busConstant.Numbers.Integer.ZERO
                    };

                    var result = await UserManager.CreateAsync(entityApplicationUser, model.Password);
                    if (result.Succeeded)
                    {
                        userId = entityApplicationUser.Id;
                        // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link
                        string code = await UserManager.GenerateEmailConfirmationTokenAsync(userId);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userId, code = code }, protocol: Request.Url.Scheme);
                        //UserManager.SendEmail(entityAspNetUser.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        using (var transaction = new TransactionScope())
                        {
                            try
                            {
                                if (model.AssignedRoles.IsNotNull() && model.AssignedRoles.Count() > busConstant.Numbers.Integer.ZERO)
                                {
                                    model.AssignedRoles.ForEach(role =>
                                    {
                                        if (role != default(long))
                                        {
                                            var aspNetUserRoleCreateViewModel = new ViewModel.AspNetUserRoleCreateOrEditViewModel
                                            {
                                                Tenant_ID = model.Tenant_ID,
                                                AspNetRole_ID = role,
                                                AspNetUser_ID = entityApplicationUser.Id
                                            };

                                            var entityAspNetUserRole = new EntityModel.AspNetUserRole();
                                            Mapper.Map(aspNetUserRoleCreateViewModel, entityAspNetUserRole);
                                            this.businessAspNetUserRole.Create(entityAspNetUserRole);
                                        }
                                    });
                                }

                                transaction.Complete();
                                response.Type = busConstant.Messages.Type.RESPONSE;
                                response.Title = busConstant.Messages.Title.SUCCESS;
                                response.Icon = busConstant.Messages.Icon.SUCCESS;
                                response.MessageCode = busConstant.Messages.MessageCode.SAVE;
                                response.Message = busConstant.Messages.Type.Responses.SAVE;

                                return Json(response);
                            }
                            catch (Exception ex)
                            {
                                transaction.Dispose();
                                throw;
                            }
                        }
                    }
                    else
                    {
                        response.Type = busConstant.Messages.Type.VALIDATION;
                        response.Title = busConstant.Messages.Title.ERROR;
                        response.Icon = busConstant.Messages.Icon.ERROR;
                        response.Message = busConstant.Messages.Type.Exceptions.SOMETHING_WENT_WRONG;
                        response.ValidationSummary = result.Errors;
                        return Json(response);
                    }
                }
            }
            catch (Exception ex)
            {
                if (userId != default(long))
                {
                    this.businessAspNetUser.Delete(userId);
                }
                return ExceptionResponse(ex);
            }
            finally
            {
                response = null;
            }
        }


        [HttpGet]
        [Route("Get/Users/EditAsync")]
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
                                Title = busConstant.Messages.Title.ERROR,
                                Icon = busConstant.Messages.Icon.ERROR,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST
                            };

                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessAspNetUser.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                //var model2 = new ViewModel.AspNetUserCreateOrEditViewModel();
                                var dynamics = new List<dynamic>();

                                var model = new ViewModel.RegisterOrEditViewModel
                                {
                                    ID = entity.ID,
                                    PasswordHash = entity.PasswordHash,
                                    AccessFailedCount = entity.AccessFailedCount,
                                    Email = entity.Email,
                                    EmailConfirmed = entity.EmailConfirmed,
                                    Tenant_ID = entity.Tenant_ID.GetValueOrDefault(),
                                    PhoneNumber = entity.PhoneNumber,
                                    PhoneNumberConfirmed = entity.PhoneNumberConfirmed,
                                    FirstName = entity.FirstName,
                                    LastName = entity.LastName,
                                    LockoutEnabled = entity.LockoutEnabled,
                                    LockoutEndDateUtc = entity.LockoutEndDateUtc,
                                    SecurityStamp = entity.SecurityStamp,
                                    TwoFactorEnabled = entity.TwoFactorEnabled,
                                    Username = entity.UserName
                                };

                                //Mapper.Map(entity, model);
                                dynamics.Add(model);

                                var roles = this.businessAspNetRole.GetRolesByUserId(Id);

                                dynamics.Add(roles);

                                transaction.Complete();
                                var response = new JsonResponse<IEnumerable<dynamic>>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    Entity = dynamics
                                };


                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND
                                };
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
        [Route("Post/Users/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.AspNetUserCreateOrEditViewModel model)
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
                            var entity = new EntityModel.AspNetUser();

                            Mapper.Map(model, entity);

                            this.businessAspNetUser.Update(entity);



                            if (model.AssignedRoles.IsNotNull() && model.AssignedRoles.Count() > busConstant.Numbers.Integer.ZERO)
                            {
                                var aspNetUserRoles = this.businessAspNetUserRole.FindBy(x => x.AspNetUser_ID == entity.ID);

                                var isExists = busConstant.Misc.FALSE;
                                Stack<long> stkFilteredRoles = new Stack<long>();

                                foreach (var aspNetUserRole in aspNetUserRoles)
                                {
                                    isExists = busConstant.Misc.FALSE;

                                    foreach (var assignedRole in model.AssignedRoles)
                                    {
                                        if (assignedRole == aspNetUserRole.AspNetRole_ID)
                                        {
                                            isExists = busConstant.Misc.TRUE;
                                            break;
                                        }
                                    }
                                    if (!isExists)
                                    {
                                        stkFilteredRoles.Push(aspNetUserRole.AspNetRole_ID);
                                    }
                                }

                                while (stkFilteredRoles.Count() > busConstant.Numbers.Integer.ZERO)
                                {
                                    long roleId = stkFilteredRoles.Pop();
                                    this.businessAspNetUserRole.DeleteWhere(x => x.AspNetRole_ID == roleId);
                                }


                                aspNetUserRoles = this.businessAspNetUserRole.FindBy(x => x.AspNetUser_ID == entity.ID);


                                foreach (var assignedRole in model.AssignedRoles)
                                {
                                    isExists = busConstant.Misc.FALSE;

                                    foreach (var aspNetUserRole in aspNetUserRoles)
                                    {
                                        if (assignedRole == aspNetUserRole.AspNetRole_ID)
                                        {
                                            isExists = busConstant.Misc.TRUE;
                                            break;
                                        }
                                    }
                                    if (!isExists)
                                    {
                                        stkFilteredRoles.Push(assignedRole);
                                    }
                                }

                                while (stkFilteredRoles.Count() > busConstant.Numbers.Integer.ZERO)
                                {
                                    var aspNetUserRoleCreateViewModel = new ViewModel.AspNetUserRoleCreateOrEditViewModel
                                    {
                                        Tenant_ID = model.Tenant_ID,
                                        AspNetRole_ID = stkFilteredRoles.Pop(),
                                        AspNetUser_ID = entity.ID
                                    };

                                    var entityAspNetUserRole = new EntityModel.AspNetUserRole();
                                    Mapper.Map(aspNetUserRoleCreateViewModel, entityAspNetUserRole);
                                    this.businessAspNetUserRole.Create(entityAspNetUserRole);
                                }
                            }
                            else
                            {
                                var aspNetUserRoles = this.businessAspNetUserRole.FindBy(x => x.AspNetUser_ID == entity.ID);
                                if (aspNetUserRoles.IsNotNull() && aspNetUserRoles.Count() > busConstant.Numbers.Integer.ZERO)
                                {
                                    aspNetUserRoles.ForEach(x =>
                                    {

                                        this.businessAspNetUserRole.DeleteWhere(ur => ur.AspNetRole_ID == x.AspNetRole_ID);
                                    });
                                }
                            }

                            transaction.Complete();

                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Title = busConstant.Messages.Title.SUCCESS,
                                Icon = busConstant.Messages.Icon.SUCCESS,
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



        //[HttpGet]
        //[Access]
        //[OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        //[Route("Settings/Security/Users/MyUsers")]
        //public ActionResult TenantIndex()
        //{            
        //    return View("TenantIndex");
        //}


        //[HttpPost]
        //[Route("Post/Users/MyUsersAsync")]
        //[ValidateAntiForgeryTokens]
        //public async Task<ActionResult> TenantIndexAsync()
        //{
        //    BusinessResultViewModel<ViewModel.AspNetUserIndexViewModel> businessResult;
        //    try
        //    {
        //        using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
        //        {
        //            try
        //            {
        //                var userId = User.Identity.GetUserId<long>();
        //                var user = UserManager.FindById(userId);
        //                businessResult = this.businessAspNetUser.Index(Request, user.Tenant_ID.GetValueOrDefault());
        //                transaction.Complete();
        //            }
        //            catch
        //            {
        //                transaction.Dispose();
        //                throw;
        //            }
        //        }

        //        var response = new { draw = businessResult.Draw, recordsFiltered = businessResult.RecordsFiltered, recordsTotal = businessResult.RecordsTotal, data = businessResult.Data };

        //        return Json(data: response);
        //    }
        //    catch (Exception ex)
        //    {
        //        //ExceptionResponse(ex);
        //        var response = new { draw = Request.Form.GetValues("draw").FirstOrDefault(), recordsFiltered = 0, recordsTotal = 0, data = string.Empty, error = ex.Message };

        //        return Json(data: response);
        //    }
        //    finally
        //    {
        //        businessResult = null;
        //    }
        //}

        #endregion

    }
}