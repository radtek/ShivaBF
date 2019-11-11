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
    public class Services4Section678FieldMaster : BaseBusiness, IServices4Section678FieldMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section678FieldMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section678FieldMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section678FieldMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section678FieldMaster => Services4Section678FieldMaster.Tenant_ID, tenant => tenant.ID, (Services4Section678FieldMaster, tenant) => new { Services4Section678FieldMaster, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section678FieldMaster_tenant => Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Service_Id, Services4Master => Services4Master.ID, (Services4Section678FieldMaster_tenant, Services4Master) => new { Services4Section678FieldMaster_tenant, Services4Master })
                    .Count(x => (tenant_Id == null || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Tenant_ID == tenant_Id)
                            && (x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.ID.ToString().Contains(searchValue)
                            || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.FieldName.CaseInsensitiveContains(searchValue)
                            || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.SectionType.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section678FieldMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section678FieldMaster => Services4Section678FieldMaster.Tenant_ID, tenant => tenant.ID, (Services4Section678FieldMaster, tenant) => new { Services4Section678FieldMaster, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section678FieldMaster_tenant => Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Service_Id, Services4Master => Services4Master.ID, (Services4Section678FieldMaster_tenant, Services4Master) => new { Services4Section678FieldMaster_tenant, Services4Master })
                    .Where(x => (tenant_Id == null || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Tenant_ID == tenant_Id)
                            && (x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.ID.ToString().Contains(searchValue)
                            || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.FieldName.CaseInsensitiveContains(searchValue)
                            || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.SectionType.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section678FieldMasterIndexViewModel
                    {
                        ID = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.ID,
                        FieldName = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.FieldName,
                        SectionType = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.SectionType,
                        SubSubCategoryName = x.Services4Master.SubSubCategoryName,
                        DisplayIndex = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.DisplayIndex,
                        Url = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Url,
                        Metadata = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Metadata,
                        MetaDescription = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.MetaDescription,
                        Keyword = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Keyword,
                        TotalViews = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.TotalViews,
                        IsActive = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.IsActive,
                        TenantName = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Tenant.Name,
                        Tenant_ID = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.Tenant.ID,
                        CreatedBy = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.CreatedBy,
                        CreatedOn = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.CreatedOn,
                        UpdatedBy = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.UpdatedBy,
                        UpdatedOn = x.Services4Section678FieldMaster_tenant.Services4Section678FieldMaster.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section678FieldMasterIndexViewModel>
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

        
        public EntityModel.Services4Section678FieldMaster Create(EntityModel.Services4Section678FieldMaster entity)
        {
            try
            {
                return unitOfWork.Services4Section678FieldMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section678FieldMaster GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section678FieldMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section678FieldMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section678FieldMaster Update(EntityModel.Services4Section678FieldMaster entity)
        {
            try
            {
                return unitOfWork.Services4Section678FieldMasterRepository.Update(entity);
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
                unitOfWork.Services4Section678FieldMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section678FieldMaster> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section678FieldMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section678FieldMaster> FindBy(Expression<Func<EntityModel.Services4Section678FieldMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section678FieldMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section678FieldMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section678FieldMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section678FieldMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section678FieldMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section678FieldMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section678FieldMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
