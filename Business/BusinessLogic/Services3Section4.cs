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
    public class Services3Section4 : BaseBusiness, IServices3Section4
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services3Section4IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services3Section4IndexViewModel> collection;
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
                totalRecords = unitOfWork.Services3Section4Repository.Get().Join(unitOfWork.TenantRepository.Get(), Services3Section4 => Services3Section4.Tenant_ID, tenant => tenant.ID, (Services3Section4, tenant) => new { Services3Section4, tenant })
                    .Join(unitOfWork.Services3MasterRepository.Get(), Services3Section4_tenant => Services3Section4_tenant.Services3Section4.Service_Id, Services3Master => Services3Master.ID, (Services3Section4_tenant, Services3Master) => new { Services3Section4_tenant, Services3Master })
                    .Join(unitOfWork.StateMasterRepository.Get(), Services3Section4_tenant_Services3Master => Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.State_Id, stateMaster => stateMaster.ID, (Services3Section4_tenant_Services3Master, stateMaster) => new { Services3Section4_tenant_Services3Master, stateMaster })
                    .Count(x => (tenant_Id == null || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Tenant_ID == tenant_Id)
                            && (x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.ID.ToString().Contains(searchValue)
                            || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services3Section4Repository.Get().Join(unitOfWork.TenantRepository.Get(), Services3Section4 => Services3Section4.Tenant_ID, tenant => tenant.ID, (Services3Section4, tenant) => new { Services3Section4, tenant })
                    .Join(unitOfWork.Services3MasterRepository.Get(), Services3Section4_tenant => Services3Section4_tenant.Services3Section4.Service_Id, Services3Master => Services3Master.ID, (Services3Section4_tenant, Services3Master) => new { Services3Section4_tenant, Services3Master })
                    .Join(unitOfWork.StateMasterRepository.Get(), Services3Section4_tenant_Services3Master => Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.State_Id, stateMaster => stateMaster.ID, (Services3Section4_tenant_Services3Master, stateMaster) => new { Services3Section4_tenant_Services3Master, stateMaster })
                    .Where(x => (tenant_Id == null || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Tenant_ID == tenant_Id)
                            && (x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.ID.ToString().Contains(searchValue)
                            || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Heading.CaseInsensitiveContains(searchValue)
                            || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services3Section4IndexViewModel
                    {
                        ID = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.ID,
                        StateFullName = x.stateMaster.StateFullName,
                        Heading = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Heading,
                        ShortDescription = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.ShortDescription,
                        AncharTagTitle = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.AncharTagTitle,
                        AncharTagUrl = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.AncharTagUrl,
                        SubSubCategoryName = x.Services3Section4_tenant_Services3Master.Services3Master.SubSubCategoryName,
                        DisplayIndex = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.DisplayIndex,
                        Url = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Url,
                        Metadata = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Metadata,
                        MetaDescription = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.MetaDescription,
                        Keyword = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Keyword,
                        TotalViews = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.TotalViews,
                        IsActive = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.IsActive,
                        TenantName = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Tenant.Name,
                        Tenant_ID = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.Tenant.ID,
                        CreatedBy = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.CreatedBy,
                        CreatedOn = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.CreatedOn,
                        UpdatedBy = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.UpdatedBy,
                        UpdatedOn = x.Services3Section4_tenant_Services3Master.Services3Section4_tenant.Services3Section4.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services3Section4IndexViewModel>
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





        public EntityModel.Services3Section4 Create(EntityModel.Services3Section4 entity)
        {
            try
            {
                return unitOfWork.Services3Section4Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services3Section4 GetById(long Id)
        {
            try
            {
                EntityModel.Services3Section4 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services3Section4Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services3Section4 Update(EntityModel.Services3Section4 entity)
        {
            try
            {
                return unitOfWork.Services3Section4Repository.Update(entity);
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
                unitOfWork.Services3Section4Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services3Section4> GetAll()
        {
            try
            {
                return unitOfWork.Services3Section4Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services3Section4> FindBy(Expression<Func<EntityModel.Services3Section4, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services3Section4> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services3Section4Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services3Section4Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services3Section4, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services3Section4Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services3Section4, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services3Section4Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
