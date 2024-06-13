using Microsoft.AspNetCore.Mvc;
using reportesApi.Models;
using reportesApi.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private readonly MateriaService _materiaService;

        public MateriaController(MateriaService materiaService)
        {
            _materiaService = materiaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Materia>>> GetMaterias()
        {
            var materias = await _materiaService.GetMateriasAsync();
            return Ok(materias);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Materia>> GetMateria(int id)
        {
            var materia = await _materiaService.GetMateriaByIdAsync(id);
            if (materia == null)
            {
                return NotFound();
            }
            return Ok(materia);
        }

        [HttpPost]
        public async Task<ActionResult> AddMateria(Materia materia)
        {
            await _materiaService.AddMateriaAsync(materia);
            return CreatedAtAction(nameof(GetMateria), new { id = materia.Id }, materia);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateMateria(int id, Materia materia)
        {
            if (id != materia.Id)
            {
                return BadRequest();
            }

            await _materiaService.UpdateMateriaAsync(materia);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteMateria(int id)
        {
            await _materiaService.DeleteMateriaAsync(id);
            return NoContent();
        }
    }
}
