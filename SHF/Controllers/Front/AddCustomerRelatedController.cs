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
        private Business.Interface.ICustomerMaster businessCustomerMaster;
        private Business.Interface.ICustomerMasterInfo businessCustomerMasterInfo;

        public AddCustomerRelatedController(Business.Interface.ICustomerSurfing ICustomerSurfing, Business.Interface.ICustomerIPInfoMapping ICustomerIPInfoMapping, Business.Interface.ICustomerMaster ICustomerMaster, Business.Interface.ICustomerMasterInfo ICustomerMasterInfo)
        {
            this.businessCustomerSurfing = ICustomerSurfing;
            this.businessCustomerIPInfoMapping = ICustomerIPInfoMapping;
            this.businessCustomerMaster = ICustomerMaster;
            this.businessCustomerMasterInfo = ICustomerMasterInfo;
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
                            var entity = new EntityModel.CustomerSurfing();
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
        [HttpPost]
        [Route("Post/AddData/CustomerSurfing/RegisterCustomer")]
        public async Task<ActionResult> RegisterCustomer(SHF.ViewModel.FrontEnd.CustomerMaster model)
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
                            var entity = new EntityModel.CustomerMaster();
                            entity.Tenant = null;
                            entity.FirstName = model.FirstName;
                            entity.LastName = model.LastName;
                            entity.EmailID = model.EmailID;
                            entity.Password = model.Password;
                            entity.DOB = DateTime.Now;
                            entity.Tenant_ID = Convert.ToInt64(model.tenantId);
                            this.businessCustomerMaster.Create(entity);
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
        [Route("Post/AddData/CustomerSurfing/UpdateCustomerLogon")]
        public async Task<ActionResult> UpdateCustomerLogon(SHF.ViewModel.FrontEnd.CustomerMasterInfo model)
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
                            if (model.CustomerMaster_ID.IsNotNull())
                            {
                                var entity = this.businessCustomerMasterInfo.GetAll().Where(cust => cust.CustomerMaster_ID == model.CustomerMaster_ID).FirstOrDefault();
                                if (entity.IsNotNull())
                                {

                                    entity.Tenant = null;
                                    entity.InfoDateOfLastLogon = DateTime.Now;
                                    entity.InfoNumberOfLogons = entity.InfoNumberOfLogons + 1;
                                    this.businessCustomerMasterInfo.Update(entity);
                                    transaction.Complete();
                                }
                            }
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
        [Route("Post/AddData/CustomerSurfing/LoginCheck")]
        public async Task<ActionResult> LoginCheck(SHF.ViewModel.FrontEnd.LoginCustomerMaster model)
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
                            if (model.UserName.IsNotNull() && model.Password.IsNotNull())
                            {
                                var entity = this.businessCustomerMaster.GetAll().Where(cust => cust.EmailID == model.UserName && cust.Password == model.Password).FirstOrDefault();
                                if (entity.IsNotNull())
                                {
                                    var response = new JsonResponse<EntityModel.CustomerMaster>()
                                    {
                                        Type = busConstant.Messages.Type.RESPONSE,
                                        Entity = entity
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