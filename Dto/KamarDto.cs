using HospitalAPI.Models;

namespace HospitalAPI.Dto
{
    public class KamarDto
    {
        public string Nama { get; set; }
        public int IdPerawatan { get; set; }
        public int Kuota { get; set; }
    }
}