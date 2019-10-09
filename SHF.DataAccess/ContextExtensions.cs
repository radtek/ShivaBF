using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SHF.DataAccess
{
    public static class ContextExtensions
    {

        public static void DbccCheckIdent<T>(this DbContext context, int? reseedTo = null) where T : class
        {
            context.Database.ExecuteSqlCommand(
                $"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED{(reseedTo != null ? "," + reseedTo : "")});" +
                $"DBCC CHECKIDENT('{context.GetTableName<T>()}',RESEED);");
        }

        public static string GetTableName<T>(this DbContext context) where T : class
        {
            var objectContext = ((IObjectContextAdapter)context).ObjectContext;
            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this ObjectContext context) where T : class
        {
            var sql = context.CreateObjectSet<T>().ToTraceString();
            var regex = new Regex(@"FROM\s+(?<table>.+)\s+AS");
            var match = regex.Match(sql);
            var table = match.Groups["table"].Value;
            return table;
        }


        private static void A()
        {
            //using (var db = new LibraryEntities())
            //{
            //    db.DbccCheckIdent<Book>(); //which Book is one of your entities
            //    db.DbccCheckIdent<Book>(0); //if you want to pass a new seed
            //}
        }
    }
}
