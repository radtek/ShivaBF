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

    public class MessageController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IMessage businessMessage;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public MessageController(Business.Interface.IMessage Imessage)
        {
            this.businessMessage = Imessage;

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
        // GET: Message

        [HttpGet]
        [Access]
        [OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Configurations/Master/Message/Index")]
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId<long>();
            ViewBag.TenantID = UserManager.FindById(userId).Tenant_ID.GetValueOrDefault();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryTokens]
        [Route("Post/Message/IndexAsync")]
        public async Task<ActionResult> IndexAsync()
        {
            ViewModel.BusinessResultViewModel<ViewModel.MessageIndexViewModel> businessResult;
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        businessResult = this.businessMessage.Index(Request);
                        transaction.Complete();
                    }
                    catch (Exception ex)
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
        [Route("Post/Message/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.MessageCreateOrEditViewModel model)
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
                            var entity = new EntityModel.Message();
                            Mapper.Map(model, entity);
                            this.businessMessage.Create(entity);
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
        [Route("Get/Message/EditAsync")]
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
                                Icon = busConstant.Messages.Icon.ERROR,
                                Title = busConstant.Messages.Title.ERROR,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST
                            };
                            Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entity = this.businessMessage.GetById(Id);

                            if (entity.IsNotNull())
                            {
                                var model = new ViewModel.MessageCreateOrEditViewModel();

                                Mapper.Map(entity, model);

                                var response = new JsonResponse<ViewModel.MessageCreateOrEditViewModel>()
                                {
                                    Type = busConstant.Messages.Type.RESPONSE,
                                    Icon = busConstant.Messages.Icon.SUCCESS,
                                    Title = busConstant.Messages.Title.SUCCESS,
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
                                    Icon = busConstant.Messages.Icon.ERROR,
                                    Title = busConstant.Messages.Title.ERROR,
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
        [Route("Post/Message/EditAsync")]
        public async Task<ActionResult> EditAsync(ViewModel.MessageCreateOrEditViewModel model)
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
                            var entity = new EntityModel.Message();
                            Mapper.Map(model, entity);
                            this.businessMessage.Update(entity);
                            transaction.Complete();

                            var response = new JsonResponse<dynamic>()
                            {
                                Type = busConstant.Messages.Type.RESPONSE,
                                Icon = busConstant.Messages.Icon.SUCCESS,
                                Title = busConstant.Messages.Title.SUCCESS,
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
        [AllowAnonymous]
        [Route("Get/Messgae/GetAllMessagesAsync")]
        public async Task<ActionResult> GetAllMessages()
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        var entity = this.businessMessage.GetAll();
                        transaction.Complete();
                        var response = new JsonResponse<IEnumerable<EntityModel.Message>>()
                        {
                            Type = busConstant.Messages.Type.RESPONSE,
                            Entity = entity
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