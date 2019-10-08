
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SHF.Helper
{
    public static class DBUtility
    {
        private static string _strcon;

        public static bool? _isFullTextInstalled;

        public static bool? _isFullTextIndexSetUp;

        public static string _connStr
        {
            get
            {
                return DBUtility._strcon;
            }
        }

        static DBUtility()
        {
            DBUtility._strcon = ConfigurationManager.ConnectionStrings[busConstant.Settings.DataBase.SqlServer.Connections.ConnectionString.DEFAULT].ConnectionString;
        }

        public static SqlConnection GetNewConnection()
        {
            return new SqlConnection(DBUtility._connStr);
        }

        public static SqlConnection GetNewOpenConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(DBUtility._connStr);
            sqlConnection.Open();
            return sqlConnection;
        }

        public static SqlDataReader ExecuteReader(this SqlConnection cn, string commandText, params SqlParameter[] sqlParameters)
        {
            SqlCommand sqlCommand = new SqlCommand(commandText, cn);
            SqlParameter[] sqlParameterArray = sqlParameters;
            for (int i = 0; i < (int)sqlParameterArray.Length; i++)
            {
                SqlParameter sqlParameter = sqlParameterArray[i];
                sqlCommand.Parameters.Add(sqlParameter);
            }
            return sqlCommand.ExecuteReader();
        }

        public static T FindNextItem<T>(this IEnumerable<T> items, Predicate<T> matchFilling)
        {
            T current;
            T t;
            using (IEnumerator<T> enumerator = items.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    if (!matchFilling(enumerator.Current))
                    {
                        continue;
                    }
                    if (!enumerator.MoveNext())
                    {
                        t = default(T);
                        current = t;
                        return current;
                    }
                    else
                    {
                        current = enumerator.Current;
                        return current;
                    }
                }
                t = default(T);
                return t;
            }

        }

        public static T FindPreviousItem<T>(this IEnumerable<T> items, Predicate<T> matchFilling)
        {
            T t;
            using (IEnumerator<T> enumerator = items.GetEnumerator())
            {
                T current = default(T);
                while (enumerator.MoveNext())
                {
                    if (!matchFilling(enumerator.Current))
                    {
                        current = enumerator.Current;
                    }
                    else
                    {
                        t = current;
                        return t;
                    }
                }
                return default(T);
            }

        }

        public static Dictionary<string, object> GetFieldsFromDataReaderCurrentPosition(SqlDataReader dr)
        {
            Dictionary<string, object> strs;
            try
            {
                Dictionary<string, object> strs1 = new Dictionary<string, object>();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    strs1.Add(dr.GetName(i), dr[i]);
                }
                strs = strs1;
            }
            catch
            {
                strs = null;
            }
            return strs;
        }

        public static string GetFullTextSearchQuery(string query)
        {
            if (query.StartsWith("\"") && query.EndsWith("\""))
            {
                return query;
            }
            List<string> list = (
                from Match m in (new Regex("\\w+|\"[\\w\\s]*\"")).Matches(query)
                select m.Value).ToList<string>();
            StringBuilder stringBuilder = new StringBuilder();
            bool flag = true;
            foreach (string str in list)
            {
                if (!(str.ToLower() != "or") || !(str.ToLower() != "and"))
                {
                    stringBuilder.AppendFormat(" {0} ", str);
                    flag = true;
                }
                else
                {
                    if (!flag)
                    {
                        stringBuilder.Append(" AND ");
                    }
                    if (!str.StartsWith("\""))
                    {
                        stringBuilder.AppendFormat("\"{0}\"", str);
                    }
                    else
                    {
                        stringBuilder.Append(str);
                    }
                    flag = false;
                }
            }
            return stringBuilder.ToString();
        }

        public static SqlCommand GetNewCommandObject(SqlConnection connection = null)
        {
            if (connection == null)
            {
                connection = new SqlConnection(DBUtility._strcon);
            }
            return new SqlCommand()
            {
                Connection = connection
            };
        }



        public static IEnumerable<T> GetPage<T>(this IEnumerable<T> source, int pageSize, int pageNumber)
        {
            return source.Skip<T>(pageSize * pageNumber).Take<T>(pageSize);
        }

        public static bool IsFullTextIndexSetUp()
        {
            if (!DBUtility._isFullTextIndexSetUp.HasValue)
            {
                using (SqlConnection newOpenConnection = DBUtility.GetNewOpenConnection())
                {
                    int? nullable = null;
                    CommandType? nullable1 = null;
                    DBUtility._isFullTextIndexSetUp = new bool?(newOpenConnection.Query("select * from sys.fulltext_indexes", null, null, true, nullable, nullable1).Count<object>() > 0);
                }
            }
            return DBUtility._isFullTextIndexSetUp.Value;
        }

        public static bool IsFullTextInstalled()
        {
            if (!DBUtility._isFullTextInstalled.HasValue)
            {
                using (SqlConnection newOpenConnection = DBUtility.GetNewOpenConnection())
                {
                    try
                    {
                        int? nullable = null;
                        CommandType? nullable1 = null;
                        DBUtility._isFullTextInstalled = new bool?(newOpenConnection.Query<int>("SELECT FULLTEXTSERVICEPROPERTY('IsFullTextInstalled')", null, null, true, nullable, nullable1).First<int>() == 1);
                    }
                    catch
                    {
                        DBUtility._isFullTextInstalled = new bool?(false);
                    }
                }
            }
            return DBUtility._isFullTextInstalled.Value;
        }

        public static object NullToDBNull(object value)
        {
            if (value != null)
            {
                return value;
            }
            return DBNull.Value;
        }

        public static DataTable SelectTopNRows(this DataTable dtSource, int topRows)
        {
            IEnumerable<DataRow> dataRows = dtSource.AsEnumerable().Take<DataRow>(topRows);
            DataTable dataTable = new DataTable();
            dataTable = dtSource.Clone();
            DataRow[] array = dataRows.ToArray<DataRow>();
            for (int i = 0; i < (int)array.Length; i++)
            {
                dataTable.ImportRow(array[i]);
            }
            dtSource.Dispose();
            return dataTable;
        }
    }
}