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
    public class FooterLinks : BaseBusiness, IFooterLinks
    {
        public ViewModel.BusinessResultViewModel<ViewModel.FooterLinksIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.FooterLinksIndexViewModel> collection;
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
                totalRecords = unitOfWork.FooterLinksRepository.Get().Join(unitOfWork.TenantRepository.Get(), FooterLinks => FooterLinks.Tenant_ID, tenant => tenant.ID, (FooterLinks, tenant) => new { FooterLinks, tenant })
                     .Join(unitOfWork.FooterBlockMasterRepository.Get(), FooterLinks_tenant => FooterLinks_tenant.FooterLinks.FooterBlockMaster_Id, FooterBlockMaster => FooterBlockMaster.ID, (FooterLinks_tenant, FooterBlockMaster) => new { FooterLinks_tenant, FooterBlockMaster })
                    .Count(x => (tenant_Id == null || x.FooterLinks_tenant.FooterLinks.Tenant_ID == tenant_Id)
                            && (x.FooterLinks_tenant.FooterLinks.ID.ToString().Contains(searchValue)
                             || x.FooterBlockMaster.Heading.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.FooterLinks_tenant.FooterLinks.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.FooterLinksRepository.Get().Join(unitOfWork.TenantRepository.Get(), FooterLinks => FooterLinks.Tenant_ID, tenant => tenant.ID, (FooterLinks, tenant) => new { FooterLinks, tenant })
                     .Join(unitOfWork.FooterBlockMasterRepository.Get(), FooterLinks_tenant => FooterLinks_tenant.FooterLinks.FooterBlockMaster_Id, FooterBlockMaster => FooterBlockMaster.ID, (FooterLinks_tenant, FooterBlockMaster) => new { FooterLinks_tenant, FooterBlockMaster })
                    .Where(x => (tenant_Id == null || x.FooterLinks_tenant.FooterLinks.Tenant_ID == tenant_Id)
                            && (x.FooterLinks_tenant.FooterLinks.ID.ToString().Contains(searchValue)
                             || x.FooterBlockMaster.Heading.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.AncharTagTitle.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.AncharTagUrl.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.FooterLinks_tenant.FooterLinks.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.FooterLinks_tenant.FooterLinks.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.FooterLinksIndexViewModel
                    {
                        ID = x.FooterLinks_tenant.FooterLinks.ID,
                        Heading = x.FooterBlockMaster.Heading,
                        AncharTagTitle = x.FooterLinks_tenant.FooterLinks.AncharTagTitle,
                        AncharTagUrl = x.FooterLinks_tenant.FooterLinks.AncharTagUrl,
                        DisplayIndex = x.FooterLinks_tenant.FooterLinks.DisplayIndex,
                        Url = x.FooterLinks_tenant.FooterLinks.Url,
                        Metadata = x.FooterLinks_tenant.FooterLinks.Metadata,
                        MetaDescription = x.FooterLinks_tenant.FooterLinks.MetaDescription,
                        Keyword = x.FooterLinks_tenant.FooterLinks.Keyword,
                        TotalViews = x.FooterLinks_tenant.FooterLinks.TotalViews,
                        IsActive = x.FooterLinks_tenant.FooterLinks.IsActive,
                        TenantName = x.FooterLinks_tenant.FooterLinks.Tenant.Name,
                        Tenant_ID = x.FooterLinks_tenant.FooterLinks.Tenant.ID,
                        CreatedBy = x.FooterLinks_tenant.FooterLinks.CreatedBy,
                        CreatedOn = x.FooterLinks_tenant.FooterLinks.CreatedOn,
                        UpdatedBy = x.FooterLinks_tenant.FooterLinks.UpdatedBy,
                        UpdatedOn = x.FooterLinks_tenant.FooterLinks.UpdatedOn,
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.FooterLinksIndexViewModel>
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





        public EntityModel.FooterLinks Create(EntityModel.FooterLinks entity)
        {
            try
            {
                return unitOfWork.FooterLinksRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.FooterLinks GetById(long Id)
        {
            try
            {
                EntityModel.FooterLinks entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.FooterLinksRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.FooterLinks Update(EntityModel.FooterLinks entity)
        {
            try
            {
                return unitOfWork.FooterLinksRepository.Update(entity);
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
                unitOfWork.FooterLinksRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.FooterLinks> GetAll()
        {
            try
            {
                return unitOfWork.FooterLinksRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.FooterLinks> FindBy(Expression<Func<EntityModel.FooterLinks, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.FooterLinks> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.FooterLinksRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.FooterLinksRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.FooterLinks, bool>> filter = null)
        {
            try
            {
                unitOfWork.FooterLinksRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.FooterLinks, bool>> filter = null)
        {
            try
            {
                return unitOfWork.FooterLinksRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
