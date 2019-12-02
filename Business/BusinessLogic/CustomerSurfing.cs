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
    public class CustomerSurfing : BaseBusiness, ICustomerSurfing
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CustomerSurfingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CustomerSurfingIndexViewModel> collection;
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
                totalRecords = unitOfWork.CustomerSurfingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (CustomerSurfingInfo, tenant) => new { CustomerSurfingInfo, tenant })
                    .Join(unitOfWork.CustomerMasterRepository.Get(), CustomerSurfingInfo_tenant => CustomerSurfingInfo_tenant.CustomerSurfingInfo.CustomerMaster_ID, Customer => Customer.ID, (CustomerSurfingInfo_tenant, Customer) => new { CustomerSurfingInfo_tenant, Customer })
                     .Join(unitOfWork.CustomerIPInfoMappingRepository.Get(), CustomerSurfingInfo_tenant_Customer => CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.Session_ID, CustomerIPInfoMapping => CustomerIPInfoMapping.Session_ID, (CustomerSurfingInfo_tenant_Customer, CustomerIPInfoMapping) => new { CustomerSurfingInfo_tenant_Customer, CustomerIPInfoMapping })
                     .Join(unitOfWork.IPInfoRepository.Get(), CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping => CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerIPInfoMapping.IPInfo_ID, IPInfo => IPInfo.ID, (CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping, IPInfo) => new { CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping, IPInfo })
                    .Count(x => (tenant_Id == null || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.Tenant_ID == tenant_Id)
                            && (x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.ID.ToString().Contains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.PageUrl.CaseInsensitiveContains(searchValue)
                        || x.IPInfo.ip.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.is_eu.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.city.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.region.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.region_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.country_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.country_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.continent_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.continent_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.latitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.longitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.postal.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.calling_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.emoji_flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CustomerSurfingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (CustomerSurfingInfo, tenant) => new { CustomerSurfingInfo, tenant })
                    .Join(unitOfWork.CustomerMasterRepository.Get(), CustomerSurfingInfo_tenant => CustomerSurfingInfo_tenant.CustomerSurfingInfo.CustomerMaster_ID, Customer => Customer.ID, (CustomerSurfingInfo_tenant, Customer) => new { CustomerSurfingInfo_tenant, Customer })
                     .Join(unitOfWork.CustomerIPInfoMappingRepository.Get(), CustomerSurfingInfo_tenant_Customer => CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.Session_ID, CustomerIPInfoMapping => CustomerIPInfoMapping.Session_ID, (CustomerSurfingInfo_tenant_Customer, CustomerIPInfoMapping) => new { CustomerSurfingInfo_tenant_Customer, CustomerIPInfoMapping })
                     .Join(unitOfWork.IPInfoRepository.Get(), CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping => CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerIPInfoMapping.IPInfo_ID, IPInfo => IPInfo.ID, (CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping, IPInfo) => new { CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping, IPInfo })
                    .Where(x => (tenant_Id == null || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.Tenant_ID == tenant_Id)
                            && (x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.ID.ToString().Contains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.PageUrl.CaseInsensitiveContains(searchValue)
                        || x.IPInfo.ip.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.is_eu.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.city.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.region.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.region_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.country_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.country_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.continent_name.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.continent_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.latitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.longitude.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.postal.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.calling_code.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.IPInfo.emoji_flag.ToString().CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CustomerSurfingIndexViewModel
                    {
                        ID = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.ID,
                        Session_ID = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.Session_ID,
                        FirstName = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FirstName,
                        LastName = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.LastName,
                        DOB = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.DOB,
                        EmailID = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.EmailID,
                        FullStreetAddress = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.Customer.FullStreetAddress,
                        PageUrl = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.PageUrl,
                        ip = x.IPInfo.ip.ToString(),
                        is_eu = x.IPInfo.is_eu,
                        city = x.IPInfo.city,
                        region = x.IPInfo.region,
                        region_code = x.IPInfo.region_code,
                        country_name = x.IPInfo.country_name,
                        country_code = x.IPInfo.country_code,
                        continent_name = x.IPInfo.continent_name,
                        continent_code = x.IPInfo.continent_code,
                        latitude = x.IPInfo.latitude,
                        longitude = x.IPInfo.longitude,
                        postal = x.IPInfo.postal,
                        calling_code = x.IPInfo.calling_code,
                        flag = x.IPInfo.flag,
                        emoji_flag = x.IPInfo.emoji_flag,
                        TenantName = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.tenant.Name,
                        Tenant_ID = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.tenant.ID,
                        CreatedBy = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.CreatedBy,
                        CreatedOn = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.CreatedOn,
                        UpdatedBy = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.UpdatedBy,
                        UpdatedOn = x.CustomerSurfingInfo_tenant_Customer_CustomerIPInfoMapping.CustomerSurfingInfo_tenant_Customer.CustomerSurfingInfo_tenant.CustomerSurfingInfo.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CustomerSurfingIndexViewModel>
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





        public EntityModel.CustomerSurfing Create(EntityModel.CustomerSurfing entity)
        {
            try
            {
                return unitOfWork.CustomerSurfingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CustomerSurfing GetById(long Id)
        {
            try
            {
                EntityModel.CustomerSurfing entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CustomerSurfingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CustomerSurfing Update(EntityModel.CustomerSurfing entity)
        {
            try
            {
                return unitOfWork.CustomerSurfingRepository.Update(entity);
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
                unitOfWork.CustomerSurfingRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CustomerSurfing> GetAll()
        {
            try
            {
                return unitOfWork.CustomerSurfingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CustomerSurfing> FindBy(Expression<Func<EntityModel.CustomerSurfing, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CustomerSurfing> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CustomerSurfingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CustomerSurfingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CustomerSurfing, bool>> filter = null)
        {
            try
            {
                unitOfWork.CustomerSurfingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.CustomerSurfing, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CustomerSurfingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
