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
    public class Services4Section3 : BaseBusiness, IServices4Section3
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section3IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section3IndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section3Repository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section3 => Services4Section3.Tenant_ID, tenant => tenant.ID, (Services4Section3, tenant) => new { Services4Section3, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section3_tenant => Services4Section3_tenant.Services4Section3.Service_Id, Services4Master => Services4Master.ID, (Services4Section3_tenant, Services4Master) => new { Services4Section3_tenant, Services4Master })
                    .Count(x => (tenant_Id == null || x.Services4Section3_tenant.Services4Section3.Tenant_ID == tenant_Id)
                            && (x.Services4Section3_tenant.Services4Section3.ID.ToString().Contains(searchValue)
                            || x.Services4Section3_tenant.Services4Section3.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services4Section3_tenant.Services4Section3.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services4Section3_tenant.Services4Section3.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section3Repository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section3 => Services4Section3.Tenant_ID, tenant => tenant.ID, (Services4Section3, tenant) => new { Services4Section3, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section3_tenant => Services4Section3_tenant.Services4Section3.Service_Id, Services4Master => Services4Master.ID, (Services4Section3_tenant, Services4Master) => new { Services4Section3_tenant, Services4Master })
                    .Where(x => (tenant_Id == null || x.Services4Section3_tenant.Services4Section3.Tenant_ID == tenant_Id)
                            && (x.Services4Section3_tenant.Services4Section3.ID.ToString().Contains(searchValue)
                            || x.Services4Section3_tenant.Services4Section3.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services4Section3_tenant.Services4Section3.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section3_tenant.Services4Section3.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section3_tenant.Services4Section3.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section3IndexViewModel
                    {
                        ID = x.Services4Section3_tenant.Services4Section3.ID,
                        Heading = x.Services4Section3_tenant.Services4Section3.Heading,
                        ShortDescription = x.Services4Section3_tenant.Services4Section3.ShortDescription,
                        SubSubCategoryName = x.Services4Master.SubSubCategoryName,
                        DisplayIndex = x.Services4Section3_tenant.Services4Section3.DisplayIndex,
                        Url = x.Services4Section3_tenant.Services4Section3.Url,
                        Metadata = x.Services4Section3_tenant.Services4Section3.Metadata,
                        MetaDescription = x.Services4Section3_tenant.Services4Section3.MetaDescription,
                        Keyword = x.Services4Section3_tenant.Services4Section3.Keyword,
                        TotalViews = x.Services4Section3_tenant.Services4Section3.TotalViews,
                        IsActive = x.Services4Section3_tenant.Services4Section3.IsActive,
                        TenantName = x.Services4Section3_tenant.Services4Section3.Tenant.Name,
                        Tenant_ID = x.Services4Section3_tenant.Services4Section3.Tenant.ID,
                        CreatedBy = x.Services4Section3_tenant.Services4Section3.CreatedBy,
                        CreatedOn = x.Services4Section3_tenant.Services4Section3.CreatedOn,
                        UpdatedBy = x.Services4Section3_tenant.Services4Section3.UpdatedBy,
                        UpdatedOn = x.Services4Section3_tenant.Services4Section3.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section3IndexViewModel>
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

        
        public EntityModel.Services4Section3 Create(EntityModel.Services4Section3 entity)
        {
            try
            {
                return unitOfWork.Services4Section3Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section3 GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section3 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section3Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section3 Update(EntityModel.Services4Section3 entity)
        {
            try
            {
                return unitOfWork.Services4Section3Repository.Update(entity);
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
                unitOfWork.Services4Section3Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section3> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section3Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section3> FindBy(Expression<Func<EntityModel.Services4Section3, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section3> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section3Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section3Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section3, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section3Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section3, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section3Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
