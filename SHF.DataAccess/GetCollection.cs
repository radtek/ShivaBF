using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using SHF.Helper;

namespace SHF.DataAccess
{
    public class GetCollection
    {
        public static IEnumerable<EntityModel.SubMenu> ByStoredProcedure(string storedProcedureName, DynamicParameters parameters = null)
        {
            using (var con = DBUtility.GetNewOpenConnection())
            {
                var result = con.Query<EntityModel.SubMenu>(sql: storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
        public static IEnumerable<ViewModel.ActiveMenuViewModel> ByStoredProcedureActiveMenu(string storedProcedureName, DynamicParameters parameters = null)
        {
            using (var con = DBUtility.GetNewOpenConnection())
            {
                var result = con.Query<ViewModel.ActiveMenuViewModel>(sql: storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }
    }

    public class GetScalar
    {
        public static System.Object ByStoredProcedure(string storedProcedureName, DynamicParameters parameters = null)
        {
            using (var con = DBUtility.GetNewOpenConnection())
            {
                var result = con.ExecuteScalar<System.Object>(sql: storedProcedureName, param: parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        public static void ExecuteNonQuery(string commandText,SqlParameter[] parameters = null)
        {
            using (var con = DBUtility.GetNewOpenConnection())
            {
                var command = con.CreateCommand();
                command.CommandText = commandText;
                command.CommandType =CommandType.StoredProcedure;

                if (parameters != null)
                {
                    foreach (var parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                }

                command.ExecuteNonQuery();
            }
        }
    }
}
