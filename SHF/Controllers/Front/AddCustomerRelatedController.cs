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

        [HttpPost]
        [Route("Post/AddData/CustomerSurfing/CustomerServiceOrder")]
        public async Task<ActionResult> CustomerServiceOrder(SHF.ViewModel.FrontEnd.LoginCustomerMaster model)
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
                                    string mailcontent = "<div style='margin:0'><table width = '750' align = 'center' border = '0' cellspacing = '0' cellpadding = '0'>";
                                    mailcontent += "<tbody><tr>";
                                    mailcontent += "<td align= 'left' valign='middle' style='padding:10px 0px'>";
                                    mailcontent += "<a href='https://www.shivafilings.com' rel = 'noreferrer' target= '_blank'>";
                                    mailcontent += "<img alt='LOGO' src='logo.png' border='0' style='width: 120px;'>";
                                    mailcontent += "</a></td></tr>";
                                    mailcontent += "<tr><td align='left' valign='top' style='font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#373737;background-color:#fff;padding:20px;border:solid 1px #bcc2cf'>";
                                    mailcontent += "Dear <strong> Mukund Jha </strong>,<br><br> Thank you for your order from";
                                    mailcontent += "<a style='font-family:Arial,Helvetica,sans-serif;font-size:12px;color:#e85f04;text-decoration:underline' href='' target='_blank'> https://www.shivafilings.com</a>";
                                    mailcontent += "<br><br> For your convenience, we have included a copy of your order below.The charge will appear on your credit card / Account Statement as<strong><a href ='http://www.ccavenue.com' rel='noreferrer' target ='_blank'> www.ccavenue.com </a></strong>";
                                    mailcontent += "<br><br><br>";
                                    mailcontent += "<table width='100%' border='0' cellspacing='0' cellpadding='0'><tbody>";
                                    mailcontent += "<tr><td align='left' valign='top' style='background-color:#fff;padding:15px 20px;border:solid 1px #dbdfe6'>";
                                    mailcontent += "<table width='100%' style='border:solid 1px #e4e6eb' border='0' cellspacing='0' cellpadding='6'>";
                                    mailcontent += "<tbody>";
                                    mailcontent += "<tr><td width= '47%' height='18' align= 'left' valign='middle' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737;background-color:#f7f7f7'>";
                                    mailcontent += "<strong>Order#</strong></td>";
                                    mailcontent += "<td width= '35%' height= '18' align='left' valign='middle' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737;background-color:#f7f7f7;border-left:solid 1px #e4e6eb'>";
                                    mailcontent += "<strong>CCAvenue Reference #</strong></td>";
                                    mailcontent += "<td width='18%' height='18' align='left' valign='middle' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737;background-color:#f7f7f7;border-left:solid 1px #e4e6eb'>";
                                    mailcontent += "<strong> Order Date </strong>";
                                    mailcontent += "</td></tr>";
                                    mailcontent += "<tr><td height= '1' align='left' valign='middle' style='background-color:#e4e6eb;padding:0px' colspan='3'>";
                                    mailcontent += "<img width= '1' height= '1' src = 'https://ci3.googleusercontent.com/proxy/Y4bHfZQ8yJgrMK4PsT2FtjaGTnURMS7uNGSZN_opsDUkHHyUYh8L_8Uvhop4n47Qxw2KpLyy1P1CpiYO_LbE4F91lh_P1A=s0-d-e1-ft#https://secure.ccavenue.com/images/blank_spacer.gif' class='CToWUd'></td></tr>";
                                    mailcontent += "<tr>";
                                    mailcontent += "<td width= '47%' height= '18' align = 'left' valign = 'middle' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' > 1554366133928508682962 </td>";
                                    mailcontent += "<td width = '35%' height = '18' align = 'left' valign = 'middle' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737;border-left:solid 1px #e4e6eb'> 108551039644 </td>";
                                    mailcontent += "<td width = '18%' height = '18' align = 'left' valign = 'middle' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737;border-left:solid 1px #e4e6eb'> 04 / 04 / 2019 13:56:15 </td>";
                                    mailcontent += "</tr>";
                                    mailcontent += "</tbody></table><br><br>";
                                    mailcontent += "<table width='100%' border='0' cellspacing='0' cellpadding='0'>";
                                    mailcontent += "<tbody>";
                                    mailcontent += "<tr>";
                                    mailcontent += "<td height = '25' align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:15px;color:#0072c6;border-bottom:solid 1px #dbdfe6' colspan = '3' > Billing Details </td>";
                                    mailcontent += "</tr><tr><td align = 'left' valign = 'top' colspan = '3' > &nbsp;</td>";
                                    mailcontent += "</tr><tr>";
                                    mailcontent += "<td width = '412' align = 'left' valign = 'top' >< table width = '100%' border = '0' cellspacing = '0' cellpadding = '4'>";
                                    mailcontent += "<tbody>";
                                    mailcontent += "<tr><td width = '23%' align = 'right' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>";
                                    mailcontent += "<strong>Customer:</strong>";
                                    mailcontent += "</td>";
                                    mailcontent += "<td width = '77%' align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>";
                                    mailcontent += "Mukund Jha & nbsp; &nbsp;| &nbsp; &nbsp;";
                                    mailcontent += "<a style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' href = 'mailto:' rel = 'noreferrer' target = '_blank' > mukund.jha@< wbr > mukundjhaco.com </a>";
                                    mailcontent += "& nbsp; &nbsp;| &nbsp; &nbsp; 8369907541</td>";
                                    mailcontent += "</tr>";
                                    mailcontent += "<tr><td align = 'right' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>";
                                    mailcontent += "<strong> Address:</strong></td>";
                                    mailcontent += "<td align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>";
                                    mailcontent += "Flat No.B - 1106,  Amar Harmony, Plot No. 22, Sector - 4,  Taloja Panchnand, Taloja Phase 1, Raigad,  Maharashtra ,Maharashtra ,Raigad 410208.India</td>";
                                    mailcontent += "</tr><tr>";
                                    mailcontent += "<td align = 'right' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>";
                                    mailcontent += "<strong>Customer IP:</strong>";
                                     
                                                                                                     </ td >
                                     
                                                                                                     < td align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' > 49.33.243.250 </ td >
                                              
                                                                                                          </ tr >
                                              
                                                                                                          < tr >
                                              
                                                                                                              < td align = 'right' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' >< strong > Pay Mode:</ strong ></ td >
                                                         
                                                                                                                         < td align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' > Net Banking - RBL Bank </ td >
                                                                  
                                                                                                                              </ tr >
                                                                  
                                                                                                                              < tr >
                                                                  
                                                                                                                                  < td align = 'right' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' >
                                                                       
                                                                                                                                           < strong > Bank Ref #:</strong>
                                                                </ td >
                                                                          
                                                                                                                                          < td align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' > 10322823 </ td >
                                                                               
                                                                                                                                           </ tr >
                                                                               
                                                                                                                                           < tr >
                                                                               
                                                                                                                                               < td align = 'right' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' >
                                                                                    
                                                                                                                                                        < strong > Instructions:</ strong >
                                                                                       
                                                                                                                                                       </ td >
                                                                                       
                                                                                                                                                       < td align = 'left' valign = 'top' style = 'font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737' ></ td >
                                                                                            

                                                                                                                                                        </ tr >
                                                                                            
                                                                                                                                                    </ tbody >
                                                                                            
                                                                                                                                                </ table >
                                                                                            

                                                                                                                                                </ td >
                                                                                            
                                                                                                                                                < td width = '20' align = 'left' valign = 'top' >
                                                                                                 
                                                                                                                                                         < img width = '20' height = '1' src = 'https://ci3.googleusercontent.com/proxy/Y4bHfZQ8yJgrMK4PsT2FtjaGTnURMS7uNGSZN_opsDUkHHyUYh8L_8Uvhop4n47Qxw2KpLyy1P1CpiYO_LbE4F91lh_P1A=s0-d-e1-ft#https://secure.ccavenue.com/images/blank_spacer.gif' class='CToWUd'>
                                                    </td>	        
                                                    <td width = '244' align='right' valign='top'><table width = '244' border='0' cellspacing='0' cellpadding='10'>	          
                                                        <tbody>
                                                            <tr>		            
                                                            <td align = 'left' valign='top' style='background-color:#f7f7f7;border:solid 1px #e4e6eb'>		            
                                                                <table width = '244' border='0' cellspacing='0' cellpadding='0'>		                
                                                                    <tbody>
                                                                        <tr>		                  
                                                                            <td width = '51%' height='19' align='right' valign='top' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>Order Amount:&nbsp;</td>		                  
                                                                            <td width = '16%' height='19' align='center' valign='top' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>INR</td>	                  
                                                                            <td width = '33%' height='19' align='right' valign='top' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>45899.00</td>		                
                                                                        </tr>		                
                                                                        <tr>	                  
                                                                            <td colspan = '3' >
                                                                                < img width='1' height='1' src='https://ci3.googleusercontent.com/proxy/Y4bHfZQ8yJgrMK4PsT2FtjaGTnURMS7uNGSZN_opsDUkHHyUYh8L_8Uvhop4n47Qxw2KpLyy1P1CpiYO_LbE4F91lh_P1A=s0-d-e1-ft#https://secure.ccavenue.com/images/blank_spacer.gif' class='CToWUd'>
                                                                            </td>		                
                                                                        </tr>	                
                                                                        <tr>	                  
                                                                            <td height = '22' align='right' valign='bottom' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>
                                                                                <strong>Net Payable:&nbsp;</strong>
                                                                            </td>		                  
                                                                            <td height = '20' align='center' valign='bottom' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'>
                                                                                <strong>INR</strong>
                                                                            </td>		                  
                                                                            <td height = '20' align='right' valign='bottom' style='font-family:Arial,Helvetica,sans-serif;font-size:11px;color:#373737'><strong>45899.00</strong>

                                                                            </td>	
                                                                        </tr>	 
                                                                    </tbody>
                                                                </table>
                                                            </td>	  
                                                            </tr>	
                                                        </tbody>
                                                       </table>
                                                    </td>	 
                                                </tr>		
                                            </tbody>
                                        </table>		";

                                    transaction.Complete();
                                    //return Json(response, JsonRequestBehavior.AllowGet);
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