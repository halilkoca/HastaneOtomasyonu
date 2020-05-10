using System;

namespace HastaneBilgiSistemi.Data.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public int PolyclinicId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsCompleted { get; set; }

        public Polyclinic Polyclinic { get; set; }
        public Doctor Doctor { get; set; }
        public Patient Patient { get; set; }
    }
}
