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
    public class AddDataController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.ICommentsReply businessCommentsReply;
        private Business.Interface.IBlogCommentsDetails businessBlogCommentsDetails;
        private Business.Interface.IBlogMaster businessBlogMaster;

        public AddDataController(Business.Interface.IBlogCommentsDetails IBlogCommentsDetails, Business.Interface.IBlogMaster IBlogMaster, Business.Interface.ICommentsReply ICommentsReply)
        {
            this.businessCommentsReply = ICommentsReply;
            this.businessBlogCommentsDetails = IBlogCommentsDetails;
            this.businessBlogMaster = IBlogMaster;

        }

        #endregion

        #region [ActionMethod]

        [HttpPost]
        [Route("Post/AddData/BlogCommentsDetails/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.BlogCommentsDetailsCreateOrEditViewModel model)
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
                            var productId = businessBlogCommentsDetails.FindBy(Services1Section4 => Services1Section4.Tenant_ID == model.Tenant_ID && Services1Section4.ID == model.ID).FirstOrDefault();

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

                                var entity = new EntityModel.BlogCommentsDetails();
                                entity.Tenant = null;
                                entity.BlogMaster = null;
                                entity.Name = model.Name;
                                entity.EmailId = model.EmailId;
                                entity.Comment = model.Comment;
                                entity.Blog_Id = model.Blog_Id;
                                entity.IsActive = model.IsActive;
                                entity.IsAdminApproved = false;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessBlogCommentsDetails.Create(entity);
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

        [HttpPost]
        [Route("Post/AddData/CommentsReply/CreateAsync")]
        public async Task<ActionResult> CreateAsync(ViewModel.CommentsReplyCreateOrEditViewModel model)
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
                            var productId = businessCommentsReply.FindBy(Services1Section4 => Services1Section4.Tenant_ID == model.Tenant_ID && Services1Section4.ID == model.ID).FirstOrDefault();

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

                                var entity = new EntityModel.CommentsReply();
                                entity.Tenant = null;
                                entity.BlogMaster = null;
                                entity.BlogCommentsDetails = null;
                                entity.Blog_Id = model.Blog_Id;
                                entity.BCD_Id = model.BCD_Id;
                                entity.Name = model.Name;
                                entity.EmailId = model.EmailId;
                                entity.Comment = model.Comment;
                                entity.Blog_Id = model.Blog_Id;
                                entity.IsActive = model.IsActive;
                                entity.IsAdminApproved = false;
                                entity.Tenant_ID = model.Tenant_ID;
                                this.businessCommentsReply.Create(entity);
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



        #endregion

    }
}