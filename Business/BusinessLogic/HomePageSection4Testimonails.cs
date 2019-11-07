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
    public class HomePageSection4Testimonails : BaseBusiness, IHomePageSection4Testimonails
    {
        public ViewModel.BusinessResultViewModel<ViewModel.HomePageSection4TestimonailsIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.HomePageSection4TestimonailsIndexViewModel> collection;
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
                totalRecords = unitOfWork.HomePageSection4TestimonailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection4Testimonails => HomePageSection4Testimonails.Tenant_ID, tenant => tenant.ID, (HomePageSection4Testimonails, tenant) => new { HomePageSection4Testimonails, tenant })
                      .Count(x => (tenant_Id == null || x.HomePageSection4Testimonails.Tenant_ID == tenant_Id)
                            && (x.HomePageSection4Testimonails.ID.ToString().Contains(searchValue)
                        || x.HomePageSection4Testimonails.Description.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Designation.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection4Testimonails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.HomePageSection4TestimonailsRepository.Get().Join(unitOfWork.TenantRepository.Get(), HomePageSection4Testimonails => HomePageSection4Testimonails.Tenant_ID, tenant => tenant.ID, (HomePageSection4Testimonails, tenant) => new { HomePageSection4Testimonails, tenant })
                      .Where(x => (tenant_Id == null || x.HomePageSection4Testimonails.Tenant_ID == tenant_Id)
                            && (x.HomePageSection4Testimonails.ID.ToString().Contains(searchValue)
                        || x.HomePageSection4Testimonails.Description.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Designation.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.DisplayIndex.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.Tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.HomePageSection4Testimonails.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.HomePageSection4Testimonails.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.HomePageSection4TestimonailsIndexViewModel 
                    {
                        ID = x.HomePageSection4Testimonails.ID,
                        Description = x.HomePageSection4Testimonails.Description,
                        Name = x.HomePageSection4Testimonails.Name,
                        Designation = x.HomePageSection4Testimonails.Designation,
                        DisplayIndex = x.HomePageSection4Testimonails.DisplayIndex,
                        Url= x.HomePageSection4Testimonails.Url.ToString(),
                        Metadata= x.HomePageSection4Testimonails.Metadata.ToString(),
                        MetaDescription= x.HomePageSection4Testimonails.MetaDescription.ToString(),
                        Keyword= x.HomePageSection4Testimonails.Keyword.ToString(),
                        TotalViews= x.HomePageSection4Testimonails.TotalViews,
                        IsActive = x.HomePageSection4Testimonails.IsActive,
                        TenantName = x.HomePageSection4Testimonails.Tenant.Name,
                        CreatedBy = x.HomePageSection4Testimonails.CreatedBy,
                        UpdatedBy = x.HomePageSection4Testimonails.UpdatedBy,
                        CreatedOn= x.HomePageSection4Testimonails.CreatedOn,
                        UpdatedOn= x.HomePageSection4Testimonails.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.HomePageSection4TestimonailsIndexViewModel>
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





        public EntityModel.HomePageSection4Testimonails Create(EntityModel.HomePageSection4Testimonails entity)
        {
            try
            {
                return unitOfWork.HomePageSection4TestimonailsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.HomePageSection4Testimonails GetById(long Id)
        {
            try
            {
                EntityModel.HomePageSection4Testimonails entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.HomePageSection4TestimonailsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.HomePageSection4Testimonails Update(EntityModel.HomePageSection4Testimonails entity)
        {
            try
            {
                return unitOfWork.HomePageSection4TestimonailsRepository.Update(entity);
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
                unitOfWork.HomePageSection4TestimonailsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.HomePageSection4Testimonails> GetAll()
        {
            try
            {
                return unitOfWork.HomePageSection4TestimonailsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.HomePageSection4Testimonails> FindBy(Expression<Func<EntityModel.HomePageSection4Testimonails, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.HomePageSection4Testimonails> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.HomePageSection4TestimonailsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.HomePageSection4TestimonailsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.HomePageSection4Testimonails, bool>> filter = null)
        {
            try
            {
                unitOfWork.HomePageSection4TestimonailsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.HomePageSection4Testimonails, bool>> filter = null)
        {
            try
            {
                return unitOfWork.HomePageSection4TestimonailsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
