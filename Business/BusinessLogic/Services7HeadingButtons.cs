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
    public class Services7HeadingButtons : BaseBusiness, IServices7HeadingButtons
    {
        public ViewModel.BusinessResultViewModel<ViewModel.Services7HeadingButtonsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.Services7HeadingButtonsIndexViewModel> collection;
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
                totalRecords = unitOfWork.Services7HeadingButtonsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services7HeadingButtons => Services7HeadingButtons.Tenant_ID, tenant => tenant.ID, (Services7HeadingButtons, tenant) => new { Services7HeadingButtons, tenant })
                    .Join(unitOfWork.Services7MasterRepository.Get(), Services7HeadingButtons_tenant => Services7HeadingButtons_tenant.Services7HeadingButtons.Service_Id, Services7Master => Services7Master.ID, (Services7HeadingButtons_tenant, Services7Master) => new { Services7HeadingButtons_tenant, Services7Master })
                    .Count(x => (tenant_Id == null || x.Services7HeadingButtons_tenant.Services7HeadingButtons.Tenant_ID == tenant_Id)
                            && (x.Services7HeadingButtons_tenant.Services7HeadingButtons.ID.ToString().Contains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services7Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.Url.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.Tenant.Name.CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.CreatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.UpdatedBy.CaseInsensitiveContains(searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ||x.Services7HeadingButtons_tenant.Services7HeadingButtons.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.Services7HeadingButtonsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Services7HeadingButtons => Services7HeadingButtons.Tenant_ID, tenant => tenant.ID, (Services7HeadingButtons, tenant) => new { Services7HeadingButtons, tenant })
                    .Join(unitOfWork.Services7MasterRepository.Get(), Services7HeadingButtons_tenant => Services7HeadingButtons_tenant.Services7HeadingButtons.Service_Id, Services7Master => Services7Master.ID, (Services7HeadingButtons_tenant, Services7Master) => new { Services7HeadingButtons_tenant, Services7Master })
                    .Where(x => (tenant_Id == null || x.Services7HeadingButtons_tenant.Services7HeadingButtons.Tenant_ID == tenant_Id)
                            && (x.Services7HeadingButtons_tenant.Services7HeadingButtons.ID.ToString().Contains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.Services7Master.SubSubCategoryName.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Services7HeadingButtons_tenant.Services7HeadingButtons.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.Services7HeadingButtonsIndexViewModel
                    {
                        ID = x.Services7HeadingButtons_tenant.Services7HeadingButtons.ID,
                        AncharTagTitle = x.Services7HeadingButtons_tenant.Services7HeadingButtons.AncharTagTitle,
                        AncharTagUrl = x.Services7HeadingButtons_tenant.Services7HeadingButtons.AncharTagUrl,
                        SubSubCategoryName = x.Services7Master.SubSubCategoryName,
                        DisplayIndex = x.Services7HeadingButtons_tenant.Services7HeadingButtons.DisplayIndex,
                        Url = x.Services7HeadingButtons_tenant.Services7HeadingButtons.Url,
                        Metadata = x.Services7HeadingButtons_tenant.Services7HeadingButtons.Metadata,
                        MetaDescription = x.Services7HeadingButtons_tenant.Services7HeadingButtons.MetaDescription,
                        Keyword = x.Services7HeadingButtons_tenant.Services7HeadingButtons.Keyword,
                        TotalViews = x.Services7HeadingButtons_tenant.Services7HeadingButtons.TotalViews,
                        IsActive = x.Services7HeadingButtons_tenant.Services7HeadingButtons.IsActive,
                        TenantName = x.Services7HeadingButtons_tenant.Services7HeadingButtons.Tenant.Name,
                        Tenant_ID = x.Services7HeadingButtons_tenant.Services7HeadingButtons.Tenant.ID,
                        CreatedBy = x.Services7HeadingButtons_tenant.Services7HeadingButtons.CreatedBy,
                        CreatedOn = x.Services7HeadingButtons_tenant.Services7HeadingButtons.CreatedOn,
                        UpdatedBy = x.Services7HeadingButtons_tenant.Services7HeadingButtons.UpdatedBy,
                        UpdatedOn = x.Services7HeadingButtons_tenant.Services7HeadingButtons.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.Services7HeadingButtonsIndexViewModel>
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





        public EntityModel.Services7HeadingButtons Create(EntityModel.Services7HeadingButtons entity)
        {
            try
            {
                return unitOfWork.Services7HeadingButtonsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Services7HeadingButtons GetById(long Id)
        {
            try
            {
                EntityModel.Services7HeadingButtons entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.Services7HeadingButtonsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Services7HeadingButtons Update(EntityModel.Services7HeadingButtons entity)
        {
            try
            {
                return unitOfWork.Services7HeadingButtonsRepository.Update(entity);
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
                unitOfWork.Services7HeadingButtonsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Services7HeadingButtons> GetAll()
        {
            try
            {
                return unitOfWork.Services7HeadingButtonsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Services7HeadingButtons> FindBy(Expression<Func<EntityModel.Services7HeadingButtons, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Services7HeadingButtons> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.Services7HeadingButtonsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.Services7HeadingButtonsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Services7HeadingButtons, bool>> filter = null)
        {
            try
            {
                unitOfWork.Services7HeadingButtonsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Services7HeadingButtons, bool>> filter = null)
        {
            try
            {
                return unitOfWork.Services7HeadingButtonsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
