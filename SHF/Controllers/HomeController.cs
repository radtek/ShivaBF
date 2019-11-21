using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using SHF.Helper;
using SHF.Web.Filters;
using System.Transactions;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using System.Net;
using SHF.Models;
using SHF.ViewModel;
using System.Threading;

namespace SHF.Controllers
{
    public class HomeController : BaseController
    {
        #region [Field & Contructor]        

        private Business.Interface.ISubMenu businessSubMenu;


        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;


        public HomeController(Business.Interface.ISubMenu IsubMenu)
        {
            this.businessSubMenu = IsubMenu;
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

        #region [Action Method]


        //[OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }


        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        [HttpGet]
        [Access]
        //[OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Configurations/Document/Home/Index")]
        public ActionResult FileManager()
        {
            return View();
        }


        [HttpGet]
        [Access]
        //[OutputCache(Duration = busConstant.Settings.Cache.OutputCache.TimeOut.S300)]
        [Route("Settings/Document/Home/MyDocuments")]
        public ActionResult MyDocuments()
        {
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Security/Account/Home/LoggedOut")]
        public ActionResult LoggedOut()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetNoStore();
            Thread.Sleep(10);
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        [Route("Security/Account/Home/LoggingOut")]
        public ActionResult LoggingOut()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            Response.Cache.SetNoStore();
            Thread.Sleep(1000);
            return View("Close");
        }


        public async Task<ActionResult> Sidebar()
        {
            var businessResult = new JsonResponse<IEnumerable<EntityModel.SubMenu>>();
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        businessResult.Entity = Business.BusinessLogic.BusinessSubMenu.GetNavigationMenuAsync(User.Identity.GetUserId<long>());
                        transaction.Complete();
                        return PartialView("_SidebarMenu", businessResult.Entity);
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
            finally
            {
                businessResult = null;
            }

        }

        public async Task<ActionResult> Dashboard()
        {

            return PartialView("_Dashboard");


        }



        public async Task<ActionResult> GetActiveMenuCollectionByUrl(string url)
        {
            BusinessResultViewModel<ViewModel.ActiveMenuViewModel> businessResult = new BusinessResultViewModel<ViewModel.ActiveMenuViewModel>();
            try
            {
                using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions() { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    try
                    {
                        businessResult.Data = Business.BusinessLogic.BusinessSubMenu.GetActiveMenuAsync(url);
                        transaction.Complete();
                        return Json(businessResult, JsonRequestBehavior.AllowGet);
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
            finally
            {
                businessResult = null;
            }

        }


        public ActionResult SetCookies(string url)
        {
            SaveCookieAsync();
            Thread.Sleep(1000);
            return url.IsNotNullOrEmpty() ? RedirectToLocal(url) : RedirectToAction("Index", "Home");
        }

        #endregion

    }
}