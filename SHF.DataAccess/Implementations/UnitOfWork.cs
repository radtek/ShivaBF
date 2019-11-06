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
        private GenericRepository<EntityModel.Services4Master> _Services4MasterRepository;
        private GenericRepository<EntityModel.Services4Section2FAQMapping> _Services4Section2FAQMappingRepository;
        private GenericRepository<EntityModel.Services4Section2Master> _Services4Section2MasterRepository;
        private GenericRepository<EntityModel.Services4Section2MasterChild> _Services4Section2MasterChildRepository;
        private GenericRepository<EntityModel.Services4Section3> _Services4Section3Repository;
        private GenericRepository<EntityModel.Services4Section3DownloadMaster> _Services4Section3DownloadMasterRepository;
        private GenericRepository<EntityModel.Services4Section3Master> _Services4Section3MasterRepository;
        private GenericRepository<EntityModel.Services4Section3MasterChild> _Services4Section3MasterChildRepository;
        private GenericRepository<EntityModel.Services4Section567FieldMaster> _Services4Section567FieldMasterRepository;
        private GenericRepository<EntityModel.Services4Section567FieldValues> _Services4Section567FieldValuesRepository;
        private GenericRepository<EntityModel.Services5Master> _Services5MasterRepository;
        private GenericRepository<EntityModel.Services5Section2Master> _Services5Section2MasterRepository;
        private GenericRepository<EntityModel.Services5Section2MasterFeaturesDetails> _Services5Section2MasterFeaturesDetailsRepository;
        private GenericRepository<EntityModel.Services6Master> _Services6MasterRepository;
        private GenericRepository<EntityModel.Services6Section2Master> _Services6Section2MasterRepository;
        private GenericRepository<EntityModel.Services6Section2MasterFeaturesDetails> _Services6Section2MasterFeaturesDetailsRepository;
        private GenericRepository<EntityModel.Services7Master> _Services7MasterRepository;
        private GenericRepository<EntityModel.Services7HeadingButtons> _Services7HeadingButtonsRepository;
        private GenericRepository<EntityModel.Services7Section4> _Services7Section4Repository;
        private GenericRepository<EntityModel.Services7Section6PriceMaster> _Services7Section6PriceMasterRepository;
        private GenericRepository<EntityModel.Services8Master> _Services8MasterRepository;
        private GenericRepository<EntityModel.Services8HeadingButtons> _Services8HeadingButtonsRepository;
        private GenericRepository<EntityModel.Services8Section6Master> _Services8Section6MasterRepository;
        private GenericRepository<EntityModel.BlogMaster> _BlogMasterRepository;
        private GenericRepository<EntityModel.BlogBannerNavigationsDetails> _BannerNavigationsDetailsRepository;
        private GenericRepository<EntityModel.BlogCommentsDetails> _BlogCommentsDetailsRepository;
        private GenericRepository<EntityModel.RelatedBlogsMapping> _RelatedBlogsMappingRepository;
        private GenericRepository<EntityModel.CommentsReply> _CommentsReplyRepository;
        private GenericRepository<EntityModel.IPInfo> _IPInfoRepository;
        private GenericRepository<EntityModel.HomePageBanner> _HomePageBannerRepository;
        private GenericRepository<EntityModel.HomePageSection1> _HomePageSection1Repository;
        private GenericRepository<EntityModel.HomePageSection2> _HomePageSection2Repository;
        private GenericRepository<EntityModel.HomePageSection3> _HomePageSection3Repository;
        private GenericRepository<EntityModel.HomePageSection3Features> _HomePageSection3FeaturesRepository;
        private GenericRepository<EntityModel.HomePageSection4> _HomePageSection4Repository;
        private GenericRepository<EntityModel.HomePageSection4Testimonails> _HomePageSection4TestimonailsRepository;
        private GenericRepository<EntityModel.HomePageSection5> _HomePageSection5Repository;
        private GenericRepository<EntityModel.BannerMaster> _BannerMasterRepository;


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
        public GenericRepository<EntityModel.Services4Master> Services4MasterRepository
        {
            get
            {
                if (this._Services4MasterRepository == null)
                {
                    this._Services4MasterRepository = new GenericRepository<EntityModel.Services4Master>(context);
                }
                return _Services4MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section2FAQMapping> Services4Section2FAQMappingRepository
        {
            get
            {
                if (this._Services4Section2FAQMappingRepository == null)
                {
                    this._Services4Section2FAQMappingRepository = new GenericRepository<EntityModel.Services4Section2FAQMapping>(context);
                }
                return _Services4Section2FAQMappingRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section2Master> Services4Section2MasterRepository
        {
            get
            {
                if (this._Services4Section2MasterRepository == null)
                {
                    this._Services4Section2MasterRepository = new GenericRepository<EntityModel.Services4Section2Master>(context);
                }
                return _Services4Section2MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section2MasterChild> Services4Section2MasterChildRepository
        {
            get
            {
                if (this._Services4Section2MasterChildRepository == null)
                {
                    this._Services4Section2MasterChildRepository = new GenericRepository<EntityModel.Services4Section2MasterChild>(context);
                }
                return _Services4Section2MasterChildRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section3> Services4Section3Repository
        {
            get
            {
                if (this._Services4Section3Repository == null)
                {
                    this._Services4Section3Repository = new GenericRepository<EntityModel.Services4Section3>(context);
                }
                return _Services4Section3Repository;
            }
        }
        public GenericRepository<EntityModel.Services4Section3DownloadMaster> Services4Section3DownloadMasterRepository
        {
            get
            {
                if (this._Services4Section3DownloadMasterRepository == null)
                {
                    this._Services4Section3DownloadMasterRepository = new GenericRepository<EntityModel.Services4Section3DownloadMaster>(context);
                }
                return _Services4Section3DownloadMasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section3Master> Services4Section3MasterRepository
        {
            get
            {
                if (this._Services4Section3MasterRepository == null)
                {
                    this._Services4Section3MasterRepository = new GenericRepository<EntityModel.Services4Section3Master>(context);
                }
                return _Services4Section3MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section3MasterChild> Services4Section3MasterChildRepository
        {
            get
            {
                if (this._Services4Section3MasterChildRepository == null)
                {
                    this._Services4Section3MasterChildRepository = new GenericRepository<EntityModel.Services4Section3MasterChild>(context);
                }
                return _Services4Section3MasterChildRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section567FieldMaster> Services4Section567FieldMasterRepository
        {
            get
            {
                if (this._Services4Section567FieldMasterRepository == null)
                {
                    this._Services4Section567FieldMasterRepository = new GenericRepository<EntityModel.Services4Section567FieldMaster>(context);
                }
                return _Services4Section567FieldMasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services4Section567FieldValues> Services4Section567FieldValuesRepository
        {
            get
            {
                if (this._Services4Section567FieldValuesRepository == null)
                {
                    this._Services4Section567FieldValuesRepository = new GenericRepository<EntityModel.Services4Section567FieldValues>(context);
                }
                return _Services4Section567FieldValuesRepository;
            }
        }
        public GenericRepository<EntityModel.Services5Master> Services5MasterRepository
        {
            get
            {
                if (this._Services5MasterRepository == null)
                {
                    this._Services5MasterRepository = new GenericRepository<EntityModel.Services5Master>(context);
                }
                return _Services5MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services5Section2Master> Services5Section2MasterRepository
        {
            get
            {
                if (this._Services5Section2MasterRepository == null)
                {
                    this._Services5Section2MasterRepository = new GenericRepository<EntityModel.Services5Section2Master>(context);
                }
                return _Services5Section2MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services5Section2MasterFeaturesDetails> Services5Section2MasterFeaturesDetailsRepository
        {
            get
            {
                if (this._Services5Section2MasterFeaturesDetailsRepository == null)
                {
                    this._Services5Section2MasterFeaturesDetailsRepository = new GenericRepository<EntityModel.Services5Section2MasterFeaturesDetails>(context);
                }
                return _Services5Section2MasterFeaturesDetailsRepository;
            }
        }
        public GenericRepository<EntityModel.Services6Master> Services6MasterRepository
        {
            get
            {
                if (this._Services6MasterRepository == null)
                {
                    this._Services6MasterRepository = new GenericRepository<EntityModel.Services6Master>(context);
                }
                return _Services6MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services6Section2Master> Services6Section2MasterRepository
        {
            get
            {
                if (this._Services6Section2MasterRepository == null)
                {
                    this._Services6Section2MasterRepository = new GenericRepository<EntityModel.Services6Section2Master>(context);
                }
                return _Services6Section2MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services6Section2MasterFeaturesDetails> Services6Section2MasterFeaturesDetailsRepository
        {
            get
            {
                if (this._Services6Section2MasterFeaturesDetailsRepository == null)
                {
                    this._Services6Section2MasterFeaturesDetailsRepository = new GenericRepository<EntityModel.Services6Section2MasterFeaturesDetails>(context);
                }
                return _Services6Section2MasterFeaturesDetailsRepository;
            }
        }
        public GenericRepository<EntityModel.Services7Master> Services7MasterRepository
        {
            get
            {
                if (this._Services7MasterRepository == null)
                {
                    this._Services7MasterRepository = new GenericRepository<EntityModel.Services7Master>(context);
                }
                return _Services7MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services7HeadingButtons> Services7HeadingButtonsRepository
        {
            get
            {
                if (this._Services7HeadingButtonsRepository == null)
                {
                    this._Services7HeadingButtonsRepository = new GenericRepository<EntityModel.Services7HeadingButtons>(context);
                }
                return _Services7HeadingButtonsRepository;
            }
        }
        public GenericRepository<EntityModel.Services7Section4> Services7Section4Repository
        {
            get
            {
                if (this._Services7Section4Repository == null)
                {
                    this._Services7Section4Repository = new GenericRepository<EntityModel.Services7Section4>(context);
                }
                return _Services7Section4Repository;
            }
        }
        public GenericRepository<EntityModel.Services7Section6PriceMaster> Services7Section6PriceMasterRepository
        {
            get
            {
                if (this._Services7Section6PriceMasterRepository == null)
                {
                    this._Services7Section6PriceMasterRepository = new GenericRepository<EntityModel.Services7Section6PriceMaster>(context);
                }
                return _Services7Section6PriceMasterRepository;
            }
        }

        public GenericRepository<EntityModel.Services8Master> Services8MasterRepository
        {
            get
            {
                if (this._Services8MasterRepository == null)
                {
                    this._Services8MasterRepository = new GenericRepository<EntityModel.Services8Master>(context);
                }
                return _Services8MasterRepository;
            }
        }
        public GenericRepository<EntityModel.Services8HeadingButtons> Services8HeadingButtonsRepository
        {
            get
            {
                if (this._Services8HeadingButtonsRepository == null)
                {
                    this._Services8HeadingButtonsRepository = new GenericRepository<EntityModel.Services8HeadingButtons>(context);
                }
                return _Services8HeadingButtonsRepository;
            }
        }
        
        public GenericRepository<EntityModel.Services8Section6Master> Services8Section6MasterRepository
        {
            get
            {
                if (this._Services8Section6MasterRepository == null)
                {
                    this._Services8Section6MasterRepository = new GenericRepository<EntityModel.Services8Section6Master>(context);
                }
                return _Services8Section6MasterRepository;
            }
        }
        public GenericRepository<EntityModel.BlogMaster> BlogMasterRepository
        {
            get
            {
                if (this._BlogMasterRepository == null)
                {
                    this._BlogMasterRepository = new GenericRepository<EntityModel.BlogMaster>(context);
                }
                return _BlogMasterRepository;
            }
        }
        public GenericRepository<EntityModel.BlogBannerNavigationsDetails> BannerNavigationsDetailsRepository
        {
            get
            {
                if (this._BannerNavigationsDetailsRepository == null)
                {
                    this._BannerNavigationsDetailsRepository = new GenericRepository<EntityModel.BlogBannerNavigationsDetails>(context);
                }
                return _BannerNavigationsDetailsRepository;
            }
        }
        public GenericRepository<EntityModel.BlogCommentsDetails> BlogCommentsDetailsRepository
        {
            get
            {
                if (this._BlogCommentsDetailsRepository == null)
                {
                    this._BlogCommentsDetailsRepository = new GenericRepository<EntityModel.BlogCommentsDetails>(context);
                }
                return _BlogCommentsDetailsRepository;
            }
        }
        public GenericRepository<EntityModel.RelatedBlogsMapping> RelatedBlogsMappingRepository
        {
            get
            {
                if (this._RelatedBlogsMappingRepository == null)
                {
                    this._RelatedBlogsMappingRepository = new GenericRepository<EntityModel.RelatedBlogsMapping>(context);
                }
                return _RelatedBlogsMappingRepository;
            }
        }
        public GenericRepository<EntityModel.CommentsReply> CommentsReplyRepository
        {
            get
            {
                if (this._CommentsReplyRepository == null)
                {
                    this._CommentsReplyRepository = new GenericRepository<EntityModel.CommentsReply>(context);
                }
                return _CommentsReplyRepository;
            }
        }
        public GenericRepository<EntityModel.IPInfo> IPInfoRepository
        {
            get
            {
                if (this._IPInfoRepository == null)
                {
                    this._IPInfoRepository = new GenericRepository<EntityModel.IPInfo>(context);
                }
                return _IPInfoRepository;
            }
        }
        public GenericRepository<EntityModel.HomePageBanner> HomePageBannerRepository
        {
            get
            {
                if (this._HomePageBannerRepository == null)
                {
                    this._HomePageBannerRepository = new GenericRepository<EntityModel.HomePageBanner>(context);
                }
                return _HomePageBannerRepository;
            }
        }
        public GenericRepository<EntityModel.HomePageSection1> HomePageSection1Repository
        {
            get
            {
                if (this._HomePageSection1Repository == null)
                {
                    this._HomePageSection1Repository = new GenericRepository<EntityModel.HomePageSection1>(context);
                }
                return _HomePageSection1Repository;
            }
        }
        public GenericRepository<EntityModel.HomePageSection2> HomePageSection2Repository
        {
            get
            {
                if (this._HomePageSection2Repository == null)
                {
                    this._HomePageSection2Repository = new GenericRepository<EntityModel.HomePageSection2>(context);
                }
                return _HomePageSection2Repository;
            }
        }
        public GenericRepository<EntityModel.HomePageSection3> HomePageSection3Repository
        {
            get
            {
                if (this._HomePageSection3Repository == null)
                {
                    this._HomePageSection3Repository = new GenericRepository<EntityModel.HomePageSection3>(context);
                }
                return _HomePageSection3Repository;
            }
        }
        public GenericRepository<EntityModel.HomePageSection3Features> HomePageSection3FeaturesRepository
        {
            get
            {
                if (this._HomePageSection3FeaturesRepository == null)
                {
                    this._HomePageSection3FeaturesRepository = new GenericRepository<EntityModel.HomePageSection3Features>(context);
                }
                return _HomePageSection3FeaturesRepository;
            }
        }
        public GenericRepository<EntityModel.HomePageSection4> HomePageSection4Repository
        {
            get
            {
                if (this._HomePageSection4Repository == null)
                {
                    this._HomePageSection4Repository = new GenericRepository<EntityModel.HomePageSection4>(context);
                }
                return _HomePageSection4Repository;
            }
        }
        public GenericRepository<EntityModel.HomePageSection5> HomePageSection5Repository
        {
            get
            {
                if (this._HomePageSection5Repository == null)
                {
                    this._HomePageSection5Repository = new GenericRepository<EntityModel.HomePageSection5>(context);
                }
                return _HomePageSection5Repository;
            }
        }

        public GenericRepository<EntityModel.BannerMaster> BannerMasterRepository
        {
            get
            {
                if (this._BannerMasterRepository == null)
                {
                    this._BannerMasterRepository = new GenericRepository<EntityModel.BannerMaster>(context);
                }
                return _BannerMasterRepository;
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
