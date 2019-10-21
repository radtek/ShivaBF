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
    public class Services4Section2Master : BaseBusiness, IServices4Section2Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section2MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section2MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section2Master => Services4Section2Master.Tenant_ID, tenant => tenant.ID, (Services4Section2Master, tenant) => new { Services4Section2Master, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section2Master_tenant => Services4Section2Master_tenant.Services4Section2Master.Service_Id, Services4Master => Services4Master.ID, (Services4Section2Master_tenant, Services4Master) => new { Services4Section2Master_tenant, Services4Master })
                    .Count(x => (tenant_Id == null || x.Services4Section2Master_tenant.Services4Section2Master.Tenant_ID == tenant_Id)
                            && (x.Services4Section2Master_tenant.Services4Section2Master.ID.ToString().Contains(searchValue)
                            || x.Services4Section2Master_tenant.Services4Section2Master.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services4Section2Master_tenant.Services4Section2Master.Description.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services4Section2Master_tenant.Services4Section2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section2MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section2Master => Services4Section2Master.Tenant_ID, tenant => tenant.ID, (Services4Section2Master, tenant) => new { Services4Section2Master, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section2Master_tenant => Services4Section2Master_tenant.Services4Section2Master.Service_Id, Services4Master => Services4Master.ID, (Services4Section2Master_tenant, Services4Master) => new { Services4Section2Master_tenant, Services4Master })
                    .Where(x => (tenant_Id == null || x.Services4Section2Master_tenant.Services4Section2Master.Tenant_ID == tenant_Id)
                            && (x.Services4Section2Master_tenant.Services4Section2Master.ID.ToString().Contains(searchValue)
                            || x.Services4Section2Master_tenant.Services4Section2Master.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services4Section2Master_tenant.Services4Section2Master.Description.CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section2Master_tenant.Services4Section2Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section2MasterIndexViewModel
                    {
                        ID = x.Services4Section2Master_tenant.Services4Section2Master.ID,
                        Heading = x.Services4Section2Master_tenant.Services4Section2Master.Heading,
                        Description = x.Services4Section2Master_tenant.Services4Section2Master.Description,
                        SubSubCategoryName = x.Services4Master.SubSubCategoryName,
                        DisplayIndex = x.Services4Section2Master_tenant.Services4Section2Master.DisplayIndex,
                        Url = x.Services4Section2Master_tenant.Services4Section2Master.Url,
                        Metadata = x.Services4Section2Master_tenant.Services4Section2Master.Metadata,
                        MetaDescription = x.Services4Section2Master_tenant.Services4Section2Master.MetaDescription,
                        Keyword = x.Services4Section2Master_tenant.Services4Section2Master.Keyword,
                        TotalViews = x.Services4Section2Master_tenant.Services4Section2Master.TotalViews,
                        IsActive = x.Services4Section2Master_tenant.Services4Section2Master.IsActive,
                        TenantName = x.Services4Section2Master_tenant.Services4Section2Master.Tenant.Name,
                        Tenant_ID = x.Services4Section2Master_tenant.Services4Section2Master.Tenant.ID,
                        CreatedBy = x.Services4Section2Master_tenant.Services4Section2Master.CreatedBy,
                        CreatedOn = x.Services4Section2Master_tenant.Services4Section2Master.CreatedOn,
                        UpdatedBy = x.Services4Section2Master_tenant.Services4Section2Master.UpdatedBy,
                        UpdatedOn = x.Services4Section2Master_tenant.Services4Section2Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section2MasterIndexViewModel>
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





        public EntityModel.Services4Section2Master Create(EntityModel.Services4Section2Master entity)
        {
            try
            {
                return unitOfWork.Services4Section2MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section2Master GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section2Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section2MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section2Master Update(EntityModel.Services4Section2Master entity)
        {
            try
            {
                return unitOfWork.Services4Section2MasterRepository.Update(entity);
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
                unitOfWork.Services4Section2MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section2Master> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section2MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section2Master> FindBy(Expression<Func<EntityModel.Services4Section2Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section2Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section2MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section2MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section2Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section2MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section2Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section2MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
