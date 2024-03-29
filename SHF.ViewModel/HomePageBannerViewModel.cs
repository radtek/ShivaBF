﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace SHF.ViewModel
{
   public class HomePageBannerIndexViewModel : BaseViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.String BannerOnHeading1 { get; set; }
        public System.String BannerOnHeading2 { get; set; }
        public System.String BannerHeadingDescription { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
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

    public sealed class HomePageBannerCreateOrEditViewModel : BaseViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.String BannerOnHeading1 { get; set; }
        public System.String BannerOnHeading2 { get; set; }
        public System.String BannerHeadingDescription { get; set; }
        public System.String AncharTagTitle { get; set; }
        public System.String AncharTagUrl { get; set; }
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

    public class HomePageBannerDropdownListViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.Int64 ID { get; set; }

    }
}
