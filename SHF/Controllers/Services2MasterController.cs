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
    public class Services2MasterController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private Business.Interface.IServices2Master businessServices2Master;
        private Business.Interface.ITenant businessTenant;
        private Business.Interface.ISubSubCategoriesMaster businessSubSubCategoriesMaster;
        

        public Services2MasterController(Business.Interface.IMessage Imessage, Business.Interface.IServices2Master IServices2Master, Business.Interface.ITenant Itenant, Business.Interface.ISubSubCategoriesMaster IsubSubCategoriesMaster)
        {
            this.businessMessage = Imessage;
            this.businessServices2Master = IServices2Master;
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
        [Route("Configurations/Master/ServiceType2/Index")]
        [Route("Settings/Master/ServiceType2/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }
        [HttpPost]
        [Route("Post/ServiceType2/IndexAsync")]
        [ValidateAntiForgeryTokens]
        public async Task<ActionResult> IndexAsync()
        {
            BusinessResultViewModel<ViewModel.Services2MasterIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        long? tenantId = Request.Form.AllKeys.Contains("tenantId") ? Convert.ToInt64(Request.Form.GetValues("tenantId").FirstOrDefault()) : busConstant.Numbers.Integer.ZERO;
                        tenantId = tenantId > busConstant.Numbers.Integer.ZERO ? tenantId : null;

                        businessResult = this.businessServices2Master.Index(Request, tenantId);
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
        [Route("Post/Services2Master/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.Services2MasterCreateOrEditViewModel model)
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
                            var catId = businessServices2Master.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.SubSubCat_Id == model.SubSubCat_Id).FirstOrDefault();

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
                                var entity = new EntityModel.Services2Master();
                                // Mapper.Map(model, entity);
                                //entity.ID = model.ID;
                                // Mapper.Map(model, entity);
                                string temppath = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY));
                                string path = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, model.Tenant_ID));
                                //string path = Server.MapPath("~/Uploads/");
                                if (!Directory.Exists(path))
                                {
                                    Directory.CreateDirectory(path);
                                }
                                var saveToFileLoc = temppath + "/" + model.BannerImageFile.FileName;
                                model.BannerImageFile.SaveAs(saveToFileLoc);
                                //Image file compress
                                CompressImage.CompressImageMethod(saveToFileLoc, path, 30);
                                System.IO.File.Delete(saveToFileLoc);
                                entity.BannerImagePath = model.BannerImageFile.FileName;
                                entity.BannerImagePath = model.BannerImagePath;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Cat_Id = entitySubSubCategoryName.Cat_Id;
                                entity.SubCat_Id = entitySubSubCategoryName.SubCat_Id;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.SubSubCategoryName = entitySubSubCategoryName.SubSubCategoryName;
                                entity.BannerHeadingDescription = model.BannerHeadingDescription;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Section1Description = model.Section1Description;
                                entity.Section2FAQDescription = model.Section2FAQDescription;
                                entity.Section3DownloadDescription = model.Section3DownloadDescription;
                                entity.Section4PriceingHeading = model.Section4PriceingHeading;
                                entity.Section4PriceingDescription = model.Section4PriceingDescription;
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
                                this.businessServices2Master.Create(entity);
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
        [Route("Get/Services2Master/EditAsync")]
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
                            var entity = this.businessServices2Master.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.Services2MasterCreateOrEditViewModel();
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
                                model.Section2FAQDescription = entity.Section2FAQDescription;
                                model.Section3DownloadDescription = entity.Section3DownloadDescription;
                                model.Section4PriceingHeading = entity.Section4PriceingHeading;
                                model.Section4PriceingDescription = entity.Section4PriceingDescription;
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


                                var response = new JsonResponse<Services2MasterCreateOrEditViewModel>()
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
        [Route("Post/Services2Master/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.Services2MasterCreateOrEditViewModel model)
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
                            var CategoriesData = businessServices2Master.FindBy(Categories => Categories.Tenant_ID == model.Tenant_ID && Categories.ID != model.ID).FirstOrDefault();

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
                                var entitySubSubCategoryName = this.businessSubSubCategoriesMaster.GetById(Convert.ToInt64(model.SubSubCat_Id));
                                var entity = this.businessServices2Master.GetById(Convert.ToInt64(model.ID));
                                if (entity.IsNotNull())
                                {
                                    // Mapper.Map(model, entity);
                                    string temppath = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY));
                                    string path = Server.MapPath("~/" + String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, model.Tenant_ID));
                                    //string path = Server.MapPath("~/Uploads/");
                                    if (!Directory.Exists(path))
                                    {
                                        Directory.CreateDirectory(path);
                                    }
                                    var saveToFileLoc = temppath + "/" + model.BannerImageFile.FileName;
                                    model.BannerImageFile.SaveAs(saveToFileLoc);
                                    //Image file compress
                                    CompressImage.CompressImageMethod(saveToFileLoc, path, 30);
                                    System.IO.File.Delete(saveToFileLoc);
                                entity.BannerImagePath = model.BannerImageFile.FileName;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Cat_Id = entitySubSubCategoryName.Cat_Id;
                                entity.SubCat_Id = entitySubSubCategoryName.SubCat_Id;
                                entity.SubSubCat_Id = model.SubSubCat_Id;
                                entity.SubSubCategoryName = entitySubSubCategoryName.SubSubCategoryName;
                                entity.BannerHeadingDescription = model.BannerHeadingDescription;
                                entity.BannerOnHeading = model.BannerOnHeading;
                                entity.Section1Description = model.Section1Description;
                                entity.Section2FAQDescription = model.Section2FAQDescription;
                                entity.Section3DownloadDescription = model.Section3DownloadDescription;
                                entity.Section4PriceingHeading = model.Section4PriceingHeading;
                                entity.Section4PriceingDescription = model.Section4PriceingDescription;
                                entity.DisplayIndex = model.DisplayIndex;
                                entity.Url = model.Url;
                                entity.Metadata = model.Metadata;
                                entity.MetaDescription = model.MetaDescription;
                                entity.Keyword = model.Keyword;
                                entity.TotalViews = model.TotalViews;
                                entity.IsActive = model.IsActive;
                                entity.Tenant_ID = model.Tenant_ID;
                                entity.IsDeleted= model.IsDeleted;
                                entity.CreatedBy = model.CreatedBy;
                                entity.UpdatedBy = model.UpdatedBy;
                                entity.CreatedOn = model.CreatedOn;
                                entity.UpdatedOn = model.UpdatedOn;

                                entity.Tenant = null;
                                entity.CategoriesMaster = null;
                                entity.SubCategoriesMaster = null;
                                entity.SubSubCategoriesMaster = null;
                                
                                this.businessServices2Master.Update(entity);

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
        [Route("Post/Services2Master/Delete")]
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
                                this.businessServices2Master.Delete(Convert.ToInt64(Id));


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
        [Route("Get/Services2Master/DropdownListbyTenantAsync")]
        public async Task<ActionResult> GetServices2MasterByTenantIdAsync(long? Id)
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
                          
                            var entities= this.businessSubSubCategoriesMaster.GetAll().Where(x =>(x.Tenant_ID == Id && x.ServiceTypeValue==busConstant.Code.CodeValue.ServiceType.SERVICE_2))
                                .Select(x => new ViewModel.Services2MasterDropdownListViewModel
                            {
                                ID = x.ID,
                                SubSubCategoryName = x.SubSubCategoryName
                            });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.Services2MasterDropdownListViewModel>>()
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

        [HttpPost]
        [Route("Post/Services2Master/FileUpload")]
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
            var saveToFileLoc = path + "/" + fileName;
            // var destToFileLoc = path + "/" + fileName;
            var fileStream = new FileStream(saveToFileLoc, FileMode.Create, FileAccess.ReadWrite);
            fileStream.Write(bytes, 0, length);
            fileStream.Close();
            //Image file compress
           // CompressImage.CompressImageMethod(saveToFileLoc, path, 30);
            //System.IO.File.Delete(saveToFileLoc);
            return string.Format("{0} bytes uploaded", bytes.Length);
        }

        #endregion

    }
}