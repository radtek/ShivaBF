﻿using System;
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
    public class Services4Section2FAQMapping : BaseBusiness, IServices4Section2FAQMapping
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section2FAQMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section2FAQMappingIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section2FAQMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section2FAQMapping => Services4Section2FAQMapping.Tenant_ID, tenant => tenant.ID, (Services4Section2FAQMapping, tenant) => new { Services4Section2FAQMapping, tenant })
                    .Join(unitOfWork.FAQMasterRepository.Get(), Services4Section2FAQMapping_tenant => Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services4Section2FAQMapping_tenant, FAQMaster) => new { Services4Section2FAQMapping_tenant, FAQMaster })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section2FAQMapping_tenant_FAQMaster => Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Service_Id, Services4Master => Services4Master.ID, (Services4Section2FAQMapping_tenant_FAQMaster, Services4Master) => new { Services4Section2FAQMapping_tenant_FAQMaster, Services4Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Section2FAQMapping_tenant_FAQMaster_Services4Master => Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services4Section2FAQMapping_tenant_FAQMaster_Services4Master, SubSubCategoryMaster) => new { Services4Section2FAQMapping_tenant_FAQMaster_Services4Master, SubSubCategoryMaster })
                    .Count(x => (tenant_Id == null || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant_ID == tenant_Id)
                            && (x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.FAQMaster.Description.ToString().Contains(searchValue)
                       || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.FAQMaster.Title.ToString().Contains(searchValue)
                            || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                      || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section2FAQMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section2FAQMapping => Services4Section2FAQMapping.Tenant_ID, tenant => tenant.ID, (Services4Section2FAQMapping, tenant) => new { Services4Section2FAQMapping, tenant })
                    .Join(unitOfWork.FAQMasterRepository.Get(), Services4Section2FAQMapping_tenant => Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.FAQMaster_Id, FAQMaster => FAQMaster.ID, (Services4Section2FAQMapping_tenant, FAQMaster) => new { Services4Section2FAQMapping_tenant, FAQMaster })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section2FAQMapping_tenant_FAQMaster => Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Service_Id, Services4Master => Services4Master.ID, (Services4Section2FAQMapping_tenant_FAQMaster, Services4Master) => new { Services4Section2FAQMapping_tenant_FAQMaster, Services4Master })
                    .Join(unitOfWork.SubSubCategoriesMasterRepository.Get(), Services4Section2FAQMapping_tenant_FAQMaster_Services4Master => Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.SubSubCat_Id, SubSubCategoryMaster => SubSubCategoryMaster.ID, (Services4Section2FAQMapping_tenant_FAQMaster_Services4Master, SubSubCategoryMaster) => new { Services4Section2FAQMapping_tenant_FAQMaster_Services4Master, SubSubCategoryMaster })
                    .Where(x => (tenant_Id == null || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant_ID == tenant_Id)
                            && (x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.FAQMaster.Description.ToString().Contains(searchValue)
                       || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.FAQMaster.Title.ToString().Contains(searchValue)
                            || x.SubSubCategoryMaster.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                      || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                         // || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayOnHome.ToString().CaseInsensitiveContains(searchValue)
                         || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Keyword.ToString().CaseInsensitiveContains(searchValue)
                            || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section2FAQMappingIndexViewModel
                    {
                        ID = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.ID,
                        SubSubCategory_Name = x.SubSubCategoryMaster.SubSubCategoryName,
                        Description = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.FAQMaster.Description,
                        Title = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.FAQMaster.Title,
                        DisplayIndex = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.DisplayIndex,
                        Url = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Url,
                        Metadata = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Metadata,
                        MetaDescription = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.MetaDescription,
                        Keyword = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Keyword,
                        TotalViews = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.TotalViews,
                        IsActive = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.IsActive,
                        TenantName = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant.Name,
                        Tenant_ID = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.Tenant.ID,
                        CreatedBy = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.CreatedBy,
                        CreatedOn = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.CreatedOn,
                        UpdatedBy = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.UpdatedBy,
                        UpdatedOn = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Section2FAQMapping_tenant_FAQMaster.Services4Section2FAQMapping_tenant.Services4Section2FAQMapping.UpdatedOn,
                        ServiceUrl = x.Services4Section2FAQMapping_tenant_FAQMaster_Services4Master.Services4Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section2FAQMappingIndexViewModel>
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





        public EntityModel.Services4Section2FAQMapping Create(EntityModel.Services4Section2FAQMapping entity)
        {
            try
            {
                return unitOfWork.Services4Section2FAQMappingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section2FAQMapping GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section2FAQMapping entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section2FAQMappingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section2FAQMapping Update(EntityModel.Services4Section2FAQMapping entity)
        {
            try
            {
                return unitOfWork.Services4Section2FAQMappingRepository.Update(entity);
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
                var param = new DynamicParameters();
                param.Add("@serviceId", Id);
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices4Section2FAQMapping]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section2FAQMapping> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section2FAQMappingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section2FAQMapping> FindBy(Expression<Func<EntityModel.Services4Section2FAQMapping, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section2FAQMapping> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section2FAQMappingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section2FAQMappingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section2FAQMapping, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section2FAQMappingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section2FAQMapping, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section2FAQMappingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
