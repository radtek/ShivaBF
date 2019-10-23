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
    public interface IRelatedBlogsMapping
    {
        EntityModel.RelatedBlogsMapping Create(EntityModel.RelatedBlogsMapping entity);

        IEnumerable<EntityModel.RelatedBlogsMapping> FindBy(Expression<Func<EntityModel.RelatedBlogsMapping, bool>> filter = null);

        EntityModel.RelatedBlogsMapping GetById(long Id);

        IEnumerable<EntityModel.RelatedBlogsMapping> GetAll();

        EntityModel.RelatedBlogsMapping Update(EntityModel.RelatedBlogsMapping entity);

        void Delete(long Id);

        void DeleteWhere(Expression<Func<EntityModel.RelatedBlogsMapping, bool>> filter = null);

        ViewModel.BusinessResultViewModel<ViewModel.RelatedBlogsMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id);

        Int32 Count(Expression<Func<EntityModel.RelatedBlogsMapping, bool>> filter = null);

      // IEnumerable<ViewModel.RelatedBlogsMappingDropdownListViewModel> GetDropdownList();
    }
}
