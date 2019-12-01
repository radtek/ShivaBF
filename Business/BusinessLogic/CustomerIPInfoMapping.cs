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
    public class CustomerIPInfoMapping : BaseBusiness, ICustomerIPInfoMapping
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CustomerIPInfoMappingIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CustomerIPInfoMappingIndexViewModel> collection;
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
                totalRecords = unitOfWork.CustomerIPInfoMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (CustomerInfo, tenant) => new { CustomerInfo, tenant })
                    .Join(unitOfWork.CustomerMasterRepository.Get(), CustomerInfo_tenant => CustomerInfo_tenant.CustomerInfo.CustomerMaster_ID, Customer => Customer.ID, (CustomerInfo_tenant, Customer) => new { CustomerInfo_tenant, Customer })
                     .Join(unitOfWork.IPInfoRepository.Get(), CustomerInfo_tenant_Customer => CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.IPInfo_ID, IPInfo => IPInfo.ID, (CustomerInfo_tenant_Customer, IPInfo) => new { CustomerInfo_tenant_Customer, IPInfo })
                    .Count(x => (tenant_Id == null || x.CustomerInfo_tenant_Customer.Customer.Tenant_ID == tenant_Id)
                            && (x.CustomerInfo_tenant_Customer.Customer.ID.ToString().Contains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
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
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CustomerIPInfoMappingRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (CustomerInfo, tenant) => new { CustomerInfo, tenant })
                    .Join(unitOfWork.CustomerMasterRepository.Get(), CustomerInfo_tenant => CustomerInfo_tenant.CustomerInfo.CustomerMaster_ID, Customer => Customer.ID, (CustomerInfo_tenant, Customer) => new { CustomerInfo_tenant, Customer })
                     .Join(unitOfWork.IPInfoRepository.Get(), CustomerInfo_tenant_Customer => CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.IPInfo_ID, IPInfo => IPInfo.ID, (CustomerInfo_tenant_Customer, IPInfo) => new { CustomerInfo_tenant_Customer, IPInfo })
                    .Where(x => (tenant_Id == null || x.CustomerInfo_tenant_Customer.Customer.Tenant_ID == tenant_Id)
                            && (x.CustomerInfo_tenant_Customer.Customer.ID.ToString().Contains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
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
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CustomerIPInfoMappingIndexViewModel
                    {
                        ID = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.ID,
                        Session_ID = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.Session_ID,
                        FirstName = x.CustomerInfo_tenant_Customer.Customer.FirstName,
                        LastName = x.CustomerInfo_tenant_Customer.Customer.LastName,
                        DOB = x.CustomerInfo_tenant_Customer.Customer.DOB,
                        EmailID = x.CustomerInfo_tenant_Customer.Customer.EmailID,
                        FullStreetAddress = x.CustomerInfo_tenant_Customer.Customer.FullStreetAddress,
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
                        TenantName = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.tenant.Name,
                        Tenant_ID = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.tenant.ID,
                        CreatedBy = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.CreatedBy,
                        CreatedOn = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.CreatedOn,
                        UpdatedBy = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.UpdatedBy,
                        UpdatedOn = x.CustomerInfo_tenant_Customer.CustomerInfo_tenant.CustomerInfo.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CustomerIPInfoMappingIndexViewModel>
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





        public EntityModel.CustomerIPInfoMapping Create(EntityModel.CustomerIPInfoMapping entity)
        {
            try
            {
                return unitOfWork.CustomerIPInfoMappingRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CustomerIPInfoMapping GetById(long Id)
        {
            try
            {
                EntityModel.CustomerIPInfoMapping entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CustomerIPInfoMappingRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CustomerIPInfoMapping Update(EntityModel.CustomerIPInfoMapping entity)
        {
            try
            {
                return unitOfWork.CustomerIPInfoMappingRepository.Update(entity);
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
                unitOfWork.CustomerIPInfoMappingRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CustomerIPInfoMapping> GetAll()
        {
            try
            {
                return unitOfWork.CustomerIPInfoMappingRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CustomerIPInfoMapping> FindBy(Expression<Func<EntityModel.CustomerIPInfoMapping, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CustomerIPInfoMapping> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CustomerIPInfoMappingRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CustomerIPInfoMappingRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CustomerIPInfoMapping, bool>> filter = null)
        {
            try
            {
                unitOfWork.CustomerIPInfoMappingRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.CustomerIPInfoMapping, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CustomerIPInfoMappingRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
