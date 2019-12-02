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


namespace SHF.Controllers.Front
{
    [AllowAnonymous]
    public class AddCustomerRelatedController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.ICustomerSurfing businessCustomerSurfing;
        private Business.Interface.ICustomerIPInfoMapping businessCustomerIPInfoMapping;

        public AddCustomerRelatedController(Business.Interface.ICustomerSurfing ICustomerSurfing, Business.Interface.ICustomerIPInfoMapping ICustomerIPInfoMapping)
        {
            this.businessCustomerSurfing = ICustomerSurfing;
            this.businessCustomerIPInfoMapping = ICustomerIPInfoMapping;
        }

        #endregion

        #region [ActionMethod]

        [HttpPost]
        [Route("Post/AddData/CustomerSurfing/AddCustomerSurfing")]
        public async Task<ActionResult> AddCustomerSurfing(SHF.ViewModel.FrontEnd.CustomerSurfingViewModel model)
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
                            var entity =new EntityModel.CustomerSurfing();
                            entity.Tenant = null;
                            entity.CustomerMaster = null;
                            entity.CustomerMaster_ID = Convert.ToInt64(model.CustomerMaster_ID);
                            entity.PageUrl = model.PageUrl;
                            entity.Session_ID = model.Session_ID;
                            entity.Tenant_ID = Convert.ToInt64(model.tenantId);
                            this.businessCustomerSurfing.Create(entity);
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

        [HttpPost]
        [Route("Post/AddData/CustomerSurfing/AddCustomerIPInfoMapping")]
        public async Task<ActionResult> AddCustomerIPInfoMapping(SHF.ViewModel.FrontEnd.CustomerIPInfoMapping model)
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
                            var entity = new EntityModel.CustomerIPInfoMapping();
                            entity.Tenant = null;
                            entity.CustomerMaster = null;
                            entity.IPInfo = null;
                            entity.CustomerMaster_ID = Convert.ToInt64(model.CustomerMaster_ID);
                            entity.IPInfo_ID = Convert.ToInt64(model.IPInfo_ID);
                            entity.Session_ID = model.Session_ID;
                            entity.Tenant_ID = Convert.ToInt64(model.tenantId);
                            this.businessCustomerIPInfoMapping.Create(entity);
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

        #endregion

    }
}