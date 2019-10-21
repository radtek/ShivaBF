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
    public class Services4Section2MasterChild : BaseBusiness, IServices4Section2MasterChild
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services4Section2MasterChildIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services4Section2MasterChildIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services4Section2MasterChildRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section2MasterChild => Services4Section2MasterChild.Tenant_ID, tenant => tenant.ID, (Services4Section2MasterChild, tenant) => new { Services4Section2MasterChild, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section2MasterChild_tenant => Services4Section2MasterChild_tenant.Services4Section2MasterChild.Service_Id, Services4Master => Services4Master.ID, (Services4Section2MasterChild_tenant, Services4Master) => new { Services4Section2MasterChild_tenant, Services4Master })
                    .Count(x => (tenant_Id == null || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Tenant_ID == tenant_Id)
                            && (x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.ID.ToString().Contains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.FeatureDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services4Section2MasterChildRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services4Section2MasterChild => Services4Section2MasterChild.Tenant_ID, tenant => tenant.ID, (Services4Section2MasterChild, tenant) => new { Services4Section2MasterChild, tenant })
                    .Join(unitOfWork.Services4MasterRepository.Get(), Services4Section2MasterChild_tenant => Services4Section2MasterChild_tenant.Services4Section2MasterChild.Service_Id, Services4Master => Services4Master.ID, (Services4Section2MasterChild_tenant, Services4Master) => new { Services4Section2MasterChild_tenant, Services4Master })
                    .Where(x => (tenant_Id == null || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Tenant_ID == tenant_Id)
                            && (x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.ID.ToString().Contains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.FeatureDescription.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Price.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services4Section2MasterChildIndexViewModel
                    {
                        ID = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.ID,
                        AncharTagTitle = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.AncharTagTitle,
                        AncharTagUrl = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.AncharTagUrl,
                        FeatureDescription = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.FeatureDescription,
                        Price = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Price,
                        SubSubCategoryName = x.Services4Master.SubSubCategoryName,
                        DisplayIndex = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.DisplayIndex,
                        Url = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Url,
                        Metadata = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Metadata,
                        MetaDescription = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.MetaDescription,
                        Keyword = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Keyword,
                        TotalViews = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.TotalViews,
                        IsActive = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.IsActive,
                        TenantName = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Tenant.Name,
                        Tenant_ID = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.Tenant.ID,
                        CreatedBy = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.CreatedBy,
                        CreatedOn = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.CreatedOn,
                        UpdatedBy = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.UpdatedBy,
                        UpdatedOn = x.Services4Section2MasterChild_tenant.Services4Section2MasterChild.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services4Section2MasterChildIndexViewModel>
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





        public EntityModel.Services4Section2MasterChild Create(EntityModel.Services4Section2MasterChild entity)
        {
            try
            {
                return unitOfWork.Services4Section2MasterChildRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services4Section2MasterChild GetById(long Id)
        {
            try
            {
                EntityModel.Services4Section2MasterChild entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services4Section2MasterChildRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services4Section2MasterChild Update(EntityModel.Services4Section2MasterChild entity)
        {
            try
            {
                return unitOfWork.Services4Section2MasterChildRepository.Update(entity);
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
                unitOfWork.Services4Section2MasterChildRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services4Section2MasterChild> GetAll()
        {
            try
            {
                return unitOfWork.Services4Section2MasterChildRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services4Section2MasterChild> FindBy(Expression<Func<EntityModel.Services4Section2MasterChild, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services4Section2MasterChild> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services4Section2MasterChildRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services4Section2MasterChildRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services4Section2MasterChild, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services4Section2MasterChildRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services4Section2MasterChild, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services4Section2MasterChildRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
