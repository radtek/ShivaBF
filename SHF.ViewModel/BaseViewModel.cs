using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SHF.ViewModel
{

    public interface IBaseViewModel
    {

    }

    public abstract class BaseViewModel : IBaseViewModel
    {
        [Display(Name = "Id")]
        public virtual long? ID { get; set; }
        [Display(Name = "Url")]
        public string Url { get; set; }

        [Display(Name = "Metadata")]
        public string Metadata { get; set; }

        [Display(Name = "Keyword")]
        public string Keyword { get; set; }

        [Display(Name = "MetaDescription")]
        public string MetaDescription { get; set; }

        [Display(Name = "Created By")]
        public virtual string CreatedBy { get; set; }

        
        [Display(Name = "Created On")]        
        public virtual DateTime? CreatedOn { get; set; }

       
        [Display(Name = "Modified By")]
        public virtual string UpdatedBy { get; set; }

       
        [Display(Name = "Modified On")]        
        public virtual DateTime? UpdatedOn { get; set; }

        
        [Display(Name = "Is Deleted")]
        public virtual bool IsDeleted { get; set; }

        
        //[Display(Name = "Created On")]
        //public string CreatedOns {
        //    get => CreatedOn.GetValueOrDefault().ToString("dd/MM/yyyy hh:mm:ss tt");
        //    }

        //[Display(Name = "Modified On")]
        //public string ModifiedOns {
        //    get => UpdatedOn.GetValueOrDefault().ToString("dd/MM/yyyy hh:mm:ss tt");
        //    }
    }
}