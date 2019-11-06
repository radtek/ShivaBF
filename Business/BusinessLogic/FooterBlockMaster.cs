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
    public class FooterBlockMaster : BaseBusiness, IFooterBlockMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.FooterBlockMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.FooterBlockMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.FooterBlockMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), footerBlockMaster => footerBlockMaster.Tenant_ID, tenant => tenant.ID, (footerBlockMaster, tenant) => new { footerBlockMaster, tenant })
                    .Count(x => (tenant_Id == null || x.footerBlockMaster.Tenant_ID == tenant_Id)
                            && (x.footerBlockMaster.ID.ToString().Contains(searchValue)
                        || x.footerBlockMaster.Heading.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.footerBlockMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.footerBlockMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.footerBlockMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.footerBlockMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.FooterBlockMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), footerBlockMaster => footerBlockMaster.Tenant_ID, tenant => tenant.ID, (footerBlockMaster, tenant) => new { footerBlockMaster, tenant })
                    .Where(x => (tenant_Id == null || x.footerBlockMaster.Tenant_ID == tenant_Id)
                            && (x.footerBlockMaster.ID.ToString().Contains(searchValue)
                        || x.footerBlockMaster.Heading.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.footerBlockMaster.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.footerBlockMaster.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.footerBlockMaster.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.footerBlockMaster.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.FooterBlockMasterIndexViewModel
                    {
                        ID = x.footerBlockMaster.ID,
                        Heading = x.footerBlockMaster.Heading,
                        DisplayIndex = x.footerBlockMaster.DisplayIndex,
                        Url = x.footerBlockMaster.Url,
                        Metadata = x.footerBlockMaster.Metadata,
                        MetaDescription = x.footerBlockMaster.MetaDescription,
                        Keyword = x.footerBlockMaster.Keyword,
                        TotalViews = x.footerBlockMaster.TotalViews,
                        IsActive = x.footerBlockMaster.IsActive,
                        TenantName = x.footerBlockMaster.Tenant.Name,
                        Tenant_ID = x.footerBlockMaster.Tenant.ID,
                        CreatedBy = x.footerBlockMaster.CreatedBy,
                        CreatedOn = x.footerBlockMaster.CreatedOn,
                        UpdatedBy = x.footerBlockMaster.UpdatedBy,
                        UpdatedOn = x.footerBlockMaster.UpdatedOn,
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.FooterBlockMasterIndexViewModel>
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





        public EntityModel.FooterBlockMaster Create(EntityModel.FooterBlockMaster entity)
        {
            try
            {
                return unitOfWork.FooterBlockMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.FooterBlockMaster GetById(long Id)
        {
            try
            {
                EntityModel.FooterBlockMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.FooterBlockMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.FooterBlockMaster Update(EntityModel.FooterBlockMaster entity)
        {
            try
            {
                return unitOfWork.FooterBlockMasterRepository.Update(entity);
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
                unitOfWork.FooterBlockMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.FooterBlockMaster> GetAll()
        {
            try
            {
                return unitOfWork.FooterBlockMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.FooterBlockMaster> FindBy(Expression<Func<EntityModel.FooterBlockMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.FooterBlockMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.FooterBlockMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.FooterBlockMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.FooterBlockMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.FooterBlockMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.FooterBlockMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.FooterBlockMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
