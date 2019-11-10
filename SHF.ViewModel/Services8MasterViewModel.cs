﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHF.ViewModel
{
   public class Services8MasterIndexViewModel : BaseViewModel
    {
       
        public System.Int64? Service_Id { get; set; }
      
        public System.Int64? Cat_Id { get; set; }
       
        public System.Int64? SubCat_Id { get; set; }
       
        public System.Int64? SubSubCat_Id { get; set; }
       
        public System.String SubSubCategoryName { get; set; }
      
        public System.String BannerImagePath { get; set; }
       
        public System.String BannerOnHeading { get; set; }
     
        public System.String BannerHeadingDescription { get; set; }
        public System.String Section1Heading { get; set; }
        public System.String Section1Description { get; set; }
        public System.String Section2BannerPath { get; set; }
        public System.String Section2BannerHeadingDescription { get; set; }
        public System.String Section4Heading { get; set; }
        public System.String Section5Heading { get; set; }
        public System.String Section5Description { get; set; }
        public System.String Section5TextboxMaskedText { get; set; }
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

    public sealed class Services8MasterCreateOrEditViewModel : BaseViewModel
    {
        public System.Int64? Service_Id { get; set; }

        public System.Int64? Cat_Id { get; set; }

        public System.Int64? SubCat_Id { get; set; }

        public System.Int64? SubSubCat_Id { get; set; }

        public System.String SubSubCategoryName { get; set; }

        public System.String BannerImagePath { get; set; }

        public System.String BannerOnHeading { get; set; }

        public System.String BannerHeadingDescription { get; set; }
        public System.String Section1Heading { get; set; }
        public System.String Section1Description { get; set; }
        public System.String Section2BannerPath { get; set; }
        public System.String Section2BannerHeadingDescription { get; set; }
        public System.String Section4Heading { get; set; }
        public System.String Section5Heading { get; set; }
        public System.String Section5Description { get; set; }
        public System.String Section5TextboxMaskedText { get; set; }
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

    public class Services8MasterDropdownListViewModel
    {
        public System.String SubSubCategoryName { get; set; }
        public System.Int64 ID { get; set; }

    }
}
