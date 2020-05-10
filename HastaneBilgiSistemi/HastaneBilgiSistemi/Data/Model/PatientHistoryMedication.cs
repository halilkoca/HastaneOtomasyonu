namespace HastaneBilgiSistemi.Data.Model
{
    public class PatientHistoryMedication
    {
        public int Id { get; set; }
        public int PatientHistoryId { get; set; }
        public int MedicationId { get; set; }

        public PatientHistory PatientHistory { get; set; }
        public Medication Medication { get; set; }
    }
}
