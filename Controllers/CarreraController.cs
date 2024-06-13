using Microsoft.AspNetCore.Mvc;
using reportesApi.Models;
using reportesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarreraController : ControllerBase
    {
        private readonly CarreraService _carreraService;

        public CarreraController(CarreraService carreraService)
        {
            _carreraService = carreraService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Carrera>>> GetCarreras()
        {
            var carreras = await _carreraService.GetCarrerasAsync();
            return Ok(carreras);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Carrera>> GetCarrera(int id)
        {
            var carrera = await _carreraService.GetCarreraByIdAsync(id);
            if (carrera == null)
            {
                return NotFound();
            }
            return Ok(carrera);
        }

        [HttpPost]
        public async Task<ActionResult> AddCarrera(Carrera carrera)
        {
            await _carreraService.AddCarreraAsync(carrera);
            return CreatedAtAction(nameof(GetCarrera), new { id = carrera.Id }, carrera);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCarrera(int id, Carrera carrera)
        {
            if (id != carrera.Id)
            {
                return BadRequest();
            }

            await _carreraService.UpdateCarreraAsync(carrera);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCarrera(int id)
        {
            await _carreraService.DeleteCarreraAsync(id);
            return NoContent();
        }
    }
}
