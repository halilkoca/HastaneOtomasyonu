using Microsoft.AspNetCore.Authorization.Policy;
using System.ComponentModel.DataAnnotations;

namespace HastaneBilgiSistemi.Data.Model
{
    public class Doctor
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PolyclinicId { get; set; }
        public ApplicationUser User { get; set; }
        public Polyclinic Polyclinic { get; set; }
    }
}
