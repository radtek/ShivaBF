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
    public class Services7Section4 : BaseBusiness, IServices7Section4
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services7Section4IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services7Section4IndexViewModel> collection;
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
                totalRecords = unitOfWork.Services7Section4Repository.Get().Join(unitOfWork.TenantRepository.Get(), Services7Section4 => Services7Section4.Tenant_ID, tenant => tenant.ID, (Services7Section4, tenant) => new { Services7Section4, tenant })
                    .Join(unitOfWork.Services7MasterRepository.Get(), Services7Section4_tenant => Services7Section4_tenant.Services7Section4.Service_Id, Services7Master => Services7Master.ID, (Services7Section4_tenant, Services7Master) => new { Services7Section4_tenant, Services7Master })
                    .Count(x => (tenant_Id == null || x.Services7Section4_tenant.Services7Section4.Tenant_ID == tenant_Id)
                            && (x.Services7Section4_tenant.Services7Section4.ID.ToString().Contains(searchValue)
                             || x.Services7Section4_tenant.Services7Section4.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.Heading.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services7Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services7Section4_tenant.Services7Section4.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services7Section4Repository.Get().Join(unitOfWork.TenantRepository.Get(), Services7Section4 => Services7Section4.Tenant_ID, tenant => tenant.ID, (Services7Section4, tenant) => new { Services7Section4, tenant })
                    .Join(unitOfWork.Services7MasterRepository.Get(), Services7Section4_tenant => Services7Section4_tenant.Services7Section4.Service_Id, Services7Master => Services7Master.ID, (Services7Section4_tenant, Services7Master) => new { Services7Section4_tenant, Services7Master })
                    .Where(x => (tenant_Id == null || x.Services7Section4_tenant.Services7Section4.Tenant_ID == tenant_Id)
                            && (x.Services7Section4_tenant.Services7Section4.ID.ToString().Contains(searchValue)
                             || x.Services7Section4_tenant.Services7Section4.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services7Section4_tenant.Services7Section4.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services7Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7Section4_tenant.Services7Section4.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services7Section4_tenant.Services7Section4.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services7Section4IndexViewModel
                    {
                        ID = x.Services7Section4_tenant.Services7Section4.ID,
                        Heading = x.Services7Section4_tenant.Services7Section4.Heading,
                        ShortDescription = x.Services7Section4_tenant.Services7Section4.ShortDescription,
                        AncharTagTitle = x.Services7Section4_tenant.Services7Section4.AncharTagTitle,
                        AncharTagUrl = x.Services7Section4_tenant.Services7Section4.AncharTagUrl,
                        SubSubCategoryName = x.Services7Master.SubSubCategoryName,
                        DisplayIndex = x.Services7Section4_tenant.Services7Section4.DisplayIndex,
                       // DisplayOnHome = x.Services7Section4_tenant.Services7Section4.DisplayOnHome,
                        Url = x.Services7Section4_tenant.Services7Section4.Url,
                        Metadata = x.Services7Section4_tenant.Services7Section4.Metadata,
                        MetaDescription = x.Services7Section4_tenant.Services7Section4.MetaDescription,
                        Keyword = x.Services7Section4_tenant.Services7Section4.Keyword,
                        TotalViews = x.Services7Section4_tenant.Services7Section4.TotalViews,
                        IsActive = x.Services7Section4_tenant.Services7Section4.IsActive,
                        TenantName = x.Services7Section4_tenant.Services7Section4.Tenant.Name,
                        Tenant_ID = x.Services7Section4_tenant.Services7Section4.Tenant.ID,
                        CreatedBy = x.Services7Section4_tenant.Services7Section4.CreatedBy,
                        CreatedOn = x.Services7Section4_tenant.Services7Section4.CreatedOn,
                        UpdatedBy = x.Services7Section4_tenant.Services7Section4.UpdatedBy,
                        UpdatedOn = x.Services7Section4_tenant.Services7Section4.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services7Section4IndexViewModel>
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





        public EntityModel.Services7Section4 Create(EntityModel.Services7Section4 entity)
        {
            try
            {
                return unitOfWork.Services7Section4Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services7Section4 GetById(long Id)
        {
            try
            {
                EntityModel.Services7Section4 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services7Section4Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services7Section4 Update(EntityModel.Services7Section4 entity)
        {
            try
            {
                return unitOfWork.Services7Section4Repository.Update(entity);
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
                unitOfWork.Services7Section4Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services7Section4> GetAll()
        {
            try
            {
                return unitOfWork.Services7Section4Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services7Section4> FindBy(Expression<Func<EntityModel.Services7Section4, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services7Section4> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services7Section4Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services7Section4Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services7Section4, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services7Section4Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services7Section4, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services7Section4Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
