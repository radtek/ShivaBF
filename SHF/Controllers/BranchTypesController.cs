using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Inventory.Helper;
//using Omu.AwesomeMvc;
using Inventory.Web.Filters;
using System.Transactions;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using System.Net;
using Inventory.Models;
using Inventory.ViewModel;

namespace Inventory.Web.Controllers
{
    public class BranchTypesController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IBranchType business;
        //private Business.BusinessLogic.BranchType businessL;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        //public BranchTypeController()
        //{
        //}
        public BranchTypesController(Business.Interface.IBranchType IbranchType)
        {
            this.business = IbranchType;
        }


        //public BranchTypeController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        //{
        //    UserManager = userManager;
        //    SignInManager = signInManager;
        //}

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



        // GET: BranchType
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> IndexAsync()
        {
            List<BranchTypeIndexViewModel> list;
            try
            {
                list = new List<BranchTypeIndexViewModel>();

                dynamic businessResult = await this.business.IndexAsync(Request);
                //For Mapping domain entity to view model    
                AutoMapper.Mapper.Map(businessResult.data, list);

                var response = new { draw = businessResult.Draw, recordsFiltered = businessResult.RecordsFiltered, recordsTotal = businessResult.RecordsTotal, data = businessResult.Data };

                return Json(data: response, behavior: JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                list = null;
            }



        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [AuditAttribute]
        [ValidateAntiForgeryTokens]
        [Route("Post/BranchType/CreateAsync")]
        public async Task<ActionResult> CreateAsync(BranchTypeCreateViewModel model)
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
                            var entity = new Entity.BranchType();
                            Mapper.Map(model, entity);
                            await this.business.CreateAsync(entity);
                            //unitOfWork.BranchTypeRepository.Insert(entity);
                            transaction.Complete();
                            var response = new JsonResponse()
                            {
                                Type = busConstant.Messages.Type.Response,
                                Message = busConstant.Messages.Type.Responses.Save,
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
        [AllowAnonymous]
        public async Task<ActionResult> Edit()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("Get/BranchType/EditAsync")]
        public async Task<ActionResult> EditAsync(long Id)
        {
            try
            {
                if (Id == default(long))
                {
                    var response = new JsonResponse()
                    {
                        Type = busConstant.Messages.Type.Exception,
                        Message = busConstant.Messages.Type.Exceptions.BadRequest,
                        Errors = null
                    };
                    Response.StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest);
                    return Json(response);
                }
                else
                {
                    //var entity = unitOfWork.CourseRepository.GetByID(Id);
                    var entity = this.business.GetByIdAsyc(Id);
                    if (entity.IsNotNull())
                    {
                        var model = new ViewModel.BranchTypeEditViewModel();

                        Mapper.Map(entity, model);

                        var response = new JsonResponse()
                        {
                            Type = busConstant.Messages.Type.Response,
                            Message = null,
                            Errors = null,
                            Entity = model
                        };
                        return Json(response);
                    }
                    else
                    {
                        var response = new JsonResponse()
                        {
                            Type = busConstant.Messages.Type.Exception,
                            Message = busConstant.Messages.Type.Exceptions.NotFound,
                            Errors = null,
                            Entity = null
                        };
                        return Json(response);
                    }
                }
            }
            catch (Exception ex)
            {
                return ExceptionResponse(ex);
            }
            finally
            {
                unitOfWork.Dispose();
            }
        }



        [HttpPost]
        [AuditAttribute]
        [ValidateAntiForgeryTokens]
        [Route("Post/BranchType/CreateAsync")]
        public async Task<ActionResult> EditAsync(BranchTypeEditViewModel model)
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
                            var entity = new Entity.BranchType();
                            Mapper.Map(model, entity);
                            await this.business.UpdateAsync(entity);
                            //unitOfWork.BranchTypeRepository.Insert(entity);
                            transaction.Complete();
                            var response = new JsonResponse()
                            {
                                Type = busConstant.Messages.Type.Response,
                                Message = busConstant.Messages.Type.Responses.Save,
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


    }
}