using System;
using System.Web;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using SHF.Business.Interface;
using SHF.Helper;
using Dapper;
using SHF.EntityModel;

namespace SHF.Business.BusinessLogic
{
    public class CodeValue : BaseBusiness, ICode, ICodeValue
    {
        public IEnumerable<EntityModel.CodeValue> FindBy(Expression<Func<EntityModel.CodeValue, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CodeValue> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CodeValueRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CodeValueRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

       

        public IEnumerable<Code> FindBy(Expression<Func<Code, bool>> filter)
        {
            try
            {
                IEnumerable<EntityModel.Code> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CodeRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CodeRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
