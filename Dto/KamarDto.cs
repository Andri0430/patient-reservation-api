using HospitalAPI.Models;

namespace HospitalAPI.Dto
{
    public class KamarDto
    {
        public string Nama { get; set; }
        public Perawatan Perawatan { get; set; }
        public int Kuota { get; set; }
    }
}
