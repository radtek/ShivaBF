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

        private SHFDBContext context = new SHFDBContext();

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
        private GenericRepository<EntityModel.CategoriesMaster> _CategoriesMasterRepository;
        private GenericRepository<EntityModel.SubCategoriesMaster> _SubCategoriesMasterRepository;
        private GenericRepository<EntityModel.SubSubCategoriesMaster> _SubSubCategoriesMasterRepository;
        private GenericRepository<EntityModel.Services1Master> _Services1MasterRepository;
        private GenericRepository<EntityModel.Services1Section10BankMapping> _Services1Section10BankMappingRepository;
        private GenericRepository<EntityModel.Services1Section1Master> _Services1Section1MasterRepository;
        private GenericRepository<EntityModel.Services1Section4Master> _Services1Section4MasterRepository;
        private GenericRepository<EntityModel.Services1Section5Master> _Services1Section5MasterRepository;
        private GenericRepository<EntityModel.Services1Section6PriceMaster> _Services1Section6PriceMasterRepository;
        private GenericRepository<EntityModel.StateMaster> _StateMasterRepository;
        private GenericRepository<EntityModel.PriceFeaturesMapping> _PriceFeaturesMappingRepository;
        private GenericRepository<EntityModel.Services1Section8FAQMapping> _Services1Section8FAQMappingRepository;
        private GenericRepository<EntityModel.Services2Master> _Services2MasterRepository;
        private GenericRepository<EntityModel.Services2Section3DownloadMaster> _Services2Section3DownloadMasterRepository;
        private GenericRepository<EntityModel.Services2Section2FAQMapping> _Services2Section2FAQMappingRepository;
        private GenericRepository<EntityModel.Services2Section4Master> _Services2Section4MasterRepository;
        private GenericRepository<EntityModel.Services3Master> _Services3MasterRepository;
        private GenericRepository<EntityModel.Services3HeadingButtons> _Services3HeadingButtonsRepository;
        private GenericRepository<EntityModel.Services3Section4> _Services3Section4Repository;
        private GenericRepository<EntityModel.Services3Section6PriceMaster> _Services3Section6PriceMasterRepository;
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
        public GenericRepository<EntityModel.CategoriesMaster> CategoriesMasterRepository
        {
            get
            {
                if (this._CategoriesMasterRepository == null)
                {
                    this._CategoriesMasterRepository = new GenericRepository<EntityModel.CategoriesMaster>(context);
                }
                return _CategoriesMasterRepository;
            }
        }
        public GenericRepository<EntityModel.SubCategoriesMaster> SubCategoriesMasterRepository
        {
            get
            {
                if (this._SubCategoriesMasterRepository == null)
                {
                    this._SubCategoriesMasterRepository = new GenericRepository<EntityModel.SubCategoriesMaster>(context);
                }
                return _SubCategoriesMasterRepository;
            }
        }
        public GenericRepository<EntityModel.SubSubCategoriesMaster> SubSubCategoriesMasterRepository
        {
            get
            {
                if (this._SubSubCategoriesMasterRepository == null)
                {
                    this._SubSubCategoriesMasterRepository = new GenericRepository<EntityModel.SubSubCategoriesMaster>(context);
                }
                return _SubSubCategoriesMasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Master> Services1MasterRepository
        {
            get
            {
                if (this._Services1MasterRepository == null)
                {
                    this._Services1MasterRepository = new GenericRepository<EntityModel.Services1Master>(context);
                }
                return _Services1MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Section10BankMapping> Services1Section10BankMappingRepository
        {
            get
            {
                if (this._Services1Section10BankMappingRepository == null)
                {
                    this._Services1Section10BankMappingRepository = new GenericRepository<EntityModel.Services1Section10BankMapping>(context);
                }
                return _Services1Section10BankMappingRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Section1Master> Services1Section1MasterRepository
        {
            get
            {
                if (this._Services1Section1MasterRepository == null)
                {
                    this._Services1Section1MasterRepository = new GenericRepository<EntityModel.Services1Section1Master>(context);
                }
                return _Services1Section1MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Section4Master> Services1Section4MasterRepository
        {
            get
            {
                if (this._Services1Section4MasterRepository == null)
                {
                    this._Services1Section4MasterRepository = new GenericRepository<EntityModel.Services1Section4Master>(context);
                }
                return _Services1Section4MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Section5Master> Services1Section5MasterRepository
        {
            get
            {
                if (this._Services1Section5MasterRepository == null)
                {
                    this._Services1Section5MasterRepository = new GenericRepository<EntityModel.Services1Section5Master>(context);
                }
                return _Services1Section5MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Section6PriceMaster> Services1Section6PriceMasterRepository
        {
            get
            {
                if (this._Services1Section6PriceMasterRepository == null)
                {
                    this._Services1Section6PriceMasterRepository = new GenericRepository<EntityModel.Services1Section6PriceMaster>(context);
                }
                return _Services1Section6PriceMasterRepository;
            }
        }
        public GenericRepository<EntityModel.StateMaster> StateMasterRepository
        {
            get
            {
                if (this._StateMasterRepository == null)
                {
                    this._StateMasterRepository = new GenericRepository<EntityModel.StateMaster>(context);
                }
                return _StateMasterRepository;
            }
        }
        public GenericRepository<EntityModel.PriceFeaturesMapping> PriceFeaturesMappingRepository
        {
            get
            {
                if (this._PriceFeaturesMappingRepository == null)
                {
                    this._PriceFeaturesMappingRepository = new GenericRepository<EntityModel.PriceFeaturesMapping>(context);
                }
                return _PriceFeaturesMappingRepository;
            }
        }
        public GenericRepository<EntityModel.Services1Section8FAQMapping> Services1Section8FAQMappingRepository
        {
            get
            {
                if (this._Services1Section8FAQMappingRepository == null)
                {
                    this._Services1Section8FAQMappingRepository = new GenericRepository<EntityModel.Services1Section8FAQMapping>(context);
                }
                return _Services1Section8FAQMappingRepository;
            }
        }
        public GenericRepository<EntityModel.Services2Master> Services2MasterRepository
        {
            get
            {
                if (this._Services2MasterRepository == null)
                {
                    this._Services2MasterRepository = new GenericRepository<EntityModel.Services2Master>(context);
                }
                return _Services2MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services2Section2FAQMapping> Services2Section2FAQMappingRepository
        {
            get
            {
                if (this._Services2Section2FAQMappingRepository == null)
                {
                    this._Services2Section2FAQMappingRepository = new GenericRepository<EntityModel.Services2Section2FAQMapping>(context);
                }
                return _Services2Section2FAQMappingRepository;
            }
        }
        public GenericRepository<EntityModel.Services2Section3DownloadMaster> Services2Section3DownloadMasterRepository
        {
            get
            {
                if (this._Services2Section3DownloadMasterRepository == null)
                {
                    this._Services2Section3DownloadMasterRepository = new GenericRepository<EntityModel.Services2Section3DownloadMaster>(context);
                }
                return _Services2Section3DownloadMasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services2Section4Master> Services2Section4MasterRepository
        {
            get
            {
                if (this._Services2Section4MasterRepository == null)
                {
                    this._Services2Section4MasterRepository = new GenericRepository<EntityModel.Services2Section4Master>(context);
                }
                return _Services2Section4MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services3Master> Services3MasterRepository
        {
            get
            {
                if (this._Services3MasterRepository == null)
                {
                    this._Services3MasterRepository = new GenericRepository<EntityModel.Services3Master>(context);
                }
                return _Services3MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services3HeadingButtons> Services3HeadingButtonsRepository
        {
            get
            {
                if (this._Services3HeadingButtonsRepository == null)
                {
                    this._Services3HeadingButtonsRepository = new GenericRepository<EntityModel.Services3HeadingButtons>(context);
                }
                return _Services3HeadingButtonsRepository;
            }
        }
        public GenericRepository<EntityModel.Services3Section4> Services3Section4Repository
        {
            get
            {
                if (this._Services3Section4Repository == null)
                {
                    this._Services3Section4Repository = new GenericRepository<EntityModel.Services3Section4>(context);
                }
                return _Services3Section4Repository;
            }
        }
        public GenericRepository<EntityModel.Services3Section6PriceMaster> Services3Section6PriceMasterRepository
        {
            get
            {
                if (this._Services3Section6PriceMasterRepository == null)
                {
                    this._Services3Section6PriceMasterRepository = new GenericRepository<EntityModel.Services3Section6PriceMaster>(context);
                }
                return _Services3Section6PriceMasterRepository;
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
