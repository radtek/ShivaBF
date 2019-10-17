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
    public class Services1Section5Master : BaseBusiness, IServices1Section5Master
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services1Section5MasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services1Section5MasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services1Section5MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Section5Master => Services1Section5Master.Tenant_ID, tenant => tenant.ID, (Services1Section5Master, tenant) => new { Services1Section5Master, tenant })
                    .Join(unitOfWork.Services1MasterRepository.Get(), Services1Section5Master_tenant => Services1Section5Master_tenant.Services1Section5Master.Service_Id, Services1Master => Services1Master.ID, (Services1Section5Master_tenant, Services1Master) => new { Services1Section5Master_tenant, Services1Master })
                    .Count(x => (tenant_Id == null || x.Services1Section5Master_tenant.Services1Section5Master.Tenant_ID == tenant_Id)
                            && (x.Services1Section5Master_tenant.Services1Section5Master.ID.ToString().Contains(searchValue)
                             || x.Services1Section5Master_tenant.Services1Section5Master.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.HeadingText.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services1Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services1Section5Master_tenant.Services1Section5Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services1Section5MasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services1Section5Master => Services1Section5Master.Tenant_ID, tenant => tenant.ID, (Services1Section5Master, tenant) => new { Services1Section5Master, tenant })
                    .Join(unitOfWork.Services1MasterRepository.Get(), Services1Section5Master_tenant => Services1Section5Master_tenant.Services1Section5Master.Service_Id, Services1Master => Services1Master.ID, (Services1Section5Master_tenant, Services1Master) => new { Services1Section5Master_tenant, Services1Master })
                    .Where(x => (tenant_Id == null || x.Services1Section5Master_tenant.Services1Section5Master.Tenant_ID == tenant_Id)
                            && (x.Services1Section5Master_tenant.Services1Section5Master.ID.ToString().Contains(searchValue)
                             || x.Services1Section5Master_tenant.Services1Section5Master.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.HeadingText.CaseInsensitiveContains(searchValue)
                            || x.Services1Section5Master_tenant.Services1Section5Master.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services1Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services1Section5Master_tenant.Services1Section5Master.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services1Section5MasterIndexViewModel
                    {
                        ID = x.Services1Section5Master_tenant.Services1Section5Master.ID,
                        HeadingText = x.Services1Section5Master_tenant.Services1Section5Master.HeadingText,
                        ShortDescription = x.Services1Section5Master_tenant.Services1Section5Master.ShortDescription,
                        AncharTagTitle = x.Services1Section5Master_tenant.Services1Section5Master.AncharTagTitle,
                        AncharTagUrl = x.Services1Section5Master_tenant.Services1Section5Master.AncharTagUrl,
                        SubSubCategoryName = x.Services1Master.SubSubCategoryName,
                        DisplayIndex = x.Services1Section5Master_tenant.Services1Section5Master.DisplayIndex,
                        DisplayOnHome = x.Services1Section5Master_tenant.Services1Section5Master.DisplayOnHome,
                        Url = x.Services1Section5Master_tenant.Services1Section5Master.Url,
                        Metadata = x.Services1Section5Master_tenant.Services1Section5Master.Metadata,
                        MetaDescription = x.Services1Section5Master_tenant.Services1Section5Master.MetaDescription,
                        Keyword = x.Services1Section5Master_tenant.Services1Section5Master.Keyword,
                        TotalViews = x.Services1Section5Master_tenant.Services1Section5Master.TotalViews,
                        IsActive = x.Services1Section5Master_tenant.Services1Section5Master.IsActive,
                        TenantName = x.Services1Section5Master_tenant.Services1Section5Master.Tenant.Name,
                        Tenant_ID = x.Services1Section5Master_tenant.Services1Section5Master.Tenant.ID,
                        CreatedBy = x.Services1Section5Master_tenant.Services1Section5Master.CreatedBy,
                        CreatedOn = x.Services1Section5Master_tenant.Services1Section5Master.CreatedOn,
                        UpdatedBy = x.Services1Section5Master_tenant.Services1Section5Master.UpdatedBy,
                        UpdatedOn = x.Services1Section5Master_tenant.Services1Section5Master.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services1Section5MasterIndexViewModel>
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





        public EntityModel.Services1Section5Master Create(EntityModel.Services1Section5Master entity)
        {
            try
            {
                return unitOfWork.Services1Section5MasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services1Section5Master GetById(long Id)
        {
            try
            {
                EntityModel.Services1Section5Master entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services1Section5MasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services1Section5Master Update(EntityModel.Services1Section5Master entity)
        {
            try
            {
                return unitOfWork.Services1Section5MasterRepository.Update(entity);
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
                unitOfWork.Services1Section5MasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services1Section5Master> GetAll()
        {
            try
            {
                return unitOfWork.Services1Section5MasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services1Section5Master> FindBy(Expression<Func<EntityModel.Services1Section5Master, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services1Section5Master> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services1Section5MasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services1Section5MasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services1Section5Master, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services1Section5MasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services1Section5Master, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services1Section5MasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
