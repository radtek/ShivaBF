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
    public class AddServiceRelatedInfoController : BaseController
    {
        #region [Field & Contructor]

        private Business.Interface.IServices1Master businessServices1Master;
        private Business.Interface.IServices2Master businessServices2Master;
        private Business.Interface.IServices3Master businessServices3Master;
        private Business.Interface.IServices4Master businessServices4Master;
        private Business.Interface.IServices5Master businessServices5Master;
        private Business.Interface.IServices6Master businessServices6Master;
        private Business.Interface.IServices7Master businessServices7Master;
        private Business.Interface.IServices8Master businessServices8Master;
        private Business.Interface.IBlogMaster businessBlogMaster;
        private Business.Interface.IHomePageSection2 businessHomePageSection2;


        public AddServiceRelatedInfoController(Business.Interface.IServices1Master IServices1Master, Business.Interface.IServices2Master IServices2Master, Business.Interface.IServices3Master IServices3Master, Business.Interface.IServices4Master IServices4Master, Business.Interface.IServices5Master IServices5Master
            , Business.Interface.IServices6Master IServices6Master, Business.Interface.IServices7Master IServices7Master, Business.Interface.IServices8Master IServices8Master, Business.Interface.IBlogMaster IBlogMaster, Business.Interface.IHomePageSection2 IHomePageSection2)
        {
            this.businessServices1Master = IServices1Master;
            this.businessServices2Master = IServices2Master;
            this.businessServices3Master = IServices3Master;
            this.businessServices4Master = IServices4Master;
            this.businessServices5Master = IServices5Master;
            this.businessServices6Master = IServices6Master;
            this.businessServices7Master = IServices7Master;
            this.businessServices8Master = IServices8Master;
            this.businessBlogMaster = IBlogMaster;
            this.businessHomePageSection2 = IHomePageSection2;
        }

        #endregion

        #region [ActionMethod]

        [HttpPost]
        [Route("Post/AddData/ServiceRelatedInfo/AddServiceTotalViews")]
        public async Task<ActionResult> AddServiceTotalViews(SHF.ViewModel.FrontEnd.ServiceInfoViewModel model)
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
                            switch (model.page_type)
                            {

                                case "page1":
                                    var servicetype1 = UnitOfWork.Services1MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype1 != null)
                                    {
                                        servicetype1.TotalViews = servicetype1.TotalViews + 1;
                                        this.businessServices1Master.Update(servicetype1);
                                    }
                                        break;
                                case "page2":
                                    var servicetype2 = UnitOfWork.Services2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype2 != null)
                                    {
                                        servicetype2.TotalViews = servicetype2.TotalViews + 1;
                                        this.businessServices2Master.Update(servicetype2);
                                    }
                                    break;
                                case "page3":
                                    var servicetype3 = UnitOfWork.Services3MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype3 != null)
                                    {
                                        servicetype3.TotalViews = servicetype3.TotalViews + 1;
                                        this.businessServices3Master.Update(servicetype3);
                                    }
                                    break;
                                case "page4":
                                    var servicetype4 = UnitOfWork.Services4MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype4 != null)
                                    {
                                        servicetype4.TotalViews = servicetype4.TotalViews + 1;
                                        this.businessServices4Master.Update(servicetype4);
                                    }
                                    break;
                                case "page5":
                                    var servicetype5 = UnitOfWork.Services5MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype5 != null)
                                    {
                                        servicetype5.TotalViews = servicetype5.TotalViews + 1;
                                        this.businessServices5Master.Update(servicetype5);
                                    }
                                    break;
                                case "page6":
                                    var servicetype6 = UnitOfWork.Services6MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype6 != null)
                                    {
                                        servicetype6.TotalViews = servicetype6.TotalViews + 1;
                                        this.businessServices6Master.Update(servicetype6);
                                    }
                                    break;
                                case "page7":
                                    var servicetype7 = UnitOfWork.Services7MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype7 != null)
                                    {
                                        servicetype7.TotalViews = servicetype7.TotalViews + 1;
                                        this.businessServices7Master.Update(servicetype7);
                                    }
                                    break;
                                case "page8":
                                    var servicetype8 = UnitOfWork.Services8MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetype8 != null)
                                    {
                                        servicetype8.TotalViews = servicetype8.TotalViews + 1;
                                        this.businessServices8Master.Update(servicetype8);
                                    }
                                    break;
                                case "blog":
                                    var servicetypeBlog = UnitOfWork.BlogMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId) && x.Url == model.url).FirstOrDefault();
                                    if (servicetypeBlog != null)
                                    {
                                        servicetypeBlog.TotalViews = servicetypeBlog.TotalViews + 1;
                                        this.businessBlogMaster.Update(servicetypeBlog);
                                    }
                                    break;
                                case "home":
                                    var servicetypehome = UnitOfWork.HomePageSection2Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(model.tenantId)).FirstOrDefault();
                                    if (servicetypehome != null)
                                    {
                                        servicetypehome.TotalViews = servicetypehome.TotalViews + 1;
                                        this.businessHomePageSection2.Update(servicetypehome);
                                    }
                                    break;
                            }

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