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
    public class HomePageSection5 : BaseBusiness, IHomePageSection5
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection5IndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection5IndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection5Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection5 => HomePageSection5.Tenant_ID, tenant => tenant.ID, (HomePageSection5, tenant) => new { HomePageSection5, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection5.Tenant_ID == tenant_Id)
                            && (x.HomePageSection5.ID.ToString().Contains(searchValue)
                        || x.HomePageSection5.ImageFilePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.LongDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection5.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection5Repository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection5 => HomePageSection5.Tenant_ID, tenant => tenant.ID, (HomePageSection5, tenant) => new { HomePageSection5, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection5.Tenant_ID == tenant_Id)
                            && (x.HomePageSection5.ID.ToString().Contains(searchValue)
                        || x.HomePageSection5.ImageFilePath.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.ShortDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.LongDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Url.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Metadata.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.MetaDescription.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Keyword.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection5.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection5.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection5IndexViewModel 
                    {
                        ID = x.HomePageSection5.ID,
                        ImageFilePath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID) + "/" + x.HomePageSection5.ImageFilePath,
                        ShortDescription = x.HomePageSection5.ShortDescription,
                        LongDescription = x.HomePageSection5.LongDescription,
                        AncharTagTitle = x.HomePageSection5.AncharTagTitle,
                        AncharTagUrl = x.HomePageSection5.AncharTagUrl,
                        DisplayIndex = x.HomePageSection5.DisplayIndex,
                        Url= x.HomePageSection5.Url,
                        Metadata= x.HomePageSection5.Metadata,
                        MetaDescription= x.HomePageSection5.MetaDescription,
                        Keyword= x.HomePageSection5.Keyword,
                        TotalViews= x.HomePageSection5.TotalViews,
                        IsActive = x.HomePageSection5.IsActive,
                        TenantName = x.HomePageSection5.Tenant.Name,
                        CreatedBy = x.HomePageSection5.CreatedBy,
                        UpdatedBy = x.HomePageSection5.UpdatedBy,
                        CreatedOn= x.HomePageSection5.CreatedOn,
                        UpdatedOn= x.HomePageSection5.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection5IndexViewModel>
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





        public EntityModel.HomePageSection5 Create(EntityModel.HomePageSection5 entity)
        {
            try
            {
                return unitOfWork.HomePageSection5Repository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection5 GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection5 entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection5Repository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection5 Update(EntityModel.HomePageSection5 entity)
        {
            try
            {
                return unitOfWork.HomePageSection5Repository.Update(entity);
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
                unitOfWork.HomePageSection5Repository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection5> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection5Repository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection5> FindBy(Expression<Func<EntityModel.HomePageSection5, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection5> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection5Repository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection5Repository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection5, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection5Repository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection5, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection5Repository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
