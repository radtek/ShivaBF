using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHF.Business.Interface
{
    public interface ICode
    {
        IEnumerable<EntityModel.Code> FindBy(Expression<Func<EntityModel.Code, bool>> filter = null);
    }
}
