
using SHF.DataAccess;
using SHF.EntityModel;
using SHF.Helper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.DataAccess.Implementations
{
    public class GenericRepository<TEntity> where TEntity : BaseEntity
    {
        #region [Fields]

        internal InventoryDBContext context;
        internal DbSet<TEntity> dbSet;

        #endregion

        #region [Contructors]      

        public GenericRepository(InventoryDBContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        #endregion

        #region [Public Methods]


        public virtual void SaveChanges()
        {
            try
            {
                context.SaveChanges();
            }
            catch (Exception dbUpdateEx)
            {
                if (dbUpdateEx.InnerException.IsNotNull() && dbUpdateEx.InnerException.InnerException.IsNotNull())
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                        //throw new DBConcurrencyException();

                                throw sqlException;

                            default:
                                // A custom exception of yours for other DB issues
                                //throw new DatabaseAccessException(
                                //  dbUpdateEx.Message, dbUpdateEx.InnerException);
                                throw dbUpdateEx;

                        }
                    }

                    throw dbUpdateEx.InnerException.InnerException;
                }

                throw dbUpdateEx;
            }
        }

        public virtual void SaveChangesAsync()
        {
            try
            {
                context.SaveChangesAsync();
            }
            catch (Exception dbUpdateEx)
            {
                if (dbUpdateEx.InnerException.IsNotNull() && dbUpdateEx.InnerException.InnerException.IsNotNull())
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                        //throw new DBConcurrencyException();

                                throw sqlException;

                            default:
                                // A custom exception of yours for other DB issues
                                //throw new DatabaseAccessException(
                                //  dbUpdateEx.Message, dbUpdateEx.InnerException);
                                throw dbUpdateEx;

                        }
                    }

                    throw dbUpdateEx.InnerException.InnerException;
                }

                throw dbUpdateEx;
            }
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query, params object[] parameters)
        {
            try
            {
                return dbSet.SqlQuery(query, parameters).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task<IEnumerable<TEntity>> GetWithRawSqlAsync(string query, params object[] parameters)
        {
            try
            {
                return await dbSet.SqlQuery(query, parameters).ToListAsync().ConfigureAwait(busConstant.Misc.FALSE);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual Int32 Count(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                return query.ToList().Count;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task<Int32> CountAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                var collection = await query.ToListAsync().ConfigureAwait(busConstant.Misc.FALSE);
                return collection.Count;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return orderBy(query).ToList();
                }
                else
                {
                    return query.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return await orderBy(query).ToListAsync().ConfigureAwait(busConstant.Misc.FALSE);
                }
                else
                {
                    return await query.ToListAsync().ConfigureAwait(busConstant.Misc.FALSE);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity GetByID(object id)
        {
            try
            {
                return dbSet.Find(id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task<TEntity> GetByIDAsync(object id)
        {
            try
            {
                return await dbSet.FindAsync(id).ConfigureAwait(busConstant.Misc.FALSE);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity Insert(TEntity entity)
        {
            try
            {
                SetAuditCoulmnValues(entity);

                dbSet.Add(entity);
                context.SaveChanges();
                return entity;

            }
            catch (Exception dbUpdateEx)
            {
                if (dbUpdateEx.InnerException.IsNotNull() && dbUpdateEx.InnerException.InnerException.IsNotNull())
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                        //throw new DBConcurrencyException();

                                throw sqlException;

                            default:
                                // A custom exception of yours for other DB issues
                                //throw new DatabaseAccessException(
                                //  dbUpdateEx.Message, dbUpdateEx.InnerException);
                                throw dbUpdateEx;

                        }
                    }

                    throw dbUpdateEx.InnerException.InnerException;
                }

                throw dbUpdateEx;
            }
        }

        public virtual void Add(TEntity entity)
        {
            try
            {
                SetAuditCoulmnValues(entity);

                dbSet.Add(entity);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task<TEntity> InsertAsync(TEntity entity)
        {
            try
            {
                SetAuditCoulmnValues(entity);

                dbSet.Add(entity);
                await context.SaveChangesAsync().ConfigureAwait(busConstant.Misc.FALSE);
                return entity;
            }
            catch (Exception dbUpdateEx)
            {
                if (dbUpdateEx.InnerException.IsNotNull() && dbUpdateEx.InnerException.InnerException.IsNotNull())
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                        //throw new DBConcurrencyException();

                                throw sqlException;

                            default:
                                // A custom exception of yours for other DB issues
                                //throw new DatabaseAccessException(
                                //  dbUpdateEx.Message, dbUpdateEx.InnerException);
                                throw dbUpdateEx;

                        }
                    }

                    throw dbUpdateEx.InnerException.InnerException;
                }

                throw dbUpdateEx;
            }
        }

        public virtual void DeleteWhere(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                TEntity entityToDelete = query.FirstOrDefault();

                if (entityToDelete.IsNotNull())
                {
                    Delete(entityToDelete);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task DeleteWhereAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            try
            {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                TEntity entityToDelete = await query.FirstOrDefaultAsync();

                if (entityToDelete.IsNotNull())
                {
                    await DeleteAsync(entityToDelete);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual void Delete(object id)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async virtual Task DeleteAsync(object id)
        {
            try
            {

                TEntity entityToDelete = dbSet.Find(id);
                await DeleteAsync(entityToDelete);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public virtual TEntity Update(TEntity entityToUpdate)
        {
            try
            {
                SetAuditCoulmnValues(entityToUpdate);

                dbSet.Attach(entityToUpdate);
                context.Entry<TEntity>(entityToUpdate).State = EntityState.Modified;
                context.Entry<TEntity>(entityToUpdate).Property(p => p.CreatedBy).IsModified = busConstant.Misc.FALSE;
                context.Entry<TEntity>(entityToUpdate).Property(p => p.CreatedOn).IsModified = busConstant.Misc.FALSE;
                context.SaveChanges();
                //return GetByID(entityToUpdate.ID);
                return entityToUpdate;
            }
            catch (Exception dbUpdateEx)
            {
                if (dbUpdateEx.InnerException.IsNotNull() && dbUpdateEx.InnerException.InnerException.IsNotNull())
                {
                    if (dbUpdateEx.InnerException.InnerException is SqlException sqlException)
                    {
                        switch (sqlException.Number)
                        {
                            case 2627:  // Unique constraint error
                            case 547:   // Constraint check violation
                            case 2601:  // Duplicated key row error
                                        // Constraint violation exception
                                        // A custom exception of yours for concurrency issues
                                        //throw new DBConcurrencyException();

                                throw sqlException;

                            default:
                                // A custom exception of yours for other DB issues
                                //throw new DatabaseAccessException(
                                //  dbUpdateEx.Message, dbUpdateEx.InnerException);
                                throw dbUpdateEx;

                        }
                    }

                    throw dbUpdateEx.InnerException.InnerException;
                }

                throw dbUpdateEx;
            }
        }

        public async virtual Task<TEntity> UpdateAsync(TEntity entityToUpdate)
        {
            try
            {
                SetAuditCoulmnValues(entityToUpdate);

                dbSet.Attach(entityToUpdate);
                context.Entry<TEntity>(entityToUpdate).State = EntityState.Modified;
                context.Entry<TEntity>(entityToUpdate).Property(p => p.CreatedBy).IsModified = busConstant.Misc.FALSE;
                context.Entry<TEntity>(entityToUpdate).Property(p => p.CreatedOn).IsModified = busConstant.Misc.FALSE;
                await context.SaveChangesAsync().ConfigureAwait(busConstant.Misc.FALSE);
                //return await GetByIDAsync(entityToUpdate.ID);
                return entityToUpdate;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        #endregion

        #region [Private Methods]


        private void SetAuditCoulmnValues(TEntity entity)
        {
            string _activityBy = busConstant.Misc.SYSTEM;
            DateTime _activityDateTime = System.DateTime.Now;
            HttpContext httpContext = HttpContext.Current;

            try
            {
                if (httpContext.ApplicationInstance.Session.Count > busConstant.Numbers.Integer.ZERO && httpContext.ApplicationInstance.Session.Keys.Count > busConstant.Numbers.Integer.ONE)
                {
                    if (httpContext.ApplicationInstance.Session[busConstant.Settings.Session.Keys.ACTIVITY_BY].IsNotNull())
                    {
                        _activityBy = Convert.ToString(httpContext.ApplicationInstance.Session[busConstant.Settings.Session.Keys.ACTIVITY_BY]).ToString();
                    }
                    if (httpContext.ApplicationInstance.Session[busConstant.Settings.Session.Keys.ACTIVITY_DATETIME].IsNotNull())
                    {
                        _activityDateTime = Convert.ToDateTime(httpContext.ApplicationInstance.Session[busConstant.Settings.Session.Keys.ACTIVITY_DATETIME]);
                    }
                }

                object _object = entity;

                if (_object.IsNotNull())
                {
                    EntityModel.BaseEntity baseEntity = _object as EntityModel.BaseEntity;

                    PropertyInfo[] properties = _object.GetType().GetProperties();

                    if (baseEntity.IsNotNull() && baseEntity.CreatedBy.IsNullOrEmpty())
                    {
                        properties.ForEach<PropertyInfo>(propInfo =>
                        {
                            switch (propInfo.Name)
                            {
                                case busConstant.SwitchCase.BaseViewModel.CREATED_BY:
                                    propInfo.SetValue(_object, _activityBy);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.CREATED_ON:
                                    propInfo.SetValue(_object, _activityDateTime);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_BY:
                                    propInfo.SetValue(_object, _activityBy);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_ON:
                                    propInfo.SetValue(_object, _activityDateTime);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.IS_DELETED:
                                    propInfo.SetValue(_object, busConstant.Misc.FALSE);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.IS_ACTIVE:
                                    propInfo.SetValue(_object, busConstant.Misc.TRUE);
                                    break;

                                default:

                                    break;
                            }
                        });
                    }
                    else
                    {
                        properties.ForEach<PropertyInfo>(propInfo =>
                        {
                            switch (propInfo.Name)
                            {
                                case busConstant.SwitchCase.BaseViewModel.UPDATED_BY:
                                    propInfo.SetValue(_object, _activityBy);
                                    break;

                                case busConstant.SwitchCase.BaseViewModel.UPDATED_ON:
                                    propInfo.SetValue(_object, _activityDateTime);
                                    break;

                                default:

                                    break;
                            }
                        });
                    }
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void DeleteSoft(TEntity entityToDelete)
        {
            try
            {
                entityToDelete.IsDeleted = busConstant.Misc.TRUE;
                SetAuditCoulmnValues(entityToDelete);                

                dbSet.Attach(entityToDelete);
                context.Entry<TEntity>(entityToDelete).State = EntityState.Modified;
                context.Entry<TEntity>(entityToDelete).Property(p => p.CreatedBy).IsModified = busConstant.Misc.FALSE;
                context.Entry<TEntity>(entityToDelete).Property(p => p.CreatedOn).IsModified = busConstant.Misc.FALSE;

                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        private void Delete(TEntity entityToDelete)
        {
            try
            {
                SetAuditCoulmnValues(entityToDelete);

                if (context.Entry<TEntity>(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
                context.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private async Task DeleteAsync(TEntity entityToDelete)
        {
            try
            {
                SetAuditCoulmnValues(entityToDelete);

                if (context.Entry<TEntity>(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }
                dbSet.Remove(entityToDelete);
                await context.SaveChangesAsync().ConfigureAwait(busConstant.Misc.FALSE);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        #endregion

    }

}