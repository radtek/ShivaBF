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
    public class Threat : BaseBusiness, IThreat
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IP_ThreatIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IP_ThreatIndexViewModel> collection;
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
                totalRecords = unitOfWork.ThreatsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Threat => Threat.Tenant_ID, tenant => tenant.ID, (Threat, tenant) => new { Threat, tenant })
                    .Count(x => (tenant_Id == null || x.Threat.Tenant_ID == tenant_Id)
                            && (x.Threat.ID.ToString().Contains(searchValue)
                        || x.Threat.is_anonymous.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_bogon.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_abuser.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_attacker.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_proxy.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_threat.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_tor.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Threat.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Threat.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Threat.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Threat.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.ThreatsRepository.Get().Join(unitOfWork.TenantRepository.Get(), Threat => Threat.Tenant_ID, tenant => tenant.ID, (Threat, tenant) => new { Threat, tenant })
                    .Where(x => (tenant_Id == null || x.Threat.Tenant_ID == tenant_Id)
                            && (x.Threat.ID.ToString().Contains(searchValue)
                        || x.Threat.is_anonymous.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_bogon.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_abuser.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_known_attacker.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_proxy.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_threat.ToString().CaseInsensitiveContains(searchValue)
                        || x.Threat.is_tor.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Threat.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Threat.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Threat.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Threat.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IP_ThreatIndexViewModel
                    {
                        ID = x.Threat.ID,
                        is_anonymous = x.Threat.is_anonymous,
                        is_bogon = x.Threat.is_bogon,
                        is_known_abuser = x.Threat.is_known_abuser,
                        is_known_attacker = x.Threat.is_known_attacker,
                        is_proxy = x.Threat.is_proxy,
                        is_threat = x.Threat.is_threat,
                        is_tor = x.Threat.is_tor,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Threat.CreatedBy,
                        CreatedOn = x.Threat.CreatedOn,
                        UpdatedBy = x.Threat.UpdatedBy,
                        UpdatedOn = x.Threat.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IP_ThreatIndexViewModel>
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





        public EntityModel.Threat Create(EntityModel.Threat entity)
        {
            try
            {
                return unitOfWork.ThreatsRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Threat GetById(long Id)
        {
            try
            {
                EntityModel.Threat entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.ThreatsRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Threat Update(EntityModel.Threat entity)
        {
            try
            {
                return unitOfWork.ThreatsRepository.Update(entity);
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
                unitOfWork.ThreatsRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Threat> GetAll()
        {
            try
            {
                return unitOfWork.ThreatsRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Threat> FindBy(Expression<Func<EntityModel.Threat, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Threat> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.ThreatsRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.ThreatsRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Threat, bool>> filter = null)
        {
            try
            {
                unitOfWork.ThreatsRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Threat, bool>> filter = null)
        {
            try
            {
                return unitOfWork.ThreatsRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
