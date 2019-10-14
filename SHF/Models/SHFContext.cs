using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using SHF.Migrations;
using SHF.Helper;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SHF.Models
{
    public class SHFContext : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {


        public SHFContext() : base(busConstant.Settings.DataBase.SqlServer.Connections.ConnectionString.DEFAULT)
        {
            //Database.SetInitializer<SHFContexts>(new DropCreateDatabaseAlways<SHFContexts>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SHFContext, Migrations.Configuration>());

            this.Configuration.AutoDetectChangesEnabled = busConstant.Misc.TRUE;
            this.Configuration.EnsureTransactionsForFunctionsAndCommands = busConstant.Misc.TRUE;
            this.Configuration.ValidateOnSaveEnabled = busConstant.Misc.TRUE;
            this.Configuration.ProxyCreationEnabled = busConstant.Misc.FALSE;        
            this.Configuration.LazyLoadingEnabled = busConstant.Misc.TRUE;
            this.SetCommandTimeOut(busConstant.Settings.DataBase.SqlServer.Connections.TimeOut.S300);
        }

        public static SHFContext Create()
        {
            return new SHFContext();
        }


        public void SetCommandTimeOut(int Timeout)
        {
            var objectContext = (this as IObjectContextAdapter).ObjectContext;
            objectContext.CommandTimeout = Timeout;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToOneConstraintIntroductionConvention>();

            base.OnModelCreating(modelBuilder);
        }
        

        public DbSet<SHF.EntityModel.Tenant> Tenant { get; set; }       
        public DbSet<SHF.EntityModel.Code> Code { get; set; }
        public DbSet<SHF.EntityModel.CodeValue> CodeValue { get; set; }
        public DbSet<SHF.EntityModel.SubMenu> SubMenu { get; set; }
        public DbSet<SHF.EntityModel.AspNetRoleSubMenu> AspNetRoleSubMenu { get; set; }
        public DbSet<SHF.EntityModel.Message> Messages { get; set; }
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