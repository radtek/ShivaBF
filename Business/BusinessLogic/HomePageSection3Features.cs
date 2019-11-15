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
    public class HomePageSection3Features : BaseBusiness, IHomePageSection3Features
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection3FeaturesIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection3FeaturesIndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection3FeaturesRepository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection3Features => HomePageSection3Features.Tenant_ID, tenant => tenant.ID, (HomePageSection3Features, tenant) => new { HomePageSection3Features, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection3Features.Tenant_ID == tenant_Id)
                            && (x.HomePageSection3Features.ID.ToString().Contains(searchValue)
                        || x.HomePageSection3Features.HomePageSection3_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.LongDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection3Features.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection3FeaturesRepository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection3Features => HomePageSection3Features.Tenant_ID, tenant => tenant.ID, (HomePageSection3Features, tenant) => new { HomePageSection3Features, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection3Features.Tenant_ID == tenant_Id)
                            && (x.HomePageSection3Features.ID.ToString().Contains(searchValue)
                        || x.HomePageSection3Features.HomePageSection3_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.LongDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3Features.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection3Features.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection3FeaturesIndexViewModel 
                    {
                        ID = x.HomePageSection3Features.ID,
                        HomePageSection3_Id = Convert.ToInt64(x.HomePageSection3Features.HomePageSection3_Id),
                        ShortDescription = x.HomePageSection3Features.ShortDescription,
                        LongDescription = x.HomePageSection3Features.LongDescription,
                        AncharTagTitle = x.HomePageSection3Features.AncharTagTitle,
                        AncharTagUrl = x.HomePageSection3Features.AncharTagUrl,
                        DisplayIndex = x.HomePageSection3Features.DisplayIndex,
                        Url= x.HomePageSection3Features.Url,
                        Metadata= x.HomePageSection3Features.Metadata,
                        MetaDescription= x.HomePageSection3Features.MetaDescription,
                        Keyword= x.HomePageSection3Features.Keyword,
                        TotalViews= x.HomePageSection3Features.TotalViews,
                        IsActive = x.HomePageSection3Features.IsActive,
                        TenantName = x.HomePageSection3Features.Tenant.Name,
                        CreatedBy = x.HomePageSection3Features.CreatedBy,
                        UpdatedBy = x.HomePageSection3Features.UpdatedBy,
                        CreatedOn= x.HomePageSection3Features.CreatedOn,
                        UpdatedOn= x.HomePageSection3Features.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection3FeaturesIndexViewModel>
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





        public EntityModel.HomePageSection3Features Create(EntityModel.HomePageSection3Features entity)
        {
            try
            {
                return unitOfWork.HomePageSection3FeaturesRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection3Features GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection3Features entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection3FeaturesRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection3Features Update(EntityModel.HomePageSection3Features entity)
        {
            try
            {
                return unitOfWork.HomePageSection3FeaturesRepository.Update(entity);
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
                unitOfWork.HomePageSection3FeaturesRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection3Features> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection3FeaturesRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection3Features> FindBy(Expression<Func<EntityModel.HomePageSection3Features, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection3Features> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection3FeaturesRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection3FeaturesRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection3Features, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection3FeaturesRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection3Features, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection3FeaturesRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
