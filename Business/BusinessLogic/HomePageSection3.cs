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
    public class HomePageSection3 : BaseBusiness, IHomePageSection3
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection3IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection3IndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection3Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection3 => HomePageSection3.Tenant_ID, tenant => tenant.ID, (HomePageSection3, tenant) => new { HomePageSection3, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection3.Tenant_ID == tenant_Id)
                            && (x.HomePageSection3.ID.ToString().Contains(searchValue)
                        || x.HomePageSection3.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Heading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Heading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Heading3.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection3.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection3Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection3 => HomePageSection3.Tenant_ID, tenant => tenant.ID, (HomePageSection3, tenant) => new { HomePageSection3, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection3.Tenant_ID == tenant_Id)
                            && (x.HomePageSection3.ID.ToString().Contains(searchValue)
                        || x.HomePageSection3.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Heading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Heading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Heading3.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection3.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection3.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection3IndexViewModel 
                    {
                        ID = x.HomePageSection3.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID) + "/" + x.HomePageSection3.BannerImagePath,
                        Heading1 = x.HomePageSection3.Heading1,
                        Heading2 = x.HomePageSection3.Heading2,
                        Heading3 = x.HomePageSection3.Heading3,
                        DisplayIndex = x.HomePageSection3.DisplayIndex,
                        Url= x.HomePageSection3.Url.ToString(),
                        Metadata= x.HomePageSection3.Metadata.ToString(),
                        MetaDescription= x.HomePageSection3.MetaDescription.ToString(),
                        Keyword= x.HomePageSection3.Keyword.ToString(),
                        TotalViews= x.HomePageSection3.TotalViews,
                        IsActive = x.HomePageSection3.IsActive,
                        TenantName = x.HomePageSection3.Tenant.Name,
                        CreatedBy = x.HomePageSection3.CreatedBy,
                        UpdatedBy = x.HomePageSection3.UpdatedBy,
                        CreatedOn= x.HomePageSection3.CreatedOn,
                        UpdatedOn= x.HomePageSection3.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection3IndexViewModel>
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





        public EntityModel.HomePageSection3 Create(EntityModel.HomePageSection3 entity)
        {
            try
            {
                return unitOfWork.HomePageSection3Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection3 GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection3 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection3Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection3 Update(EntityModel.HomePageSection3 entity)
        {
            try
            {
                return unitOfWork.HomePageSection3Repository.Update(entity);
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
                unitOfWork.HomePageSection3Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection3> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection3Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection3> FindBy(Expression<Func<EntityModel.HomePageSection3, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection3> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection3Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection3Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection3, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection3Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection3, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection3Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
