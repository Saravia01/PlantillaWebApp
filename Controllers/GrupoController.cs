using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using reportesApi.Models;
using reportesApi.Services;

namespace reportesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {
        private readonly GrupoService _grupoService;

        public GrupoController(GrupoService grupoService)
        {
            _grupoService = grupoService;
        }

        [HttpGet]
        public async Task<IEnumerable<Grupo>> GetGrupos()
        {
            return await _grupoService.GetGruposAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetGrupo(int id)
        {
            var grupo = await _grupoService.GetGrupoByIdAsync(id);

            if (grupo == null)
            {
                return NotFound();
            }

            return grupo;
        }

        [HttpPost]
        public async Task<ActionResult<Grupo>> AddGrupo(Grupo grupo)
        {
            await _grupoService.AddGrupoAsync(grupo);
            return CreatedAtAction(nameof(GetGrupo), new { id = grupo.Id }, grupo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateGrupo(int id, Grupo grupo)
        {
            if (id != grupo.Id)
            {
                return BadRequest();
            }

            await _grupoService.UpdateGrupoAsync(grupo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrupo(int id)
        {
            await _grupoService.DeleteGrupoAsync(id);
            return NoContent();
        }
    }
}
