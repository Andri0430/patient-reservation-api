using HospitalAPI.Models;

namespace HospitalAPI.Dto
{
    public class PasienDto
    {
        public string Nama { get; set; }
        public string Usia { get; set; }
        public string NoHp { get; set; }
        public string NoKtp { get; set; }
        public int IdPerawatan { get; set; }
        public int IdKamar { get; set; }
    }
}
