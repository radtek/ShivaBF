﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
//using Inventory.EntityModel;
using SHF.Helper;
using System.Data.Entity.Infrastructure;

namespace SHF.DataAccess
{
    public class SHFDBContext : DbContext
    {
        public SHFDBContext() : base(busConstant.Settings.DataBase.SqlServer.Connections.ConnectionString.DEFAULT)
        {
            //Database.SetInitializer<InventoryContexts>(new DropCreateDatabaseAlways<InventoryContexts>());
            ///Database.SetInitializer(new MigrateDatabaseToLatestVersion<InventoryContexts, Migrations.Configuration>());

            this.Configuration.AutoDetectChangesEnabled = busConstant.Misc.TRUE;
            this.Configuration.EnsureTransactionsForFunctionsAndCommands = busConstant.Misc.TRUE;
            this.Configuration.ValidateOnSaveEnabled = busConstant.Misc.TRUE;
            this.Configuration.ProxyCreationEnabled = busConstant.Misc.FALSE;
            this.Configuration.LazyLoadingEnabled = busConstant.Misc.TRUE;
            this.SetCommandTimeOut(busConstant.Settings.DataBase.SqlServer.Connections.TimeOut.S300);
        }

        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }

        public DbSet<EntityModel.Code> Code { get; set; }
        public DbSet<EntityModel.CodeValue> CodeValue { get; set; }
        public DbSet<EntityModel.Tenant> Tenant { get; set; }
        public DbSet<EntityModel.ExceptionLog> ExceptionLogs { get; set; }
        public DbSet<EntityModel.AspNetRole> AspNetRole { get; set; }
        public DbSet<EntityModel.AspNetUser> AspNetUser { get; set; }
        public DbSet<EntityModel.AspNetUserRole> AspNetUserRole { get; set; }
        public DbSet<EntityModel.SubMenu> SubMenu { get; set; }
        public DbSet<EntityModel.AspNetRoleSubMenu> AspNetRoleSubMenu { get; set; }
       
        public DbSet<EntityModel.Message> Messages { get; set; }
        public DbSet<SHF.EntityModel.BankMaster> BankMaster { get; set; }
        public DbSet<SHF.EntityModel.PriceFeaturesMaster> PriceFeaturesMaster { get; set; }
        public DbSet<SHF.EntityModel.FAQMaster> FAQMaster { get; set; }
        public DbSet<SHF.EntityModel.CategoriesMaster> CategoriesMaster { get; set; }
        public DbSet<SHF.EntityModel.SubCategoriesMaster> SubCategoriesMaster { get; set; }
        public DbSet<SHF.EntityModel.SubSubCategoriesMaster> SubSubCategoriesMaster { get; set; }
        public DbSet<SHF.EntityModel.Services1Master> Services1Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section10BankMapping> Services1Section10BankMapping { get; set; }
        public DbSet<SHF.EntityModel.Services1Section1Master> Services1Section1Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section4Master> Services1Section4Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section5Master> Services1Section5Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section6PriceMaster> Services1Section6PriceMaster { get; set; }
        public DbSet<SHF.EntityModel.StateMaster> StateMaster { get; set; }
        public DbSet<SHF.EntityModel.PriceFeaturesMapping> PriceFeaturesMapping { get; set; }



    }
}