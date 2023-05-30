using HospitalAPI.Dto;
using HospitalAPI.Interface;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class KamarController : ControllerBase
    {
        private readonly IKamar _kamarRepo;
        private readonly IPerawatan _perawatanRepo;

        public KamarController(IKamar kamarRepo, IPerawatan perawatanRepo)
        {
            _kamarRepo = kamarRepo;
            _perawatanRepo = perawatanRepo;
        }

        [HttpGet("")]
        public IActionResult GetAllKamar()
        {
            return Ok(_kamarRepo.GetAllKamar());
        }

        [HttpGet("{id}")]
        public IActionResult GetKamarById(int id)
        {
            var kamarId = _kamarRepo.GetKamarById(id);
            if(kamarId == null)
            {
                ModelState.AddModelError("", "ID Kamar Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                return Ok(kamarId);
            }
        }

        [HttpPost("Create")]
        public IActionResult CreateKamar([FromForm]KamarDto kamarDto)
        {
            var kamarExist = _kamarRepo.GetAllKamar().Where(k => k.Nama.ToLower() == kamarDto.Nama.ToLower()).FirstOrDefault();
            var perawatanExist = _perawatanRepo.GetPerawatanById(kamarDto.IdPerawatan);
            if(perawatanExist == null)
            {
                ModelState.AddModelError("", "ID Perawatan Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                if(kamarExist != null)
                {
                    ModelState.AddModelError("", "Nama Kamar Sudah Pernah Digunakan!!!");
                    return StatusCode(400, ModelState);
                }
                else
                {
                    var newKamar = new Kamar
                    {
                        Nama = kamarDto.Nama,
                        Kuota = kamarDto.Kuota,
                        Perawatan = _perawatanRepo.GetPerawatanById(kamarDto.IdPerawatan)
                    };
                    _kamarRepo.Create(newKamar);
                    return Ok("Berhasil Menambahkan Kamar");
                }
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdateKamar([FromForm]KamarDto kamarDto, [FromQuery]int idKamar)
        {
            var kamarExistId = _kamarRepo.GetKamarById(idKamar);
            var kamarExistNama = _kamarRepo.GetAllKamar().Where(k => k.Nama.ToLower() == kamarDto.Nama.ToLower()).FirstOrDefault();
            var perawatanExistId = _perawatanRepo.GetPerawatanById(kamarDto.IdPerawatan);

            if(perawatanExistId == null)
            {
                ModelState.AddModelError("", "ID Perawatan Tidak di Temukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                if(kamarExistId == null)
                {
                    ModelState.AddModelError("", "ID Kamar Tidak di Temukan!!!");
                    return StatusCode(400, ModelState);
                }
                else if(kamarExistNama != null && kamarExistId.Nama != kamarDto.Nama)
                {
                    ModelState.AddModelError("", "Kamar Telah Tersedia!!!");
                    return StatusCode(400, ModelState);
                }
                else
                {
                    kamarExistId.Id = idKamar;
                    kamarExistId.Nama = kamarDto.Nama;
                    kamarExistId.Kuota = kamarDto.Kuota;
                    kamarExistId.Perawatan = _perawatanRepo.GetPerawatanById(kamarDto.IdPerawatan);

                    _kamarRepo.Update(kamarExistId);
                    return Ok("Berhasil Update Data Kamar!!!");
                }
            }
        }

        [HttpDelete("")]
        public IActionResult DeleteKamar(int id)
        {
            var kamarId = _kamarRepo.GetKamarById(id);
            if(kamarId == null)
            {
                ModelState.AddModelError("", "Id Kamar Tidak Ditemukan!!!");
                return StatusCode(400, ModelState);
            }
            else
            {
                _kamarRepo.Delete(kamarId.Id);
                return Ok("Kamar Berhasil di Hapus!!!");
            }
        }
    }
}
