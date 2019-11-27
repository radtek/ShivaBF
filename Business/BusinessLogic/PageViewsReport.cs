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
    public class PageViewsReport : BaseBusiness, IPageViewsReport
    {
        public ViewModel.BusinessResultViewModel<ViewModel.PageViewsReportIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.PageViewsReportIndexViewModel> collection;
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
                totalRecords = unitOfWork.PageViewsReportRepository.Get().Join(unitOfWork.TenantRepository.Get(), PageViewsReport => PageViewsReport.Tenant_ID, tenant => tenant.ID, (PageViewsReport, tenant) => new { PageViewsReport, tenant })
                    .Count(x => (tenant_Id == null || x.PageViewsReport.Tenant_ID == tenant_Id)
                            && (x.PageViewsReport.ID.ToString().Contains(searchValue)
                        || x.PageViewsReport.Url.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.Count.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.PageViewsReport.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.PageViewsReportRepository.Get().Join(unitOfWork.TenantRepository.Get(), PageViewsReport => PageViewsReport.Tenant_ID, tenant => tenant.ID, (PageViewsReport, tenant) => new { PageViewsReport, tenant })
                    .Where(x => (tenant_Id == null || x.PageViewsReport.Tenant_ID == tenant_Id)
                            && (x.PageViewsReport.ID.ToString().Contains(searchValue)
                        || x.PageViewsReport.Url.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.Count.ToString().CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.PageViewsReport.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.PageViewsReport.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.PageViewsReportIndexViewModel
                    {
                        ID = x.PageViewsReport.ID,
                        Url = x.PageViewsReport.Url,
                        Count = x.PageViewsReport.Count,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.PageViewsReport.CreatedBy,
                        CreatedOn = x.PageViewsReport.CreatedOn,
                        UpdatedBy = x.PageViewsReport.UpdatedBy,
                        UpdatedOn = x.PageViewsReport.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.PageViewsReportIndexViewModel>
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





        public EntityModel.PageViewsReport Create(EntityModel.PageViewsReport entity)
        {
            try
            {
                return unitOfWork.PageViewsReportRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.PageViewsReport GetById(long Id)
        {
            try
            {
                EntityModel.PageViewsReport entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.PageViewsReportRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.PageViewsReport Update(EntityModel.PageViewsReport entity)
        {
            try
            {
                return unitOfWork.PageViewsReportRepository.Update(entity);
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
                unitOfWork.PageViewsReportRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.PageViewsReport> GetAll()
        {
            try
            {
                return unitOfWork.PageViewsReportRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.PageViewsReport> FindBy(Expression<Func<EntityModel.PageViewsReport, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.PageViewsReport> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.PageViewsReportRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.PageViewsReportRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.PageViewsReport, bool>> filter = null)
        {
            try
            {
                unitOfWork.PageViewsReportRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.PageViewsReport, bool>> filter = null)
        {
            try
            {
                return unitOfWork.PageViewsReportRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
