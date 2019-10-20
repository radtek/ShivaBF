using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public sealed class Services1Section8FAQMappingIndexViewModel : BaseViewModel
    {
        
        public System.Int64? Service_Id { get; set; }
        public System.Int64 SubSubCat_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64 FAQMaster_Id { get; set; }
        public System.String Title { get; set; }
        public System.String Description { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }


        public string Metadata { get; set; }


        public string Keyword { get; set; }


        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public sealed class Services1Section8FAQMappingCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64 SubSubCat_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64 FAQMaster_Id { get; set; }
        public System.String Title { get; set; }
        public System.String Description { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }


        public string Metadata { get; set; }


        public string Keyword { get; set; }


        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class Services1Section8FAQMappingViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.Int64 SubSubCat_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64 FAQMaster_Id { get; set; }
        public System.String Title { get; set; }
        public System.String Description { get; set; }

        public System.Int32 DisplayIndex { get; set; }

        public System.Boolean? DisplayOnHome { get; set; }

        public System.Boolean? IsActive { get; set; }

        public System.Int32 TotalViews { get; set; }
        public string Url { get; set; }


        public string Metadata { get; set; }


        public string Keyword { get; set; }


        public string MetaDescription { get; set; }
        public System.String TenantName { get; set; }
        public System.Int64 Tenant_ID { get; set; }
    }
    public class Services1Section8FAQMappingDropdownListViewModel
    {
        public System.String Description { get; set; }
        public System.Int64 ID { get; set; }

    }
}
