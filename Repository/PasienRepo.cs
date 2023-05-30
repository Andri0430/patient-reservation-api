using HospitalAPI.Data;
using HospitalAPI.Interface;
using HospitalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Repository
{
    public class PasienRepo : IPasien
    {
        private readonly HospitalContext _hospitalContext;
        public PasienRepo(HospitalContext hospitalContext)
        {
            _hospitalContext = hospitalContext;
        }

        public void Create(Pasien pasien)
        {
            _hospitalContext.Pasien.Add(pasien);
            _hospitalContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            _hospitalContext.Pasien.Remove(GetPasienById(Id));
            _hospitalContext.SaveChanges();
        }

        public ICollection<Pasien> GetAllPasiens()
        {
            return _hospitalContext.Pasien.Include(p => p.Perawatan).ToList();
        }

        public Pasien GetPasienById(int id)
        {
            return _hospitalContext.Pasien.Include(p => p.Perawatan).Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Pasien pasien)
        {
            _hospitalContext.Pasien.Update(pasien);
            _hospitalContext.SaveChanges();
        }
    }
}