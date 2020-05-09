using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HastaneBilgiSistemi.Data.Model
{
    public class ApplicationUser : IdentityUser<int>
    {
        public ApplicationUser()
        {
            UserRoles = new HashSet<ApplicationUserRole>();
        }

        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public override string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserRole : IdentityUserRole<int>
    {
        public virtual ApplicationUser User { get; set; }
        public virtual ApplicationRole Role { get; set; }
    }

    public class ApplicationRole : IdentityRole<int>
    {
        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }

    public class ApplicationUserClaim : IdentityUserClaim<int>
    {
    }

    public class ApplicationUserLogin : IdentityUserLogin<int>
    {
    }

    public class ApplicationUserToken : IdentityUserToken<int>
    {
    }

    public class ApplicationRoleClaim : IdentityRoleClaim<int>
    {
    }
}
