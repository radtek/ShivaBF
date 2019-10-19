﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
    public sealed class PriceFeaturesMappingIndexViewModel : BaseViewModel
    {
        
        public System.Int64? Service_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64? S1S6PM_Id { get; set; }
        public System.Int64? PriceFeaturesMaster_Id { get; set; }
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
    public sealed class PriceFeaturesMappingCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64? S1S6PM_Id { get; set; }
        public System.Int64? PriceFeaturesMaster_Id { get; set; }
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
    public class PriceFeaturesMappingViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }
        public System.String SubSubCategory_Name { get; set; }
        public System.Int64? S1S6PM_Id { get; set; }
        public System.Int64? PriceFeaturesMaster_Id { get; set; }
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
    public class PriceFeaturesMappingDropdownListViewModel
    {
        public System.String Description { get; set; }
        public System.Int64 ID { get; set; }

    }
}
