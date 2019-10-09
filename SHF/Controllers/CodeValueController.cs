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
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace SHF.Controllers
{
    public class CodeValueController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.ICode businessCode;
        private Business.Interface.ICodeValue businessCodeValue;

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;



        public CodeValueController(Business.Interface.ICode Icode, Business.Interface.ICodeValue IcodeValue)
        {
            this.businessCode = Icode;
            this.businessCodeValue = IcodeValue;
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

        #region [Action Methode]


        [HttpGet]
        [Route("Get/CodeValue/CodeValueByCodeAsync")]
        public async Task<ActionResult> GetCodeValueByCode(long Id)
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
                                Title = busConstant.Messages.Title.ERROR,
                                Icon = busConstant.Messages.Icon.ERROR,
                                Message = busConstant.Messages.Type.Exceptions.BAD_REQUEST,
                                StatusCode = Convert.ToInt32(HttpStatusCode.BadRequest)
                            };

                            return Json(response, JsonRequestBehavior.AllowGet);
                        }
                        else
                        {
                            var entities = this.businessCodeValue.FindBy(codeValue => codeValue.Code_ID == Id)
                                               .Select(x => new ViewModel.CodeValueDropDownListViewModel
                                               {
                                                   Value = x.Value,
                                                   Description = x.Description
                                               });

                            if (entities.IsNotNull())
                            {
                                var response = new JsonResponse<IEnumerable<ViewModel.CodeValueDropDownListViewModel>>()
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
                                    Title = busConstant.Messages.Title.ERROR,
                                    Icon = busConstant.Messages.Icon.ERROR,
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




        [HttpGet]
        [AllowAnonymous]
        [Route("Get/CodeValue/GetAllCodeValuesAsync")]
        public async Task<ActionResult> GetAllCodeValues()
        {
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        var entity = SHF.Business.busCache.CodeValueTable();
                        transaction.Complete();
                        var response = new JsonResponse<IEnumerable<EntityModel.CodeValue>>()
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