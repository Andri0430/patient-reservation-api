using HospitalAPI.Data;
using HospitalAPI.Interface;
using HospitalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repository
{
    public class KamarRepo : IKamar
    {
        private readonly HospitalContext _hospitalContext;
        public KamarRepo(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        } 
        public void Create(Kamar kamar)
        {
            _hospitalContext.Kamar.Add(kamar);
            _hospitalContext.SaveChanges();
        }

        public void Delete(int id)
        {
            _hospitalContext.Kamar.Remove(GetKamarById(id));
            _hospitalContext.SaveChanges();
        }

        public ICollection<Kamar> GetAllKamar()
        {
            return _hospitalContext.Kamar.Include(k => k.Perawatan).ToList();
        }

        public Kamar GetKamarById(int id)
        {
            return _hospitalContext.Kamar.Include(k => k.Perawatan).Where(k => k.Id == id).FirstOrDefault();
        }

        public void Update(Kamar kamar)
        {
            _hospitalContext.Kamar.Update(kamar);
            _hospitalContext.SaveChanges();
        }
    }
}
