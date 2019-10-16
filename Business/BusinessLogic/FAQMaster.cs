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
    public class FAQMaster : BaseBusiness, IFAQMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.FAQMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.FAQMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.FAQMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), FAQ => FAQ.Tenant_ID, tenant => tenant.ID, (FAQ, tenant) => new { FAQ, tenant })
                    .Count(x => (tenant_Id == null || x.FAQ.Tenant_ID == tenant_Id)
                            && (x.FAQ.ID.ToString().Contains(searchValue)
                        || x.FAQ.Title.CaseInsensitiveContains(searchValue)
                        || x.FAQ.Description.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.FAQ.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.FAQ.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.FAQ.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.FAQ.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.FAQMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), FAQ => FAQ.Tenant_ID, tenant => tenant.ID, (FAQ, tenant) => new { FAQ, tenant })
                    .Where(x => (tenant_Id == null || x.FAQ.Tenant_ID == tenant_Id)
                            && (x.FAQ.ID.ToString().Contains(searchValue)
                        || x.FAQ.Title.CaseInsensitiveContains(searchValue)
                        || x.FAQ.Description.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.Url.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.Metadata.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.FAQ.TotalViews.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.FAQ.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.FAQ.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.FAQ.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.FAQ.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.FAQMasterIndexViewModel
                    {
                        ID = x.FAQ.ID,
                        Title = x.FAQ.Title,
                        Description = x.FAQ.Description,
                        Url = x.FAQ.Url,
                        Metadata = x.FAQ.Metadata,
                        MetaDescription = x.FAQ.MetaDescription,
                        Keyword = x.FAQ.Keyword,
                        TotalViews = x.FAQ.TotalViews,
                        IsActive = x.FAQ.IsActive,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.FAQ.CreatedBy,
                        CreatedOn = x.FAQ.CreatedOn,
                        UpdatedBy = x.FAQ.UpdatedBy,
                        UpdatedOn = x.FAQ.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.FAQMasterIndexViewModel>
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





        public EntityModel.FAQMaster Create(EntityModel.FAQMaster entity)
        {
            try
            {
                return unitOfWork.FAQMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.FAQMaster GetById(long Id)
        {
            try
            {
                EntityModel.FAQMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.FAQMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.FAQMaster Update(EntityModel.FAQMaster entity)
        {
            try
            {
                return unitOfWork.FAQMasterRepository.Update(entity);
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
                unitOfWork.FAQMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.FAQMaster> GetAll()
        {
            try
            {
                return unitOfWork.FAQMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.FAQMaster> FindBy(Expression<Func<EntityModel.FAQMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.FAQMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.FAQMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.FAQMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.FAQMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.FAQMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.FAQMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.FAQMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
