using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HastaneBilgiSistemi.Data.Model
{
    public class PatientHistory
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        public int ReservationId { get; set; }
        public int DoctorId { get; set; }
        public int DiseasId { get; set; } // hastalık türü
        public int PolyclinicId { get; set; }
        [MaxLength(512)]
        public string Complaint { get; set; } //şikayet

        public Reservation Reservation { get; set; }
        public Doctor Doctor { get; set; }
        public Polyclinic Polyclinic { get; set; }
        public Diseas Diseas { get; set; }
        public Patient Patient { get; set; }
        public virtual ICollection<PatientHistoryMedication> Medications { get; set; }
    }
}
