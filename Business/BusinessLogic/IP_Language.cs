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
    public class Language : BaseBusiness, ILanguage
    {
        public ViewModel.BusinessResultViewModel<ViewModel.IP_LanguageIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.IP_LanguageIndexViewModel> collection;
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
                totalRecords = unitOfWork.LanguagesRepository.Get().Join(unitOfWork.TenantRepository.Get(), Language => Language.Tenant_ID, tenant => tenant.ID, (Language, tenant) => new { Language, tenant })
                    .Count(x => (tenant_Id == null || x.Language.Tenant_ID == tenant_Id)
                            && (x.Language.ID.ToString().Contains(searchValue)
                        || x.Language.name.CaseInsensitiveContains(searchValue)
                        || x.Language.native.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Language.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Language.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Language.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Language.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.LanguagesRepository.Get().Join(unitOfWork.TenantRepository.Get(), Language => Language.Tenant_ID, tenant => tenant.ID, (Language, tenant) => new { Language, tenant })
                    .Where(x => (tenant_Id == null || x.Language.Tenant_ID == tenant_Id)
                            && (x.Language.ID.ToString().Contains(searchValue)
                        || x.Language.name.CaseInsensitiveContains(searchValue)
                        || x.Language.native.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.Language.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.Language.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.Language.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.Language.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.IP_LanguageIndexViewModel
                    {
                        ID = x.Language.ID,
                        native = x.Language.native,
                        name = x.Language.name,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.Language.CreatedBy,
                        CreatedOn = x.Language.CreatedOn,
                        UpdatedBy = x.Language.UpdatedBy,
                        UpdatedOn = x.Language.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.IP_LanguageIndexViewModel>
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





        public EntityModel.Language Create(EntityModel.Language entity)
        {
            try
            {
                return unitOfWork.LanguagesRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.Language GetById(long Id)
        {
            try
            {
                EntityModel.Language entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.LanguagesRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.Language Update(EntityModel.Language entity)
        {
            try
            {
                return unitOfWork.LanguagesRepository.Update(entity);
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
                unitOfWork.LanguagesRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.Language> GetAll()
        {
            try
            {
                return unitOfWork.LanguagesRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.Language> FindBy(Expression<Func<EntityModel.Language, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.Language> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.LanguagesRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.LanguagesRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.Language, bool>> filter = null)
        {
            try
            {
                unitOfWork.LanguagesRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.Language, bool>> filter = null)
        {
            try
            {
                return unitOfWork.LanguagesRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
