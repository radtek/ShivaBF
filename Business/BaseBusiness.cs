using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Dapper;
using SHF.Business.Interface;
using SHF.DataAccess.Implementations;
using SHF.EntityModel;
using SHF.Helper;
using SHF.ViewModel;


namespace SHF.Business
{
    public class BaseBusiness
    {
        protected UnitOfWork unitOfWork;



        public BaseBusiness()
        {
            this.unitOfWork = new UnitOfWork();

        }
        public BaseBusiness(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }


        protected dynamic GetValueOfProperty(PropertyInfo info, object obj)
        {

            try
            {
                dynamic value = new object();

                if (info.PropertyType == typeof(Decimal))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is Decimal)
                        value = Convert.ToDecimal(v);
                }
                else if (info.PropertyType == typeof(Int64?))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is Int64)
                        value = Convert.ToInt64(v);
                }
                else if (info.PropertyType == typeof(String))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is String)
                        value = Convert.ToString(v);
                }
                else if (info.PropertyType == typeof(Int32))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is Int32)
                        value = Convert.ToInt32(v);
                }
                else if (info.PropertyType == typeof(Boolean))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is Boolean)
                        value = Convert.ToBoolean(v);

                }
                else if (info.PropertyType == typeof(DateTime))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is DateTime)
                        value = Convert.ToDateTime(v);

                }
                else if (info.PropertyType == typeof(Guid))
                {
                    object v = info.GetValue(obj);
                    if (v.IsNotNull() && v is Guid)
                        value = (Guid)v;
                }

                return value;
            }
            catch(Exception e)
            {
                throw e;// new Exception(busConstant.Messages.Type.Exceptions.InternalServerError);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static string GetDiscriptionOfCodeIdCodeValue(long CodeId, string CodeValue)
        {
           return Business.busCache.CodeValueTable().FirstOrDefault(x => x.Code_ID == CodeId && x.Value == CodeValue).Description;
        }


    }
}
