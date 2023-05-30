using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAPI.Models
{
    public class Kamar
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Kuota { get; set; }
        public Perawatan Perawatan { get; set; }
        public ICollection<Pasien> Pasiens { get; set; }
    }
}
