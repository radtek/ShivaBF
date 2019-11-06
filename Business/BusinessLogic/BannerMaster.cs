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
    public class BannerMaster : BaseBusiness, IBannerMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.BannerMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.BannerMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.BannerMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Banner => Banner.Tenant_ID, tenant => tenant.ID, (Banner, tenant) => new { Banner, tenant })
                    .Count(x => (tenant_Id == null || x.Banner.Tenant_ID == tenant_Id)
                            && (x.Banner.ID.ToString().Contains(searchValue)
                        || x.Banner.BannerPath.CaseInsensitiveContains(searchValue)
                        || x.Banner.AlternativeText.CaseInsensitiveContains(searchValue)
                        || x.Banner.Title.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Banner.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Banner.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Banner.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Banner.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.BannerMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), Banner => Banner.Tenant_ID, tenant => tenant.ID, (Banner, tenant) => new { Banner, tenant })
                    .Where(x => (tenant_Id == null || x.Banner.Tenant_ID == tenant_Id)
                            && (x.Banner.ID.ToString().Contains(searchValue)
                        || x.Banner.BannerPath.CaseInsensitiveContains(searchValue)
                        || x.Banner.AlternativeText.CaseInsensitiveContains(searchValue)
                        || x.Banner.Title.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Banner.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Banner.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Banner.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Banner.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.BannerMasterIndexViewModel
                    {
                        ID = x.Banner.ID,
                        AlternativeText = x.Banner.AlternativeText,
                        Title = x.Banner.Title,
                        BannerName= x.Banner.BannerPath,
                        BannerPath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID)+"/"+x.Banner.BannerPath,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Banner.CreatedBy,
                        CreatedOn = x.Banner.CreatedOn,
                        UpdatedBy = x.Banner.UpdatedBy,
                        UpdatedOn = x.Banner.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.BannerMasterIndexViewModel>
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





        public EntityModel.BannerMaster Create(EntityModel.BannerMaster entity)
        {
            try
            {
                return unitOfWork.BannerMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.BannerMaster GetById(long Id)
        {
            try
            {
                EntityModel.BannerMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.BannerMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.BannerMaster Update(EntityModel.BannerMaster entity)
        {
            try
            {
                return unitOfWork.BannerMasterRepository.Update(entity);
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
                unitOfWork.BannerMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.BannerMaster> GetAll()
        {
            try
            {
                return unitOfWork.BannerMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.BannerMaster> FindBy(Expression<Func<EntityModel.BannerMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.BannerMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.BannerMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.BannerMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.BannerMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.BannerMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.BannerMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.BannerMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
