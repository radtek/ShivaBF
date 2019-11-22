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
    public class Asn : BaseBusiness, IAsn
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IP_AsnIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IP_AsnIndexViewModel> collection;
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
                totalRecords = unitOfWork.AsnsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Asn => Asn.Tenant_ID, tenant => tenant.ID, (Asn, tenant) => new { Asn, tenant })
                    .Count(x => (tenant_Id == null || x.Asn.Tenant_ID == tenant_Id)
                            && (x.Asn.ID.ToString().Contains(searchValue)
                        || x.Asn.name.CaseInsensitiveContains(searchValue)
                        || x.Asn.route.CaseInsensitiveContains(searchValue)
                        || x.Asn.type.CaseInsensitiveContains(searchValue)
                        || x.Asn.domain.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Asn.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Asn.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Asn.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Asn.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.AsnsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Asn => Asn.Tenant_ID, tenant => tenant.ID, (Asn, tenant) => new { Asn, tenant })
                    .Where(x => (tenant_Id == null || x.Asn.Tenant_ID == tenant_Id)
                            && (x.Asn.ID.ToString().Contains(searchValue)
                        || x.Asn.name.CaseInsensitiveContains(searchValue)
                        || x.Asn.route.CaseInsensitiveContains(searchValue)
                        || x.Asn.type.CaseInsensitiveContains(searchValue)
                        || x.Asn.domain.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Asn.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Asn.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Asn.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Asn.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IP_AsnIndexViewModel
                    {
                        ID = x.Asn.ID,
                        asn = x.Asn.asn,
                        domain = x.Asn.domain,
                        name= x.Asn.name,
                        route = x.Asn.route,
                        type = x.Asn.type,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Asn.CreatedBy,
                        CreatedOn = x.Asn.CreatedOn,
                        UpdatedBy = x.Asn.UpdatedBy,
                        UpdatedOn = x.Asn.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IP_AsnIndexViewModel>
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





        public EntityModel.Asn Create(EntityModel.Asn entity)
        {
            try
            {
                return unitOfWork.AsnsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Asn GetById(long Id)
        {
            try
            {
                EntityModel.Asn entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.AsnsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Asn Update(EntityModel.Asn entity)
        {
            try
            {
                return unitOfWork.AsnsRepository.Update(entity);
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
                unitOfWork.AsnsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Asn> GetAll()
        {
            try
            {
                return unitOfWork.AsnsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Asn> FindBy(Expression<Func<EntityModel.Asn, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Asn> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.AsnsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.AsnsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Asn, bool>> filter = null)
        {
            try
            {
                unitOfWork.AsnsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Asn, bool>> filter = null)
        {
            try
            {
                return unitOfWork.AsnsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
