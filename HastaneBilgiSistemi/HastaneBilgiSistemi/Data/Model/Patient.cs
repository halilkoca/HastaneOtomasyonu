using System.Collections.Generic;

namespace HastaneBilgiSistemi.Data.Model
{
    public class Patient
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }

        public virtual ICollection<PatientHistory> PatientHistories { get; set; }
    }
}
