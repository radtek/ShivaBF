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
    public class TimeZone : BaseBusiness, ITimeZone
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IP_TimeZoneIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IP_TimeZoneIndexViewModel> collection;
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
                totalRecords = unitOfWork.TimeZonesRepository.Get().Join(unitOfWork.TenantRepository.Get(), TimeZone => TimeZone.Tenant_ID, tenant => tenant.ID, (TimeZone, tenant) => new { TimeZone, tenant })
                    .Count(x => (tenant_Id == null || x.TimeZone.Tenant_ID == tenant_Id)
                            && (x.TimeZone.ID.ToString().Contains(searchValue)
                        || x.TimeZone.abbr.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.current_time.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.is_dst.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.name.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.offset.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.TimeZone.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.TimeZone.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.TimeZone.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.TimeZone.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.TimeZonesRepository.Get().Join(unitOfWork.TenantRepository.Get(), TimeZone => TimeZone.Tenant_ID, tenant => tenant.ID, (TimeZone, tenant) => new { TimeZone, tenant })
                    .Where(x => (tenant_Id == null || x.TimeZone.Tenant_ID == tenant_Id)
                            && (x.TimeZone.ID.ToString().Contains(searchValue)
                        || x.TimeZone.abbr.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.current_time.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.is_dst.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.name.ToString().CaseInsensitiveContains(searchValue)
                        || x.TimeZone.offset.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.TimeZone.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.TimeZone.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.TimeZone.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.TimeZone.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IP_TimeZoneIndexViewModel
                    {
                        ID = x.TimeZone.ID,
                        abbr = x.TimeZone.abbr,
                        current_time = x.TimeZone.current_time,
                        is_dst = x.TimeZone.is_dst,
                        name = x.TimeZone.name,
                        offset = x.TimeZone.offset,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.TimeZone.CreatedBy,
                        CreatedOn = x.TimeZone.CreatedOn,
                        UpdatedBy = x.TimeZone.UpdatedBy,
                        UpdatedOn = x.TimeZone.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IP_TimeZoneIndexViewModel>
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





        public EntityModel.TimeZone Create(EntityModel.TimeZone entity)
        {
            try
            {
                return unitOfWork.TimeZonesRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.TimeZone GetById(long Id)
        {
            try
            {
                EntityModel.TimeZone entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.TimeZonesRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.TimeZone Update(EntityModel.TimeZone entity)
        {
            try
            {
                return unitOfWork.TimeZonesRepository.Update(entity);
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
                unitOfWork.TimeZonesRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.TimeZone> GetAll()
        {
            try
            {
                return unitOfWork.TimeZonesRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.TimeZone> FindBy(Expression<Func<EntityModel.TimeZone, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.TimeZone> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.TimeZonesRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.TimeZonesRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.TimeZone, bool>> filter = null)
        {
            try
            {
                unitOfWork.TimeZonesRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.TimeZone, bool>> filter = null)
        {
            try
            {
                return unitOfWork.TimeZonesRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
