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
    public class Services5MasterController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IServices5Master businessServices5Master;
        private Business.Interface.ITenant businessTenant;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        

        public Services5MasterController(Business.Interface.IMessage Imessage, Business.Interface.IServices5Master IServices5Master, Business.Interface.ITenant Itenant, Business.Interface.ISubSubCategoriesMaster IsubSubCategoriesMaster)
        {
            this.businessMessage = Imessage;
            this.businessServices5Master = IServices5Master;
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
        [Route("Configurations/Master/ServiceType5/Index")]
        [Route("Settings/Master/ServiceType5/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/ServiceType5/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.Services5MasterIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessServices5Master.Index(Request, tenantId);
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
        [Route("Post/Services5Master/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.Services5MasterCreateOrEditViewModel model)
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
                            var catId = businessServices5Master.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();

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
                                var entitySubSubCategoryName = this.businessSubSubCategoriesMaster.GetById(Convert.ToInt64(model.SubSubCat_Id));
                                var entity = new EntityModel.Services5Master();
                                // Mapper.Map(model, entity);
                                //entity.ID = model.ID;
                                entity.BannerImagePath = model.BannerImagePath;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Cat_Id = entitySubSubCategoryName.Cat_Id;
                                entity.SubCat_Id = entitySubSubCategoryName.SubCat_Id;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.SubSubCategoryName = entitySubSubCategoryName.SubSubCategoryName;
                                entity.BannerHeadingDescription = model.BannerHeadingDescription;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Section1Description = model.Section1Description;
                                entity.Section2Heading = model.Section2Heading;
                                entity.Section2HeadingDescription = model.Section2HeadingDescription;
                               
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.Url= model.Url;
                                entity.Metadata= model.Metadata;
                                entity.MetaDescription= model.MetaDescription;
                                entity.Keyword= model.Keyword;
                                entity.TotalViews = model.TotalViews;
                                entity.IsActive = model.IsActive;
                                entity.Tenant_ID = model.Tenant_ID;
                                //entity.CreatedBy = model.CreatedBy;
                                //entity.UpdatedBy = model.UpdatedBy;
                                //entity.CreatedOn = model.CreatedOn;
                                //entity.UpdatedOn = model.UpdatedOn;

                                entity.Tenant = null;
                                entity.CategoriesMaster = null;
                                entity.SubCategoriesMaster = null;
                                entity.SubSubCategoriesMaster = null;
                                entity.CategoriesMaster = null;
                                this.businessServices5Master.Create(entity);
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
        [Route("Get/Services5Master/EditAsync")]
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
                            var entity = this.businessServices5Master.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.Services5MasterCreateOrEditViewModel();
                                var entitySubSubCategoryName = this.businessSubSubCategoriesMaster.GetById(Convert.ToInt64(Id));
                                model.ID = entity.ID;
                                model.BannerImagePath = entity.BannerImagePath;
                                model.BannerOnHeading = entity.BannerOnHeading;
                                model.Cat_Id = entity.Cat_Id;
                                model.SubCat_Id = entity.SubCat_Id;
                                model.SubSubCat_Id = entity.SubSubCat_Id;
                                model.SubSubCategoryName = entity.SubSubCategoryName;
                                model.BannerHeadingDescription = entity.BannerHeadingDescription;
                                model.BannerOnHeading = entity.BannerOnHeading;
                                model.Section1Description = entity.Section1Description;
                                model.Section2Heading = entity.Section2Heading;
                                model.Section2HeadingDescription = entity.Section2HeadingDescription;
                              
                                model.DisplayIndex = entity.DisplayIndex;
                                model.Url = entity.Url.ToString();
                                model.Metadata = entity.Metadata.ToString();
                                model.MetaDescription = entity.MetaDescription.ToString();
                                model.Keyword = entity.Keyword.ToString();
                                model.IsActive = entity.IsActive;
                                model.TotalViews = entity.TotalViews;
                                model.Tenant_ID = Convert.ToInt64(entity.Tenant_ID);
                                model.CreatedBy = entity.CreatedBy;
                                model.UpdatedBy = entity.UpdatedBy;
                                model.CreatedOn = entity.CreatedOn;
                                model.UpdatedOn = entity.UpdatedOn;


                                var response = new JsonResponse<Services5MasterCreateOrEditViewModel>()
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
        [Route("Post/Services5Master/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.Services5MasterCreateOrEditViewModel model)
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
                            var CategoriesData = businessServices5Master.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.ID != model.ID).FirstOrDefault();

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
                                var entity = this.businessServices5Master.GetById(Convert.ToInt64(model.ID));
                                var entitySubSubCategoryName = this.businessSubSubCategoriesMaster.GetById(Convert.ToInt64(model.SubSubCat_Id));
                               
                                // Mapper.Map(model, entity);
                                entity.ID = Convert.ToInt64(model.ID);
                                entity.BannerImagePath = model.BannerImagePath;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Cat_Id = entitySubSubCategoryName.Cat_Id;
                                entity.SubCat_Id = entitySubSubCategoryName.SubCat_Id;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.SubSubCategoryName = entitySubSubCategoryName.SubSubCategoryName;
                                entity.BannerHeadingDescription = model.BannerHeadingDescription;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Section1Description = model.Section1Description;
                                entity.Section2Heading = model.Section2Heading;
                                entity.Section2HeadingDescription = model.Section2HeadingDescription;
                               
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.Url = model.Url;
                                entity.Metadata = model.Metadata;
                                entity.MetaDescription = model.MetaDescription;
                                entity.Keyword = model.Keyword;
                                entity.TotalViews = model.TotalViews;
                                entity.IsActive = model.IsActive;
                                entity.Tenant_ID = model.Tenant_ID;
                                //entity.CreatedBy = model.CreatedBy;
                                //entity.UpdatedBy = model.UpdatedBy;
                                //entity.CreatedOn = model.CreatedOn;
                                //entity.UpdatedOn = model.UpdatedOn;

                                entity.Tenant = null;
                                entity.CategoriesMaster = null;
                                entity.SubCategoriesMaster = null;
                                entity.SubSubCategoriesMaster = null;
                                entity.CategoriesMaster = null;

                                this.businessServices5Master.Update(entity);

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
        [Route("Post/Services5Master/Delete")]
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
                                this.businessServices5Master.Delete(Convert.ToInt64(Id));


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
        [Route("Get/Services5Master/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetServices5MasterByTenantIdAsync(long? Id)
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        if (Id == null)
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
                          
                            var entities= this.businessSubSubCategoriesMaster.GetAll().Where(x =>(x.Tenant_ID == Id && x.ServiceTypeValue==busConstant.Code.CodeValue.ServiceType.SERVICE_5))
                                .Select(x => new ViewModel.Services5MasterDropdownListViewModel
                            {
                                ID = x.ID,
                                SubSubCategoryName = x.SubSubCategoryName
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.Services5MasterDropdownListViewModel>>()
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