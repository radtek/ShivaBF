using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Inventory.Helper;
//using Omu.AwesomeMvc;
using Inventory.DataAccess.Implementations;
using System.Transactions;
using Inventory.EntityModel;
using Inventory.ViewModel;
using Inventory.DataAccess;
using AutoMapper;
using AutoMapper.EntityFramework;
using AutoMapper.Collection;
using AutoMapper.Collection.LinqToSQL;
using Inventory.Web.Filters;

namespace Inventory.Controllers
{
    public class BranchesController : BaseController
    {
        // GET: Branches
        public ActionResult Index()
        {
            return View();
        }



        //public async Task<JsonResult> GetDropdwonListByCustomerId()
        //{

        //}

    }
}