using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SHF.EntityModel
{
    [Table("Tbl_IPInfo", Schema = "dbo")]
    public class IPInfo : BaseEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual long ID { get; set; }
        public string ip { get; set; }
        public bool is_eu { get; set; }
        public string city { get; set; }
        public string region { get; set; }
        public string region_code { get; set; }
        public string country_name { get; set; }
        public string country_code { get; set; }
        public string continent_name { get; set; }
        public string continent_code { get; set; }
        public double latitude { get; set; }
        public double longitude { get; set; }
        public string postal { get; set; }
        public string calling_code { get; set; }
        public string flag { get; set; }
        public string emoji_flag { get; set; }
        public string emoji_unicode { get; set; }
        [ForeignKey("Asn_ID")]
        public virtual Asn asn { get; set; }
        public System.Int64? Asn_ID { get; set; }
        [ForeignKey("Carrier_ID")]
        public virtual Carrier carrier { get; set; }
        public System.Int64? Carrier_ID { get; set; }
        [ForeignKey("Language_ID")]
        public virtual Language language { get; set; }
        public System.Int64? Language_ID { get; set; }
        [ForeignKey("Currency_ID")]
        public virtual Currency currency { get; set; }
        public System.Int64? Currency_ID { get; set; }
        [ForeignKey("TimeZone_ID")]
        public virtual TimeZone time_zone { get; set; }
        public System.Int64? TimeZone_ID { get; set; }
        [ForeignKey("Threat_ID")]
        public virtual Threat threat { get; set; }
        public System.Int64? Threat_ID { get; set; }
        public string count { get; set; }
        [ForeignKey("Tenant_ID")]
        public virtual Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

    }


}