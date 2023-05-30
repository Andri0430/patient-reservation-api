using HospitalAPI.Data;
using HospitalAPI.Interface;
using HospitalAPI.Models;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<Kamar> GetAllKamar()
        {
            throw new NotImplementedException();
        }

        public Kamar GetKamarById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Kamar kamar)
        {
            throw new NotImplementedException();
        }
    }
}
