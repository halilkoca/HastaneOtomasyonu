using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace HastaneBilgiSistemi.Data.Model
{
    public class ApplicationUser : IdentityUser<int>
    {

        [MaxLength(128)]
        public string FirstName { get; set; }
        [MaxLength(128)]
        public string LastName { get; set; }
        [MaxLength(256)]
        public string FullName { get; set; }

        [MaxLength(20)]
        public override string PhoneNumber { get; set; }

        public DateTime  BirthDate { get; set; }
    }
    public class ApplicationRole : IdentityRole<int>
    {
    }
}
