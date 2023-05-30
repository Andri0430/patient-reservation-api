using HospitalAPI.Models;

namespace HospitalAPI.Interface
{
    public interface IKamar
    {
        ICollection<Kamar> GetAllKamar();
        Kamar GetKamarById(int id);
        void Create(Kamar kamar);
        void Update(Kamar kamar);
        void Delete(int id);
    }
}