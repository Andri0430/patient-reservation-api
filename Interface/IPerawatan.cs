using HospitalAPI.Models;

namespace HospitalAPI.Interface
{
    public interface IPerawatan
    {
        ICollection<Perawatan> GetAllPerawatan();
        Perawatan GetPerawatanById(int id);
        void Create(Perawatan perawatan);
        void Update(Perawatan perawatan);
        void Delete(int id);
    }
}
