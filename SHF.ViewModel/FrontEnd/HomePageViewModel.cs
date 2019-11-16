using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.ViewModel.FrontEnd
{
    public class HomePageBannerViewModel : BaseViewModel
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

    public class HomePageSection1ViewModel : BaseViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.String ShortDescription { get; set; }
        public System.String LongtDescription { get; set; }
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

    public class HomePageSection2ViewModel : BaseViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.String Heading1 { get; set; }
        public System.String Heading2 { get; set; }
        public System.String Heading3 { get; set; }
        public System.String Description1 { get; set; }
        public System.String Description2 { get; set; }
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

    public class HomePageSection3ViewModel : BaseViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.String Heading1 { get; set; }
        public System.String Heading2 { get; set; }
        public System.String Heading3 { get; set; }
        public System.String Heading4 { get; set; }
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

        public List<HomePageSection3FeaturesViewModel> HomePageSection3FeaturesViewModel { get; set; }
    }

    public class HomePageSection3FeaturesViewModel : BaseViewModel
    {
        public System.Int64 HomePageSection3_Id { get; set; }
        public System.String ShortDescription { get; set; }
        public System.String LongDescription { get; set; }
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

    public class HomePageSection4ViewModel : BaseViewModel
    {
        public System.String BannerImagePath { get; set; }
        public System.String Heading1 { get; set; }
        public System.String Heading2 { get; set; }
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
        public List<HomePageSection5ViewModel> HomePageSection5ViewModel { get; set; }
    }

    public class HomePageSection4TestimonailsViewModel : BaseViewModel
    {
        public System.String Description { get; set; }
        public System.String Name { get; set; }
        public System.String Designation { get; set; }
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

    public class HomePageSection5ViewModel : BaseViewModel
    {
        public System.String ImageFilePath { get; set; }
        public System.String ShortDescription { get; set; }
        public System.String LongDescription { get; set; }
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
}

