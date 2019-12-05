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
    public class CustomerServiceOrder : BaseBusiness, ICustomerServiceOrder
    {
        public ViewModel.BusinessResultViewModel<ViewModel.CustomerServiceOrderIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.CustomerServiceOrderIndexViewModel> collection;
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
                totalRecords = unitOfWork.CustomerServiceOrderRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (customerServiceOrder, tenant) => new { customerServiceOrder, tenant })
                    .Count(x => (tenant_Id == null || x.customerServiceOrder.Tenant_ID == tenant_Id)
                            && (x.customerServiceOrder.ID.ToString().Contains(searchValue)
                        || x.customerServiceOrder.FirstName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.LastName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.EmailID.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Telephone.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Fax.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Service_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.ServiceName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Plan_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.PlanName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Amount.ToString().CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.PaymentMethod.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.DatePurchased.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.customerServiceOrder.OrdersStatus.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.OrdersDateFinished.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.customerServiceOrder.Comments.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.IsActive.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.customerServiceOrder.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CustomerServiceOrderRepository.Get().Join(unitOfWork.TenantRepository.Get(), Customer => Customer.Tenant_ID, tenant => tenant.ID, (customerServiceOrder, tenant) => new { customerServiceOrder, tenant })
                    .Where(x => (tenant_Id == null || x.customerServiceOrder.Tenant_ID == tenant_Id)
                            && (x.customerServiceOrder.ID.ToString().Contains(searchValue)
                        || x.customerServiceOrder.FirstName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.LastName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.EmailID.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.FullStreetAddress.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Telephone.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Fax.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Service_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.ServiceName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Plan_Id.ToString().CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.PlanName.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.Amount.ToString().CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.PaymentMethod.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.DatePurchased.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.customerServiceOrder.OrdersStatus.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.OrdersDateFinished.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.customerServiceOrder.Comments.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.IsActive.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.customerServiceOrder.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.customerServiceOrder.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.CustomerServiceOrderIndexViewModel
                    {
                        ID = x.customerServiceOrder.ID,
                        FirstName = x.customerServiceOrder.FirstName,
                        LastName = x.customerServiceOrder.LastName,
                        EmailID = x.customerServiceOrder.EmailID,
                        FullStreetAddress = x.customerServiceOrder.FullStreetAddress,
                        Telephone = x.customerServiceOrder.Telephone,
                        Fax = x.customerServiceOrder.Fax,
                        Service_Id= x.customerServiceOrder.Service_Id,
                        ServiceName = x.customerServiceOrder.ServiceName,
                        Plan_Id = x.customerServiceOrder.Plan_Id,
                        PlanName = x.customerServiceOrder.PlanName,
                        Amount = x.customerServiceOrder.Amount,
                        PaymentMethod = x.customerServiceOrder.PaymentMethod,
                        DatePurchased = x.customerServiceOrder.DatePurchased,
                        OrdersStatus = x.customerServiceOrder.OrdersStatus,
                        OrdersDateFinished = x.customerServiceOrder.OrdersDateFinished,
                        Comments = x.customerServiceOrder.Comments,
                        IsActive = x.customerServiceOrder.IsActive,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.customerServiceOrder.CreatedBy,
                        CreatedOn = x.customerServiceOrder.CreatedOn,
                        UpdatedBy = x.customerServiceOrder.UpdatedBy,
                        UpdatedOn = x.customerServiceOrder.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.CustomerServiceOrderIndexViewModel>
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





        public EntityModel.CustomerServiceOrder Create(EntityModel.CustomerServiceOrder entity)
        {
            try
            {
                return unitOfWork.CustomerServiceOrderRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.CustomerServiceOrder GetById(long Id)
        {
            try
            {
                EntityModel.CustomerServiceOrder entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CustomerServiceOrderRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.CustomerServiceOrder Update(EntityModel.CustomerServiceOrder entity)
        {
            try
            {
                return unitOfWork.CustomerServiceOrderRepository.Update(entity);
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
                unitOfWork.CustomerServiceOrderRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.CustomerServiceOrder> GetAll()
        {
            try
            {
                return unitOfWork.CustomerServiceOrderRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.CustomerServiceOrder> FindBy(Expression<Func<EntityModel.CustomerServiceOrder, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.CustomerServiceOrder> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CustomerServiceOrderRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CustomerServiceOrderRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.CustomerServiceOrder, bool>> filter = null)
        {
            try
            {
                unitOfWork.CustomerServiceOrderRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.CustomerServiceOrder, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CustomerServiceOrderRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
