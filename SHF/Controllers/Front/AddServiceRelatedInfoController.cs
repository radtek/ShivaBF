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
        private Business.Interface.IHomePageBanner businessHomePageBanner;


        public AddServiceRelatedInfoController(Business.Interface.IServices1Master IServices1Master, Business.Interface.IServices2Master IServices2Master, Business.Interface.IServices3Master IServices3Master, Business.Interface.IServices4Master IServices4Master, Business.Interface.IServices5Master IServices5Master
            , Business.Interface.IServices6Master IServices6Master, Business.Interface.IServices7Master IServices7Master, Business.Interface.IServices8Master IServices8Master, Business.Interface.IBlogMaster IBlogMaster, Business.Interface.IHomePageBanner IHomePageBanner)
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
            this.businessHomePageBanner = IHomePageBanner;
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
                                //case "page2":
                                //    var dataset2 = UnitOfWork.Services2MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset2 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset2.ID;
                                //        commonSEOViewModel.PageTitle = dataset2.PageTitle;
                                //        commonSEOViewModel.Url = dataset2.Url;
                                //        commonSEOViewModel.Metadata = dataset2.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset2.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset2.Keyword;
                                //    }
                                //    break;
                                //case "page3":
                                //    var dataset3 = UnitOfWork.Services3MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset3 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset3.ID;
                                //        commonSEOViewModel.PageTitle = dataset3.PageTitle;
                                //        commonSEOViewModel.Url = dataset3.Url;
                                //        commonSEOViewModel.Metadata = dataset3.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset3.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset3.Keyword;
                                //    }
                                //    break;
                                //case "page4":
                                //    var dataset4 = UnitOfWork.Services4MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset4 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset4.ID;
                                //        commonSEOViewModel.PageTitle = dataset4.PageTitle;
                                //        commonSEOViewModel.Url = dataset4.Url;
                                //        commonSEOViewModel.Metadata = dataset4.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset4.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset4.Keyword;
                                //    }
                                //    break;
                                //case "page5":
                                //    var dataset5 = UnitOfWork.Services5MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset5 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset5.ID;
                                //        commonSEOViewModel.PageTitle = dataset5.PageTitle;
                                //        commonSEOViewModel.Url = dataset5.Url;
                                //        commonSEOViewModel.Metadata = dataset5.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset5.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset5.Keyword;
                                //    }
                                //    break;
                                //case "page6":
                                //    var dataset6 = UnitOfWork.Services6MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset6 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset6.ID;
                                //        commonSEOViewModel.PageTitle = dataset6.PageTitle;
                                //        commonSEOViewModel.Url = dataset6.Url;
                                //        commonSEOViewModel.Metadata = dataset6.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset6.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset6.Keyword;
                                //    }
                                //    break;
                                //case "page7":
                                //    var dataset7 = UnitOfWork.Services7MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset7 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset7.ID;
                                //        commonSEOViewModel.PageTitle = dataset7.PageTitle;
                                //        commonSEOViewModel.Url = dataset7.Url;
                                //        commonSEOViewModel.Metadata = dataset7.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset7.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset7.Keyword;
                                //    }
                                //    break;
                                //case "page8":
                                //    var dataset8 = UnitOfWork.Services8MasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (dataset8 != null)
                                //    {
                                //        commonSEOViewModel.ID = dataset8.ID;
                                //        commonSEOViewModel.PageTitle = dataset8.PageTitle;
                                //        commonSEOViewModel.Url = dataset8.Url;
                                //        commonSEOViewModel.Metadata = dataset8.Metadata;
                                //        commonSEOViewModel.MetaDescription = dataset8.MetaDescription;
                                //        commonSEOViewModel.Keyword = dataset8.Keyword;
                                //    }
                                //    break;
                                //case "blog":
                                //    var datasetBlog = UnitOfWork.BlogMasterRepository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.Url == url && x.IsActive == true).FirstOrDefault();
                                //    if (datasetBlog != null)
                                //    {
                                //        commonSEOViewModel.ID = datasetBlog.ID;
                                //        commonSEOViewModel.PageTitle = datasetBlog.PageTitle;
                                //        commonSEOViewModel.Url = datasetBlog.Url;
                                //        commonSEOViewModel.Metadata = datasetBlog.Metadata;
                                //        commonSEOViewModel.MetaDescription = datasetBlog.MetaDescription;
                                //        commonSEOViewModel.Keyword = datasetBlog.Keyword;
                                //    }
                                //    break;
                                //case "home":
                                //    var datasetHome = UnitOfWork.HomePageSection2Repository.Get().Where(x => x.Tenant_ID == Convert.ToInt64(tenantId) && x.IsActive == true).FirstOrDefault();
                                //    if (datasetHome != null)
                                //    {
                                //        commonSEOViewModel.ID = datasetHome.ID;
                                //        commonSEOViewModel.PageTitle = datasetHome.PageTitle;
                                //        commonSEOViewModel.Url = datasetHome.Url;
                                //        commonSEOViewModel.Metadata = datasetHome.Metadata;
                                //        commonSEOViewModel.MetaDescription = datasetHome.MetaDescription;
                                //        commonSEOViewModel.Keyword = datasetHome.Keyword;
                                //    }
                                //    break;
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