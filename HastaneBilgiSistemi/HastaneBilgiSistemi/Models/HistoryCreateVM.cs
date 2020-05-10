using HastaneBilgiSistemi.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HastaneBilgiSistemi.Models
{
    public class HistoryCreateVM
    {
        [MaxLength(512)]
        public string Complaint { get; set; } // şikayet
        public Reservation Reservation { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DoctorId { get; set; }
        [Required]
        public int DiseasId { get; set; }
        public int PolyclinicId { get; set; }
        [Required(ErrorMessage = "Reservation Does Not Exist")]
        public int ReservationId { get; set; }
        public List<int> Medication { get; set; }
        [Required]
        public int PatientId { get; set; }
    }
}
