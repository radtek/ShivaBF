using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using SHF.Helper;
using SHF.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SHF.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {

        //public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        //{
        //    // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
        //    var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
        //    // Add custom user claims here
        //    return userIdentity;
        //}

        //[ForeignKey("Branch_ID")]
        //public virtual EntityModel.Branch Branch { get; set; }
        //public System.Int64? Branch_ID { get; set; }

        [ForeignKey("Tenant_ID")]
        public virtual EntityModel.Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

        [Column("First_Name")]
        public System.String FirstName { get; set; }

        [Column("Last_Name")]
        public System.String LastName { get; set; }

        [Column("Profile_Image")]
        public System.String ProfileImage { get; set; }

        [Column("Created_By")]
        public System.String CreatedBy { get; set; }

        [Column("Created_On")]
        public System.DateTime? CreatedOn { get; set; }

        [Column("Modified_By")]
        public System.String UpdatedBy { get; set; }

        [Column("Modified_On")]
        public System.DateTime? UpdatedOn { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Is_Deleted")]
        public System.Boolean? IsDeleted { get; set; }

        [Column("Update_Seq")]
        public System.Int32? UpdateSeq { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, long> manager)
        {
            // Note the authenticationType must match the one defined in
            // CookieAuthenticationOptions.AuthenticationType 
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here 
            return userIdentity;
        }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, long, CustomUserLogin, CustomUserRole, CustomUserClaim>
    //{
    //    public ApplicationDbContext()
    //        : base(busConstant.Settings.DataBase.SqlServer.Connections.ConnectionString.Default)
    //    {
    //    }

    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}

    public class CustomUserRole : IdentityUserRole<long>
    {
        

        [ForeignKey("Tenant_ID")]
        public virtual EntityModel.Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

        [Column("Created_By")]
        public System.String CreatedBy { get; set; }

        [Column("Created_On")]
        public System.DateTime? CreatedOn { get; set; }

        [Column("Modified_By")]
        public System.String UpdatedBy { get; set; }

        [Column("Modified_On")]
        public System.DateTime? UpdatedOn { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Is_Deleted")]
        public System.Boolean? IsDeleted { get; set; }

        [Column("Update_Seq")]
        public System.Int32? UpdateSeq { get; set; }
    }
    public class CustomUserClaim : IdentityUserClaim<long>
    {
        [ForeignKey("Tenant_ID")]
        public virtual EntityModel.Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }

        [Column("Created_By")]
        public System.String CreatedBy { get; set; }

        [Column("Created_On")]
        public System.DateTime? CreatedOn { get; set; }

        [Column("Modified_By")]
        public System.String UpdatedBy { get; set; }

        [Column("Modified_On")]
        public System.DateTime? UpdatedOn { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Is_Deleted")]
        public System.Boolean? IsDeleted { get; set; }

        [Column("Update_Seq")]
        public System.Int32? UpdateSeq { get; set; }
    }
    public class CustomUserLogin : IdentityUserLogin<long>
    {
        [ForeignKey("Tenant_ID")]
        public virtual EntityModel.Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }


        [Column("Created_By")]
        public System.String CreatedBy { get; set; }

        [Column("Created_On")]
        public System.DateTime? CreatedOn { get; set; }

        [Column("Modified_By")]
        public System.String UpdatedBy { get; set; }

        [Column("Modified_On")]
        public System.DateTime? UpdatedOn { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Is_Deleted")]
        public System.Boolean? IsDeleted { get; set; }

        [Column("Update_Seq")]
        public System.Int32? UpdateSeq { get; set; }
    }

    public class CustomRole : IdentityRole<long, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }

        [Column("Display_Name")]
        public System.String DisplayName { get; set; }

        [ForeignKey("Tenant_ID")]
        public virtual EntityModel.Tenant Tenant { get; set; }
        public System.Int64? Tenant_ID { get; set; }    

        [Column("Created_By")]
        public System.String CreatedBy { get; set; }

        [Column("Created_On")]
        public System.DateTime? CreatedOn { get; set; }

        [Column("Modified_By")]
        public System.String UpdatedBy { get; set; }

        [Column("Modified_On")]
        public System.DateTime? UpdatedOn { get; set; }

        [Column("Is_Active")]
        public System.Boolean? IsActive { get; set; }

        [Column("Is_Deleted")]
        public System.Boolean? IsDeleted { get; set; }

        [Column("Update_Seq")]
        public System.Int32? UpdateSeq { get; set; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, long,
        CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(SHFContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, long, CustomUserRole>
    {
        public CustomRoleStore(SHFContext context)
            : base(context)
        {
        }
    }



}