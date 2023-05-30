using HospitalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalAPI.Data
{
    public class HospitalContext: DbContext
    {
        public HospitalContext(DbContextOptions options) : base(options) { }
        public DbSet<Pasien> Pasien { get; set; }
        public DbSet<Perawatan> Perawatan { get; set; }
        public DbSet<Kamar> Kamar { get; set; }
    }
}