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
    public class Currency : BaseBusiness, ICurrency
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IP_CurrencyIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IP_CurrencyIndexViewModel> collection;
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
                totalRecords = unitOfWork.CurrenciesRepository.Get().Join(unitOfWork.TenantRepository.Get(), Currency => Currency.Tenant_ID, tenant => tenant.ID, (Currency, tenant) => new { Currency, tenant })
                    .Count(x => (tenant_Id == null || x.Currency.Tenant_ID == tenant_Id)
                            && (x.Currency.ID.ToString().Contains(searchValue)
                        || x.Currency.name.CaseInsensitiveContains(searchValue)
                        || x.Currency.native.CaseInsensitiveContains(searchValue)
                        || x.Currency.plural.CaseInsensitiveContains(searchValue) 
                        || x.Currency.symbol.CaseInsensitiveContains(searchValue)
                        || x.Currency.code.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Currency.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Currency.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Currency.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Currency.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.CurrenciesRepository.Get().Join(unitOfWork.TenantRepository.Get(), Currency => Currency.Tenant_ID, tenant => tenant.ID, (Currency, tenant) => new { Currency, tenant })
                    .Where(x => (tenant_Id == null || x.Currency.Tenant_ID == tenant_Id)
                            && (x.Currency.ID.ToString().Contains(searchValue)
                        || x.Currency.name.CaseInsensitiveContains(searchValue)
                        || x.Currency.native.CaseInsensitiveContains(searchValue)
                        || x.Currency.plural.CaseInsensitiveContains(searchValue)
                        || x.Currency.symbol.CaseInsensitiveContains(searchValue)
                        || x.Currency.code.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Currency.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Currency.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Currency.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Currency.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IP_CurrencyIndexViewModel
                    {
                        ID = x.Currency.ID,
                        code = x.Currency.code,
                        native = x.Currency.native,
                        plural = x.Currency.plural,
                        symbol = x.Currency.symbol,
                        name = x.Currency.name,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Currency.CreatedBy,
                        CreatedOn = x.Currency.CreatedOn,
                        UpdatedBy = x.Currency.UpdatedBy,
                        UpdatedOn = x.Currency.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IP_CurrencyIndexViewModel>
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





        public EntityModel.Currency Create(EntityModel.Currency entity)
        {
            try
            {
                return unitOfWork.CurrenciesRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Currency GetById(long Id)
        {
            try
            {
                EntityModel.Currency entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.CurrenciesRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Currency Update(EntityModel.Currency entity)
        {
            try
            {
                return unitOfWork.CurrenciesRepository.Update(entity);
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
                unitOfWork.CurrenciesRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Currency> GetAll()
        {
            try
            {
                return unitOfWork.CurrenciesRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Currency> FindBy(Expression<Func<EntityModel.Currency, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Currency> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.CurrenciesRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.CurrenciesRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Currency, bool>> filter = null)
        {
            try
            {
                unitOfWork.CurrenciesRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Currency, bool>> filter = null)
        {
            try
            {
                return unitOfWork.CurrenciesRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
