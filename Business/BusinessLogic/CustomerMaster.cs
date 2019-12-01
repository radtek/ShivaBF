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
    public class CustomerMaster : BaseBusiness, ICustomerMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CustomerMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CustomerMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.CustomerMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (Customer, tenant) => new { Customer, tenant })
                    .Count(x => (tenant_Id == null || x.Customer.Tenant_ID == tenant_Id)
                            && (x.Customer.ID.ToString().Contains(searchValue)
                        || x.Customer.Gender.CaseInsensitiveContains(searchValue)
                        || x.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.Customer.Telephone.CaseInsensitiveContains(searchValue)
                        || x.Customer.Fax.CaseInsensitiveContains(searchValue)
                        || x.Customer.Newsletter.CaseInsensitiveContains(searchValue)
                        || x.Customer.IsActive.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CustomerMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (Customer, tenant) => new { Customer, tenant })
                    .Where(x => (tenant_Id == null || x.Customer.Tenant_ID == tenant_Id)
                            && (x.Customer.ID.ToString().Contains(searchValue)
                        || x.Customer.Gender.CaseInsensitiveContains(searchValue)
                        || x.Customer.FirstName.CaseInsensitiveContains(searchValue)
                        || x.Customer.LastName.CaseInsensitiveContains(searchValue)
                        || x.Customer.DOB.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.EmailID.CaseInsensitiveContains(searchValue)
                        || x.Customer.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.Customer.Telephone.CaseInsensitiveContains(searchValue)
                        || x.Customer.Fax.CaseInsensitiveContains(searchValue)
                        || x.Customer.Newsletter.CaseInsensitiveContains(searchValue)
                        || x.Customer.IsActive.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Customer.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Customer.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CustomerMasterIndexViewModel
                    {
                        ID = x.Customer.ID,
                        Gender = x.Customer.Gender,
                        FirstName = x.Customer.FirstName,
                        LastName = x.Customer.LastName,
                        DOB = x.Customer.DOB,
                        EmailID = x.Customer.EmailID,
                        FullStreetAddress = x.Customer.FullStreetAddress,
                        Telephone = x.Customer.Telephone,
                        Fax = x.Customer.Fax,
                        Newsletter = x.Customer.Newsletter,
                        IsActive = x.Customer.IsActive,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Customer.CreatedBy,
                        CreatedOn = x.Customer.CreatedOn,
                        UpdatedBy = x.Customer.UpdatedBy,
                        UpdatedOn = x.Customer.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CustomerMasterIndexViewModel>
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





        public EntityModel.CustomerMaster Create(EntityModel.CustomerMaster entity)
        {
            try
            {
                return unitOfWork.CustomerMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CustomerMaster GetById(long Id)
        {
            try
            {
                EntityModel.CustomerMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CustomerMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CustomerMaster Update(EntityModel.CustomerMaster entity)
        {
            try
            {
                return unitOfWork.CustomerMasterRepository.Update(entity);
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
                unitOfWork.CustomerMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CustomerMaster> GetAll()
        {
            try
            {
                return unitOfWork.CustomerMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CustomerMaster> FindBy(Expression<Func<EntityModel.CustomerMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CustomerMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CustomerMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CustomerMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CustomerMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.CustomerMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.CustomerMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CustomerMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
