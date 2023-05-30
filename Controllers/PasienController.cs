using HospitalAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dto;
using HospitalAPI.Models;

namespace HospitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PasienController : ControllerBase
    {
        private readonly IPasien _Ipasien;
        private readonly IPerawatan _Iperawatan;
        public PasienController(IPasien pasien, IPerawatan perawatan)
        {
            _Ipasien = pasien;
            _Iperawatan = perawatan;
        }

        [HttpGet("")]
        public IActionResult GetAllPasiens()
        {
            var pasiens = _Ipasien.GetAllPasiens();
            return Ok(pasiens);
        }

        [HttpPost("/Create")]
        public IActionResult CreatePasien([FromForm] PasienDto pasien)
        {
            var pasienExist = _Ipasien.GetAllPasiens().Where(p => p.NoKtp == pasien.NoKtp || p.NoHp == pasien.NoHp).FirstOrDefault();
            var perawatanExist = _Iperawatan.GetPerawatanById(pasien.IdPerawatan);

            if (pasienExist != null)
            {
                if (pasienExist.NoKtp == pasien.NoKtp)
                {
                    ModelState.AddModelError("", "No.KTP Sudah Pernah Terdaftar!!!\nPasien Sudah Pernah Terdaftar!!!");
                    return StatusCode(442, ModelState);
                }
                if (pasienExist.NoHp == pasien.NoHp)
                {
                    ModelState.AddModelError("", "No.HP Sudah Pernah Terdaftar!!!\nPasien Sudah Pernah Terdaftar!!!");
                    return StatusCode(442, ModelState);
                }
                if(perawatanExist == null)
                {
                    ModelState.AddModelError("","Jenis Perawatan Tidak Ada!!!");
                    return StatusCode(442, ModelState);
                }
            }
            else
            {
                var createPasien = new Pasien
                {
                    Nama = pasien.Nama,
                    Usia = pasien.Usia,
                    NoHp = pasien.NoHp,
                    NoKtp = pasien.NoKtp,
                    Perawatan = _Iperawatan.GetPerawatanById(pasien.IdPerawatan)
                };

                _Ipasien.Create(createPasien);
            }
            return Ok("Berhasil Menambahkan Data Pasien");
        }

        [HttpGet("{id}")]
        public IActionResult GetPasienById(int id)
        {
            var pasienId = _Ipasien.GetPasienById(id);
            if(pasienId == null)
            {
                ModelState.AddModelError("", "ID Pasien Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            return Ok(pasienId);
        }

        [HttpPut("Update")]
        public IActionResult UpdatePasien([FromForm]PasienDto pasien, [FromQuery]int idPasien)
        {
            var pasienEdit = _Ipasien.GetPasienById(idPasien);

            if(pasienEdit == null)
            {
                ModelState.AddModelError("", "Pasien Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                pasienEdit.Id = idPasien;
                pasienEdit.Nama = pasien.Nama;
                pasienEdit.Usia = pasien.Usia;
                pasienEdit.NoHp = pasien.NoHp;
                pasienEdit.NoKtp = pasien.NoKtp;
                pasienEdit.Perawatan = _Iperawatan.GetPerawatanById(pasien.IdPerawatan);

                _Ipasien.Update(pasienEdit);
                return Ok("Update Data Pasien Berhasil!!!");
            }
        }

        [HttpDelete("")]
        public IActionResult DeletePasien(int id)
        {
            var pasienId = _Ipasien.GetPasienById(id);
            if(pasienId == null)
            {
                ModelState.AddModelError("", "Pasien Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                _Ipasien.Delete(id);
                return Ok("Data Pasien Berhasil di Hapus!!!");
            }
        }
    }
}