using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using Dapper;
using SHF.Business.Interface;
using SHF.EntityModel;
using SHF.Helper;


namespace SHF.Business.BusinessLogic
{
    public class BlogMaster : BaseBusiness, IBlogMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.BlogMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.BlogMasterIndexViewModel> collection;
            // ArrayList arrayList;
            try
            {
                //Datatable parameter
                var draw = Request.Form.GetValues("draw").FirstOrDefault();
                //paging parameter
                var start = Request.Form.GetValues("start").FirstOrDefault();
                var length = Request.Form.GetValues("length").FirstOrDefault();
                //sorting parameter            
                var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
                var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();

                //Global filter parameter
                var searchValue = Request.Form.GetValues("search[value]").FirstOrDefault();

                int pageSize = length != null ? Convert.ToInt32(length) : busConstant.Numbers.Integer.ZERO;
                int skip = start != null ? Convert.ToInt32(start) : busConstant.Numbers.Integer.ZERO;
                int totalRecords = busConstant.Numbers.Integer.ZERO;


                //Count total Records meeting criteria
                totalRecords = unitOfWork.BlogMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), BlogMaster => BlogMaster.Tenant_ID, tenant => tenant.ID, (BlogMaster, tenant) => new { BlogMaster, tenant })
                  .Count(x => (tenant_Id == null || x.BlogMaster.Tenant_ID == tenant_Id)
                            && (x.BlogMaster.ID.ToString().Contains(searchValue)
                        || x.BlogMaster.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.BannerDescription1.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.BannerDescription2.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section1ImagePath.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section2Description.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section3Heading.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section3Description.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.BlogMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.BlogMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), BlogMaster => BlogMaster.Tenant_ID, tenant => tenant.ID, (BlogMaster, tenant) => new { BlogMaster, tenant })
                  .Where(x => (tenant_Id == null || x.BlogMaster.Tenant_ID == tenant_Id)
                            && (x.BlogMaster.ID.ToString().Contains(searchValue)
                        || x.BlogMaster.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.BannerDescription1.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.BannerDescription2.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.BlogTitle.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section1ImagePath.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section2Description.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section3Heading.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Section3Description.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.BlogMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.BlogMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.BlogMasterIndexViewModel 
                    {
                        ID = x.BlogMaster.ID,
                        BannerImagePath = x.BlogMaster.BannerImagePath,
                        BannerDescription1 = x.BlogMaster.BannerDescription1,
                        BannerDescription2 = x.BlogMaster.BannerDescription2,
                        BlogTitle = x.BlogMaster.BlogTitle,
                        Section1ImagePath = x.BlogMaster.Section1ImagePath,
                        Section2Heading = x.BlogMaster.Section2Heading,
                        Section2Description = x.BlogMaster.Section2Description,
                        Section3Heading = x.BlogMaster.Section3Heading,
                        Section3Description = x.BlogMaster.Section3Description,
                        Url= x.BlogMaster.Url.ToString(),
                        Metadata= x.BlogMaster.Metadata.ToString(),
                        MetaDescription= x.BlogMaster.MetaDescription.ToString(),
                        Keyword= x.BlogMaster.Keyword.ToString(),
                        TotalViews= x.BlogMaster.TotalViews,
                        IsActive = x.BlogMaster.IsActive,
                        TenantName = x.BlogMaster.Tenant.Name,
                        CreatedBy = x.BlogMaster.CreatedBy,
                        UpdatedBy = x.BlogMaster.UpdatedBy,
                        CreatedOn= x.BlogMaster.CreatedOn,
                        UpdatedOn= x.BlogMaster.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.BlogMasterIndexViewModel>
                {
                    Draw = draw,
                    RecordsFiltered = totalRecords,
                    RecordsTotal = totalRecords,
                    Data = collection
                };

                return businessResultViewModel;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                collection = null;
            }
        }





        public EntityModel.BlogMaster Create(EntityModel.BlogMaster entity)
        {
            try
            {
                return unitOfWork.BlogMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.BlogMaster GetById(long Id)
        {
            try
            {
                EntityModel.BlogMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.BlogMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.BlogMaster Update(EntityModel.BlogMaster entity)
        {
            try
            {
                return unitOfWork.BlogMasterRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void Delete(long Id)
        {
            try
            {
                unitOfWork.BlogMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.BlogMaster> GetAll()
        {
            try
            {
                return unitOfWork.BlogMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.BlogMaster> FindBy(Expression<Func<EntityModel.BlogMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.BlogMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.BlogMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.BlogMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.BlogMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.BlogMasterRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        //public IEnumerable<ProductDropdownListViewModel> GetDropdownList()
        //{
        //    try
        //    {
        //        var productDropdownListViewModel = unitOfWork.ProductRepository.Get().Select(x => new ViewModel.ProductDropdownListViewModel
        //        {
        //            ID = x.ID,
        //            Name = x.Name
        //        });

        //        return productDropdownListViewModel;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

        public Int32 Count(Expression<Func<EntityModel.BlogMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.BlogMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
