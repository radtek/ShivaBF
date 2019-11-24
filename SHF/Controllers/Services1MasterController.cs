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
using System.IO;
using SHF.Helpers;

namespace SHF.Controllers
{
    [AllowAnonymous]
    public class Services1MasterController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IServices1Master businessServices1Master;
        private Business.Interface.ITenant businessTenant;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;


        public Services1MasterController(Business.Interface.IMessage Imessage, Business.Interface.IServices1Master IServices1Master, Business.Interface.ITenant Itenant, Business.Interface.ISubSubCategoriesMaster IsubSubCategoriesMaster)
        {
            this.businessMessage = Imessage;
            this.businessServices1Master = IServices1Master;
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
        [Route("Configurations/Master/ServiceType1/Index")]
        [Route("Settings/Master/ServiceType1/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/ServiceType1/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.Services1MasterIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessServices1Master.Index(Request, tenantId);
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
        [Route("Post/Services1Master/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.Services1MasterCreateOrEditViewModel model)
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
                            var catId = businessServices1Master.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();

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
                                var entity = new EntityModel.Services1Master();
                                // Mapper.Map(model, entity);
                                //entity.ID = model.ID;
                                entity.BannerImagePath = model.BannerImagePath;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Cat_Id = entitySubSubCategoryName.Cat_Id;
                                entity.SubCat_Id = entitySubSubCategoryName.SubCat_Id;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.SubSubCategoryName = entitySubSubCategoryName.SubSubCategoryName;
                                entity.BannerHeadingDescription = model.BannerHeadingDescription;
                                entity.BannerAncharTagTitle = model.BannerAncharTagTitle;
                                entity.BannerAncharTagUrl = model.BannerAncharTagUrl;
                                entity.Section1AfterBannerHeading = model.Section1AfterBannerHeading;
                                entity.Section1AfterBannerDescription = model.Section1AfterBannerDescription;
                                entity.Section1AfterBannerImagePath = model.Section1AfterBannerImagePath;
                                entity.Section1AfterBannerImageOnDescription = model.Section1AfterBannerImageOnDescription;
                                entity.Section2Heading = model.Section2Heading;
                                entity.Section2Description = model.Section2Description;
                                entity.Section3Heading = model.Section3Heading;
                                entity.Section3Description = model.Section3Description;
                                entity.Section3TextboxMaskedText = model.Section3TextboxMaskedText;
                                entity.Section4Heading = model.Section4Heading;
                                entity.Section5Heading = model.Section5Heading;
                                entity.Section6Heading = model.Section6Heading;
                                entity.Section6Description = model.Section6Description;
                                entity.Section7Description = model.Section7Description;
                                entity.Section8Description = model.Section8Description;
                                entity.Section96Heading = model.Section96Heading;
                                entity.Section9Description = model.Section9Description;
                                entity.Section10MappingBankFlag = model.Section10MappingBankFlag;
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.PageTitle = model.PageTitle;
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
                                this.businessServices1Master.Create(entity);
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
        [Route("Get/Services1Master/EditAsync")]
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
                            var entity = this.businessServices1Master.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.Services1MasterCreateOrEditViewModel();

                                // Mapper.Map(entity, model);
                                model.ID = entity.ID;
                                model.BannerImagePath = entity.BannerImagePath;
                                model.BannerOnHeading = entity.BannerOnHeading;
                                entity.Cat_Id = entity.Cat_Id;
                                entity.SubCat_Id = entity.SubCat_Id;
                                model.SubSubCat_Id = entity.SubSubCat_Id;
                                model.SubSubCategoryName = entity.SubSubCategoryName;
                                model.BannerHeadingDescription = entity.BannerHeadingDescription;
                                model.BannerAncharTagTitle = entity.BannerAncharTagTitle;
                                model.BannerAncharTagUrl = entity.BannerAncharTagUrl;
                                model.Section1AfterBannerHeading = entity.Section1AfterBannerHeading;
                                model.Section1AfterBannerDescription = entity.Section1AfterBannerDescription;
                                model.Section1AfterBannerImagePath = entity.Section1AfterBannerImagePath;
                                model.Section1AfterBannerImageOnDescription = entity.Section1AfterBannerImageOnDescription;
                                model.Section2Heading = entity.Section2Heading;
                                model.Section2Description = entity.Section2Description;
                                model.Section3Heading = entity.Section3Heading;
                                model.Section3Description = entity.Section3Description;
                                model.Section3TextboxMaskedText = entity.Section3TextboxMaskedText;
                                model.Section4Heading = entity.Section4Heading;
                                model.Section5Heading = entity.Section5Heading;
                                model.Section6Heading = entity.Section6Heading;
                                model.Section6Description = entity.Section6Description;
                                model.Section7Description = entity.Section7Description;
                                model.Section8Description = entity.Section8Description;
                                model.Section96Heading = entity.Section96Heading;
                                model.Section9Description = entity.Section9Description;
                                model.Section10MappingBankFlag = entity.Section10MappingBankFlag;
                                model.DisplayIndex = entity.DisplayIndex;
                                model.PageTitle = entity.PageTitle;
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


                                var response = new JsonResponse<Services1MasterCreateOrEditViewModel>()
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
        [Audit]
        [ValidateAntiForgeryTokens]
        [Route("Post/Services1Master/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.Services1MasterCreateOrEditViewModel model)
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
                            var CategoriesData = businessServices1Master.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.ID == model.ID).FirstOrDefault();

                            if (CategoriesData.IsNull())
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
                                var entitySubSubCategoryName = this.businessSubSubCategoriesMaster.GetById(Convert.ToInt64(model.SubSubCat_Id));
                                var entity = this.businessServices1Master.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {
                                    // Mapper.Map(model, entity);
                                    entity.ID = Convert.ToInt64(model.ID);
                                    entity.BannerImagePath = model.BannerImagePath;
                                    entity.BannerOnHeading = model.BannerOnHeading;
                                    entity.SubSubCat_Id = model.SubSubCat_Id;
                                    entity.Cat_Id = entitySubSubCategoryName.Cat_Id;
                                    entity.SubCat_Id = entitySubSubCategoryName.SubCat_Id;
                                    entity.SubSubCategoryName = entitySubSubCategoryName.SubSubCategoryName;
                                    entity.BannerHeadingDescription = model.BannerHeadingDescription;
                                    entity.BannerAncharTagTitle = model.BannerAncharTagTitle;
                                    entity.BannerAncharTagUrl = model.BannerAncharTagUrl;
                                    entity.Section1AfterBannerHeading = model.Section1AfterBannerHeading;
                                    entity.Section1AfterBannerDescription = model.Section1AfterBannerDescription;
                                    entity.Section1AfterBannerImagePath = model.Section1AfterBannerImagePath;
                                    entity.Section1AfterBannerImageOnDescription = model.Section1AfterBannerImageOnDescription;
                                    entity.Section2Heading = model.Section2Heading;
                                    entity.Section2Description = model.Section2Description;
                                    entity.Section3Heading = model.Section3Heading;
                                    entity.Section3Description = model.Section3Description;
                                    entity.Section3TextboxMaskedText = model.Section3TextboxMaskedText;
                                    entity.Section4Heading = model.Section4Heading;
                                    entity.Section5Heading = model.Section5Heading;
                                    entity.Section6Heading = model.Section6Heading;
                                    entity.Section6Description = model.Section6Description;
                                    entity.Section7Description = model.Section7Description;
                                    entity.Section8Description = model.Section8Description;
                                    entity.Section96Heading = model.Section96Heading;
                                    entity.Section9Description = model.Section9Description;
                                    entity.Section10MappingBankFlag = model.Section10MappingBankFlag;
                                    entity.DisplayIndex = model.DisplayIndex;
                                    entity.PageTitle = model.PageTitle;
                                    entity.Url = model.Url;
                                    entity.Metadata = model.Metadata;
                                    entity.MetaDescription = model.MetaDescription;
                                    entity.Keyword = model.Keyword;
                                    entity.TotalViews = model.TotalViews;
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

                                    this.businessServices1Master.Update(entity);

                                    transaction.Complete();
                                }
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
        [Route("Post/Services1Master/Delete")]
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
                            this.businessServices1Master.Delete(Convert.ToInt64(Id));


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
        [Route("Get/Services1Master/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetServices1MasterByTenantIdAsync(long? Id)
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

                            var entities = this.businessSubSubCategoriesMaster.GetAll().Where(x => (x.Tenant_ID == Id && x.ServiceTypeValue == busConstant.Code.CodeValue.ServiceType.SERVICE_1))
                                 .Select(x => new ViewModel.Services1MasterDropdownListViewModel
                                 {
                                     ID = x.ID,
                                     SubSubCategoryName = x.SubSubCategoryName
                                 });
                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.Services1MasterDropdownListViewModel>>()
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