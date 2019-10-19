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
    public class PriceFeaturesMaster : BaseBusiness, IPriceFeaturesMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.PriceFeaturesMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.PriceFeaturesMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.PriceFeaturesMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), PriceFeatures => PriceFeatures.Tenant_ID, tenant => tenant.ID, (PriceFeatures, tenant) => new { PriceFeatures, tenant })
                    .Count(x => (tenant_Id == null || x.PriceFeatures.Tenant_ID == tenant_Id)
                            && (x.PriceFeatures.ID.ToString().Contains(searchValue)
                        || x.PriceFeatures.Description.CaseInsensitiveContains(searchValue)
                         || x.PriceFeatures.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.PriceFeatures.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.PriceFeatures.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.PriceFeatures.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.PriceFeatures.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.PriceFeatures.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.PriceFeatures.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.PriceFeatures.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.PriceFeaturesMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), PriceFeatures => PriceFeatures.Tenant_ID, tenant => tenant.ID, (PriceFeatures, tenant) => new { PriceFeatures, tenant })
                    .Where(x => (tenant_Id == null || x.PriceFeatures.Tenant_ID == tenant_Id)
                            && (x.PriceFeatures.ID.ToString().Contains(searchValue)
                        || x.PriceFeatures.Description.CaseInsensitiveContains(searchValue)
                         || x.PriceFeatures.Url.ToString().CaseInsensitiveContains(searchValue)
                          || x.PriceFeatures.Metadata.ToString().CaseInsensitiveContains(searchValue)
                           || x.PriceFeatures.MetaDescription.ToString().CaseInsensitiveContains(searchValue)
                            || x.PriceFeatures.Keyword.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.PriceFeatures.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.PriceFeatures.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.PriceFeatures.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.PriceFeatures.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.PriceFeaturesMasterIndexViewModel
                    {
                        ID = x.PriceFeatures.ID,
                        Description = x.PriceFeatures.Description,
                        Url = x.PriceFeatures.Url,
                        Metadata = x.PriceFeatures.Metadata,
                        MetaDescription = x.PriceFeatures.MetaDescription,
                        Keyword = x.PriceFeatures.Keyword,
                        IsActive = x.PriceFeatures.IsActive,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.PriceFeatures.CreatedBy,
                        CreatedOn = x.PriceFeatures.CreatedOn,
                        UpdatedBy = x.PriceFeatures.UpdatedBy,
                        UpdatedOn = x.PriceFeatures.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.PriceFeaturesMasterIndexViewModel>
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





        public EntityModel.PriceFeaturesMaster Create(EntityModel.PriceFeaturesMaster entity)
        {
            try
            {
                return unitOfWork.PriceFeaturesMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.PriceFeaturesMaster GetById(long Id)
        {
            try
            {
                EntityModel.PriceFeaturesMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.PriceFeaturesMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.PriceFeaturesMaster Update(EntityModel.PriceFeaturesMaster entity)
        {
            try
            {
                return unitOfWork.PriceFeaturesMasterRepository.Update(entity);
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
                unitOfWork.PriceFeaturesMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.PriceFeaturesMaster> GetAll()
        {
            try
            {
                return unitOfWork.PriceFeaturesMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.PriceFeaturesMaster> FindBy(Expression<Func<EntityModel.PriceFeaturesMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.PriceFeaturesMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.PriceFeaturesMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.PriceFeaturesMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.PriceFeaturesMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.PriceFeaturesMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.PriceFeaturesMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.PriceFeaturesMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
