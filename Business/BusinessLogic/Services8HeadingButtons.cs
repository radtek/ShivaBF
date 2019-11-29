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
    public class Services8HeadingButtons : BaseBusiness, IServices8HeadingButtons
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services8HeadingButtonsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services8HeadingButtonsIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services8HeadingButtonsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services8HeadingButtons => Services8HeadingButtons.Tenant_ID, tenant => tenant.ID, (Services8HeadingButtons, tenant) => new { Services8HeadingButtons, tenant })
                    .Join(unitOfWork.Services8MasterRepository.Get(), Services8HeadingButtons_tenant => Services8HeadingButtons_tenant.Services8HeadingButtons.Service_Id, Services8Master => Services8Master.ID, (Services8HeadingButtons_tenant, Services8Master) => new { Services8HeadingButtons_tenant, Services8Master })
                    .Count(x => (tenant_Id == null || x.Services8HeadingButtons_tenant.Services8HeadingButtons.Tenant_ID == tenant_Id)
                            && (x.Services8HeadingButtons_tenant.Services8HeadingButtons.ID.ToString().Contains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services8Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services8HeadingButtons_tenant.Services8HeadingButtons.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services8HeadingButtonsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services8HeadingButtons => Services8HeadingButtons.Tenant_ID, tenant => tenant.ID, (Services8HeadingButtons, tenant) => new { Services8HeadingButtons, tenant })
                    .Join(unitOfWork.Services8MasterRepository.Get(), Services8HeadingButtons_tenant => Services8HeadingButtons_tenant.Services8HeadingButtons.Service_Id, Services8Master => Services8Master.ID, (Services8HeadingButtons_tenant, Services8Master) => new { Services8HeadingButtons_tenant, Services8Master })
                    .Where(x => (tenant_Id == null || x.Services8HeadingButtons_tenant.Services8HeadingButtons.Tenant_ID == tenant_Id)
                            && (x.Services8HeadingButtons_tenant.Services8HeadingButtons.ID.ToString().Contains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services8Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services8HeadingButtons_tenant.Services8HeadingButtons.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services8HeadingButtonsIndexViewModel
                    {
                        ID = x.Services8HeadingButtons_tenant.Services8HeadingButtons.ID,
                        AncharTagTitle = x.Services8HeadingButtons_tenant.Services8HeadingButtons.AncharTagTitle,
                        AncharTagUrl = x.Services8HeadingButtons_tenant.Services8HeadingButtons.AncharTagUrl,
                        SubSubCategoryName = x.Services8Master.SubSubCategoryName,
                        DisplayIndex = x.Services8HeadingButtons_tenant.Services8HeadingButtons.DisplayIndex,
                        Url = x.Services8HeadingButtons_tenant.Services8HeadingButtons.Url,
                        Metadata = x.Services8HeadingButtons_tenant.Services8HeadingButtons.Metadata,
                        MetaDescription = x.Services8HeadingButtons_tenant.Services8HeadingButtons.MetaDescription,
                        Keyword = x.Services8HeadingButtons_tenant.Services8HeadingButtons.Keyword,
                        TotalViews = x.Services8HeadingButtons_tenant.Services8HeadingButtons.TotalViews,
                        IsActive = x.Services8HeadingButtons_tenant.Services8HeadingButtons.IsActive,
                        TenantName = x.Services8HeadingButtons_tenant.Services8HeadingButtons.Tenant.Name,
                        Tenant_ID = x.Services8HeadingButtons_tenant.Services8HeadingButtons.Tenant.ID,
                        CreatedBy = x.Services8HeadingButtons_tenant.Services8HeadingButtons.CreatedBy,
                        CreatedOn = x.Services8HeadingButtons_tenant.Services8HeadingButtons.CreatedOn,
                        UpdatedBy = x.Services8HeadingButtons_tenant.Services8HeadingButtons.UpdatedBy,
                        UpdatedOn = x.Services8HeadingButtons_tenant.Services8HeadingButtons.UpdatedOn,
                        ServiceUrl = x.Services8Master.Url
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services8HeadingButtonsIndexViewModel>
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





        public EntityModel.Services8HeadingButtons Create(EntityModel.Services8HeadingButtons entity)
        {
            try
            {
                return unitOfWork.Services8HeadingButtonsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services8HeadingButtons GetById(long Id)
        {
            try
            {
                EntityModel.Services8HeadingButtons entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services8HeadingButtonsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services8HeadingButtons Update(EntityModel.Services8HeadingButtons entity)
        {
            try
            {
                return unitOfWork.Services8HeadingButtonsRepository.Update(entity);
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
                var x = DataAccess.GetScalar.ByStoredProcedure("[dbo].[usp_DeleteServices8HeadingButtons]", param);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services8HeadingButtons> GetAll()
        {
            try
            {
                return unitOfWork.Services8HeadingButtonsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services8HeadingButtons> FindBy(Expression<Func<EntityModel.Services8HeadingButtons, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services8HeadingButtons> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services8HeadingButtonsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services8HeadingButtonsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services8HeadingButtons, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services8HeadingButtonsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services8HeadingButtons, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services8HeadingButtonsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
