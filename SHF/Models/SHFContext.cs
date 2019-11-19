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

            this.Configuration.AutoDetectChangesEnabled = busConstant.Misc.FALSE;
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
        public DbSet<SHF.EntityModel.FAQMaster> FAQMaster { get; set; }
        public DbSet<SHF.EntityModel.CategoriesMaster> CategoriesMaster { get; set; }
        public DbSet<SHF.EntityModel.SubCategoriesMaster> SubCategoriesMaster { get; set; }
        public DbSet<SHF.EntityModel.SubSubCategoriesMaster> SubSubCategoriesMaster { get; set; }
        public DbSet<SHF.EntityModel.StateMaster> StateMaster { get; set; }

        /*new files added */
        public DbSet<SHF.EntityModel.HomePageBanner> HomePageBanner { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection1> HomePageSection1 { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection2> HomePageSection2 { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection3> HomePageSection3 { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection3Features> HomePageSection3Features { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection4> HomePageSection4 { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection4Testimonails> HomePageSection4Testimonails { get; set; }
        public DbSet<SHF.EntityModel.HomePageSection5> HomePageSection5 { get; set; }
        public DbSet<SHF.EntityModel.PriceFeaturesMapping> PriceFeaturesMapping { get; set; }
        public DbSet<SHF.EntityModel.PriceFeaturesMaster> PriceFeaturesMaster { get; set; }
        /*service 1*/
        public DbSet<SHF.EntityModel.Services1Master> Services1Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section10BankMapping> Services1Section10BankMapping { get; set; }
        public DbSet<SHF.EntityModel.Services1Section1Master> Services1Section1Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section4Master> Services1Section4Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section5Master> Services1Section5Master { get; set; }
        public DbSet<SHF.EntityModel.Services1Section6PriceMaster> Services1Section6PriceMaster { get; set; }
        public DbSet<SHF.EntityModel.Services1Section8FAQMapping> Services1Section8FAQMapping { get; set; }
        /*service 2*/
        public DbSet<SHF.EntityModel.Services2Master> Services2Master { get; set; }
        public DbSet<SHF.EntityModel.Services2Section2FAQMapping> Services2Section2FAQMapping { get; set; }
        public DbSet<SHF.EntityModel.Services2Section3DownloadMaster> Services2Section3DownloadMaster { get; set; }
        public DbSet<SHF.EntityModel.Services2Section4Master> Services2Section4Master { get; set; }
        /*service 3*/
        public DbSet<SHF.EntityModel.Services3HeadingButtons> Services3HeadingButtons { get; set; }
        public DbSet<SHF.EntityModel.Services3Master> Services3Master { get; set; }
        public DbSet<SHF.EntityModel.Services3Section4> Services3Section4 { get; set; }
        public DbSet<SHF.EntityModel.Services3Section6PriceMaster> Services3Section6PriceMaster { get; set; }
        /*service 4*/
        public DbSet<SHF.EntityModel.Services4Master> Services4Master { get; set; }
        public DbSet<SHF.EntityModel.Services4Section2FAQMapping> Services4Section2FAQMapping { get; set; }
        public DbSet<SHF.EntityModel.Services4Section345Master> Services4Section2Master { get; set; }
        public DbSet<SHF.EntityModel.Services4Section345MasterButtonsChild> Services4Section2MasterChild { get; set; }
        public DbSet<SHF.EntityModel.Services4Section345MasterFeaturesDetails> Services4Section3 { get; set; }
       
        public DbSet<SHF.EntityModel.Services4Section678FieldMaster> Services4Section567FieldMaster { get; set; }
        public DbSet<SHF.EntityModel.Services4Section678FieldValues> Services4Section567FieldValues { get; set; }
        /*service 5*/
        public DbSet<SHF.EntityModel.Services5Master> Services5Master { get; set; }
        public DbSet<SHF.EntityModel.Services5Section2Master> Services5Section2Master { get; set; }
        public DbSet<SHF.EntityModel.Services5Section2MasterFeaturesDetails> Services5Section2MasterFeaturesDetails { get; set; }
        /*service 6*/
        public DbSet<SHF.EntityModel.Services6Master> Services6Master { get; set; }
        public DbSet<SHF.EntityModel.Services6Section2Master> Services6Section2Master { get; set; }
        public DbSet<SHF.EntityModel.Services6Section2MasterFeaturesDetails> Services6Section2MasterFeaturesDetails { get; set; }
        /*service 7*/
        public DbSet<SHF.EntityModel.Services7HeadingButtons> Services7HeadingButtons { get; set; }
        public DbSet<SHF.EntityModel.Services7Master> Services7Master { get; set; }
        public DbSet<SHF.EntityModel.Services7Section4> Services7Section4 { get; set; }
        public DbSet<SHF.EntityModel.Services7Section6PriceMaster> Services7Section6PriceMaster { get; set; }
        /*service 8*/
        public DbSet<SHF.EntityModel.Services8HeadingButtons> Services8HeadingButtons { get; set; }
        public DbSet<SHF.EntityModel.Services8Master> Services8Master { get; set; }
        public DbSet<SHF.EntityModel.Services8Section6Master> Services8Section6Master { get; set; }
        /****Blog***/
        public DbSet<SHF.EntityModel.BlogMaster> BlogMaster { get; set; }
        public DbSet<SHF.EntityModel.BlogCommentsDetails> BlogCommentsDetails { get; set; }
        public DbSet<SHF.EntityModel.RelatedBlogsMapping> RelatedBlogsMapping { get; set; }
        public DbSet<SHF.EntityModel.CommentsReply> CommentsReply { get; set; }
        public DbSet<SHF.EntityModel.BlogBannerNavigationsDetails> BannerNavigationsDetails { get; set; }
        public DbSet<SHF.EntityModel.IPInfo> IPInfo { get; set; }

        public DbSet<SHF.EntityModel.BannerMaster> BannerMaster { get; set; }
        
        public DbSet<SHF.EntityModel.FooterBlockMaster> FooterBlockMaster { get; set; }
        public DbSet<SHF.EntityModel.FooterLinks> FooterLinks { get; set; }
    }
}