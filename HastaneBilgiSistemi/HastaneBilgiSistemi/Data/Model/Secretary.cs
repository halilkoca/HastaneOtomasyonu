namespace HastaneBilgiSistemi.Data.Model
{
    public class Secretary
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
