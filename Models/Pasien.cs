using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Pasien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public string Nama { get; set; }
        public string Usia { get; set; }
        public string NoHp { get; set; }
        public string NoKtp { get; set; }
        public Perawatan Perawatan { get; set; }
        public Kamar Kamar { get; set; }
    }
}