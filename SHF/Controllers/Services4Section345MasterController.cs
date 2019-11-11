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
    public class Services4Section345MasterController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IServices4Section345Master businessServices4Section345Master;
        private Business.Interface.IServices4Master businessServices4Master;

        public Services4Section345MasterController(Business.Interface.IMessage Imessage, Business.Interface.IServices4Section345Master IServices4Section345Master, Business.Interface.IServices4Master IServices4Master)
        {
            this.businessMessage = Imessage;
            this.businessServices4Section345Master = IServices4Section345Master;
            this.businessServices4Master = IServices4Master;

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
        [Route("Configurations/Master/ServiceType4/Section345Master")]
        [Route("Settings/Master/ServiceType4/Section345Master")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/Services4Section345Master/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.Services4Section345MasterIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessServices4Section345Master.Index(Request, tenantId);
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
        [Route("Post/Services4Section345Master/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.Services4Section345MasterCreateOrEditViewModel model)
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
                            var productId = businessServices4Section345Master.FindBy(Services2Section3Download => Services2Section3Download.Tenant_ID == model.Tenant_ID && Services2Section3Download.ID == model.ID).FirstOrDefault();

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
                                var entityServices = this.businessServices4Master.FindBy(Services4Master => Services4Master.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();
                                var entity = new EntityModel.Services4Section345Master();
                                entity.Tenant = null;
                                //entity.Services4Section345Masters = null;
                                entity.SubSubCategoriesMaster = null;
                                entity.Services4Master = null;
                                entity.Service_Id = entityServices.ID;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.Heading = model.Heading;
                                entity.SectionType_ID = busConstant.Code.SECTION_TYPE;
                                entity.SectionTypeValue = model.SectionTypeValue;
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.IsActive = model.IsActive;
                                entity.TotalViews = model.TotalViews;
                                entity.Url = model.Url;
                                entity.Metadata = model.Metadata;
                                entity.Keyword = model.Keyword;
                                entity.MetaDescription = model.MetaDescription;
                                entity.Tenant_ID = model.Tenant_ID;
                                //Mapper.Map(model, entity);
                                this.businessServices4Section345Master.Create(entity);
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
        [Route("Get/Services4Section345Master/EditAsync")]
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
                            var entity = this.businessServices4Section345Master.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var entityServices = this.businessServices4Master.FindBy(Services4Master => Services4Master.SubSubCat_Id == entity.SubSubCat_Id).FirstOrDefault();
                                var model = new ViewModel.Services4Section345MasterCreateOrEditViewModel();

                                // Mapper.Map(entity, model);

                                model.ID = entity.ID;
                                model.SubSubCat_Id = Convert.ToInt64(entity.SubSubCat_Id);
                                model.SubSubCategoryName = entityServices.SubSubCategoryName;
                                model.Heading = entity.Heading;
                                model.SectionType_ID = busConstant.Code.SECTION_TYPE;
                                model.SectionTypeValue = entity.SectionTypeValue;
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

                                var response = new JsonResponse<Services4Section345MasterCreateOrEditViewModel>()
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
        [Route("Post/Services4Section345Master/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.Services4Section345MasterCreateOrEditViewModel model)
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
                            var Services2Section3DownloadData = businessServices4Section345Master.FindBy(Services2Section3Download => Services2Section3Download.Tenant_ID == model.Tenant_ID && Services2Section3Download.ID == model.ID).FirstOrDefault();

                            if (Services2Section3DownloadData.IsNull())
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
                                var entityServices = this.businessServices4Master.FindBy(Services4Master => Services4Master.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();
                                var entity = this.businessServices4Section345Master.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {
                                    entity.Service_Id = entityServices.ID;
                                    entity.SubSubCat_Id = model.SubSubCat_Id;
                                    entity.Heading = model.Heading;
                                    entity.SectionType_ID = busConstant.Code.SECTION_TYPE;
                                    entity.SectionTypeValue = model.SectionTypeValue;
                                    entity.DisplayIndex = model.DisplayIndex;
                                    entity.IsActive = model.IsActive;
                                    entity.TotalViews = model.TotalViews;
                                    entity.Url = model.Url;
                                    entity.Metadata = model.Metadata;
                                    entity.Keyword = model.Keyword;
                                    entity.MetaDescription = model.MetaDescription;
                                    entity.Tenant_ID = model.Tenant_ID;
                                    entity.Tenant = null;
                                    //entity.Services4Section345Masters = null;
                                    entity.SubSubCategoriesMaster = null;
                                    entity.Services4Master = null;
                                    this.businessServices4Section345Master.Update(entity);

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
        [Route("Post/Services4Section345Master/Delete")]
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
                            this.businessServices4Section345Master.Delete(Convert.ToInt64(Id));


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
        [Route("Get/Services4Section345Master/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetServices4Section345MasterByTenantIdAsync(long Id)
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
                            var entities = this.businessServices4Section345Master.FindBy(product => product.Tenant_ID == Id).Select(x => new ViewModel.Services4Section345MasterDropdownListViewModel
                            {
                                ID = x.ID,
                                Heading = x.Heading
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.Services4Section345MasterDropdownListViewModel>>()
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