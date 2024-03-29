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
    public class HomePageSection1 : BaseBusiness, IHomePageSection1
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection1IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection1IndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection1Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection1 => HomePageSection1.Tenant_ID, tenant => tenant.ID, (HomePageSection1, tenant) => new { HomePageSection1, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection1.Tenant_ID == tenant_Id)
                            && (x.HomePageSection1.ID.ToString().Contains(searchValue)
                        || x.HomePageSection1.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.LongtDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection1.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection1Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection1 => HomePageSection1.Tenant_ID, tenant => tenant.ID, (HomePageSection1, tenant) => new { HomePageSection1, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection1.Tenant_ID == tenant_Id)
                            && (x.HomePageSection1.ID.ToString().Contains(searchValue)
                        || x.HomePageSection1.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.LongtDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection1.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection1.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection1IndexViewModel 
                    {
                        ID = x.HomePageSection1.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.HomePageSection1.Tenant_ID) + "/" + x.HomePageSection1.BannerImagePath,
                        ShortDescription = x.HomePageSection1.ShortDescription,
                        LongtDescription = x.HomePageSection1.LongtDescription,
                        AncharTagTitle = x.HomePageSection1.AncharTagTitle,
                        AncharTagUrl = x.HomePageSection1.AncharTagUrl,
                        DisplayIndex = x.HomePageSection1.DisplayIndex,
                        Url= x.HomePageSection1.Url,
                        Metadata= x.HomePageSection1.Metadata,
                        MetaDescription= x.HomePageSection1.MetaDescription,
                        Keyword= x.HomePageSection1.Keyword.ToString(),
                        TotalViews= x.HomePageSection1.TotalViews,
                        IsActive = x.HomePageSection1.IsActive,
                        TenantName = x.HomePageSection1.Tenant.Name,
                        CreatedBy = x.HomePageSection1.CreatedBy,
                        UpdatedBy = x.HomePageSection1.UpdatedBy,
                        CreatedOn= x.HomePageSection1.CreatedOn,
                        UpdatedOn= x.HomePageSection1.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection1IndexViewModel>
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





        public EntityModel.HomePageSection1 Create(EntityModel.HomePageSection1 entity)
        {
            try
            {
                return unitOfWork.HomePageSection1Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection1 GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection1 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection1Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection1 Update(EntityModel.HomePageSection1 entity)
        {
            try
            {
                return unitOfWork.HomePageSection1Repository.Update(entity);
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
                unitOfWork.HomePageSection1Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection1> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection1Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection1> FindBy(Expression<Func<EntityModel.HomePageSection1, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection1> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection1Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection1Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection1, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection1Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection1, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection1Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
