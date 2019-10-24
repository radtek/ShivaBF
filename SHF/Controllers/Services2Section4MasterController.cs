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


namespace SHF.Controllers
{
    [AllowAnonymous]
    public class Services2Section4MasterController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IServices2Section4Master businessServices2Section4Master;
        private Business.Interface.IServices2Master businessServices2Master;

        public Services2Section4MasterController(Business.Interface.IMessage Imessage, Business.Interface.IServices2Section4Master IServices2Section4Master, Business.Interface.IServices2Master IServices2Master)
        {
            this.businessMessage = Imessage;
            this.businessServices2Section4Master = IServices2Section4Master;
            this.businessServices2Master = IServices2Master;

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
        [Route("Configurations/Master/ServiceType2/Section4")]
        [Route("Settings/Master/ServiceType2/Section4")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/Services2Section4/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.Services2Section4MasterIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessServices2Section4Master.Index(Request, tenantId);
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
        [Route("Post/Services2Section4Master/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.Services2Section4MasterCreateOrEditViewModel model)
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
                            var productId = businessServices2Section4Master.FindBy(Services2Section4 => Services2Section4.Tenant_ID == model.Tenant_ID && Services2Section4.ID == model.ID).FirstOrDefault();

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
                                var entityServices = this.businessServices2Master.FindBy(Services2Master => Services2Master.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();
                                var entity = new EntityModel.Services2Section4Master();
                                entity.Tenant = null;
                                //entity.Services2Section4Masters = null;
                                entity.SubSubCategoriesMaster = null;
                                entity.Services2Master = null;
                                entity.Service_Id = entityServices.ID;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.AncharTagTitle = model.AncharTagTitle;
                                entity.AncharTagUrl = model.AncharTagUrl;
                                entity.Heading = model.HeadingText;
                                entity.Price = model.Price;
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.IsActive = model.IsActive;
                                entity.TotalViews = model.TotalViews;
                                entity.Url = model.Url;
                                entity.Metadata = model.Metadata;
                                entity.Keyword = model.Keyword;
                                entity.MetaDescription = model.MetaDescription;
                                entity.Tenant_ID = model.Tenant_ID;
                                //Mapper.Map(model, entity);
                                this.businessServices2Section4Master.Create(entity);
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
        [Route("Get/Services2Section4Master/EditAsync")]
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
                            var entity = this.businessServices2Section4Master.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var entityServices = this.businessServices2Master.FindBy(Services2Master => Services2Master.SubSubCat_Id == entity.SubSubCat_Id).FirstOrDefault();
                                var model = new ViewModel.Services2Section4MasterCreateOrEditViewModel();

                                // Mapper.Map(entity, model);

                                model.ID = entity.ID;
                                model.SubSubCat_Id = Convert.ToInt64(entity.SubSubCat_Id);
                                model.SubSubCategoryName = entityServices.SubSubCategoryName;
                                model.AncharTagTitle = entity.AncharTagTitle;
                                model.AncharTagUrl = entity.AncharTagUrl;
                                model.HeadingText = entity.Heading;
                                model.Price = entity.Price;
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

                                var response = new JsonResponse<Services2Section4MasterCreateOrEditViewModel>()
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
        [Route("Post/Services2Section4Master/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.Services2Section4MasterCreateOrEditViewModel model)
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
                            var Services2Section4Data = businessServices2Section4Master.FindBy(Services2Section4 => Services2Section4.Tenant_ID == model.Tenant_ID && Services2Section4.ID == model.ID).FirstOrDefault();

                            if (Services2Section4Data.IsNull())
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
                                var entityServices = this.businessServices2Master.FindBy(Services2Master => Services2Master.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();
                                var entity = this.businessServices2Section4Master.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {

                                    entity.Service_Id = entityServices.ID;
                                    entity.SubSubCat_Id = model.SubSubCat_Id;
                                    entity.AncharTagTitle = model.AncharTagTitle;
                                    entity.AncharTagUrl = model.AncharTagUrl;
                                    entity.Heading = model.HeadingText;
                                    entity.Price = model.Price;
                                    entity.DisplayIndex = model.DisplayIndex;
                                    entity.IsActive = model.IsActive;
                                    entity.TotalViews = model.TotalViews;
                                    entity.Url = model.Url;
                                    entity.Metadata = model.Metadata;
                                    entity.Keyword = model.Keyword;
                                    entity.MetaDescription = model.MetaDescription;
                                    entity.Tenant_ID = model.Tenant_ID;
                                    entity.Tenant = null;
                                    //entity.Services2Section4Masters = null;
                                    entity.SubSubCategoriesMaster = null;
                                    entity.Services2Master = null;
                                    this.businessServices2Section4Master.Update(entity);

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
        [Route("Post/Services2Section4Master/Delete")]
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
                            this.businessServices2Section4Master.Delete(Convert.ToInt64(Id));


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
        [Route("Get/Services2Section4Master/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetServices2Section4MasterByTenantIdAsync(long Id)
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
                            var entities = this.businessServices2Section4Master.FindBy(product => product.Tenant_ID == Id).Select(x => new ViewModel.Services2Section4MasterDropdownListViewModel
                            {
                                ID = x.ID,
                                AncharTagTitle = x.AncharTagTitle
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.Services2Section4MasterDropdownListViewModel>>()
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