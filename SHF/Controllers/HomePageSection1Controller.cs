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
using System.IO;
using SHF.Helpers;

namespace SHF.Controllers
{
    [AllowAnonymous]
    public class HomePageSection1Controller : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IHomePageSection1 businessHomePageSection1;
        private Business.Interface.ITenant businessTenant;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        

        public HomePageSection1Controller(Business.Interface.IMessage Imessage, Business.Interface.IHomePageSection1 IHomePageSection1, Business.Interface.ITenant Itenant, Business.Interface.ISubSubCategoriesMaster IsubSubCategoriesMaster)
        {
            this.businessMessage = Imessage;
            this.businessHomePageSection1 = IHomePageSection1;
            this.businessSubSubCategoriesMaster = IsubSubCategoriesMaster;
            this.businessTenant = Itenant;

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
        [Route("Configurations/Master/HomePage/Section1")]
        [Route("Settings/Master/HomePage/Section1")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/HomePageSection1/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.HomePageSection1IndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessHomePageSection1.Index(Request, tenantId);
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
        [Route("Post/HomePageSection1/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.HomePageSection1CreateOrEditViewModel model)
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
                            var catId = businessHomePageSection1.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.ID == model.ID).FirstOrDefault();

                            if (catId.IsNotNull())
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
                               
                                var entity = new EntityModel.HomePageSection1();
                                
                                entity.BannerImagePath = model.BannerImagePath;
                                entity.ShortDescription = model.ShortDescription;
                                entity.LongtDescription = model.LongtDescription;
                                entity.AncharTagTitle = model.AncharTagTitle;
                                entity.AncharTagUrl = model.AncharTagUrl;
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.DisplayOnHome = model.DisplayOnHome;
                                
                                entity.Url= model.Url;
                                entity.Metadata= model.Metadata;
                                entity.MetaDescription= model.MetaDescription;
                                entity.Keyword= model.Keyword;
                                entity.TotalViews = model.TotalViews;
                                entity.IsActive = model.IsActive;
                                entity.Tenant_ID = model.Tenant_ID;
                               
                                entity.Tenant = null;
                                
                                this.businessHomePageSection1.Create(entity);
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
        [Route("Get/HomePageSection1/EditAsync")]
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
                            var entity = this.businessHomePageSection1.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.HomePageSection1CreateOrEditViewModel();
                               
                                model.ID = entity.ID;
                                model.BannerImagePath = entity.BannerImagePath;
                                model.ShortDescription = entity.ShortDescription;
                                model.LongtDescription = entity.LongtDescription;
                                model.DisplayOnHome = entity.DisplayOnHome;
                                model.AncharTagTitle = entity.AncharTagTitle;
                                model.AncharTagUrl = entity.AncharTagUrl;
                                model.DisplayIndex = entity.DisplayIndex;
                                model.Url = entity.Url;
                                model.Metadata = entity.Metadata;
                                model.MetaDescription = entity.MetaDescription;
                                model.Keyword = entity.Keyword;
                                model.TotalViews = entity.TotalViews;
                                model.IsActive = entity.IsActive;
                                model.Tenant_ID = Convert.ToInt64(entity.Tenant_ID);


                                var response = new JsonResponse<HomePageSection1CreateOrEditViewModel>()
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
        [Route("Post/HomePageSection1/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.HomePageSection1CreateOrEditViewModel model)
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
                            var CategoriesData = businessHomePageSection1.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.ID != model.ID).FirstOrDefault();

                            if (CategoriesData.IsNotNull())
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
                                
                                var entity = this.businessHomePageSection1.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {
                                    // Mapper.Map(model, entity);
                                    entity.BannerImagePath = model.BannerImagePath;
                                    entity.ShortDescription = model.ShortDescription;
                                    entity.LongtDescription = model.LongtDescription;
                                    entity.DisplayOnHome = model.DisplayOnHome;
                                    entity.AncharTagTitle = model.AncharTagTitle;
                                    entity.AncharTagUrl = model.AncharTagUrl;
                                    entity.DisplayIndex = model.DisplayIndex;
                                    entity.Url = model.Url;
                                    entity.Metadata = model.Metadata;
                                    entity.MetaDescription = model.MetaDescription;
                                    entity.Keyword = model.Keyword;
                                    entity.TotalViews = model.TotalViews;
                                    entity.IsActive = model.IsActive;
                                    entity.Tenant_ID = model.Tenant_ID;
                                    entity.Tenant = null;
                                
                                this.businessHomePageSection1.Update(entity);

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
        [Route("Post/HomePageSection1/Delete")]
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
                                this.businessHomePageSection1.Delete(Convert.ToInt64(Id));


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

        

        #endregion

    }
}