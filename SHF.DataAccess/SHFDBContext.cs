using System;
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
        public DbSet<SHF.EntityModel.Services4Section2Master> Services4Section2Master { get; set; }
        public DbSet<SHF.EntityModel.Services4Section2MasterChild> Services4Section2MasterChild { get; set; }
        public DbSet<SHF.EntityModel.Services4Section3> Services4Section3 { get; set; }
        public DbSet<SHF.EntityModel.Services4Section3DownloadMaster> Services4Section3DownloadMaster { get; set; }
        public DbSet<SHF.EntityModel.Services4Section3Master> Services4Section3Master { get; set; }
        public DbSet<SHF.EntityModel.Services4Section3MasterChild> Services4Section3MasterChild { get; set; }
        public DbSet<SHF.EntityModel.Services4Section567FieldMaster> Services4Section567FieldMaster { get; set; }
        public DbSet<SHF.EntityModel.Services4Section567FieldValues> Services4Section567FieldValues { get; set; }
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
        public DbSet<SHF.EntityModel.BannerNavigationsDetails> BannerNavigationsDetails { get; set; }
        public DbSet<SHF.EntityModel.IPInfo> IPInfo { get; set; }

    }
}
