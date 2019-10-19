using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   
    public sealed class PriceFeaturesMasterIndexViewModel : BaseViewModel
    {
        // public System.Int64 Id { get; set; }
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
    public sealed class PriceFeaturesMasterCreateOrEditViewModel : BaseViewModel
    {
        // public System.Int64 Id { get; set; }
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
    public class PriceFeaturesMasterViewModel : BaseViewModel
    {
        // public System.Int64 Id { get; set; }
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
    public class PriceFeaturesMasterDropdownListViewModel
    {
        public System.String Description { get; set; }
        public System.Int64 ID { get; set; }

    }
}
