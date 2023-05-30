using HospitalAPI.Data;
using HospitalAPI.Interface;
using HospitalAPI.Models;

namespace HospitalAPI.Repository
{
    public class PerawatanRepo : IPerawatan
    {
        private readonly HospitalContext _hospitalContext;

        public PerawatanRepo(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        public void Create(Perawatan perawatan)
        {
            _hospitalContext.Perawatan.Add(perawatan);
            _hospitalContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _hospitalContext.Perawatan.Remove(GetPerawatanById(id));
            _hospitalContext.SaveChanges();
        }

        public ICollection<Perawatan> GetAllPerawatan()
        {
            return _hospitalContext.Perawatan.ToList();
        }

        public Perawatan GetPerawatanById(int id)
        {
            return _hospitalContext.Perawatan.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Perawatan perawatan)
        {
            _hospitalContext.Perawatan.Update(perawatan);
            _hospitalContext.SaveChanges();
        }
    }
}
