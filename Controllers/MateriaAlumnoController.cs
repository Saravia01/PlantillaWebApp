using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using reportesApi.Models;
using reportesApi.Services;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaAlumnoController : ControllerBase
    {
        private readonly MateriaAlumnoService _materiaAlumnoService;

        public MateriaAlumnoController(MateriaAlumnoService materiaAlumnoService)
        {
            _materiaAlumnoService = materiaAlumnoService;
        }

        [HttpGet]
        public async Task<IEnumerable<MateriaAlumno>> GetMateriaAlumnos()
        {
            return await _materiaAlumnoService.GetMateriaAlumnosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MateriaAlumno>> GetMateriaAlumno(int id)
        {
            var materiaAlumno = await _materiaAlumnoService.GetMateriaAlumnoByIdAsync(id);

            if (materiaAlumno == null)
            {
                return NotFound();
            }

            return materiaAlumno;
        }

        [HttpPost]
        public async Task<ActionResult<MateriaAlumno>> AddMateriaAlumno(MateriaAlumno materiaAlumno)
        {
            await _materiaAlumnoService.AddMateriaAlumnoAsync(materiaAlumno);
            return CreatedAtAction(nameof(GetMateriaAlumno), new { id = materiaAlumno.Id }, materiaAlumno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMateriaAlumno(int id, MateriaAlumno materiaAlumno)
        {
            if (id != materiaAlumno.Id)
            {
                return BadRequest();
            }

            await _materiaAlumnoService.UpdateMateriaAlumnoAsync(materiaAlumno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMateriaAlumno(int id)
        {
            await _materiaAlumnoService.DeleteMateriaAlumnoAsync(id);
            return NoContent();
        }
    }
}
