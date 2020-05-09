using System.ComponentModel.DataAnnotations;

namespace HastaneBilgiSistemi.Data.Model
{
    public class Polyclinic
    {
        public int Id { get; set; }
        [MaxLength(128)]
        public string Name { get; set; }
    }
}
