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
    public class CustomerMasterInfo : BaseBusiness, ICustomerMasterInfo
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CustomerMasterInfoIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CustomerMasterInfoIndexViewModel> collection;
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
                totalRecords = unitOfWork.CustomerMasterInfoRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (CustomerInfo, tenant) => new { CustomerInfo, tenant })
                    .Join(unitOfWork.CustomerMasterRepository.Get(), CustomerInfo_tenant => CustomerInfo_tenant.CustomerInfo.CustomerMaster_ID, Customer => Customer.ID, (CustomerInfo_tenant, Customer) => new { CustomerInfo_tenant, Customer })
                    .Count(x => (tenant_Id == null || x.Customer.Tenant_ID == tenant_Id)
                            && (x.Customer.ID.ToString().Contains(searchValue)
                        || x.Customer.Gender.CaseInsensitiveContains(searchValue)
                        || x.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoDateOfLastLogon.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoNumberOfLogons.ToString().CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoDateAccountCreated.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoDateAccountLastModified.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CustomerMasterInfoRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (CustomerInfo, tenant) => new { CustomerInfo, tenant })
                    .Join(unitOfWork.CustomerMasterRepository.Get(), CustomerInfo_tenant => CustomerInfo_tenant.CustomerInfo.CustomerMaster_ID, Customer => Customer.ID, (CustomerInfo_tenant, Customer) => new { CustomerInfo_tenant, Customer })
                    .Where(x => (tenant_Id == null || x.Customer.Tenant_ID == tenant_Id)
                            && (x.Customer.ID.ToString().Contains(searchValue)
                        || x.Customer.Gender.CaseInsensitiveContains(searchValue)
                        || x.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoDateOfLastLogon.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoNumberOfLogons.ToString().CaseInsensitiveContains(searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoDateAccountCreated.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant.CustomerInfo.InfoDateAccountLastModified.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.CustomerInfo_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CustomerMasterInfoIndexViewModel
                    {
                        ID = x.Customer.ID,
                        FirstName = x.Customer.FirstName,
                        LastName = x.Customer.LastName,
                        DOB = x.Customer.DOB,
                        EmailID = x.Customer.EmailID,
                        FullStreetAddress = x.Customer.FullStreetAddress,
                        InfoDateOfLastLogon= x.CustomerInfo_tenant.CustomerInfo.InfoDateOfLastLogon,
                        InfoNumberOfLogons= x.CustomerInfo_tenant.CustomerInfo.InfoNumberOfLogons,
                        InfoDateAccountCreated = x.CustomerInfo_tenant.CustomerInfo.InfoDateAccountCreated,
                        InfoDateAccountLastModified = x.CustomerInfo_tenant.CustomerInfo.InfoDateAccountLastModified,
                        TenantName = x.CustomerInfo_tenant.tenant.Name,
                        Tenant_ID = x.CustomerInfo_tenant.tenant.ID,
                        CreatedBy = x.Customer.CreatedBy,
                        CreatedOn = x.Customer.CreatedOn,
                        UpdatedBy = x.Customer.UpdatedBy,
                        UpdatedOn = x.Customer.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CustomerMasterInfoIndexViewModel>
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





        public EntityModel.CustomerMasterInfo Create(EntityModel.CustomerMasterInfo entity)
        {
            try
            {
                return unitOfWork.CustomerMasterInfoRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CustomerMasterInfo GetById(long Id)
        {
            try
            {
                EntityModel.CustomerMasterInfo entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CustomerMasterInfoRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CustomerMasterInfo Update(EntityModel.CustomerMasterInfo entity)
        {
            try
            {
                return unitOfWork.CustomerMasterInfoRepository.Update(entity);
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
                unitOfWork.CustomerMasterInfoRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CustomerMasterInfo> GetAll()
        {
            try
            {
                return unitOfWork.CustomerMasterInfoRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CustomerMasterInfo> FindBy(Expression<Func<EntityModel.CustomerMasterInfo, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CustomerMasterInfo> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CustomerMasterInfoRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CustomerMasterInfoRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CustomerMasterInfo, bool>> filter = null)
        {
            try
            {
                unitOfWork.CustomerMasterInfoRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.CustomerMasterInfo, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CustomerMasterInfoRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
