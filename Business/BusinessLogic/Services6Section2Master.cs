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
    public class Services6Section2Master : BaseBusiness, IServices6Section2Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services6Section2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services6Section2MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services6Section2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services6Section2Master => Services6Section2Master.Tenant_ID, tenant => tenant.ID, (Services6Section2Master, tenant) => new { Services6Section2Master, tenant })
                    .Join(unitOfWork.Services6MasterRepository.Get(), Services6Section2Master_tenant => Services6Section2Master_tenant.Services6Section2Master.Service_Id, Services6Master => Services6Master.ID, (Services6Section2Master_tenant, Services6Master) => new { Services6Section2Master_tenant, Services6Master })
                    .Count(x => (tenant_Id == null || x.Services6Section2Master_tenant.Services6Section2Master.Tenant_ID == tenant_Id)
                            && (x.Services6Section2Master_tenant.Services6Section2Master.ID.ToString().Contains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.Title.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.ImageFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services6Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services6Section2Master_tenant.Services6Section2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services6Section2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services6Section2Master => Services6Section2Master.Tenant_ID, tenant => tenant.ID, (Services6Section2Master, tenant) => new { Services6Section2Master, tenant })
                    .Join(unitOfWork.Services6MasterRepository.Get(), Services6Section2Master_tenant => Services6Section2Master_tenant.Services6Section2Master.Service_Id, Services6Master => Services6Master.ID, (Services6Section2Master_tenant, Services6Master) => new { Services6Section2Master_tenant, Services6Master })
                    .Where(x => (tenant_Id == null || x.Services6Section2Master_tenant.Services6Section2Master.Tenant_ID == tenant_Id)
                            && (x.Services6Section2Master_tenant.Services6Section2Master.ID.ToString().Contains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.Title.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.ImageFilePath.CaseInsensitiveContains(searchValue)
                        || x.Services6Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services6Section2Master_tenant.Services6Section2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services6Section2MasterIndexViewModel
                    {
                        ID = x.Services6Section2Master_tenant.Services6Section2Master.ID,
                        Title = x.Services6Section2Master_tenant.Services6Section2Master.Title,
                        ImageFilePath = x.Services6Section2Master_tenant.Services6Section2Master.ImageFilePath,
                        SubSubCategoryName = x.Services6Master.SubSubCategoryName,
                        DisplayIndex = x.Services6Section2Master_tenant.Services6Section2Master.DisplayIndex,
                        Url = x.Services6Section2Master_tenant.Services6Section2Master.Url,
                        Metadata = x.Services6Section2Master_tenant.Services6Section2Master.Metadata,
                        MetaDescription = x.Services6Section2Master_tenant.Services6Section2Master.MetaDescription,
                        Keyword = x.Services6Section2Master_tenant.Services6Section2Master.Keyword,
                        TotalViews = x.Services6Section2Master_tenant.Services6Section2Master.TotalViews,
                        IsActive = x.Services6Section2Master_tenant.Services6Section2Master.IsActive,
                        TenantName = x.Services6Section2Master_tenant.Services6Section2Master.Tenant.Name,
                        Tenant_ID = x.Services6Section2Master_tenant.Services6Section2Master.Tenant.ID,
                        CreatedBy = x.Services6Section2Master_tenant.Services6Section2Master.CreatedBy,
                        CreatedOn = x.Services6Section2Master_tenant.Services6Section2Master.CreatedOn,
                        UpdatedBy = x.Services6Section2Master_tenant.Services6Section2Master.UpdatedBy,
                        UpdatedOn = x.Services6Section2Master_tenant.Services6Section2Master.UpdatedOn,
                        ServiceUrl = x.Services6Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services6Section2MasterIndexViewModel>
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





        public EntityModel.Services6Section2Master Create(EntityModel.Services6Section2Master entity)
        {
            try
            {
                return unitOfWork.Services6Section2MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services6Section2Master GetById(long Id)
        {
            try
            {
                EntityModel.Services6Section2Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services6Section2MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services6Section2Master Update(EntityModel.Services6Section2Master entity)
        {
            try
            {
                return unitOfWork.Services6Section2MasterRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices6Section2Master]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services6Section2Master> GetAll()
        {
            try
            {
                return unitOfWork.Services6Section2MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services6Section2Master> FindBy(Expression<Func<EntityModel.Services6Section2Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services6Section2Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services6Section2MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services6Section2MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services6Section2Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services6Section2MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services6Section2Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services6Section2MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
