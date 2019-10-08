using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHF.Business.Interface
{
    public interface ICodeValue
    {
        IEnumerable<EntityModel.CodeValue> FindBy(Expression<Func<EntityModel.CodeValue, bool>> filter = null);
       
    }
}
