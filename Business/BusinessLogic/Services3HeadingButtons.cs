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
    public class Services3HeadingButtons : BaseBusiness, IServices3HeadingButtons
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services3HeadingButtonsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services3HeadingButtonsIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services3HeadingButtonsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services3HeadingButtons => Services3HeadingButtons.Tenant_ID, tenant => tenant.ID, (Services3HeadingButtons, tenant) => new { Services3HeadingButtons, tenant })
                    .Join(unitOfWork.Services3MasterRepository.Get(), Services3HeadingButtons_tenant => Services3HeadingButtons_tenant.Services3HeadingButtons.Service_Id, Services3Master => Services3Master.ID, (Services3HeadingButtons_tenant, Services3Master) => new { Services3HeadingButtons_tenant, Services3Master })
                    .Count(x => (tenant_Id == null || x.Services3HeadingButtons_tenant.Services3HeadingButtons.Tenant_ID == tenant_Id)
                            && (x.Services3HeadingButtons_tenant.Services3HeadingButtons.ID.ToString().Contains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services3Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services3HeadingButtons_tenant.Services3HeadingButtons.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services3HeadingButtonsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services3HeadingButtons => Services3HeadingButtons.Tenant_ID, tenant => tenant.ID, (Services3HeadingButtons, tenant) => new { Services3HeadingButtons, tenant })
                    .Join(unitOfWork.Services3MasterRepository.Get(), Services3HeadingButtons_tenant => Services3HeadingButtons_tenant.Services3HeadingButtons.Service_Id, Services3Master => Services3Master.ID, (Services3HeadingButtons_tenant, Services3Master) => new { Services3HeadingButtons_tenant, Services3Master })
                    .Where(x => (tenant_Id == null || x.Services3HeadingButtons_tenant.Services3HeadingButtons.Tenant_ID == tenant_Id)
                            && (x.Services3HeadingButtons_tenant.Services3HeadingButtons.ID.ToString().Contains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services3Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services3HeadingButtons_tenant.Services3HeadingButtons.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services3HeadingButtonsIndexViewModel
                    {
                        ID = x.Services3HeadingButtons_tenant.Services3HeadingButtons.ID,
                        AncharTagTitle = x.Services3HeadingButtons_tenant.Services3HeadingButtons.AncharTagTitle,
                        AncharTagUrl = x.Services3HeadingButtons_tenant.Services3HeadingButtons.AncharTagUrl,
                        SubSubCategoryName = x.Services3Master.SubSubCategoryName,
                        DisplayIndex = x.Services3HeadingButtons_tenant.Services3HeadingButtons.DisplayIndex,
                        Url = x.Services3HeadingButtons_tenant.Services3HeadingButtons.Url,
                        Metadata = x.Services3HeadingButtons_tenant.Services3HeadingButtons.Metadata,
                        MetaDescription = x.Services3HeadingButtons_tenant.Services3HeadingButtons.MetaDescription,
                        Keyword = x.Services3HeadingButtons_tenant.Services3HeadingButtons.Keyword,
                        TotalViews = x.Services3HeadingButtons_tenant.Services3HeadingButtons.TotalViews,
                        IsActive = x.Services3HeadingButtons_tenant.Services3HeadingButtons.IsActive,
                        TenantName = x.Services3HeadingButtons_tenant.Services3HeadingButtons.Tenant.Name,
                        Tenant_ID = x.Services3HeadingButtons_tenant.Services3HeadingButtons.Tenant.ID,
                        CreatedBy = x.Services3HeadingButtons_tenant.Services3HeadingButtons.CreatedBy,
                        CreatedOn = x.Services3HeadingButtons_tenant.Services3HeadingButtons.CreatedOn,
                        UpdatedBy = x.Services3HeadingButtons_tenant.Services3HeadingButtons.UpdatedBy,
                        UpdatedOn = x.Services3HeadingButtons_tenant.Services3HeadingButtons.UpdatedOn,
                        ServiceUrl = x.Services3Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services3HeadingButtonsIndexViewModel>
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





        public EntityModel.Services3HeadingButtons Create(EntityModel.Services3HeadingButtons entity)
        {
            try
            {
                return unitOfWork.Services3HeadingButtonsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services3HeadingButtons GetById(long Id)
        {
            try
            {
                EntityModel.Services3HeadingButtons entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services3HeadingButtonsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services3HeadingButtons Update(EntityModel.Services3HeadingButtons entity)
        {
            try
            {
                return unitOfWork.Services3HeadingButtonsRepository.Update(entity);
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
                unitOfWork.Services3HeadingButtonsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services3HeadingButtons> GetAll()
        {
            try
            {
                return unitOfWork.Services3HeadingButtonsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services3HeadingButtons> FindBy(Expression<Func<EntityModel.Services3HeadingButtons, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services3HeadingButtons> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services3HeadingButtonsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services3HeadingButtonsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services3HeadingButtons, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services3HeadingButtonsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services3HeadingButtons, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services3HeadingButtonsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
