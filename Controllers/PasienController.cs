using HospitalAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using HospitalAPI.Dto;
using HospitalAPI.Models;
using Org.BouncyCastle.Crypto.Prng;

namespace HospitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PasienController : ControllerBase
    {
        private readonly IPasien _Ipasien;
        private readonly IPerawatan _Iperawatan;
        private readonly IKamar _Ikamar;
        public PasienController(IPasien pasien, IPerawatan perawatan, IKamar kamar)
        {
            _Ipasien = pasien;
            _Iperawatan = perawatan;
            _Ikamar = kamar;
        }

        [HttpGet("")]
        public IActionResult GetAllPasiens()
        {
            return Ok(_Ipasien.GetAllPasiens());
        }

        [HttpPost("Create")]
        public IActionResult CreatePasien([FromForm] PasienDto pasien)
        {
            var pasienExist = _Ipasien.GetAllPasiens().Where(p => p.NoKtp == pasien.NoKtp || p.NoHp == pasien.NoHp).FirstOrDefault();
            var perawatanExistId = _Iperawatan.GetPerawatanById(pasien.IdPerawatan);
            var kamarExistId = _Ikamar.GetKamarById(pasien.IdKamar);

            if(pasienExist == null)
            {
                if(perawatanExistId == null)
                {
                    ModelState.AddModelError("", "Data Perawatan Tidak Ditemukan!!!");
                    return StatusCode(400, ModelState);
                }
                else if(kamarExistId == null)
                {
                    ModelState.AddModelError("", "Data Kamar Tidak Ditemukan!!!");
                    return StatusCode(400, ModelState);
                }
                else
                {
                    var newPasien = new Pasien
                    {
                        Nama = pasien.Nama,
                        Usia = pasien.Usia,
                        NoHp = pasien.NoHp,
                        NoKtp = pasien.NoKtp,
                        Perawatan = _Iperawatan.GetPerawatanById(pasien.IdPerawatan),
                        Kamar = _Ikamar.GetKamarById(pasien.IdKamar)
                    };
                    _Ipasien.Create(newPasien);
                    return Ok("Tambah Data Pasien Berhasil!!!");
                }
            }
            else
            {
                ModelState.AddModelError("", "Pasien Sudah Pernah Terdaftar!!!");
                return StatusCode(400, ModelState);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetPasienById(int id)
        {
            var pasienId = _Ipasien.GetPasienById(id);
            if (pasienId == null)
            {
                ModelState.AddModelError("", "ID Pasien Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            return Ok(pasienId);
        }

        [HttpPut("Update")]
        public IActionResult UpdatePasien([FromForm] PasienDto pasien, [FromQuery] int idPasien)
        {
            var pasienEdit = _Ipasien.GetPasienById(idPasien);
            var perawatanId = _Iperawatan.GetPerawatanById(pasien.IdPerawatan);
            var kamarId = _Ikamar.GetKamarById(pasien.IdKamar);

            if (pasienEdit == null)
            {
                ModelState.AddModelError("", "Pasien Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                if (perawatanId == null)
                {
                    ModelState.AddModelError("", "Data Perawatan Tidak Ditemukan!!!");
                    return StatusCode(400, ModelState);
                }
                else if (kamarId == null)
                {
                    ModelState.AddModelError("", "Data Kamar Tidak Ditemukan!!!");
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
        }

        [HttpDelete("")]
        public IActionResult DeletePasien(int id)
        {
            var pasienId = _Ipasien.GetPasienById(id);
            if (pasienId == null)
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