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
    public class Services3Master : BaseBusiness, IServices3Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services3MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services3MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services3MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services3Master => Services3Master.Tenant_ID, tenant => tenant.ID, (Services3Master, tenant) => new { Services3Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services3Master_tenant => Services3Master_tenant.Services3Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services3Master_tenant, SubSubCategoriesMaster) => new { Services3Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services3Master_tenant.Services3Master.Tenant_ID == tenant_Id)
                            && (x.Services3Master_tenant.Services3Master.ID.ToString().Contains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section1Heading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section4Heading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section5Heading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section5Description.CaseInsensitiveContains(searchValue)
                         || x.Services3Master_tenant.Services3Master.Section5TextboxMaskedText.CaseInsensitiveContains(searchValue)
                          || x.Services3Master_tenant.Services3Master.Section6PriceingHeading.CaseInsensitiveContains(searchValue)
                           || x.Services3Master_tenant.Services3Master.Section6PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services3Master_tenant.Services3Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services3MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services3Master => Services3Master.Tenant_ID, tenant => tenant.ID, (Services3Master, tenant) => new { Services3Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services3Master_tenant => Services3Master_tenant.Services3Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services3Master_tenant, SubSubCategoriesMaster) => new { Services3Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services3Master_tenant.Services3Master.Tenant_ID == tenant_Id)
                            && (x.Services3Master_tenant.Services3Master.ID.ToString().Contains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section1Heading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section4Heading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section5Heading.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Section5Description.CaseInsensitiveContains(searchValue)
                         || x.Services3Master_tenant.Services3Master.Section5TextboxMaskedText.CaseInsensitiveContains(searchValue)
                          || x.Services3Master_tenant.Services3Master.Section6PriceingHeading.CaseInsensitiveContains(searchValue)
                           || x.Services3Master_tenant.Services3Master.Section6PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Master_tenant.Services3Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services3Master_tenant.Services3Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services3MasterIndexViewModel 
                    {
                        ID = x.Services3Master_tenant.Services3Master.ID,
                        BannerImagePath = x.Services3Master_tenant.Services3Master.BannerImagePath,
                        BannerOnHeading = x.Services3Master_tenant.Services3Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services3Master_tenant.Services3Master.BannerHeadingDescription,
                        Cat_Id = x.Services3Master_tenant.Services3Master.Cat_Id,
                        SubCat_Id = x.Services3Master_tenant.Services3Master.SubCat_Id,
                        SubSubCat_Id = x.Services3Master_tenant.Services3Master.SubSubCat_Id,
                        Section1Heading = x.Services3Master_tenant.Services3Master.Section1Heading,
                        Section1Description = x.Services3Master_tenant.Services3Master.Section1Description,
                        Section4Heading = x.Services3Master_tenant.Services3Master.Section4Heading,
                        Section5Heading = x.Services3Master_tenant.Services3Master.Section5Heading,
                        Section5Description = x.Services3Master_tenant.Services3Master.Section5Description,
                        Section5TextboxMaskedText = x.Services3Master_tenant.Services3Master.Section5TextboxMaskedText,
                        Section6PriceingHeading = x.Services3Master_tenant.Services3Master.Section6PriceingHeading,
                        Section6PriceingDescription = x.Services3Master_tenant.Services3Master.Section6PriceingDescription,
                        DisplayIndex = x.Services3Master_tenant.Services3Master.DisplayIndex,
                        Url= x.Services3Master_tenant.Services3Master.Url.ToString(),
                        Metadata= x.Services3Master_tenant.Services3Master.Metadata.ToString(),
                        MetaDescription= x.Services3Master_tenant.Services3Master.MetaDescription.ToString(),
                        Keyword= x.Services3Master_tenant.Services3Master.Keyword.ToString(),
                        TotalViews= x.Services3Master_tenant.Services3Master.TotalViews,
                        IsActive = x.Services3Master_tenant.Services3Master.IsActive,
                        TenantName = x.Services3Master_tenant.Services3Master.Tenant.Name,
                        CreatedBy = x.Services3Master_tenant.Services3Master.CreatedBy,
                        UpdatedBy = x.Services3Master_tenant.Services3Master.UpdatedBy,
                        CreatedOn= x.Services3Master_tenant.Services3Master.CreatedOn,
                        UpdatedOn= x.Services3Master_tenant.Services3Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services3MasterIndexViewModel>
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





        public EntityModel.Services3Master Create(EntityModel.Services3Master entity)
        {
            try
            {
                return unitOfWork.Services3MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services3Master GetById(long Id)
        {
            try
            {
                EntityModel.Services3Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services3MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services3Master Update(EntityModel.Services3Master entity)
        {
            try
            {
                return unitOfWork.Services3MasterRepository.Update(entity);
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
                unitOfWork.Services3MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services3Master> GetAll()
        {
            try
            {
                return unitOfWork.Services3MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services3Master> FindBy(Expression<Func<EntityModel.Services3Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services3Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services3MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services3MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services3Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services3MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services3Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services3MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
