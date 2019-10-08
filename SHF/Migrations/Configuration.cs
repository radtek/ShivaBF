namespace SHF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SHF.Helper;

    internal sealed class Configuration : DbMigrationsConfiguration<SHF.Models.SHFContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = busConstant.Misc.FALSE;
            AutomaticMigrationDataLossAllowed = busConstant.Misc.FALSE;
            ContextKey = "SHF.Models.SHFContext";
        }

        protected override void Seed(SHF.Models.SHFContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}