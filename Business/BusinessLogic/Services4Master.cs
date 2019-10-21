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
    public class Services4Master : BaseBusiness, IServices4Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Master => Services4Master.Tenant_ID, tenant => tenant.ID, (Services4Master, tenant) => new { Services4Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Master_tenant => Services4Master_tenant.Services4Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services4Master_tenant, SubSubCategoriesMaster) => new { Services4Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services4Master_tenant.Services4Master.Tenant_ID == tenant_Id)
                            && (x.Services4Master_tenant.Services4Master.ID.ToString().Contains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section2PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section2PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section3PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section3PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section4PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section4PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section5PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section6PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section7PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Master_tenant.Services4Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Master => Services4Master.Tenant_ID, tenant => tenant.ID, (Services4Master, tenant) => new { Services4Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Master_tenant => Services4Master_tenant.Services4Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services4Master_tenant, SubSubCategoriesMaster) => new { Services4Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services4Master_tenant.Services4Master.Tenant_ID == tenant_Id)
                            && (x.Services4Master_tenant.Services4Master.ID.ToString().Contains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section2PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section2PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section3PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section3PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section4PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section4PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section5PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section6PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Section7PriceingHeading.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Master_tenant.Services4Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Master_tenant.Services4Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4MasterIndexViewModel 
                    {
                        ID = x.Services4Master_tenant.Services4Master.ID,
                        BannerImagePath = x.Services4Master_tenant.Services4Master.BannerImagePath,
                        BannerOnHeading = x.Services4Master_tenant.Services4Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services4Master_tenant.Services4Master.BannerHeadingDescription,
                        Cat_Id = x.Services4Master_tenant.Services4Master.Cat_Id,
                        SubCat_Id = x.Services4Master_tenant.Services4Master.SubCat_Id,
                        SubSubCat_Id = x.Services4Master_tenant.Services4Master.SubSubCat_Id,
                        Section1Description = x.Services4Master_tenant.Services4Master.Section1Description,
                        Section2PriceingHeading = x.Services4Master_tenant.Services4Master.Section2PriceingHeading,
                        Section2PriceingDescription = x.Services4Master_tenant.Services4Master.Section2PriceingDescription,
                        Section3PriceingHeading = x.Services4Master_tenant.Services4Master.Section3PriceingHeading,
                        Section3PriceingDescription = x.Services4Master_tenant.Services4Master.Section3PriceingDescription,
                        Section4PriceingHeading = x.Services4Master_tenant.Services4Master.Section4PriceingHeading,
                        Section4PriceingDescription = x.Services4Master_tenant.Services4Master.Section4PriceingDescription,
                        Section5PriceingHeading = x.Services4Master_tenant.Services4Master.Section5PriceingHeading,
                        Section6PriceingHeading = x.Services4Master_tenant.Services4Master.Section6PriceingHeading,
                        Section7PriceingHeading = x.Services4Master_tenant.Services4Master.Section7PriceingHeading,
                        DisplayIndex = x.Services4Master_tenant.Services4Master.DisplayIndex,
                        Url= x.Services4Master_tenant.Services4Master.Url.ToString(),
                        Metadata= x.Services4Master_tenant.Services4Master.Metadata.ToString(),
                        MetaDescription= x.Services4Master_tenant.Services4Master.MetaDescription.ToString(),
                        Keyword= x.Services4Master_tenant.Services4Master.Keyword.ToString(),
                        TotalViews= x.Services4Master_tenant.Services4Master.TotalViews,
                        IsActive = x.Services4Master_tenant.Services4Master.IsActive,
                        TenantName = x.Services4Master_tenant.Services4Master.Tenant.Name,
                        CreatedBy = x.Services4Master_tenant.Services4Master.CreatedBy,
                        UpdatedBy = x.Services4Master_tenant.Services4Master.UpdatedBy,
                        CreatedOn= x.Services4Master_tenant.Services4Master.CreatedOn,
                        UpdatedOn= x.Services4Master_tenant.Services4Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4MasterIndexViewModel>
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





        public EntityModel.Services4Master Create(EntityModel.Services4Master entity)
        {
            try
            {
                return unitOfWork.Services4MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Master GetById(long Id)
        {
            try
            {
                EntityModel.Services4Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Master Update(EntityModel.Services4Master entity)
        {
            try
            {
                return unitOfWork.Services4MasterRepository.Update(entity);
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
                unitOfWork.Services4MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Master> GetAll()
        {
            try
            {
                return unitOfWork.Services4MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Master> FindBy(Expression<Func<EntityModel.Services4Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
