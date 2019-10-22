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
    public class Services7Master : BaseBusiness, IServices7Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services7MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services7MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services7MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services7Master => Services7Master.Tenant_ID, tenant => tenant.ID, (Services7Master, tenant) => new { Services7Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services7Master_tenant => Services7Master_tenant.Services7Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services7Master_tenant, SubSubCategoriesMaster) => new { Services7Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services7Master_tenant.Services7Master.Tenant_ID == tenant_Id)
                            && (x.Services7Master_tenant.Services7Master.ID.ToString().Contains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section1Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section4Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section5Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section5Description.CaseInsensitiveContains(searchValue)
                         || x.Services7Master_tenant.Services7Master.Section5TextboxMaskedText.CaseInsensitiveContains(searchValue)
                          || x.Services7Master_tenant.Services7Master.Section6PriceingHeading.CaseInsensitiveContains(searchValue)
                           || x.Services7Master_tenant.Services7Master.Section6PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services7Master_tenant.Services7Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services7MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services7Master => Services7Master.Tenant_ID, tenant => tenant.ID, (Services7Master, tenant) => new { Services7Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services7Master_tenant => Services7Master_tenant.Services7Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services7Master_tenant, SubSubCategoriesMaster) => new { Services7Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services7Master_tenant.Services7Master.Tenant_ID == tenant_Id)
                            && (x.Services7Master_tenant.Services7Master.ID.ToString().Contains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section1Description.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section1Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section4Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section5Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Section5Description.CaseInsensitiveContains(searchValue)
                         || x.Services7Master_tenant.Services7Master.Section5TextboxMaskedText.CaseInsensitiveContains(searchValue)
                          || x.Services7Master_tenant.Services7Master.Section6PriceingHeading.CaseInsensitiveContains(searchValue)
                           || x.Services7Master_tenant.Services7Master.Section6PriceingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7Master_tenant.Services7Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services7Master_tenant.Services7Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services7MasterIndexViewModel 
                    {
                        ID = x.Services7Master_tenant.Services7Master.ID,
                        BannerImagePath = x.Services7Master_tenant.Services7Master.BannerImagePath,
                        BannerOnHeading = x.Services7Master_tenant.Services7Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services7Master_tenant.Services7Master.BannerHeadingDescription,
                        Cat_Id = x.Services7Master_tenant.Services7Master.Cat_Id,
                        SubCat_Id = x.Services7Master_tenant.Services7Master.SubCat_Id,
                        SubSubCat_Id = x.Services7Master_tenant.Services7Master.SubSubCat_Id,
                        Section1Heading = x.Services7Master_tenant.Services7Master.Section1Heading,
                        Section1Description = x.Services7Master_tenant.Services7Master.Section1Description,
                        Section4Heading = x.Services7Master_tenant.Services7Master.Section4Heading,
                        Section5Heading = x.Services7Master_tenant.Services7Master.Section5Heading,
                        Section5Description = x.Services7Master_tenant.Services7Master.Section5Description,
                        Section5TextboxMaskedText = x.Services7Master_tenant.Services7Master.Section5TextboxMaskedText,
                        Section6PriceingHeading = x.Services7Master_tenant.Services7Master.Section6PriceingHeading,
                        Section6PriceingDescription = x.Services7Master_tenant.Services7Master.Section6PriceingDescription,
                        DisplayIndex = x.Services7Master_tenant.Services7Master.DisplayIndex,
                        Url= x.Services7Master_tenant.Services7Master.Url.ToString(),
                        Metadata= x.Services7Master_tenant.Services7Master.Metadata.ToString(),
                        MetaDescription= x.Services7Master_tenant.Services7Master.MetaDescription.ToString(),
                        Keyword= x.Services7Master_tenant.Services7Master.Keyword.ToString(),
                        TotalViews= x.Services7Master_tenant.Services7Master.TotalViews,
                        IsActive = x.Services7Master_tenant.Services7Master.IsActive,
                        TenantName = x.Services7Master_tenant.Services7Master.Tenant.Name,
                        CreatedBy = x.Services7Master_tenant.Services7Master.CreatedBy,
                        UpdatedBy = x.Services7Master_tenant.Services7Master.UpdatedBy,
                        CreatedOn= x.Services7Master_tenant.Services7Master.CreatedOn,
                        UpdatedOn= x.Services7Master_tenant.Services7Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services7MasterIndexViewModel>
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





        public EntityModel.Services7Master Create(EntityModel.Services7Master entity)
        {
            try
            {
                return unitOfWork.Services7MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services7Master GetById(long Id)
        {
            try
            {
                EntityModel.Services7Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services7MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services7Master Update(EntityModel.Services7Master entity)
        {
            try
            {
                return unitOfWork.Services7MasterRepository.Update(entity);
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
                unitOfWork.Services7MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services7Master> GetAll()
        {
            try
            {
                return unitOfWork.Services7MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services7Master> FindBy(Expression<Func<EntityModel.Services7Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services7Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services7MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services7MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services7Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services7MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services7Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services7MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
