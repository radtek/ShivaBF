using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Collections.Generic;




namespace SHF.DataAccess.Implementations
{
    public class UnitOfWork : IDisposable
    {
        #region [Fields]

        private bool disposed = false;
        private TransactionScope transaction;

        private InventoryDBContext context = new InventoryDBContext();

        private GenericRepository<EntityModel.Code> _CodeRepository;
        private GenericRepository<EntityModel.CodeValue> _CodeValueRepository;
        private GenericRepository<EntityModel.Tenant> _TenantRepository;
        //private GenericRepository<EntityModel.Customer> _CustomerRepository;
        private GenericRepository<EntityModel.ExceptionLog> exceptionLogRepository;      
        //private GenericRepository<EntityModel.Branch> branchRepository;
        private GenericRepository<EntityModel.AspNetRole> _AspNetRoleRepository;
        private GenericRepository<EntityModel.AspNetUser> _AspNetUserRepository;
        private GenericRepository<EntityModel.AspNetUserRole> _AspNetUserRoleRepository;
        private GenericRepository<EntityModel.SubMenu> _SubMenuRepository;
        private GenericRepository<EntityModel.AspNetRoleSubMenu> _AspNetRoleSubMenuRepository;
        private GenericRepository<EntityModel.Message> _MessageRepository;
        private GenericRepository<EntityModel.BankMaster> _BankMasterRepository;
        private GenericRepository<EntityModel.PriceFeaturesMaster> _PriceFeaturesMasterRepository;
        private GenericRepository<EntityModel.FAQMaster> _FAQMasterRepository;

        #endregion



        #region [Proerties]


        public GenericRepository<EntityModel.Code> CodeRepository
        {
            get
            {
                if (this._CodeRepository == null)
                {
                    this._CodeRepository = new GenericRepository<EntityModel.Code>(context);
                }
                return _CodeRepository;
            }
        }

        public GenericRepository<EntityModel.CodeValue> CodeValueRepository
        {
            get
            {
                if (this._CodeValueRepository == null)
                {
                    this._CodeValueRepository = new GenericRepository<EntityModel.CodeValue>(context);
                }
                return _CodeValueRepository;
            }
        }

        public GenericRepository<EntityModel.Tenant> TenantRepository
        {
            get
            {
                if (this._TenantRepository == null)
                {
                    this._TenantRepository = new GenericRepository<EntityModel.Tenant>(context);
                }
                return _TenantRepository;
            }
        }
        public GenericRepository<EntityModel.ExceptionLog> ExceptionLogRepository
        {
            get
            {
                if (this.exceptionLogRepository == null)
                {
                    this.exceptionLogRepository = new GenericRepository<EntityModel.ExceptionLog>(context);
                }
                return exceptionLogRepository;
            }
        }




       

        public GenericRepository<EntityModel.SubMenu> SubMenuRepository
        {
            get
            {
                if (this._SubMenuRepository == null)
                {
                    this._SubMenuRepository = new GenericRepository<EntityModel.SubMenu>(context);
                }
                return _SubMenuRepository;
            }
        }

        public GenericRepository<EntityModel.AspNetRoleSubMenu> AspNetRoleSubMenuRepository
        {
            get
            {
                if (this._AspNetRoleSubMenuRepository == null)
                {
                    this._AspNetRoleSubMenuRepository = new GenericRepository<EntityModel.AspNetRoleSubMenu>(context);
                }
                return _AspNetRoleSubMenuRepository;
            }
        }

        public GenericRepository<EntityModel.AspNetRole> AspNetRoleRepository
        {
            get
            {
                if (this._AspNetRoleRepository == null)
                {
                    this._AspNetRoleRepository = new GenericRepository<EntityModel.AspNetRole>(context);
                }
                return _AspNetRoleRepository;
            }
        }

        public GenericRepository<EntityModel.AspNetUser> AspNetUserRepository
        {
            get
            {
                if (this._AspNetUserRepository == null)
                {
                    this._AspNetUserRepository = new GenericRepository<EntityModel.AspNetUser>(context);
                }
                return _AspNetUserRepository;
            }
        }

        public GenericRepository<EntityModel.AspNetUserRole> AspNetUserRoleRepository
        {
            get
            {
                if (this._AspNetUserRoleRepository == null)
                {
                    this._AspNetUserRoleRepository = new GenericRepository<EntityModel.AspNetUserRole>(context);
                }
                return _AspNetUserRoleRepository;
            }
        }

        public GenericRepository<EntityModel.Message> MessageRepository
        {
            get
            {
                if(this._MessageRepository == null)
                {
                    this._MessageRepository = new GenericRepository<EntityModel.Message>(context);
                }
                return _MessageRepository;
            }
        }

        public GenericRepository<EntityModel.BankMaster> BankMasterRepository
        {
            get
            {
                if (this._BankMasterRepository == null)
                {
                    this._BankMasterRepository = new GenericRepository<EntityModel.BankMaster>(context);
                }
                return _BankMasterRepository;
            }
        }
        public GenericRepository<EntityModel.PriceFeaturesMaster> PriceFeaturesMasterRepository
        {
            get
            {
                if (this._PriceFeaturesMasterRepository == null)
                {
                    this._PriceFeaturesMasterRepository = new GenericRepository<EntityModel.PriceFeaturesMaster>(context);
                }
                return _PriceFeaturesMasterRepository;
            }
        }
        public GenericRepository<EntityModel.FAQMaster> FAQMasterRepository
        {
            get
            {
                if (this._FAQMasterRepository == null)
                {
                    this._FAQMasterRepository = new GenericRepository<EntityModel.FAQMaster>(context);
                }
                return _FAQMasterRepository;
            }
        }


        #endregion

        #region [Constructors]

        public UnitOfWork()
        {

        }

        #endregion

        #region [Methods]

        public void Save()
        {
            context.SaveChanges();
        }

        public async void SaveAsyc()
        {
            await context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region [Transaction]

        public void BegginTransacation()
        {
            StartTransaction();
        }

        public void BegginTransacation(bool TransactionScopeAsyncFlowOptions)
        {
            StartTransaction(TransactionScopeAsyncFlowOptions);
        }

        public void CommitTransaction()
        {
            this.transaction.Complete();
        }

        public void RollBackTransaction()
        {
            this.transaction.Dispose();
        }

        private void StartTransaction(bool TransactionScopeAsyncFlowOptions = false)
        {
            if (TransactionScopeAsyncFlowOptions)
            {
                this.transaction = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled);
            }
            else
            {
                this.transaction = new TransactionScope();
            }
        }



        private void DisposeTransaction()
        {
            this.transaction.Dispose();
        }

        #endregion

        #endregion
    }
}
