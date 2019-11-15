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
    public class HomePageSection4 : BaseBusiness, IHomePageSection4
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection4IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection4IndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection4Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection4 => HomePageSection4.Tenant_ID, tenant => tenant.ID, (HomePageSection4, tenant) => new { HomePageSection4, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection4.Tenant_ID == tenant_Id)
                            && (x.HomePageSection4.ID.ToString().Contains(searchValue)
                        || x.HomePageSection4.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Heading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Heading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection4.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection4Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection4 => HomePageSection4.Tenant_ID, tenant => tenant.ID, (HomePageSection4, tenant) => new { HomePageSection4, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection4.Tenant_ID == tenant_Id)
                            && (x.HomePageSection4.ID.ToString().Contains(searchValue)
                        || x.HomePageSection4.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Heading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Heading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection4.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection4IndexViewModel 
                    {
                        ID = x.HomePageSection4.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID) + "/" + x.HomePageSection4.BannerImagePath,
                        Heading1 = x.HomePageSection4.Heading1,
                        Heading2 = x.HomePageSection4.Heading2,
                        DisplayIndex = x.HomePageSection4.DisplayIndex,
                        Url= x.HomePageSection4.Url,
                        Metadata= x.HomePageSection4.Metadata,
                        MetaDescription= x.HomePageSection4.MetaDescription,
                        Keyword= x.HomePageSection4.Keyword,
                        TotalViews= x.HomePageSection4.TotalViews,
                        IsActive = x.HomePageSection4.IsActive,
                        TenantName = x.HomePageSection4.Tenant.Name,
                        CreatedBy = x.HomePageSection4.CreatedBy,
                        UpdatedBy = x.HomePageSection4.UpdatedBy,
                        CreatedOn= x.HomePageSection4.CreatedOn,
                        UpdatedOn= x.HomePageSection4.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection4IndexViewModel>
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





        public EntityModel.HomePageSection4 Create(EntityModel.HomePageSection4 entity)
        {
            try
            {
                return unitOfWork.HomePageSection4Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection4 GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection4 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection4Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection4 Update(EntityModel.HomePageSection4 entity)
        {
            try
            {
                return unitOfWork.HomePageSection4Repository.Update(entity);
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
                unitOfWork.HomePageSection4Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection4> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection4Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection4> FindBy(Expression<Func<EntityModel.HomePageSection4, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection4> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection4Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection4Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection4, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection4Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection4, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection4Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
