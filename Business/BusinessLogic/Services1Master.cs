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
    public class Services1Master : BaseBusiness, IServices1Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services1MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services1MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services1MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Master => Services1Master.Tenant_ID, tenant => tenant.ID, (Services1Master, tenant) => new { Services1Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services1Master_tenant => Services1Master_tenant.Services1Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services1Master_tenant, SubSubCategoriesMaster) => new { Services1Master_tenant, SubSubCategoriesMaster })
                    .Count(x => (tenant_Id == null || x.Services1Master_tenant.Services1Master.Tenant_ID == tenant_Id)
                            && (x.Services1Master_tenant.Services1Master.ID.ToString().Contains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerAncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerAncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerHeading.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerImageOnDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section2Description.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section3Heading.CaseInsensitiveContains(searchValue)
                         || x.Services1Master_tenant.Services1Master.Section3Description.CaseInsensitiveContains(searchValue)
                          || x.Services1Master_tenant.Services1Master.Section3TextboxMaskedText.CaseInsensitiveContains(searchValue)
                           || x.Services1Master_tenant.Services1Master.Section4Heading.CaseInsensitiveContains(searchValue)
                            || x.Services1Master_tenant.Services1Master.Section5Heading.CaseInsensitiveContains(searchValue)
                             || x.Services1Master_tenant.Services1Master.Section6Heading.CaseInsensitiveContains(searchValue)
                              || x.Services1Master_tenant.Services1Master.Section6Description.CaseInsensitiveContains(searchValue)
                               || x.Services1Master_tenant.Services1Master.Section7Description.CaseInsensitiveContains(searchValue)
                                || x.Services1Master_tenant.Services1Master.Section8Description.CaseInsensitiveContains(searchValue)
                                 || x.Services1Master_tenant.Services1Master.Section96Heading.CaseInsensitiveContains(searchValue)
                                 || x.Services1Master_tenant.Services1Master.Section9Description.CaseInsensitiveContains(searchValue)
                                  || x.Services1Master_tenant.Services1Master.Section10MappingBankFlag.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Master_tenant.Services1Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services1MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Master => Services1Master.Tenant_ID, tenant => tenant.ID, (Services1Master, tenant) => new { Services1Master, tenant })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services1Master_tenant => Services1Master_tenant.Services1Master.SubSubCat_Id, SubSubCategoriesMaster => SubSubCategoriesMaster.ID, (Services1Master_tenant, SubSubCategoriesMaster) => new { Services1Master_tenant, SubSubCategoriesMaster })
                    .Where(x => (tenant_Id == null || x.Services1Master_tenant.Services1Master.Tenant_ID == tenant_Id)
                            && (x.Services1Master_tenant.Services1Master.ID.ToString().Contains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerOnHeading.CaseInsensitiveContains(searchValue)
                        || x.SubSubCategoriesMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerHeadingDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerAncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.BannerAncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerHeading.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section1AfterBannerImageOnDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section2Heading.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section2Description.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Section3Heading.CaseInsensitiveContains(searchValue)
                         || x.Services1Master_tenant.Services1Master.Section3Description.CaseInsensitiveContains(searchValue)
                          || x.Services1Master_tenant.Services1Master.Section3TextboxMaskedText.CaseInsensitiveContains(searchValue)
                           || x.Services1Master_tenant.Services1Master.Section4Heading.CaseInsensitiveContains(searchValue)
                            || x.Services1Master_tenant.Services1Master.Section5Heading.CaseInsensitiveContains(searchValue)
                             || x.Services1Master_tenant.Services1Master.Section6Heading.CaseInsensitiveContains(searchValue)
                              || x.Services1Master_tenant.Services1Master.Section6Description.CaseInsensitiveContains(searchValue)
                               || x.Services1Master_tenant.Services1Master.Section7Description.CaseInsensitiveContains(searchValue)
                                || x.Services1Master_tenant.Services1Master.Section8Description.CaseInsensitiveContains(searchValue)
                                 || x.Services1Master_tenant.Services1Master.Section96Heading.CaseInsensitiveContains(searchValue)
                                 || x.Services1Master_tenant.Services1Master.Section9Description.CaseInsensitiveContains(searchValue)
                                  || x.Services1Master_tenant.Services1Master.Section10MappingBankFlag.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Master_tenant.Services1Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Master_tenant.Services1Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services1MasterIndexViewModel 
                    {
                        ID = x.Services1Master_tenant.Services1Master.ID,
                        BannerImagePath = x.Services1Master_tenant.Services1Master.BannerImagePath,
                        BannerOnHeading = x.Services1Master_tenant.Services1Master.BannerOnHeading,
                        SubSubCategoryName = x.SubSubCategoriesMaster.SubSubCategoryName,
                        BannerHeadingDescription = x.Services1Master_tenant.Services1Master.BannerHeadingDescription,
                        BannerAncharTagTitle = x.Services1Master_tenant.Services1Master.BannerAncharTagTitle,
                        BannerAncharTagUrl = x.Services1Master_tenant.Services1Master.BannerAncharTagUrl,
                        Section1AfterBannerHeading = x.Services1Master_tenant.Services1Master.Section1AfterBannerHeading,
                        Section1AfterBannerDescription = x.Services1Master_tenant.Services1Master.Section1AfterBannerDescription,
                        Section1AfterBannerImagePath = x.Services1Master_tenant.Services1Master.Section1AfterBannerImagePath,
                        Section1AfterBannerImageOnDescription = x.Services1Master_tenant.Services1Master.Section1AfterBannerImageOnDescription,
                        Section2Heading = x.Services1Master_tenant.Services1Master.Section2Heading,
                        Section2Description = x.Services1Master_tenant.Services1Master.Section2Description,
                        Section3Heading = x.Services1Master_tenant.Services1Master.Section3Heading,
                        Section3Description = x.Services1Master_tenant.Services1Master.Section3Description,
                        Section3TextboxMaskedText = x.Services1Master_tenant.Services1Master.Section3TextboxMaskedText,
                        Section4Heading = x.Services1Master_tenant.Services1Master.Section4Heading,
                        Section5Heading = x.Services1Master_tenant.Services1Master.Section5Heading,
                        Section6Heading = x.Services1Master_tenant.Services1Master.Section6Heading,
                        Section6Description = x.Services1Master_tenant.Services1Master.Section6Description,
                        Section7Description = x.Services1Master_tenant.Services1Master.Section7Description,
                        Section8Description = x.Services1Master_tenant.Services1Master.Section8Description,
                        Section96Heading = x.Services1Master_tenant.Services1Master.Section96Heading,
                        Section9Description = x.Services1Master_tenant.Services1Master.Section9Description,
                        Section10MappingBankFlag= x.Services1Master_tenant.Services1Master.Section10MappingBankFlag,
                        DisplayIndex= x.Services1Master_tenant.Services1Master.DisplayIndex,
                        Url= x.Services1Master_tenant.Services1Master.Url.ToString(),
                        Metadata= x.Services1Master_tenant.Services1Master.Metadata.ToString(),
                        MetaDescription= x.Services1Master_tenant.Services1Master.MetaDescription.ToString(),
                        Keyword= x.Services1Master_tenant.Services1Master.Keyword.ToString(),
                        TotalViews= x.Services1Master_tenant.Services1Master.TotalViews,
                        IsActive = x.Services1Master_tenant.Services1Master.IsActive,
                        TenantName = x.Services1Master_tenant.Services1Master.Tenant.Name,
                        CreatedBy = x.Services1Master_tenant.Services1Master.CreatedBy,
                        UpdatedBy = x.Services1Master_tenant.Services1Master.UpdatedBy,
                        CreatedOn= x.Services1Master_tenant.Services1Master.CreatedOn,
                        UpdatedOn= x.Services1Master_tenant.Services1Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services1MasterIndexViewModel>
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





        public EntityModel.Services1Master Create(EntityModel.Services1Master entity)
        {
            try
            {
                return unitOfWork.Services1MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services1Master GetById(long Id)
        {
            try
            {
                EntityModel.Services1Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services1MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services1Master Update(EntityModel.Services1Master entity)
        {
            try
            {
                return unitOfWork.Services1MasterRepository.Update(entity);
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
                unitOfWork.Services1MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services1Master> GetAll()
        {
            try
            {
                return unitOfWork.Services1MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services1Master> FindBy(Expression<Func<EntityModel.Services1Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services1Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services1MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services1MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services1Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services1MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services1Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services1MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
