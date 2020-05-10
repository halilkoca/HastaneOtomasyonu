using System;
using System.Collections.Generic;

namespace HastaneBilgiSistemi.Data.Model
{
    public class ClientHistory
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int ReservationId { get; set; }
        public int DoctorId { get; set; }
        public int DiseasId { get; set; } // hastalık türü
        public int PolyclinicId { get; set; }

        public Reservation Reservation { get; set; }
        public Doctor Doctor { get; set; }
        public Polyclinic Polyclinic { get; set; }
        public Diseas Diseas { get; set; }
        public virtual ICollection<ClientHistoryMedication> Medications { get; set; }
    }
}
