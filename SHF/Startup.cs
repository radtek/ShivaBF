using Microsoft.Owin;
using Owin;
using Unity;
using Hangfire;
using Hangfire.Dashboard;
using Hangfire.SqlServer;
using System.Web;

[assembly: OwinStartupAttribute(typeof(SHF.Startup))]
namespace SHF
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);




            #region [Batch Configuration]


            //app.UseHangfire(config =>
            //{
            //    config.UseSqlServerStorage(SHF.Helper.busConstant.Settings.DataBase.SqlServer.Connections.ConnectionString.Default);
            //    config.UseServer();
            //config.UseAuthorizationFilters(new AuthorizationFilter
            //{
            //    Users = knfConstant.USER_ROLE.DEVLOPER, // allow only specified users
            //    Roles = knfConstant.USER_ROLE.DEVLOPER // allow only specified roles
            //});
            //});
            //var options = new DashboardOptions
            //{
            //AuthorizationFilters = new[]
            //{
            //    new AuthorizationFilter { Roles = knfConstant.USER_ROLE.DEVLOPER }
            //},
            //AppPath = VirtualPathUtility.ToAbsolute("~")
            //};

            //app.UseHangfireDashboard("/Delmon", options);
            //RecurringJob.AddOrUpdate<DailyPayout>(x => DailyPayout.PayoutJob1(), Cron.Daily(00, 45), timeZone: TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            //RecurringJob.AddOrUpdate<VW_RecognitionAchiverRepo>(x => VW_RecognitionAchiverRepo.UpdateRecognitionAchiver(), Cron.Daily(01, 45), timeZone: TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            //RecurringJob.AddOrUpdate<VW_AwardAchieverRepo>(x => VW_AwardAchieverRepo.CalculateAwards(), Cron.Daily(02, 45), timeZone: TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            //RecurringJob.AddOrUpdate<VW_CumulativeRepo>(x => VW_CumulativeRepo.UpdateCumulative(), Cron.Daily(03, 45), timeZone: TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            //RecurringJob.AddOrUpdate<VW_ManageMemberRepo>(x => VW_ManageMemberRepo.SendBirthdayWishes(), Cron.Daily(7, 00), timeZone: TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));

            #endregion
        }


    }
}
