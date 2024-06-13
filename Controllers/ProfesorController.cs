using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using reportesApi.Models;
using reportesApi.Services;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ProfesorService _profesorService;

        public ProfesorController(ProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        [HttpGet]
        public async Task<IEnumerable<Profesor>> GetProfesores()
        {
            return await _profesorService.GetProfesoresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Profesor>> GetProfesor(int id)
        {
            var profesor = await _profesorService.GetProfesorByIdAsync(id);

            if (profesor == null)
            {
                return NotFound();
            }

            return profesor;
        }

        [HttpPost]
        public async Task<ActionResult<Profesor>> AddProfesor(Profesor profesor)
        {
            await _profesorService.AddProfesorAsync(profesor);
            return CreatedAtAction(nameof(GetProfesor), new { id = profesor.Id }, profesor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfesor(int id, Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest();
            }

            await _profesorService.UpdateProfesorAsync(profesor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfesor(int id)
        {
            await _profesorService.DeleteProfesorAsync(id);
            return NoContent();
        }
    }
}
