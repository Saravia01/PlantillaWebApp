using Microsoft.AspNetCore.Mvc;
using reportesApi.Models;
using reportesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {
        private readonly AlumnoService _alumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> GetAlumnos()
        {
            var alumnos = await _alumnoService.GetAlumnosAsync();
            return Ok(alumnos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await _alumnoService.GetAlumnoByIdAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return Ok(alumno);
        }

        [HttpPost]
        public async Task<ActionResult> AddAlumno(Alumno alumno)
        {
            await _alumnoService.AddAlumnoAsync(alumno);
            return CreatedAtAction(nameof(GetAlumno), new { id = alumno.Id }, alumno);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAlumno(int id, Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            await _alumnoService.UpdateAlumnoAsync(alumno);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAlumno(int id)
        {
            await _alumnoService.DeleteAlumnoAsync(id);
            return NoContent();
        }
    }
}
