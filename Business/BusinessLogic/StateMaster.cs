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
    public class StateMaster : BaseBusiness, IStateMaster
    {
       
        public EntityModel.StateMaster Create(EntityModel.StateMaster entity)
        {
            try
            {
                return unitOfWork.StateMasterRepository.Insert(entity);
            }
            catch (Exception ex)
            {
                throw;
            }

        }




        public EntityModel.StateMaster GetById(long Id)
        {
            try
            {
                EntityModel.StateMaster entity;
                if (Id == default(long))
                {
                    throw new Exception(busConstant.Messages.Type.Exceptions.BAD_REQUEST);
                }

                entity = unitOfWork.StateMasterRepository.GetByID(Id);

                return entity;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public EntityModel.StateMaster Update(EntityModel.StateMaster entity)
        {
            try
            {
                return unitOfWork.StateMasterRepository.Update(entity);
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
                unitOfWork.StateMasterRepository.Delete(Id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public IEnumerable<EntityModel.StateMaster> GetAll()
        {
            try
            {
                return unitOfWork.StateMasterRepository.Get();
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public IEnumerable<EntityModel.StateMaster> FindBy(Expression<Func<EntityModel.StateMaster, bool>> filter = null)
        {
            try
            {
                IEnumerable<EntityModel.StateMaster> entities;
                if (filter.IsNotNull())
                {
                    entities = unitOfWork.StateMasterRepository.Get(filter);
                }
                else
                {
                    entities = unitOfWork.StateMasterRepository.Get();
                }

                return entities;
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        public void DeleteWhere(Expression<Func<EntityModel.StateMaster, bool>> filter = null)
        {
            try
            {
                unitOfWork.StateMasterRepository.DeleteWhere(filter);
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

        public Int32 Count(Expression<Func<EntityModel.StateMaster, bool>> filter = null)
        {
            try
            {
                return unitOfWork.StateMasterRepository.Count(filter);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
