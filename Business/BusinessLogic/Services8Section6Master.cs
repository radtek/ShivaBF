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
    public class Services8Section6Master : BaseBusiness, IServices8Section6Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services8Section6MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services8Section6MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services8Section6MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services8Section6Master => Services8Section6Master.Tenant_ID, tenant => tenant.ID, (Services8Section6Master, tenant) => new { Services8Section6Master, tenant })
                    .Join(unitOfWork.Services8MasterRepository.Get(), Services8Section6Master_tenant => Services8Section6Master_tenant.Services8Section6Master.Service_Id, Services8Master => Services8Master.ID, (Services8Section6Master_tenant, Services8Master) => new { Services8Section6Master_tenant, Services8Master })
                    .Count(x => (tenant_Id == null || x.Services8Section6Master_tenant.Services8Section6Master.Tenant_ID == tenant_Id)
                            && (x.Services8Section6Master_tenant.Services8Section6Master.ID.ToString().Contains(searchValue)
                             || x.Services8Section6Master_tenant.Services8Section6Master.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.HeadingText.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services8Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services8Section6Master_tenant.Services8Section6Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services8Section6MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services8Section6Master => Services8Section6Master.Tenant_ID, tenant => tenant.ID, (Services8Section6Master, tenant) => new { Services8Section6Master, tenant })
                    .Join(unitOfWork.Services8MasterRepository.Get(), Services8Section6Master_tenant => Services8Section6Master_tenant.Services8Section6Master.Service_Id, Services8Master => Services8Master.ID, (Services8Section6Master_tenant, Services8Master) => new { Services8Section6Master_tenant, Services8Master })
                    .Where(x => (tenant_Id == null || x.Services8Section6Master_tenant.Services8Section6Master.Tenant_ID == tenant_Id)
                            && (x.Services8Section6Master_tenant.Services8Section6Master.ID.ToString().Contains(searchValue)
                             || x.Services8Section6Master_tenant.Services8Section6Master.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.HeadingText.CaseInsensitiveContains(searchValue)
                            || x.Services8Section6Master_tenant.Services8Section6Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services8Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services8Section6Master_tenant.Services8Section6Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services8Section6MasterIndexViewModel
                    {
                        ID = x.Services8Section6Master_tenant.Services8Section6Master.ID,
                        HeadingText = x.Services8Section6Master_tenant.Services8Section6Master.HeadingText,
                        ShortDescription = x.Services8Section6Master_tenant.Services8Section6Master.ShortDescription,
                        AncharTagTitle = x.Services8Section6Master_tenant.Services8Section6Master.AncharTagTitle,
                        AncharTagUrl = x.Services8Section6Master_tenant.Services8Section6Master.AncharTagUrl,
                        SubSubCategoryName = x.Services8Master.SubSubCategoryName,
                        DisplayIndex = x.Services8Section6Master_tenant.Services8Section6Master.DisplayIndex,
                       // DisplayOnHome = x.Services8Section6Master_tenant.Services8Section6Master.DisplayOnHome,
                        Url = x.Services8Section6Master_tenant.Services8Section6Master.Url,
                        Metadata = x.Services8Section6Master_tenant.Services8Section6Master.Metadata,
                        MetaDescription = x.Services8Section6Master_tenant.Services8Section6Master.MetaDescription,
                        Keyword = x.Services8Section6Master_tenant.Services8Section6Master.Keyword,
                        TotalViews = x.Services8Section6Master_tenant.Services8Section6Master.TotalViews,
                        IsActive = x.Services8Section6Master_tenant.Services8Section6Master.IsActive,
                        TenantName = x.Services8Section6Master_tenant.Services8Section6Master.Tenant.Name,
                        Tenant_ID = x.Services8Section6Master_tenant.Services8Section6Master.Tenant.ID,
                        CreatedBy = x.Services8Section6Master_tenant.Services8Section6Master.CreatedBy,
                        CreatedOn = x.Services8Section6Master_tenant.Services8Section6Master.CreatedOn,
                        UpdatedBy = x.Services8Section6Master_tenant.Services8Section6Master.UpdatedBy,
                        UpdatedOn = x.Services8Section6Master_tenant.Services8Section6Master.UpdatedOn,
                        ServiceUrl = x.Services8Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services8Section6MasterIndexViewModel>
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





        public EntityModel.Services8Section6Master Create(EntityModel.Services8Section6Master entity)
        {
            try
            {
                return unitOfWork.Services8Section6MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services8Section6Master GetById(long Id)
        {
            try
            {
                EntityModel.Services8Section6Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services8Section6MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services8Section6Master Update(EntityModel.Services8Section6Master entity)
        {
            try
            {
                return unitOfWork.Services8Section6MasterRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices8Section6Master]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services8Section6Master> GetAll()
        {
            try
            {
                return unitOfWork.Services8Section6MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services8Section6Master> FindBy(Expression<Func<EntityModel.Services8Section6Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services8Section6Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services8Section6MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services8Section6MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services8Section6Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services8Section6MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services8Section6Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services8Section6MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
