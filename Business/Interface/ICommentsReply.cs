using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using SHF.Helper;

namespace SHF.Business.Interface
{
    public interface ICommentsReply
    {
        EntityModel.CommentsReply Create(EntityModel.CommentsReply entity);

        IEnumerable<EntityModel.CommentsReply> FindBy(Expression<Func<EntityModel.CommentsReply, bool>> filter = null);

        EntityModel.CommentsReply GetById(long Id);

        IEnumerable<EntityModel.CommentsReply> GetAll();

        EntityModel.CommentsReply Update(EntityModel.CommentsReply entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.CommentsReply, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.CommentsReplyIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.CommentsReply, bool>> filter = null);

      // IEnumerable<ViewModel.CommentsReplyDropdownListViewModel> GetDropdownList();
    }
}
