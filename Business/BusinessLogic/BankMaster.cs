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
    public class BankMaster : BaseBusiness, IBankMaster
    {
        public ViewModel.BusinessResultViewModel<ViewModel.BankMasterIndexViewModel> Index(HttpRequestBase Request, long? tenant_Id)
        {
            List<ViewModel.BankMasterIndexViewModel> collection;
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
                totalRecords = unitOfWork.BankMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), bank => bank.Tenant_ID, tenant => tenant.ID, (bank, tenant) => new { bank, tenant })
                    .Count(x => (tenant_Id == null || x.bank.Tenant_ID == tenant_Id)
                            && (x.bank.ID.ToString().Contains(searchValue)
                        || x.bank.Description.CaseInsensitiveContains(searchValue)
                        || x.bank.IconPath.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.bank.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.bank.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.bank.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.bank.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.BankMasterRepository.Get().Join(unitOfWork.TenantRepository.Get(), bank => bank.Tenant_ID, tenant => tenant.ID, (bank, tenant) => new { bank, tenant })
                    .Where(x => (tenant_Id == null || x.bank.Tenant_ID == tenant_Id)
                            && (x.bank.ID.ToString().Contains(searchValue)
                        || x.bank.Description.CaseInsensitiveContains(searchValue)
                        || x.bank.IconPath.CaseInsensitiveContains(searchValue)
                        || x.tenant.Name.CaseInsensitiveContains(searchValue)
                        || x.bank.CreatedBy.CaseInsensitiveContains(searchValue)
                        || x.bank.UpdatedBy.CaseInsensitiveContains(searchValue)
                        || x.bank.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        || x.bank.UpdatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                        ))
                    .OrderBy(sortColumn + " " + sortColumnDir)
                    .Skip(skip).Take(pageSize).ToList()
                    .Select(x => new ViewModel.BankMasterIndexViewModel
                    {
                        ID = x.bank.ID,
                        Description = x.bank.Description,
                        IsActive = x.bank.IsActive,
                        IconPath = String.Concat(busConstant.Settings.CMSPath.TENANAT_UPLOAD_DIRECTORY, x.tenant.ID)+"/"+x.bank.IconPath,
                        TenantName = x.tenant.Name,
                        Tenant_ID = x.tenant.ID,
                        CreatedBy = x.bank.CreatedBy,
                        CreatedOn = x.bank.CreatedOn,
                        UpdatedBy = x.bank.UpdatedBy,
                        UpdatedOn = x.bank.UpdatedOn
                    }).ToList();


                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.BankMasterIndexViewModel>
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





        public EntityModel.BankMaster Create(EntityModel.BankMaster entity)
        {
            try
            {
                return unitOfWork.BankMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.BankMaster GetById(long Id)
        {
            try
            {
                EntityModel.BankMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.BankMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.BankMaster Update(EntityModel.BankMaster entity)
        {
            try
            {
                return unitOfWork.BankMasterRepository.Update(entity);
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
                unitOfWork.BankMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.BankMaster> GetAll()
        {
            try
            {
                return unitOfWork.BankMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.BankMaster> FindBy(Expression<Func<EntityModel.BankMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.BankMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.BankMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.BankMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.BankMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.BankMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.BankMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.BankMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
