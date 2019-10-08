using SHF.Business;
using SHF.Business.Interface;
using SHF.EntityModel;
using SHF.Helper;
using SHF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Linq.Dynamic;

namespace SHF.Business.BusinessLogic
{
    public class Message : BaseBusiness, IMessage
    {
        public int Count(Expression<Func<SHF.EntityModel.Message, bool>> filter = null)
        {
            try
            {
                return unitOfWork.MessageRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SHF.EntityModel.Message Create(SHF.EntityModel.Message entity)
        {
            try
            {
                return unitOfWork.MessageRepository.Insert(entity);
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
                unitOfWork.MessageRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteWhere(Expression<Func<SHF.EntityModel.Message, bool>> filter = null)
        {
            try
            {
                unitOfWork.MessageRepository.DeleteWhere(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<SHF.EntityModel.Message> FindBy(Expression<Func<SHF.EntityModel.Message, bool>> filter = null)
        {
            try
            {
                IEnumerable<SHF.EntityModel.Message> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.MessageRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.MessageRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public IEnumerable<SHF.EntityModel.Message> GetAll()
        {
            try
            {
                return unitOfWork.MessageRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public SHF.EntityModel.Message GetById(long Id)
        {
            try
            {
                SHF.EntityModel.Message entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.MessageRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public BusinessResultViewModel<MessageIndexViewModel> Index(HttpRequestBase Request)
        {
            List<ViewModel.MessageIndexViewModel> collection;
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

                totalRecords = unitOfWork.MessageRepository.Get().Count(x => (x.ID.ToString().Contains(searchValue)
                                                             || x.Description.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.Icon.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.Title.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.Type.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.UpdateSeq.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.CreatedBy.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.UpdatedBy.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                                                             || x.UpdatedBy.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                                                    ));

                pageSize = pageSize < busConstant.Numbers.Integer.ZERO ? totalRecords : pageSize;

                //Database query
                collection = unitOfWork.MessageRepository.Get().Where(x => (x.ID.ToString().Contains(searchValue)
                                                             || x.Description.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.Icon.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.Title.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.Type.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.UpdateSeq.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.CreatedBy.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.UpdatedBy.ToString().CaseInsensitiveContains(searchValue)
                                                             || x.CreatedOn.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                                                             || x.UpdatedBy.ToString().Contains(searchValue.IsMatchingTo("{0:dd/MM/yyyy HH:mm:ss tt}") ? Convert.ToDateTime(searchValue).ToString("dd/MM/yyyy HH:mm:ss tt") : searchValue)
                                                    )).OrderBy(sortColumn + " " + sortColumnDir).Skip(skip).Take(pageSize).ToList()
                                                    .Select(x => new ViewModel.MessageIndexViewModel
                                                    {
                                                        ID = x.ID,
                                                        Description = x.Description,
                                                        Icon = x.Icon,
                                                        Title = x.Title,
                                                        Type = x.Type,
                                                        UpdateSeq = x.UpdateSeq,
                                                        CreatedBy = x.CreatedBy,
                                                        UpdatedBy = x.UpdatedBy,
                                                        CreatedOn = x.CreatedOn,
                                                        UpdatedOn = x.UpdatedOn,
                                                        IsActive = x.IsActive,
                                                        IsDeleted = x.IsDeleted
                                                    }).ToList();

                var businessResultViewModel = new ViewModel.BusinessResultViewModel<ViewModel.MessageIndexViewModel>
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

        public SHF.EntityModel.Message Update(SHF.EntityModel.Message entity)
        {
            try
            {
                return unitOfWork.MessageRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
