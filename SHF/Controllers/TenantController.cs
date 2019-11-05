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
using SHF.ViewModel;
using System.Reflection;
using System.ComponentModel;
using System.IO;
using SHF.Helpers;

namespace SHF.Controllers
{
    [AllowAnonymous]
    public class TenantController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.ITenant businessTenant;
        private Business.Interface.IAspNetUser businessAspNetUser;
        private Business.Interface.IAspNetRole businessAspNetRole;
        private Business.Interface.IAspNetUserRole businessAspNetUserRole;
        private Business.Interface.ISubMenu businessSubMenu;
        private Business.Interface.IAspNetRoleSubMenu businessAspNetRoleSubMenu;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;



        public TenantController(Business.Interface.ITenant Itenant, Business.Interface.IAspNetUser IaspNetUser, Business.Interface.IAspNetRole IaspNetRole, Business.Interface.IAspNetUserRole IaspNetUserRole, Business.Interface.ISubMenu IsubMenu, Business.Interface.IAspNetRoleSubMenu IaspNetRoleSubMenu)
        {
            this.businessTenant = Itenant;
            this.businessAspNetUser = IaspNetUser;
            this.businessAspNetRole = IaspNetRole;
            this.businessAspNetUserRole = IaspNetUserRole;
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
        [Route("Configurations/Master/Tenant/Index")]
        public ActionResult Index()
        {
            return View();
        }


        [HttpPost]
        [Route("Post/Tenant/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.TenantIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        businessResult = this.businessTenant.Index(Request);
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
        [AuditAttribute]
        [ValidateAntiForgeryTokens]
        [Route("Post/Tenant/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.TenantCreateOrEditViewModel model)
        {
            long tenantId = 0, userId = 0, roleId = 0;
            var response = new JsonResponse<dynamic>();
            try
            {
                if (!ModelState.IsValid)
                {
                    return ValidationResponse();
                }
                else
                {
                    var fullName = model.ContactPerson.Split(" ");
                    var firstName = fullName[busConstant.Numbers.Integer.ZERO];
                    var lastname = string.Empty;
                    if (fullName.Count() > busConstant.Numbers.Integer.TWO)
                    {
                        lastname = fullName[busConstant.Numbers.Integer.TWO];
                    }
                    else if (fullName.Count() > busConstant.Numbers.Integer.ONE)
                    {
                        lastname = fullName[busConstant.Numbers.Integer.ONE];
                    }
                    var entityApplicationUser = new ApplicationUser
                    {
                        FirstName = firstName,
                        LastName = lastname,
                        UserName = model.Username,
                        Email = model.Email,
                        PhoneNumber = model.ContactNumber,
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
                        string verificationCode = await UserManager.GenerateEmailConfirmationTokenAsync(entityApplicationUser.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = entityApplicationUser.Id, code = verificationCode }, protocol: Request.Url.Scheme);
                        // Send an email with this link
                        //UserManager.SendEmail(entityAspNetUser.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                        using (var transaction = new TransactionScope())
                        {
                            try
                            {
                                var entityTenant = new EntityModel.Tenant();
                                Mapper.Map(model, entityTenant);
                                this.businessTenant.Create(entityTenant);
                                tenantId = entityTenant.ID;

                                busGlobalFunction.CreateDirectory(String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, tenantId));
                                busGlobalFunction.CreateDirectory(String.Concat(busConstant.Settings.CMSPath.TENANAT_THUMB_DIRECTORY, tenantId));


                                //for tenant admin 
                                var aspNetRoleCreateOrViewModel = new ViewModel.AspNetRoleCreateOrEditViewModel
                                {
                                    Tenant_ID = entityTenant.ID,
                                    Name = Guid.NewGuid().ToString(),
                                    DisplayName = busConstant.Settings.AspNetRoles.ADMIN,
                                    IsActive = busConstant.Misc.TRUE,
                                    IsDeleted = busConstant.Misc.FALSE
                                };

                                var entityAspNetRole = new EntityModel.AspNetRole();
                                Mapper.Map(aspNetRoleCreateOrViewModel, entityAspNetRole);
                                this.businessAspNetRole.Create(entityAspNetRole);
                                roleId = entityAspNetRole.ID;

                                var aspNetUserRoleCreateViewModel = new ViewModel.AspNetUserRoleCreateOrEditViewModel
                                {
                                    Tenant_ID = tenantId,
                                    AspNetRole_ID = roleId,
                                    AspNetUser_ID = userId
                                };

                                var entityAspNetUserRole = new EntityModel.AspNetUserRole();
                                Mapper.Map(aspNetUserRoleCreateViewModel, entityAspNetUserRole);
                                this.businessAspNetUserRole.Create(entityAspNetUserRole);

                                var entityAspNetUser = this.businessAspNetUser.GetById(userId);
                                entityAspNetUser.Tenant_ID = tenantId;
                                this.businessAspNetUser.Update(entityAspNetUser);

                                var subMenus = this.businessSubMenu.GetAll().Where(x => x.UseOnlyFor==busConstant.Settings.NavigationFor.TENANT);
                                subMenus.ForEach(subMenu =>
                                {
                                    var aspNetRoleSubMenuCreateOrEditViewModel = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                    {
                                        Tenant_ID = entityTenant.ID,
                                        AspNetRole_ID = roleId,
                                        SubMenu_ID = subMenu.ID,
                                        HasAccess = busConstant.Misc.TRUE,
                                        IsActive = busConstant.Misc.TRUE,
                                        IsDeleted = busConstant.Misc.FALSE
                                    };
                                    var entityAspNetRoleSubMenu = new EntityModel.AspNetRoleSubMenu();
                                    Mapper.Map(aspNetRoleSubMenuCreateOrEditViewModel, entityAspNetRoleSubMenu);
                                    this.businessAspNetRoleSubMenu.Create(entityAspNetRoleSubMenu);
                                });

                                //for tenant by default roles added.
                                foreach (busConstant.Settings.AspNetRoles.DefaultRolesForTenant defaultRoles in Enum.GetValues(typeof(busConstant.Settings.AspNetRoles.DefaultRolesForTenant)))
                                {
                                    long roleIdForDefaultRole;
                                    var aspNetRoleCreateOrViewModelForDefaultRole = new ViewModel.AspNetRoleCreateOrEditViewModel
                                    {
                                        Tenant_ID = entityTenant.ID,
                                        Name = Guid.NewGuid().ToString(),
                                        DisplayName = stringValueOf(defaultRoles),
                                        IsActive = busConstant.Misc.TRUE,
                                        IsDeleted = busConstant.Misc.FALSE
                                    };

                                    var entityAspNetRoleForDefaultRole = new EntityModel.AspNetRole();
                                    Mapper.Map(aspNetRoleCreateOrViewModelForDefaultRole, entityAspNetRoleForDefaultRole);
                                    this.businessAspNetRole.Create(entityAspNetRoleForDefaultRole);
                                    roleIdForDefaultRole = entityAspNetRoleForDefaultRole.ID;

                                    var subMenusForDefaultRole = this.businessSubMenu.GetAll().Where(x => x.UseOnlyFor == busConstant.Settings.NavigationFor.TENANT);
                                    subMenusForDefaultRole.ForEach(subMenu =>
                                    {
                                        var aspNetRoleSubMenuCreateOrEditViewModelForDefaultRole = new ViewModel.AspNetRoleSubMenuCreateOrEditViewModel
                                        {
                                            Tenant_ID = entityTenant.ID,
                                            AspNetRole_ID = roleIdForDefaultRole,
                                            SubMenu_ID = subMenu.ID,
                                            HasAccess = busConstant.Misc.TRUE,
                                            IsActive = busConstant.Misc.TRUE,
                                            IsDeleted = busConstant.Misc.FALSE
                                        };
                                        var entityAspNetRoleSubMenuForDefaultRole = new EntityModel.AspNetRoleSubMenu();
                                        Mapper.Map(aspNetRoleSubMenuCreateOrEditViewModelForDefaultRole, entityAspNetRoleSubMenuForDefaultRole);
                                        this.businessAspNetRoleSubMenu.Create(entityAspNetRoleSubMenuForDefaultRole);
                                    });
                                }
                                

                                transaction.Complete();

                                busGlobalFunction.CreateDirectory(String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, entityTenant.ID));
                                busGlobalFunction.CreateDirectory(String.Concat(busConstant.Settings.CMSPath.TENANAT_THUMB_DIRECTORY, entityTenant.ID));


                                response.Type = busConstant.Messages.Type.RESPONSE;
                                response.Message = busConstant.Messages.Type.Responses.SAVE;
                                response.Title = busConstant.Messages.Title.SUCCESS;
                                response.Icon = busConstant.Messages.Icon.SUCCESS;

                                return Json(response);
                            }
                            catch
                            {
                                transaction.Dispose();
                                this.businessAspNetUser.Delete(userId);
                                throw;
                            }
                        }
                    }
                    else
                    {
                        response.Type = busConstant.Messages.Type.VALIDATION;
                        response.Message = busConstant.Messages.Type.Exceptions.SOMETHING_WENT_WRONG;
                        response.ValidationSummary = result.Errors;
                        response.Title = busConstant.Messages.Title.ERROR;
                        response.Icon = busConstant.Messages.Icon.ERROR;
                        response.Entity = result.Errors;
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
        #region Other Private Support Method
        private string stringValueOf(Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (attributes.Length > 0)
            {
                return attributes[0].Description;
            }
            else
            {
                return value.ToString();
            }
        }
        #endregion

        [HttpGet]
        [Route("Get/Tenant/EditAsync")]
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
                                Errors = null
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);

                            transaction.Complete();

                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessTenant.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.TenantCreateOrEditViewModel();

                                Mapper.Map(entity, model);

                                var response = new JsonResponse<TenantCreateOrEditViewModel>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Message = null,
                                    Errors = null,
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
                                    Errors = null,
                                    Entity = null
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
        [AuditAttribute]
        [ValidateAntiForgeryTokens]
        [Route("Post/Tenant/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.TenantCreateOrEditViewModel model)
        {
            try
            {
                ModelState.Remove("CreatedOn");
                ModelState.Remove("UpdatedOn");
                ModelState.Remove("Username");
                ModelState.Remove("Password");
                ModelState.Remove("ConfirmPassword");
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
                            var entity = new EntityModel.Tenant();

                            Mapper.Map(model, entity);

                            this.businessTenant.Update(entity);

                            transaction.Complete();

                            var response = new JsonResponse<TenantCreateOrEditViewModel>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Message = busConstant.Messages.Type.Responses.SAVE,
                                Errors = null,
                                ReturnUrl = null
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
        [Route("Get/Tenant/DropdownListAsync")]
        public async Task<ActionResult> DropdownListAsync()
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        var entities = this.businessTenant.GetDropdownList();

                        if (entities.IsNotNull())
                        {
                            var response = new JsonResponse<IEnumerable<ViewModel.TenantDropdownListViewModel>>()
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

        [HttpPost]
        [Route("Post/TenantCommonUploadFile/FileUpload")]
        public virtual string UploadFiles(object obj)
        {
            //  var tenantId = ViewBag.TenantID;
            var length = Request.ContentLength;
            var bytes = new byte[length];
            Request.InputStream.Read(bytes, 0, length);

            var fileName = Request.Headers["X-File-Name"];
            var fileSize = Request.Headers["X-File-Size"];
            var fileType = Request.Headers["X-File-Type"];
            var tenantId = Request.Headers["tenantId"];
            string temppath = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY));
            string path = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, tenantId));
            //string path = Server.MapPath("~/Uploads/");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            var saveToFileLoc = temppath + "/" + fileName;
            // var destToFileLoc = path + "/" + fileName;
            var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, length);
            fileStream.Close();
            //Image file compress
            CompressImage.CompressImageMethod(saveToFileLoc, path, 30);
            System.IO.File.Delete(saveToFileLoc);
            return string.Format("{0} bytes uploaded", bytes.Length);
        }
        #endregion
    }
}