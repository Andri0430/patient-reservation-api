using HospitalAPI.Dto;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Interface
{
    public interface IPasien
    {
        ICollection<Pasien> GetAllPasiens();
        Pasien GetPasienById(int id);
        void Create(Pasien pasien);
        void Update(Pasien pasien);
        void Delete(int Id);
    }
}
