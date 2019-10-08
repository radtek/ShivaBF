using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Caching;
using Dapper;
using SHF.Helper;

namespace SHF.Business
{
    [System.ComponentModel.DataObject]
    public class busCache
    {

        public static void LoadCache()
        {
            /* HttpRuntime.Cache.Insert(
          /* key * /                "key",
          /* value * /              suppliers,
          /* dependencies * /       null,
          /* absoluteExpiration * / Cache.NoAbsoluteExpiration,
          /* slidingExpiration * /  Cache.NoSlidingExpiration,
          /* priority * /           CacheItemPriority.NotRemovable,
          /* onRemoveCallback * /   null);*/

            LoadCodeValue();
            LoadMessage();
            LoadSubMenu();
            LoadAspNetRoleSubMenu();
            LoadAspNetUserRole();
        }


        #region [Set Data in Cache]

        public static void LoadCodeValue()
        {
            SHF.Business.Interface.ICodeValue IcodeValue = new SHF.Business.BusinessLogic.CodeValue();
            var CodeValues = IcodeValue.FindBy(x => x.IsActive == busConstant.Misc.TRUE);
            HttpRuntime.Cache.Insert(busConstant.Settings.Cache.Keys.CODE_VALUE_TABLE, CodeValues);
        }

        public static void LoadMessage()
        {
            SHF.Business.Interface.IMessage Imessage = new SHF.Business.BusinessLogic.Message();
            var CodeValues = Imessage.FindBy(x => x.IsActive == busConstant.Misc.TRUE);
            HttpRuntime.Cache.Insert(busConstant.Settings.Cache.Keys.MESSAGE_TABLE, CodeValues);
        }

        public static void LoadSubMenu()
        {
            SHF.Business.Interface.ISubMenu IsubMenu = new SHF.Business.BusinessLogic.SubMenu();
            var SubMenus = IsubMenu.FindBy();
            HttpRuntime.Cache.Insert(busConstant.Settings.Cache.Keys.SUB_MENU_TABLE, SubMenus);
        }

        public static void LoadAspNetRoleSubMenu()
        {
            SHF.Business.Interface.IAspNetRoleSubMenu IaspNetRoleSubMenu = new SHF.Business.BusinessLogic.AspNetRoleSubMenu();
            var AspNetRoleSubMenus = IaspNetRoleSubMenu.FindBy();
            HttpRuntime.Cache.Insert(busConstant.Settings.Cache.Keys.ASPNET_ROLE_SUBMENU_TABLE, AspNetRoleSubMenus);
        }

        public static void LoadAspNetUserRole()
        {
            SHF.Business.Interface.IAspNetUserRole IaspNetUserRole = new SHF.Business.BusinessLogic.AspNetUserRole();
            var AspNetUserRoles = IaspNetUserRole.FindBy();
            HttpRuntime.Cache.Insert(busConstant.Settings.Cache.Keys.ASPNET_USER_ROLE_TABLE, AspNetUserRoles);
        }

        #endregion








        #region [Get Data from Cache]

        public static IEnumerable<EntityModel.CodeValue> CodeValueTable()
        {
            var cacheData = HttpRuntime.Cache.Get(busConstant.Settings.Cache.Keys.CODE_VALUE_TABLE);
            if (cacheData.IsNull())
            {
                LoadCodeValue();
                CodeValueTable();
            }
            else
            {
                return cacheData as IEnumerable<EntityModel.CodeValue>;
            }
            return cacheData as IEnumerable<EntityModel.CodeValue>;
        }

        public static IEnumerable<EntityModel.SubMenu> SubMenuTable()
        {
            var cacheData = HttpRuntime.Cache.Get(busConstant.Settings.Cache.Keys.SUB_MENU_TABLE);
            if (cacheData.IsNull())
            {
                LoadSubMenu();
                SubMenuTable();
            }
            else
            {
                return cacheData as IEnumerable<EntityModel.SubMenu>;
            }
            return cacheData as IEnumerable<EntityModel.SubMenu>;
        }

        public static IEnumerable<EntityModel.AspNetRoleSubMenu> AspNetRoleSubMenuTable()
        {
            var cacheData = HttpRuntime.Cache.Get(busConstant.Settings.Cache.Keys.ASPNET_ROLE_SUBMENU_TABLE);
            if (cacheData.IsNull())
            {
                LoadAspNetRoleSubMenu();
                AspNetRoleSubMenuTable();
            }
            else
            {
                return cacheData as IEnumerable<EntityModel.AspNetRoleSubMenu>;
            }
            return cacheData as IEnumerable<EntityModel.AspNetRoleSubMenu>;
        }

        public static IEnumerable<EntityModel.AspNetUserRole> AspNetUserRoleTable()
        {
            var cacheData = HttpRuntime.Cache.Get(busConstant.Settings.Cache.Keys.ASPNET_USER_ROLE_TABLE);
            if (cacheData.IsNull())
            {
                LoadAspNetUserRole();
                AspNetUserRoleTable();
            }
            else
            {
                return cacheData as IEnumerable<EntityModel.AspNetUserRole>;
            }
            return cacheData as IEnumerable<EntityModel.AspNetUserRole>;
        }

        #endregion









        //public static string GetDescription(int CodeId, string CodeValue, string Data1 = "")
        //{
        //    var str = String.Empty;
        //    str = Data1.IsNullOrEmpty() ?
        //         CodeValueTable().Where(x => x.CodeId == CodeId && x.CodeValue == CodeValue).FirstOrDefault().Description :
        //             CodeValueTable().Where(x => x.CodeId == CodeId && x.CodeValue == CodeValue && x.Data1 == Data1).FirstOrDefault().Description;

        //    return str;
        //}


    }
}