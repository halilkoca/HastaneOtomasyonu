namespace HastaneBilgiSistemi.Data.Model
{
    public class ClientHistoryMedication
    {
        public int Id { get; set; }
        public int ClientHistoryId { get; set; }
        public int MedicationId { get; set; }

        public ClientHistory ClientHistory { get; set; }
        public Medication Medication { get; set; }
    }
}
