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
    public class HomePageSection2 : BaseBusiness, IHomePageSection2
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection2IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection2IndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection2Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection2 => HomePageSection2.Tenant_ID, tenant => tenant.ID, (HomePageSection2, tenant) => new { HomePageSection2, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection2.Tenant_ID == tenant_Id)
                            && (x.HomePageSection2.ID.ToString().Contains(searchValue)
                        || x.HomePageSection2.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Heading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Heading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Heading3.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Description1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Description2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection2.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection2Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection2 => HomePageSection2.Tenant_ID, tenant => tenant.ID, (HomePageSection2, tenant) => new { HomePageSection2, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection2.Tenant_ID == tenant_Id)
                            && (x.HomePageSection2.ID.ToString().Contains(searchValue)
                        || x.HomePageSection2.BannerImagePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Heading1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Heading2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Heading3.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Description1.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Description2.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.PageTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection2.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection2.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection2IndexViewModel 
                    {
                        ID = x.HomePageSection2.ID,
                        BannerImagePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID) + "/" + x.HomePageSection2.BannerImagePath,
                        Heading1 = x.HomePageSection2.Heading1,
                        Heading2 = x.HomePageSection2.Heading2,
                        Heading3 = x.HomePageSection2.Heading3,
                        Description1 = x.HomePageSection2.Description1,
                        Description2 = x.HomePageSection2.Description2,
                        DisplayOnHome = x.HomePageSection2.DisplayOnHome,
                        DisplayIndex = x.HomePageSection2.DisplayIndex,
                        PageTitle = x.HomePageSection2.PageTitle,
                        Url = x.HomePageSection2.Url,
                        Metadata= x.HomePageSection2.Metadata,
                        MetaDescription= x.HomePageSection2.MetaDescription,
                        Keyword= x.HomePageSection2.Keyword,
                        TotalViews= x.HomePageSection2.TotalViews,
                        IsActive = x.HomePageSection2.IsActive,
                        TenantName = x.HomePageSection2.Tenant.Name,
                        CreatedBy = x.HomePageSection2.CreatedBy,
                        UpdatedBy = x.HomePageSection2.UpdatedBy,
                        CreatedOn= x.HomePageSection2.CreatedOn,
                        UpdatedOn= x.HomePageSection2.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection2IndexViewModel>
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





        public EntityModel.HomePageSection2 Create(EntityModel.HomePageSection2 entity)
        {
            try
            {
                return unitOfWork.HomePageSection2Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection2 GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection2 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection2Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection2 Update(EntityModel.HomePageSection2 entity)
        {
            try
            {
                return unitOfWork.HomePageSection2Repository.Update(entity);
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
                unitOfWork.HomePageSection2Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection2> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection2Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection2> FindBy(Expression<Func<EntityModel.HomePageSection2, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection2> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection2Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection2Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection2, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection2Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection2, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection2Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
