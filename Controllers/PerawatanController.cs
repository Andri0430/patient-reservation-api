using HospitalAPI.Dto;
using HospitalAPI.Interface;
using HospitalAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PerawatanController : ControllerBase
    {
        private readonly IPerawatan _IPerawatan;
        public PerawatanController(IPerawatan perawatanRepo)
        {
            _IPerawatan = perawatanRepo;
        }

        [HttpGet("")]
        public IActionResult GetAllPerawatan()
        {
            return Ok(_IPerawatan.GetAllPerawatan());
        }

        [HttpGet("{id}")]
        public IActionResult GetPerawatanById(int id)
        {
            var perawatan = _IPerawatan.GetPerawatanById(id);
            if(perawatan == null)
            {
                ModelState.AddModelError("", "Data Tersebut Tidak Ditenukan");
                return StatusCode(442, ModelState);
            }
            else
            {
                return Ok(perawatan);
            }
        }

        [HttpPost("Create")]
        public IActionResult CreatePerawatan([FromForm] PerawatanDto perawatanDto)
        {
            var perawatan = _IPerawatan.GetAllPerawatan().Where(p => p.NamaPerawatan == perawatanDto.NamaPerawatan).FirstOrDefault();
            if(perawatan != null)
            {
                ModelState.AddModelError("", "Perawatan Sudah Pernah DiTambahkan!!!");
                return StatusCode(442, ModelState);
            }
            else
            {
                var createPerawatan = new Perawatan
                {
                    NamaPerawatan = perawatanDto.NamaPerawatan
                };

                _IPerawatan.Create(createPerawatan);
                return Ok("Perawatan Berhasil Di Tambahkan");
            }
        }

        [HttpPut("Update")]
        public IActionResult UpdatePerawatan([FromForm] int idPerawatan, [FromForm] PerawatanDto perawatan)
        {
            var getPerawatan = _IPerawatan.GetPerawatanById(idPerawatan);
            if (getPerawatan == null)
            {
                ModelState.AddModelError("", "Data Tidak DiTemukan!!!");
                return StatusCode(442, ModelState);
            }
            else
            {
                getPerawatan.Id = idPerawatan;
                getPerawatan.NamaPerawatan = perawatan.NamaPerawatan;
                _IPerawatan.Update(getPerawatan);
                return Ok("Update Data Perawatan Berhasil!!!");
            }
        }

        [HttpDelete("")]
        public IActionResult DeletePerawatan([FromQuery]int idPerawatan)
        {
            var getPerawatanById = _IPerawatan.GetPerawatanById(idPerawatan);
            if(getPerawatanById == null)
            {
                ModelState.AddModelError("", "Data Tidak DiTemukan!!!");
                return StatusCode(442, ModelState);
            }
            else
            {
                _IPerawatan.Delete(idPerawatan);
                return Ok("Hapus Data Perawatan Berhasil di Hapus!!!");
            }
        }
    }
}