using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using reportesApi.Models;
using reportesApi.Services;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoAlumnoController : ControllerBase
    {
        private readonly GrupoAlumnoService _grupoAlumnoService;

        public GrupoAlumnoController(GrupoAlumnoService grupoAlumnoService)
        {
            _grupoAlumnoService = grupoAlumnoService;
        }

        [HttpGet]
        public async Task<IEnumerable<GrupoAlumno>> GetGrupoAlumnos()
        {
            return await _grupoAlumnoService.GetGrupoAlumnosAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GrupoAlumno>> GetGrupoAlumno(int id)
        {
            var grupoAlumno = await _grupoAlumnoService.GetGrupoAlumnoByIdAsync(id);

            if (grupoAlumno == null)
            {
                return NotFound();
            }

            return grupoAlumno;
        }

        [HttpPost]
        public async Task<ActionResult<GrupoAlumno>> AddGrupoAlumno(GrupoAlumno grupoAlumno)
        {
            await _grupoAlumnoService.AddGrupoAlumnoAsync(grupoAlumno);
            return CreatedAtAction(nameof(GetGrupoAlumno), new { id = grupoAlumno.Id }, grupoAlumno);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrupoAlumno(int id, GrupoAlumno grupoAlumno)
        {
            if (id != grupoAlumno.Id)
            {
                return BadRequest();
            }

            await _grupoAlumnoService.UpdateGrupoAlumnoAsync(grupoAlumno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupoAlumno(int id)
        {
            await _grupoAlumnoService.DeleteGrupoAlumnoAsync(id);
            return NoContent();
        }
    }
}
