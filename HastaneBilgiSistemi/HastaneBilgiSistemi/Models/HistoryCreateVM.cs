using HastaneBilgiSistemi.Data.Model;
using System;

namespace HastaneBilgiSistemi.Models
{
    public class HistoryCreateVM
    {
        public Reservation Reservation { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DoctorId { get; set; }
        public int DiseasId { get; set; }
        public int PolyclinicId { get; set; }
        public int MedicationId { get; set; }
    }
}
