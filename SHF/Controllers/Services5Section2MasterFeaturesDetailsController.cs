﻿using System;
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


namespace SHF.Controllers
{
    [AllowAnonymous]
    public class Services5Section2MasterFeaturesDetailsController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IServices5Section2MasterFeaturesDetails businessServices5Section2MasterFeaturesDetails;
        private Business.Interface.IServices5Master businessServices5Master;

        public Services5Section2MasterFeaturesDetailsController(Business.Interface.IMessage Imessage, Business.Interface.IServices5Section2MasterFeaturesDetails IServices5Section2MasterFeaturesDetails, Business.Interface.IServices5Master IServices5Master)
        {
            this.businessMessage = Imessage;
            this.businessServices5Section2MasterFeaturesDetails = IServices5Section2MasterFeaturesDetails;
            this.businessServices5Master = IServices5Master;

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

        #region [ActionMethod]
        // GET: Categories Master
        [HttpGet]
        [Access]
        [OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Configurations/Master/ServiceType5/Section2Features")]
        [Route("Settings/Master/ServiceType1/Section2Features")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/Services5Section2MasterFeaturesDetails/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.Services5Section2MasterFeaturesDetailsIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessServices5Section2MasterFeaturesDetails.Index(Request, tenantId);
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
        [Route("Post/Services5Section2MasterFeaturesDetails/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.Services5Section2MasterFeaturesDetailsCreateOrEditViewModel model)
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
                            var productId = businessServices5Section2MasterFeaturesDetails.FindBy(subCategories => subCategories.Tenant_ID == model.Tenant_ID && subCategories.ID == model.ID).FirstOrDefault();

                            if (productId.IsNotNull())
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.EXCEPTION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.SKU_ALREADY_EXIST,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST
                                };
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var entityServices = this.businessServices5Master.FindBy(Services5Master => Services5Master.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();
                                var entity = new EntityModel.Services5Section2MasterFeaturesDetails();
                                entity.Tenant = null;
                                entity.Services5Section2Master = null;
                                entity.Services5Master = null;
                                entity.SubSubCategoriesMaster = null;
                                entity.Service_Id = entityServices.ID;
                                entity.S5S2M_Id = model.S5S2M_Id;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.Text = model.Text;
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.IsActive = model.IsActive;
                                entity.TotalViews = model.TotalViews;
                                entity.Url = model.Url;
                                entity.Metadata = model.Metadata;
                                entity.Keyword = model.Keyword;
                                entity.MetaDescription = model.MetaDescription;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessServices5Section2MasterFeaturesDetails.Create(entity);
                                transaction.Complete();

                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Title = busConstant.Messages.Title.SUCCESS,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    MessageCode = busConstant.Messages.MessageCode.SAVE,
                                    Message = busConstant.Messages.Type.Responses.SAVE
                                };

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
        [Route("Get/Services5Section2MasterFeaturesDetails/EditAsync")]
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
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessServices5Section2MasterFeaturesDetails.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var entityServices = this.businessServices5Master.FindBy(Services5Master => Services5Master.ID == entity.Service_Id).FirstOrDefault();
                                var model = new ViewModel.Services5Section2MasterFeaturesDetailsCreateOrEditViewModel();

                                model.ID = entity.ID;
                                // model.SubSubCategory_Name = ent;
                                model.S5S2M_Id = entity.S5S2M_Id;
                                model.Service_Id = entity.Service_Id;
                                model.SubSubCat_Id = Convert.ToInt64(entity.SubSubCat_Id);
                                model.Text = entity.Text;
                                model.DisplayIndex = entity.DisplayIndex;
                                model.IsActive = entity.IsActive;
                                model.TotalViews = entity.TotalViews;
                                model.Url = entity.Url;
                                model.Metadata = entity.Metadata;
                                model.Keyword = entity.Keyword;
                                model.MetaDescription = entity.MetaDescription;
                                model.Tenant_ID = Convert.ToInt64(entity.Tenant_ID);
                                model.CreatedBy = entity.CreatedBy;
                                model.CreatedOn = entity.CreatedOn;
                                model.UpdatedBy = entity.UpdatedBy;
                                model.UpdatedOn = entity.UpdatedOn;
                                model.IsDeleted = entity.IsDeleted;

                                var response = new JsonResponse<Services5Section2MasterFeaturesDetailsCreateOrEditViewModel>()
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
                                    Message = busConstant.Messages.Type.Exceptions.NOT_FOUND,
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
        [Route("Post/Services5Section2MasterFeaturesDetails/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.Services5Section2MasterFeaturesDetailsCreateOrEditViewModel model)
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
                            var SubCategoriesData = businessServices5Section2MasterFeaturesDetails.FindBy(SubCategories => SubCategories.Tenant_ID == model.Tenant_ID && SubCategories.ID == model.ID).FirstOrDefault();

                            if (SubCategoriesData.IsNull())
                            {
                                transaction.Complete();
                                var response = new JsonResponse<dynamic>()
                                {
                                    Type = busConstant.Messages.Type.VALIDATION,
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    MessageCode = busConstant.Messages.MessageCode.SKU_ALREADY_EXIST,
                                    Message = busConstant.Messages.Type.Responses.ALREADY_EXIST
                                };
                                return Json(response, JsonRequestBehavior.AllowGet);
                            }
                            else
                            {
                                var entityServices = this.businessServices5Master.FindBy(Services5Master => Services5Master.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();
                                var entity = this.businessServices5Section2MasterFeaturesDetails.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {
                                    entity.Tenant = null;
                                    entity.Services5Section2Master = null;
                                    entity.Services5Master = null;
                                    entity.SubSubCategoriesMaster = null;
                                    entity.Service_Id = entityServices.ID;
                                    entity.S5S2M_Id = model.S5S2M_Id;
                                    entity.SubSubCat_Id = model.SubSubCat_Id;
                                    entity.Text = model.Text;
                                    entity.DisplayIndex = model.DisplayIndex;
                                    entity.IsActive = model.IsActive;
                                    entity.TotalViews = model.TotalViews;
                                    entity.Url = model.Url;
                                    entity.Metadata = model.Metadata;
                                    entity.Keyword = model.Keyword;
                                    entity.MetaDescription = model.MetaDescription;
                                    entity.Tenant_ID = model.Tenant_ID;
                                    this.businessServices5Section2MasterFeaturesDetails.Update(entity);

                                    transaction.Complete();

                                    var response = new JsonResponse<dynamic>()
                                    {
                                        Type = busConstant.Messages.Type.RESPONSE,
                                        Title = busConstant.Messages.Title.SUCCESS,
                                        Icon = busConstant.Messages.Icon.SUCCESS,
                                        Message = busConstant.Messages.Type.Responses.SAVE,
                                        MessageCode = busConstant.Messages.MessageCode.SAVE
                                    };
                                    return Json(response);
                                }
                                else
                                {
                                    var response = new JsonResponse<dynamic>()
                                    {
                                        Type = busConstant.Messages.Type.EXCEPTION,
                                        Message = busConstant.Messages.Type.Exceptions.NOT_FOUND,
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
        [AuditAttribute]
        [ValidateAntiForgeryTokens]
        [Route("Post/Services5Section2MasterFeaturesDetails/Delete")]
        public async Task<ActionResult> DeleteAsync(string Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Convert.ToInt64(Id) == 0)
                        {
                            transaction.Complete();
                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.EXCEPTION,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                            };

                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            this.businessServices5Section2MasterFeaturesDetails.Delete(Convert.ToInt64(Id));


                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Message = busConstant.Messages.Icon.SUCCESS,
                            };

                            transaction.Complete();
                            return Json(response, JsonRequestBehavior.AllowGet);

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

        [HttpGet]
        [Route("Get/Services5Section2MasterFeaturesDetails/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetServices5Section2MasterFeaturesDetailsByTenantIdAsync(long Id)
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
                                StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest)
                            };

                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entities = this.businessServices5Section2MasterFeaturesDetails.FindBy(category => category.ID == Id).Select(x => new ViewModel.SubCategoriesDropdownListViewModel
                            {
                                ID = x.ID,
                                SubCategoryName = x.MetaDescription
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.SubCategoriesDropdownListViewModel>>()
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
                                    StatusCode = Convert.ToInt32(HttpStatusCode.NotFound)
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


        #endregion

    }
}