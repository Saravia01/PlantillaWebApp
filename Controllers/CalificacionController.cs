using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using reportesApi.Models;
using reportesApi.Services;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalificacionController : ControllerBase
    {
        private readonly CalificacionService _calificacionService;

        public CalificacionController(CalificacionService calificacionService)
        {
            _calificacionService = calificacionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Calificacion>> GetCalificaciones()
        {
            return await _calificacionService.GetCalificacionesAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Calificacion>> GetCalificacion(int id)
        {
            var calificacion = await _calificacionService.GetCalificacionByIdAsync(id);

            if (calificacion == null)
            {
                return NotFound();
            }

            return calificacion;
        }

        [HttpPost]
        public async Task<ActionResult<Calificacion>> AddCalificacion(Calificacion calificacion)
        {
            await _calificacionService.AddCalificacionAsync(calificacion);
            return CreatedAtAction(nameof(GetCalificacion), new { id = calificacion.Id }, calificacion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCalificacion(int id, Calificacion calificacion)
        {
            if (id != calificacion.Id)
            {
                return BadRequest();
            }

            await _calificacionService.UpdateCalificacionAsync(calificacion);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalificacion(int id)
        {
            await _calificacionService.DeleteCalificacionAsync(id);
            return NoContent();
        }
    }
}
