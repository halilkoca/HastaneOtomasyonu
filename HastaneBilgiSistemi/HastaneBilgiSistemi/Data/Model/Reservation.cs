using System;

namespace HastaneBilgiSistemi.Data.Model
{
    public class Reservation
    {
        public int Id { get; set; }
        public int PolicylinicId { get; set; }
        public int ClientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime StartDate { get; set; }

        public Polyclinic Polyclinic { get; set; }
        public Doctor Doctor { get; set; }
        public Client Client { get; set; }
    }
}
