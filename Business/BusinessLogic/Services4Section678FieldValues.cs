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
    public class Services4Section678FieldValues : BaseBusiness, IServices4Section678FieldValues
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section678FieldValuesIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section678FieldValuesIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section678FieldValuesRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section678FieldValues => Services4Section678FieldValues.Tenant_ID, tenant => tenant.ID, (Services4Section678FieldValues, tenant) => new { Services4Section678FieldValues, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section678FieldValues_tenant => Services4Section678FieldValues_tenant.Services4Section678FieldValues.Service_Id, Services4Master => Services4Master.ID, (Services4Section678FieldValues_tenant, Services4Master) => new { Services4Section678FieldValues_tenant, Services4Master })
                    .Count(x => (tenant_Id == null || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Tenant_ID == tenant_Id)
                            && (x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.ID.ToString().Contains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.RowNumber.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayText.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DownloadFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section678FieldValuesRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section678FieldValues => Services4Section678FieldValues.Tenant_ID, tenant => tenant.ID, (Services4Section678FieldValues, tenant) => new { Services4Section678FieldValues, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section678FieldValues_tenant => Services4Section678FieldValues_tenant.Services4Section678FieldValues.Service_Id, Services4Master => Services4Master.ID, (Services4Section678FieldValues_tenant, Services4Master) => new { Services4Section678FieldValues_tenant, Services4Master })
                    .Where(x => (tenant_Id == null || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Tenant_ID == tenant_Id)
                            && (x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.ID.ToString().Contains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.RowNumber.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayText.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DownloadFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section678FieldValuesIndexViewModel
                    {
                        ID = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.ID,
                        S4S678FM_Id = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.S4S678FM_Id,
                        RowNumber = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.RowNumber,
                        DisplayText = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayText,
                        DownloadFilePath = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DownloadFilePath,
                        SubSubCategoryName = x.Services4Master.SubSubCategoryName,
                        DisplayIndex = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.DisplayIndex,
                        Url = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Url,
                        Metadata = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Metadata,
                        MetaDescription = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.MetaDescription,
                        Keyword = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Keyword,
                        TotalViews = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.TotalViews,
                        IsActive = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.IsActive,
                        TenantName = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Tenant.Name,
                        Tenant_ID = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.Tenant.ID,
                        CreatedBy = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedBy,
                        CreatedOn = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.CreatedOn,
                        UpdatedBy = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedBy,
                        UpdatedOn = x.Services4Section678FieldValues_tenant.Services4Section678FieldValues.UpdatedOn,
                        ServiceUrl = x.Services4Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section678FieldValuesIndexViewModel>
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





        public EntityModel.Services4Section678FieldValues Create(EntityModel.Services4Section678FieldValues entity)
        {
            try
            {
                return unitOfWork.Services4Section678FieldValuesRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section678FieldValues GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section678FieldValues entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section678FieldValuesRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section678FieldValues Update(EntityModel.Services4Section678FieldValues entity)
        {
            try
            {
                return unitOfWork.Services4Section678FieldValuesRepository.Update(entity);
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
                unitOfWork.Services4Section678FieldValuesRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section678FieldValues> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section678FieldValuesRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section678FieldValues> FindBy(Expression<Func<EntityModel.Services4Section678FieldValues, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section678FieldValues> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section678FieldValuesRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section678FieldValuesRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section678FieldValues, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section678FieldValuesRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section678FieldValues, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section678FieldValuesRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
