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
    public class Carrier : BaseBusiness, ICarrier
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IP_CarrierIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IP_CarrierIndexViewModel> collection;
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
                totalRecords = unitOfWork.CarriersRepository.Get().Join(unitOfWork.TenantRepository.Get(), Carrier => Carrier.Tenant_ID, tenant => tenant.ID, (Carrier, tenant) => new { Carrier, tenant })
                    .Count(x => (tenant_Id == null || x.Carrier.Tenant_ID == tenant_Id)
                            && (x.Carrier.ID.ToString().Contains(searchValue)
                        || x.Carrier.name.CaseInsensitiveContains(searchValue)
                        || x.Carrier.mcc.CaseInsensitiveContains(searchValue)
                        || x.Carrier.mnc.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Carrier.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Carrier.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Carrier.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Carrier.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CarriersRepository.Get().Join(unitOfWork.TenantRepository.Get(), Carrier => Carrier.Tenant_ID, tenant => tenant.ID, (Carrier, tenant) => new { Carrier, tenant })
                    .Where(x => (tenant_Id == null || x.Carrier.Tenant_ID == tenant_Id)
                            && (x.Carrier.ID.ToString().Contains(searchValue)
                        || x.Carrier.name.CaseInsensitiveContains(searchValue)
                        || x.Carrier.mcc.CaseInsensitiveContains(searchValue)
                        || x.Carrier.mnc.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Carrier.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Carrier.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Carrier.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Carrier.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IP_CarrierIndexViewModel
                    {
                        ID = x.Carrier.ID,
                        mnc = x.Carrier.mnc,
                        mcc = x.Carrier.mcc,
                        name= x.Carrier.name,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Carrier.CreatedBy,
                        CreatedOn = x.Carrier.CreatedOn,
                        UpdatedBy = x.Carrier.UpdatedBy,
                        UpdatedOn = x.Carrier.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IP_CarrierIndexViewModel>
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





        public EntityModel.Carrier Create(EntityModel.Carrier entity)
        {
            try
            {
                return unitOfWork.CarriersRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Carrier GetById(long Id)
        {
            try
            {
                EntityModel.Carrier entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CarriersRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Carrier Update(EntityModel.Carrier entity)
        {
            try
            {
                return unitOfWork.CarriersRepository.Update(entity);
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
                unitOfWork.CarriersRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Carrier> GetAll()
        {
            try
            {
                return unitOfWork.CarriersRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Carrier> FindBy(Expression<Func<EntityModel.Carrier, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Carrier> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CarriersRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CarriersRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Carrier, bool>> filter = null)
        {
            try
            {
                unitOfWork.CarriersRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Carrier, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CarriersRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
