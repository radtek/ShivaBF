using System;
using System.Web;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SHF.Business.Interface
{
    public interface IMessage
    {
        EntityModel.Message Create(EntityModel.Message entity);
        IEnumerable<EntityModel.Message> FindBy(Expression<Func<EntityModel.Message, bool>> filter = null);
        EntityModel.Message GetById(long Id);
        IEnumerable<EntityModel.Message> GetAll();
        EntityModel.Message Update(EntityModel.Message entity);
        void Delete(long Id);
        void DeleteWhere(Expression<Func<EntityModel.Message, bool>> filter = null);
        Int32 Count(Expression<Func<EntityModel.Message, bool>> filter = null);
        ViewModel.BusinessResultViewModel<ViewModel.MessageIndexViewModel> Index(HttpRequestBase Request);
    }
}
